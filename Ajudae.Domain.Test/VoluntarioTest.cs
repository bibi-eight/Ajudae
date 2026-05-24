using Ajudae.Domain.Entities;
using Ajudae.Domain.Enums;

namespace Ajudae.Domain.Test;

public class VoluntarioTest
{

        [Fact]
        public void AtribuirNomeCompleto_DeveAtualizarNomeCompleto()
        {
            // Arrange
            var voluntario = new Voluntario();
            var nomeEsperado = "João da Silva";

            // Act
            voluntario.AtribuirNomeCompleto(nomeEsperado);

            // Assert
            Assert.Equal(nomeEsperado, voluntario.NomeCompleto);
        }

        [Fact]
        public void AtribuirEmail_DeveAtualizarEmail()
        {
            // Arrange
            var voluntario = new Voluntario();
            var emailEsperado = "joao@email.com";

            // Act
            voluntario.AtribuirEmail(emailEsperado);

            // Assert
            Assert.Equal(emailEsperado, voluntario.Email);
        }

        [Fact]
        public void AtribuirTelefone_DeveAtualizarTelefone()
        {
            // Arrange
            var voluntario = new Voluntario();
            var telefoneEsperado = "11999999999";

            // Act
            voluntario.AtribuirTelefone(telefoneEsperado);

            // Assert
            Assert.Equal(telefoneEsperado, voluntario.Telefone);
        }

        [Fact]
        public void AtribuirAreaVoluntariado_DeveAtualizarArea()
        {
            // Arrange
            var voluntario = new Voluntario();
            var areaEsperada = AreaVoluntariadoEnum.Nutricao; 

            // Act
            voluntario.AtribuirAreaVoluntariado(areaEsperada);

            // Assert
            Assert.Equal(areaEsperada, voluntario.AreaVoluntariado);
        }

        [Fact]
        public void AtribuirPontuacao_DeveAtualizarPontuacao()
        {
            // Arrange
            var voluntario = new Voluntario();
            var pontosEsperados = 150;

            // Act
            voluntario.AtribuirPontuacao(pontosEsperados);

            // Assert
            Assert.Equal(pontosEsperados, voluntario.Pontuacao);
        }

        [Fact]
        public void TornarPresencial_DeveMudarParaTrue()
        {
            // Arrange
            var voluntario = new Voluntario();
            voluntario.TornarRemoto(true);

            // Act
            voluntario.TornarPresencial(true);

            // Assert
            Assert.True(voluntario.Presencial);
        }

        [Fact]
        public void TornarRemoto_DeveMudarParaFalse()
        {
            // Arrange
            var voluntario = new Voluntario();
            voluntario.TornarPresencial(true); 

            // Act
            voluntario.TornarRemoto(true);

            // Assert
            Assert.False(voluntario.Presencial);
        }

        [Fact]
        public void AtivarVoluntario_DeveMudarAtivoParaTrue()
        {
            // Arrange
            var voluntario = new Voluntario();
            voluntario.DesativarVoluntario();

            // Act
            voluntario.AtivarVoluntario();

            // Assert
            Assert.True(voluntario.Ativo);
        }

        [Fact]
        public void DesativarVoluntario_DeveMudarAtivoParaFalse()
        {
            // Arrange
            var voluntario = new Voluntario();
            voluntario.AtivarVoluntario(); 

            // Act
            voluntario.DesativarVoluntario();

            // Assert
            Assert.False(voluntario.Ativo);
        }

        [Fact]
        public void AdicionarAtividade_DeveAdicionarNaLista_E_MudarStatusParaPendente()
        {
            // Arrange
            var voluntario = new Voluntario();
            var atividade = new AtividadeVoluntario();

            // Act
            voluntario.AdicionarAtividade(atividade);

            // Assert
            Assert.Contains(atividade, voluntario.atividades);
            Assert.Equal(StatusEnum.Pendente, atividade.Status); 
        }

        [Fact]
        public void RemoverAtividade_DeveRemoverDaLista_E_MudarStatusParaNova()
        {
            // Arrange
            var voluntario = new Voluntario();
            var atividade = new AtividadeVoluntario();
            voluntario.AdicionarAtividade(atividade); 

            // Act
            voluntario.RemoverAtividade(atividade);

            // Assert
            Assert.DoesNotContain(atividade, voluntario.atividades);
            Assert.Equal(StatusEnum.Nova, atividade.Status);
        }

        [Fact]
        public void AdicionarRecompensa_DeveAdicionarNaLista()
        {
            // Arrange
            var voluntario = new Voluntario();
            var recompensa = new Recompensa();

            // Act
              voluntario.AdicionarRecompensa(recompensa);

            // Assert
            Assert.Contains(recompensa, voluntario.recompensas);
        }
    }
