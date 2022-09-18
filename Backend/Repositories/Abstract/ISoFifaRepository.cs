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
public interface ISoFifaRepository
{

    Task<List<Jugador>> GetJugadoresBySearch(string query);
    Task<List<EquipoSofifa>> GetEquipos(int offset);
    Task<List<EquipoSofifa>> GetEquiposSoFifa();
    Task<List<EquipoSofifa>> SetEquiposSoFifa();
    Task<EquipoSofifa> GetEquipoSoFifaById(int id);
}