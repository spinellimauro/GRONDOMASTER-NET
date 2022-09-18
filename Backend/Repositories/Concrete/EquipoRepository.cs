using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

#pragma warning disable 1591
public class EquipoRepository : IEquipoRepository
{
    private readonly ApplicationDbContext db;

    public EquipoRepository(ApplicationDbContext _db)
    {
        db = _db;
    }

    public async Task<Equipo> FindEquipoByIdAsync(int id)
    {
        Equipo? equipo = await db.Equipos
            .FirstOrDefaultAsync(e => e.Id == id);

        return equipo;
    }

    public async void SetUser(Equipo equipo, int UsuarioId)
    {
        equipo.ManagerId = UsuarioId;

        db.Equipos.Update(equipo);
        await db.SaveChangesAsync();
    }

    public async Task<Equipo> CreateEquipoByEquipoSoFifa(EquipoSofifa equipoSofifa)
    {
        Equipo equipo = new Equipo();
        equipo.EquipoSoFifaId = equipoSofifa.Id;
        equipo.Nombre = equipoSofifa.Nombre;
        equipo.EquipoSofifa = equipoSofifa;

        return equipo;
    }
}