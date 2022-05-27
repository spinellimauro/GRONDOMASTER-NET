using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Oferta
{
    public int Id { get; set; }
    public DT DtOfertante { get; set; }
    public DT DtReceptor { get; set; }
    public double Monto { get; set; }
    public Jugador JugadorOfertado { get; set; }
    public List<Jugador> JugadoresOfrecidos { get; set; }
    public int IdDtOfertante { get; set; }
    public int IdDtReceptor { get; set; }
    public int IdJugadorOfertado { get; set; }
    public int IdJugadorOfrecido { get; set; }
    public Mercado Mercado { get; set; }
    public int IdMercado { get; set; }

}