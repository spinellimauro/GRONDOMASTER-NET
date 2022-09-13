using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class Mercado
{
    public int Id { get; set; }
    public List<Oferta> listaOfertas { get; set; }
    public List<Transferencia> listaTransferencias { get; set; }

    public Mercado()
    {
        listaOfertas = new List<Oferta>();
        listaTransferencias = new List<Transferencia>();
    }

}