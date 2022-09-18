using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net;
using System.Xml.Linq;

#pragma warning disable 1591
public class SoFifaRepository : ISoFifaRepository
{
    private readonly ApplicationDbContext db;

    public SoFifaRepository(ApplicationDbContext _db)
    {
        db = _db;
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

    public async Task<List<EquipoSofifa>> GetEquipos(int offset)
    {
        List<EquipoSofifa> equipos = new List<EquipoSofifa>();

        HtmlWeb web = new HtmlWeb();

        HtmlDocument? doc = web.Load("http://sofifa.com/teams?type=club&offset=" + offset);

        var rows = doc.DocumentNode.SelectNodes(".//tbody//tr//td").Elements().ToList();
        rows = rows.Where(row => row.Name == "a").ToList();
        List<HtmlNode> teams = new List<HtmlNode>();

        rows.Select((item, index) => (item, index)).ToList().ForEach(element =>
            {

                if (element.index % 2 == 0)
                {
                    EquipoSofifa equipo = new EquipoSofifa();
                    equipo.IdSoFifa = Convert.ToInt32(element.item.OuterHtml.Split("/")[2]);
                    equipo.Nombre = element.item.InnerText;
                    equipo.UrlImage = "https://cdn.sofifa.net/teams/" + equipo.IdSoFifa + "/60.png";
                    equipos.Add(equipo);
                }

            });

        return equipos;
    }

    public async Task<List<EquipoSofifa>> SetEquiposSoFifa()
    {
        List<int> offsets = new List<int>() { 1, 60, 120, 180, 240, 300, 360, 420, 480, 540, 600 };
        List<EquipoSofifa> equipos = new List<EquipoSofifa>();

        offsets.ForEach(async offset => {
            List<EquipoSofifa> equiposObtenidos = await GetEquipos(offset);
            equipos.AddRange(equiposObtenidos);
        });

        await db.EquiposSofifa.AddRangeAsync(equipos);
        await db.SaveChangesAsync();

        return equipos;
    }

    public async Task<List<EquipoSofifa>> GetEquiposSoFifa()
    {
        return db.EquiposSofifa.ToList();
    }

    public async Task<EquipoSofifa> GetEquipoSoFifaById(int id)
    {
        return db.EquiposSofifa.Where(equipo => equipo.Id == id).FirstOrDefault();
    }
}