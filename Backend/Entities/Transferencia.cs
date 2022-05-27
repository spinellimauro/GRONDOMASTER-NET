using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Transferencia
{
    public int Id { get; set; }
    public DT DtComprador { get; set; }
    public DT DtVendedor { get; set; }
    public double Monto { get; set; }
    public Jugador Jugador { get; set; }

    public int IdDTComprador { get; set; }
    public int IdDTVendedor { get; set; }

}