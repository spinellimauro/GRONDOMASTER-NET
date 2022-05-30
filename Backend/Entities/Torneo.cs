using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Torneo
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<TorneoEquipo> TorneosEquipos { get; set; }
    public List<Partido> Partidos { get; set; }
    public int LimiteAmarillas { get; set; }
    public Boolean Finalizado { get; set; }

}