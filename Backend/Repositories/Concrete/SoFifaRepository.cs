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

        foreach (var row in rows)
        {

            var cols = row.SelectNodes("//td");
            Jugador jugador = new Jugador();
            var dta = row.SelectNodes("//td/img").Descendants("title");
            jugador.Nombre = cols[1].SelectNodes("//a//div[@class='ellipsis']")[0].InnerText;
            jugador.Nacionalidad = cols[1].SelectNodes("//img/title")[0].InnerText;
            // jugador.NacionalidadCorta = jugador.Nacionalidad.Substring(0, 2).ToLower();
            // jugador.Id = Convert.ToInt32(cols.get(0).select("img").attr("id"));
            // jugador.Posiciones = cols.get(1).select("span").text();
            // jugador.Edad = Convert.ToInt32(cols.get(2).text());
            // jugador.Nivel = Convert.ToInt32(cols.get(3).text());
            // jugador.Potencial = Convert.ToInt32(cols.get(4).text());

            jugadores.Add(jugador);
        }

        return jugadores;
    }
}