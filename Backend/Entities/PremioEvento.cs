using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class PremioEvento
{
    public int Id { get; set; }
    public string NombreEvento { get; set; }
    public double Cantidad { get; set; }

}