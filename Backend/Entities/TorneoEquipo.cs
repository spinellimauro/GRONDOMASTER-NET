using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class TorneoEquipo
{
    public int Id { get; set; }
    public Torneo Torneo { get; set; }
    public Equipo Equipo { get; set; }
    public int IdTorneo { get; set; }
    public int IdEquipo { get; set; }

}