using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Equipo
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Jugador> Jugadores { get; set; }
    public DT DT { get; set; }
    public string UserId { get; set; }
    public List<Partido> PartidosJugadosLocal { get; set; }
    public List<Partido> PartidosJugadosVisitante { get; set; }
    public List<TorneoEquipo> TorneosEquipos { get; set; }

}