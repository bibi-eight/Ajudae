using Ajudae.Domain.Entities;
using EstartandoDevsCore.Data;

namespace Ajudae.Domain.Interfaces;

public interface IAtividadeRepository : IRepository<Atividade>
{
    Task<Atividade> ObterAtividadesPorStatus(int status);
}