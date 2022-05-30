using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class UsuarioRol
{
    public int Id { get; set; }
    public string IdUsuario { get; set; }
    public string RolId { get; set; }
    public IdentityRole Rol { get; set; }
    public DT Usuario { get; set; }

    public UsuarioRol()
    {

    }

}