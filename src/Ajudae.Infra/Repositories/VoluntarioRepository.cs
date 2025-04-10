using Ajudae.Domain.Entities;
using Ajudae.Domain.Interfaces;
using Ajudae.Infra.Data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace Ajudae.Infra.Repositories;

public class VoluntarioRepository : IVoluntarioRepository
{
    private readonly AjudaeContext _context;

    public VoluntarioRepository(AjudaeContext context)
    {
        _context = context;
    }

    public IUnitOfWorks UnitOfWork => _context;
    
    public async Task<Voluntario> ObterPorId(Guid Id)
    {
        return await _context.Voluntarios.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public void Adicionar(Voluntario entity)
    {
        _context.Voluntarios.Add(entity);
    }

    public void Atualizar(Voluntario entity)
    {
        _context.Voluntarios.Update(entity);
    }

    public void Apagar(Func<Voluntario, bool> predicate)
    {
        var voluntario = _context.Voluntarios.FirstOrDefault(predicate);
        _context.Voluntarios.Remove(voluntario);
    }

    public async Task<IEnumerable<Voluntario>> ObterVoluntariosAtivos()
    {
        return await _context.Voluntarios.Where(x => x.Ativo == true).ToListAsync();
    }

    public async Task<IEnumerable<Voluntario>> ObterVoluntariosInativos()
    {
        return await _context.Voluntarios.Where(x => x.Ativo == false).ToListAsync();
    }

    public async Task<IEnumerable<Voluntario>> ObterVoluntarios()
    {
        return await _context.Voluntarios.ToListAsync();
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}