using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class EquipoSofifa
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int IdSoFifa { get; set; }
    public string UrlImage { get; set; }

    public Equipo Equipo { get; set; }

    public EquipoSofifa() {}

}