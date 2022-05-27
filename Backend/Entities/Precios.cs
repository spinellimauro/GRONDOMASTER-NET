using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Precios
{
    public int id { get; set; }
    public int nivel { get; set; }
    public double precio { get; set; }

}