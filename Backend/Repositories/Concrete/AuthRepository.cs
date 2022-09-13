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
public class AuthRepository : IAuthRepository
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<ApplicationRole> roleManager;
    private readonly IHelpers helper;
    private readonly ApplicationDbContext db;

    public AuthRepository(
        UserManager<ApplicationUser> _userManager,
        RoleManager<ApplicationRole> _roleManager,
        ApplicationDbContext _db,
        IHelpers _helper)
    {
        userManager = _userManager;
        roleManager = _roleManager;
        db = _db;
        helper = _helper;
    }

    public Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
    {
        user.UserName = user.UserName;
        user.FirstLogin = false;
        user.LastPasswordChangedDate = helper.GetCurrentDateTime();

        return userManager.CreateAsync(user, password);
    }

    public bool CheckPassword(string password)
    {
        const string REGEX_LOWERCASE = @"[a-z]";
        const string REGEX_UPPERCASE = @"[A-Z]";
        const string REGEX_NUMERIC = @"[0-9]";
        const string REGEX_SPECIAL = @"[\!\#\$(\)\*\+\-\=\<\>\?_\{\}\~]";

        var validations = new bool[4];

        validations[0] = Regex.IsMatch(password, REGEX_LOWERCASE);
        validations[1] = Regex.IsMatch(password, REGEX_UPPERCASE);
        validations[2] = Regex.IsMatch(password, REGEX_NUMERIC);
        validations[3] = Regex.IsMatch(password, REGEX_SPECIAL);

        var passedValidations = validations.Where(passed => passed);

        return passedValidations.Count() >= 3;
    }

    public async Task<DT> FindDTByIdAsync(string userId)
    {

        return await db.Managers.FindAsync(userId);
    }

    public async Task<List<string>> GetRolesAsync(ApplicationUser user)
    {
        var roles = await userManager.GetRolesAsync(user);
        List<string> list = new List<string>();

        list.AddRange(roles);

        return list;
    }

    public async Task<List<ApplicationRole>> GetIdentitiesRolesAsync(ApplicationUser user)
    {
        var roles = await userManager.GetRolesAsync(user);
        List<string> list = new List<string>();
        List<ApplicationRole> rolesIdentity = new List<ApplicationRole>();

        list.AddRange(roles);
        list.ForEach(r =>
        {
            rolesIdentity.Add(roleManager.FindByNameAsync(r).Result);
        });

        return rolesIdentity;
    }

    public async Task<List<ApplicationRole>> GetIdentitiesRoles(List<UsuarioRol> usuariosRoles)
    {
        List<ApplicationRole> roles = new List<ApplicationRole>();
        Parallel.ForEach(usuariosRoles, (usuarioRol) =>
        {
            roles.Add(roleManager.FindByIdAsync(usuarioRol.Rol.Id.ToString()).Result);
        });

        return roles;
    }

    public DT SetDefaultDataDT(DT usuario, int idEquipo)
    {
        usuario.IdEquipo = usuario.IdEquipo;
        usuario.Dinero = 60000;
        usuario.Enabled = true;
        usuario.Slots = 30;
        usuario.FechaActualizacion = helper.GetCurrentDateTime();

        return usuario;
    }

    public List<UsuarioRol> GetUsuariosRoles(ApplicationUser user)
    {
        return db.UsuariosRoles.Where(ur => ur.Usuario.Id == user.Usuario.Id).ToList();
    }

    public DT SetUsuariosRolesByIdentitiesRoles(List<ApplicationRole> roles, DT usuario)
    {

        roles.ForEach(rol =>
        {
            UsuarioRol usuarioRol = new UsuarioRol();
            usuarioRol.FechaCreacion = DateTime.Now;
            usuarioRol.Enabled = true;
            usuarioRol.Rol = rol;
            usuarioRol.Usuario = usuario;
            usuario.UsuariosRoles.Add(usuarioRol);
        });

        return usuario;
    }

    public async void MUsuario(DT usuario, DT usuarioDb)
    {
        usuarioDb.Nombre = usuario.Nombre;
        usuarioDb.Apellido = usuario.Apellido;
        usuarioDb.Enabled = usuario.Enabled;
        usuarioDb.FechaActualizacion = helper.GetCurrentDateTime();

        db.Managers.Update(usuarioDb);

        await db.SaveChangesAsync();
        // UpdateUsuarioRoles(usuario, usuarioDb);
    }

    public async Task AddRoleAsync(ApplicationUser user, ApplicationRole roleName)
    {
        if (roleManager.RoleExistsAsync(roleName.Name).Result)
            await userManager.AddToRoleAsync(user, roleName.Name);
    }

    public async Task<List<ApplicationRole>> SetApplicationUser(ApplicationUser user, string email, string rolName)
    {
        user.CreationTime = helper.GetCurrentDateTime();
        user.EmailConfirmed = true;
        user.UserName = email;

        List<ApplicationRole> roles = new List<ApplicationRole>();

        ApplicationRole rol = (await roleManager
            .FindByNameAsync(rolName));

        roles.Add(rol);

        return roles;
    }

    public async Task<ApplicationUser> MUser(ApplicationUser userAModificar, ApplicationUser userModificado, int time)
    {

        userAModificar.LockoutEnabled = userModificado.LockoutEnabled;
        await userManager.SetLockoutEnabledAsync(userAModificar, userModificado.LockoutEnabled);
        userAModificar.LockoutEnd = helper.GetCurrentDateTime().AddMinutes(time);
        userAModificar.Email = userModificado.Email;
        userAModificar.EmailConfirmed = userModificado.EmailConfirmed;

        return userAModificar;
    }

    public Task<List<ApplicationUser>> GetUsers()
    {
        return db.Users
            .Include(u => u.Usuario)
            .ToListAsync();
    }

    public async Task<DT> GetDtById(int id)
    {
        return await db.Managers
            .FirstOrDefaultAsync(u => u.Id == id);
    }


    public async Task<DT> FindManagerByEmailAsync(string email)
    {
        return await db.Managers
            .Include(u => u.Equipo)
            .Include(u => u.User)
            .Include(u => u.UsuariosRoles)
            .FirstOrDefaultAsync(u => u.User.Email == email);
    }

    public async Task<ApplicationUser> FindUserByEmailAsync(string email)
    {
        return await db.Users
            .Include(u => u.Usuario)
            .FirstOrDefaultAsync(u => u.Email == email);

    }
}