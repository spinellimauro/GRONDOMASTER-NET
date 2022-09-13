using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class SaveUserViewModel
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Enabled { get; set; }
    public List<ApplicationRole> Perfiles { get; set; }
    public List<UsuarioRol> UsuarioRoles { get; set; }
    public int IdEquipo { get; set; }

    public SaveUserViewModel()
    {
        Perfiles = new List<ApplicationRole>();
        UsuarioRoles = new List<UsuarioRol>();
    }
}