using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Equipo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public List<Jugador>? Jugadores { get; set; }
    public DT? DT { get; set; }
    public int? ManagerId { get; set; }
    public EquipoSofifa EquipoSofifa { get; set; }
    public int? EquipoSoFifaId { get; set; }
    public List<Partido>? PartidosJugadosLocal { get; set; }
    public List<Partido>? PartidosJugadosVisitante { get; set; }
    public List<TorneoEquipo>? TorneosEquipos { get; set; }

    public Equipo() {
        EquipoSofifa = new EquipoSofifa();
        Jugadores = new List<Jugador>();
        PartidosJugadosLocal = new List<Partido>();
        PartidosJugadosVisitante = new List<Partido>();
        TorneosEquipos = new List<TorneoEquipo>();
    }

}