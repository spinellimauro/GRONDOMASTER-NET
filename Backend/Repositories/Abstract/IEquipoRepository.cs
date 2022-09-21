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
public interface IEquipoRepository
{

    Task<Equipo> FindEquipoByIdAsync(int id);
    void SetUser(Equipo equipo, int usuarioId);
    Task<Equipo> CreateEquipoByEquipoSoFifa(EquipoSofifa equipoSofifa);

    Task<Equipo> GetEquipo(int id);

}