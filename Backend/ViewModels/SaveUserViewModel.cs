using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class SaveUserViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Enabled { get; set; }
    public List<IdentityRole> Perfiles { get; set; }
    public List<UsuarioRol> UsuarioRoles { get; set; }

    public SaveUserViewModel()
    {
        Perfiles = new List<IdentityRole>();
    }
}