using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class DT
{

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public Equipo Equipo { get; set; }
    public double Dinero { get; set; }
    public int TorneosDisponibles { get; set; }
    public int Slots { get; set; }
    public Boolean Enabled { get; set; }
    public List<Transferencia> Compras { get; set; }
    public List<Transferencia> Ventas { get; set; }
    public List<Oferta> OfertasRecibidas { get; set; }
    public List<Oferta> OfertasRealizadas { get; set; }
    public ApplicationUser User { get; set; }
    public List<UsuarioRol> UsuariosRoles { get; set; }
    public int UserId { get; set; }
    public int IdEquipo { get; set; }
    public DateTime FechaActualizacion { get; set; }

    public DT() {
        Compras = new List<Transferencia>();
        Ventas = new List<Transferencia>();
        User = new ApplicationUser();
        Equipo = new Equipo();
        OfertasRecibidas = new List<Oferta>();
        OfertasRealizadas = new List<Oferta>();
        UsuariosRoles = new List<UsuarioRol>();
    }

}