using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class PrecioEvento
{
    public int id { get; set; }
    public string nombreEvento { get; set; }
    public double precio { get; set; }

}