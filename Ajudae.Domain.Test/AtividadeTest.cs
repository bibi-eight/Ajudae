
using Ajudae.Domain.Entities;
using Ajudae.Domain.Enums;
using EstartandoDevsCore.DomainObjects;

namespace Ajudae.Tests.Domain.Entities;

public class AtividadeTests
{
    [Fact]
    public void ConstrutorSemParametros_DeveInicializarColecaoDeVoluntarios()
    {
        // Act
        var atividade = new Atividade();

        // Assert
        Assert.NotNull(atividade.Voluntarios);
        Assert.Empty(atividade.Voluntarios);
    }

    [Fact]
    public void ConstrutorComParametros_DeveInicializarPropriedades()
    {
        // Arrange
        const string titulo = "Arrecadação de alimentos";
        const string descricao = "Arrecadar alimentos para uma ONG";
        const int pontos = 100;

        // Act
        var atividade = new Atividade(titulo, descricao, pontos);

        // Assert
        Assert.Equal(titulo, atividade.Titulo);
        Assert.Equal(descricao, atividade.Descricao);
        Assert.Equal(pontos, atividade.Pontos);
        Assert.NotNull(atividade.Voluntarios);
        Assert.Empty(atividade.Voluntarios);
    }

    [Fact]
    public void AtribuirTitulo_DeveAtualizarTitulo()
    {
        // Arrange
        var atividade = new Atividade();
        const string titulo = "Novo título";

        // Act
        atividade.AtribuirTitulo(titulo);

        // Assert
        Assert.Equal(titulo, atividade.Titulo);
    }

    [Fact]
    public void AtribuirDescricao_DeveAtualizarDescricao()
    {
        // Arrange
        var atividade = new Atividade();
        const string descricao = "Nova descrição";

        // Act
        atividade.AtribuirDescricao(descricao);

        // Assert
        Assert.Equal(descricao, atividade.Descricao);
    }

    [Fact]
    public void AtribuirPontos_DeveAtualizarPontos()
    {
        // Arrange
        var atividade = new Atividade();
        const int pontos = 250;

        // Act
        atividade.AtribuirPontos(pontos);

        // Assert
        Assert.Equal(pontos, atividade.Pontos);
    }

    [Fact]
    public void AtribuirPrazo_DeveAtualizarPrazo()
    {
        // Arrange
        var atividade = new Atividade();
        var prazo = new DateTime(2026, 12, 31);

        // Act
        atividade.AtribuirPrazo(prazo);

        // Assert
        Assert.Equal(prazo, atividade.Prazo);
    }

    [Fact]
    public void AdicionarVoluntario_ComVoluntarioNovo_DeveAdicionarVinculoPendente()
    {
        // Arrange
        var atividade = new Atividade();
        var voluntarioId = Guid.NewGuid();

        // Act
        atividade.AdicionarVoluntario(voluntarioId);

        // Assert
        var vinculo = Assert.Single(atividade.Voluntarios);

        Assert.Equal(voluntarioId, vinculo.VoluntarioId);
        Assert.Equal(atividade.Id, vinculo.AtividadeId);
        Assert.Equal(StatusEnum.Pendente, vinculo.Status);
    }

    [Fact]
    public void AdicionarVoluntario_ComVoluntarioJaVinculado_DeveLancarDomainException()
    {
        // Arrange
        var atividade = new Atividade();
        var voluntarioId = Guid.NewGuid();

        atividade.AdicionarVoluntario(voluntarioId);

        // Act
        var exception = Assert.Throws<DomainException>(
            () => atividade.AdicionarVoluntario(voluntarioId));

        // Assert
        Assert.Equal(
            "Voluntário já está vinculado à atividade.",
            exception.Message);

        Assert.Single(atividade.Voluntarios);
    }

    [Fact]
    public void AdicionarVoluntario_ComIdsDiferentes_DeveAdicionarAmbosOsVinculos()
    {
        // Arrange
        var atividade = new Atividade();
        var primeiroVoluntarioId = Guid.NewGuid();
        var segundoVoluntarioId = Guid.NewGuid();

        // Act
        atividade.AdicionarVoluntario(primeiroVoluntarioId);
        atividade.AdicionarVoluntario(segundoVoluntarioId);

        // Assert
        Assert.Equal(2, atividade.Voluntarios.Count);

        Assert.Contains(
            atividade.Voluntarios,
            x => x.VoluntarioId == primeiroVoluntarioId);

        Assert.Contains(
            atividade.Voluntarios,
            x => x.VoluntarioId == segundoVoluntarioId);
    }
    
        [Fact]
        public void AtribuirStatus_DeveAtualizarStatus()
        {
            // Arrange
            var vinculo = new AtividadeVoluntario();
            var status = StatusEnum.Pendente;

            // Act
            vinculo.AtribuirStatus(status);

            // Assert
            Assert.Equal(status, vinculo.Status);
        }

        [Fact]
        public void AtribuirStatus_ComOutroStatus_DeveSubstituirStatusAnterior()
        {
            // Arrange
            var vinculo = new AtividadeVoluntario();

            vinculo.AtribuirStatus(StatusEnum.Pendente);

            // Act
            vinculo.AtribuirStatus(StatusEnum.Concluido);

            // Assert
            Assert.Equal(StatusEnum.Concluido, vinculo.Status);
        }
    }


