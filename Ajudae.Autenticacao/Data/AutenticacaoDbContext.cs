using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ajudae.Autenticacao.Data;

public class AutenticacaoDbContext : IdentityDbContext
{
    public AutenticacaoDbContext(DbContextOptions<AutenticacaoDbContext> options) : base(options) { }
}