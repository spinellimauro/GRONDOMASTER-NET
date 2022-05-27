using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class PrecioEvento
{
    public int Id { get; set; }
    public string NombreEvento { get; set; }
    public double Precio { get; set; }

}