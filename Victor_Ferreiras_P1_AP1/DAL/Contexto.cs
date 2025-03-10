using Microsoft.EntityFrameworkCore;
using Victor_Ferreiras_P1_AP1.Models;
namespace Victor_Ferreiras_P1_AP1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Aporte> Aportes { get; set; }
}