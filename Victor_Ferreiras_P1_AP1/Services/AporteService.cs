using Victor_Ferreiras_P1_AP1.Models;
using Victor_Ferreiras_P1_AP1.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Victor_Ferreiras_P1_AP1.Services;

public class AporteService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Aporte Aporte)
    {
        if (!await Existe(Aporte.AporteId))
        {
            return await Insertar(Aporte);
        }
        else
        {
            return await Modificar(Aporte);
        }
    }

    public async Task<bool> Existe(int AporteId)
    {
        await using var Contexto = DbFactory.CreateDbContext();
        return await Contexto.Aportes.AsNoTracking().AnyAsync(a => a.AporteId == AporteId);
    }

    public async Task<bool> Insertar(Aporte Aporte)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Aportes.Add(Aporte);
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Aporte Aporte)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Aportes.Update(Aporte);
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<Aporte?> Buscar(int AporteId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Aportes.AsNoTracking().FirstOrDefaultAsync(a => a.AporteId == AporteId);
    }

    public async Task<bool> Eliminar(int AporteId)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Aportes.AsNoTracking().Where(a => a.AporteId == AporteId).ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Aporte>> Listar(Expression<Func<Aporte, bool>> criterio)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Aportes.Where(criterio).AsNoTracking().ToListAsync();
    }
}