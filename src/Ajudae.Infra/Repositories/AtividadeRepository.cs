using Ajudae.Domain.Entities;
using Ajudae.Domain.Enums;
using Ajudae.Domain.Interfaces;
using Ajudae.Infra.Data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace Ajudae.Infra.Repositories;

public class AtividadeRepository : IAtividadeRepository
{
    private readonly AjudaeContext _context;

    public AtividadeRepository(AjudaeContext context)
    {
        _context = context;
    }

    public IUnitOfWorks UnitOfWork => _context;
    
    // public async Task<IEnumerable<Atividade>> ObterAtividadesPorStatus(int status)
    // {
    //     return await _context.Atividades.Where(x => x.Status == (StatusEnum)status).ToListAsync();
    // }

    public void AdicionarRecompensa(Recompensa recompensa)
    {
        _context.Recompensas.Add(recompensa);
    }

    public void ExcluirRecompensa(Guid recompensaId)
    {
        var recompensa = _context.Recompensas.FirstOrDefault(x => x.Id == recompensaId);
        _context.Recompensas.Remove(recompensa);
    }

    public async Task<bool> ExisteAtividade(string Titulo)
    {
        return await _context.Atividades.AnyAsync(x => x.Titulo == Titulo);
    }

    public async Task<Atividade> ObterPorId(Guid Id)
    {
        return await _context.Atividades.FirstOrDefaultAsync(x => x.Id == Id);
    }

    public void Adicionar(Atividade entity)
    {
        _context.Atividades.Add(entity);
    }

    public void Atualizar(Atividade entity)
    {
        _context.Atividades.Update(entity);
    }

    public void Apagar(Func<Atividade, bool> predicate)
    {
        var atividade = _context.Atividades.FirstOrDefault(predicate);
        _context.Atividades.Remove(atividade);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
