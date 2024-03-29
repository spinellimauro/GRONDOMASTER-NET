using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Jugador
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Nacionalidad { get; set; }
    public string NacionalidadCorta { get; set; }
    public string Posiciones { get; set; }
    public int Edad { get; set; }
    public int Nivel { get; set; }
    public int Potencial { get; set; }
    public int IdWeb { get; set; }
    public int Lesion { get; set; }
    public bool Enabled { get; set; }
    public double PrecioVenta { get; set; }
    public int VecesImpagas { get; set; }
    public Equipo Equipo { get; set; }
    public int IdEquipo { get; set; }
    public List<OfertaJugador> OfertasJugador { get; set; }
    public List<Transferencia> Transferencias { get; set; }
    public List<Suceso> Sucesos { get; set; }

    public Jugador()
    {
        Equipo = new Equipo();
        OfertasJugador = new List<OfertaJugador>();
        Transferencias = new List<Transferencia>();
        Sucesos = new List<Suceso>();
    }
}