using Ajudae.Domain.Entities;
using EstartandoDevsCore.Data;

namespace Ajudae.Domain.Interfaces;

public interface IAtividadeRepository : IRepository<Atividade>
{
    Task<IEnumerable<Atividade>> ObterAtividadesPorStatus(int status);
    void AdicionarRecompensa(Recompensa recompensa);
    void ExcluirRecompensa(Guid recompensaId);
    Task<bool> ExisteAtividade(string Titulo);
}