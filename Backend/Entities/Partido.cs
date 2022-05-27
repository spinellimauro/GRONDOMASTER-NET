using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Partido
{
    public int Id { get; set; }
    public int NroFecha { get; set; }
    public Equipo EquipoLocal { get; set; }
    public Equipo EquipoVisitante { get; set; }
    public Torneo Torneo { get; set; }
    public List<Suceso> Sucesos { get; set; }
    public Boolean Finalizado { get; set; }

}