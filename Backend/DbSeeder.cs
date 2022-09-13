using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#pragma warning disable 1591
public class DbSeeder
{

    private UserManager<DT> UserManager;
    private RoleManager<ApplicationRole> RoleManager;
    private ApplicationDbContext context;

    public DbSeeder(UserManager<DT> userManager, ApplicationDbContext Context, RoleManager<ApplicationRole> roleManager)
    {
        UserManager = userManager;
        RoleManager = roleManager;
        context = Context;
    }

    public async Task SeedAsync()
    {
        await CreateUsersAsync();
    }

    private async Task CreateUsersAsync()
    {
        ApplicationUser userADM = context.Users.FirstOrDefault(u => u.Email == "gabrielcarlassare@gmail.com");

        if (userADM == null)
        {
            DT user = new DT();
            string pass = "123456Aa";

            user.Nombre = "gabriel";
            user.Apellido = "CARLASSARE";
            user.Dinero = 10000;
            user.Equipo = new Equipo();
            user.Slots = 30;

            ApplicationUser userA = new ApplicationUser();

            userA.EmailConfirmed = true;
            userA.LockoutEnabled = false;

            await UserManager.CreateAsync(user, pass);

            user.UserId = context.Users.FirstOrDefault(u => u.Id == user.Id).Id;

            userA.Usuario = user;
            context.Managers.Add(user);

            await context.SaveChangesAsync();

            bool admin = await RoleManager.RoleExistsAsync("ADM");
            if (admin)
            {
                await UserManager.AddToRoleAsync(user, "ADM");

                UsuarioRol usuarioRol = new UsuarioRol();
                usuarioRol.FechaCreacion = DateTime.Now;
                usuarioRol.Usuario = context.Managers.FirstOrDefault(u => u.Id == 1);

                var roladm = RoleManager.FindByNameAsync("ADM");

                usuarioRol.Rol = roladm.Result;

                context.UsuariosRoles.Add(usuarioRol);
                await context.SaveChangesAsync();
            }

        }

    }

}