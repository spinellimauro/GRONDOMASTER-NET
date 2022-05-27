using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class PremioEvento
{
    public int id { get; set; }
    public string nombreEvento { get; set; }
    public double cantidad { get; set; }

}