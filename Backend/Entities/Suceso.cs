using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Suceso
{
    public int Id { get; set; }
    public Jugador Jugador { get; set; }
    public Partido Partido { get; set; }
    public int CantidadGoles { get; set; }
    public int CantidadAmarillas { get; set; }
    public int CantidadRojas { get; set; }
    public int IdJugador { get; set; }
    public int IdPartido { get; set; }

}