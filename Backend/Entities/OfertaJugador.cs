using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class OfertaJugador
{
    public int Id { get; set; }
    public Oferta Oferta { get; set; }
    public Jugador Jugador { get; set; }
    public int IdOferta { get; set; }
    public int IdJugador { get; set; }

}