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

}