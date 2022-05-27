using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Torneo
{
    public int id { get; set; }
    public string nombre { get; set; }
    public List<Equipo> equipos { get; set; }
    public List<Partido> partidos { get; set; }
    public int limiteAmarillas { get; set; }
    public Boolean finalizado { get; set; }

}