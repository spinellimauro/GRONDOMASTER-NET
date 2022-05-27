using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Suceso
{
    public int id { get; set; }
    public Jugador jugador { get; set; }
    public int cantidadGoles { get; set; }
    public int cantidadAmarillas { get; set; }
    public int cantidadRojas { get; set; }

}