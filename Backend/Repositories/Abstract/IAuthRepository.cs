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
public interface IAuthRepository
{

    Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
    bool CheckPassword(string password);
    Task<DT> FindDTByIdAsync(string userId);
    Task<List<string>> GetRolesAsync(ApplicationUser user);
    Task<List<ApplicationRole>> GetIdentitiesRolesAsync(ApplicationUser user);
    List<UsuarioRol> GetUsuariosRoles(ApplicationUser user);
    void MUsuario(DT usuario, DT usuarioDb);
    Task<ApplicationUser> MUser(ApplicationUser userAModificar, ApplicationUser userModificado, int time);
    Task<DT> GetDtById(int id);
    Task<DT> FindManagerByEmailAsync(string email);
    Task<ApplicationUser> FindUserByEmailAsync(string email);
    DT SetUsuariosRolesByIdentitiesRoles(List<ApplicationRole> roles, DT usuario);
    Task AddRoleAsync(ApplicationUser user, ApplicationRole roleName);
    Task<List<ApplicationRole>> SetApplicationUser(ApplicationUser user, string email, string rolName);
    DT SetDefaultDataDT(DT dt, int idEquipo);

}