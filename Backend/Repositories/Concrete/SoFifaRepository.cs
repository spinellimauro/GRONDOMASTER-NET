using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net;
using System.Xml.Linq;

#pragma warning disable 1591
public class SoFifaRepository : ISoFifaRepository
{

    public SoFifaRepository()
    {

    }

    public async Task<List<Jugador>> GetJugadoresBySearch(string query)
    {
        List<Jugador> jugadores = new List<Jugador>();

        HtmlWeb web = new HtmlWeb();

        HtmlDocument? doc = web.Load("http://sofifa.com/players?keyword=" + query + "&layout=2017desktop&hl=es-ES");

        var rows = doc.DocumentNode.SelectNodes("//tbody//tr");

        int i = 0;
        string posicionesString = "";

        foreach (var row in rows)
        {
            var posiciones = row.SelectNodes(".//td//a/span").Elements().ToList();

            posiciones.Select((posicion, index) => (posicion, index)).ToList().ForEach(element =>
            {
                posicionesString += element.index == 0 ? element.posicion.InnerText : ", " + element.posicion.InnerText;
            });

            Jugador jugador = new Jugador();
            jugador.Nombre = row.SelectNodes("//td//a//div[@class='ellipsis']")[i].InnerText;
            jugador.Nacionalidad = row.SelectNodes("//td/img")[i].GetAttributeValue("title", string.Empty);
            jugador.NacionalidadCorta = jugador.Nacionalidad.Substring(0, 2).ToLower();
            jugador.Id = Convert.ToInt32(row.SelectNodes(".//td//figure/img")[0].GetAttributeValue("id", string.Empty));
            jugador.Posiciones = posicionesString;
            jugador.Edad = Convert.ToInt32(row.SelectNodes("//td[@class='col col-ae']")[i].InnerText);
            jugador.Nivel = Convert.ToInt32(row.SelectNodes("//td[@class='col col-oa col-sort']")[i].InnerText);
            jugador.Potencial = Convert.ToInt32(row.SelectNodes("//td[@class='col col-pt']")[i].InnerText);

            jugadores.Add(jugador);
            
            i++;
            posicionesString = "";
        }

        return jugadores;
    }
}