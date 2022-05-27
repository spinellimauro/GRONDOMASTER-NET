using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Precios
{
    public int Id { get; set; }
    public int Nivel { get; set; }
    public double Precio { get; set; }

}