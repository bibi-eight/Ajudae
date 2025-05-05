using Ajudae.Domain.Entities;
using EstartandoDevsCore.Data;

namespace Ajudae.Domain.Interfaces;

public interface IVoluntarioRepository : IRepository<Voluntario>
{
    Task<IEnumerable<Voluntario>> ObterVoluntariosAtivos();
    Task<IEnumerable<Voluntario>> ObterVoluntariosInativos();
    Task<IEnumerable<Voluntario>> ObterVoluntarios();
    Task<bool> ExisteVoluntario(string email);
}