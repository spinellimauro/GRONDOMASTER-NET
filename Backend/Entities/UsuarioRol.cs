using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class UsuarioRol
{
    public int Id { get; set; }
    // public int IdUsuario { get; set; }
    // public int RolId { get; set; }
    public ApplicationRole Rol { get; set; }
    public DT Usuario { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Enabled { get; set; }

    public UsuarioRol()
    {

    }

}