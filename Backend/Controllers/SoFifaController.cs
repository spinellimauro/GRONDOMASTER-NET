using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;

namespace Gaby.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoFifaController : ControllerBase
    {

        private readonly ISoFifaRepository soFifaRepository;
        private readonly IMapper mapper;

        public SoFifaController(
            ISoFifaRepository _soFifaRepository,
            IMapper _mapper)
        {

            mapper = _mapper;
            soFifaRepository = _soFifaRepository;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Roles.USER)]
        [HttpGet("get-jugadores-by-search")]
        public async Task<IActionResult> GetJugadoresSoFifa(string query)
        {

            List<Jugador> jugadores = await soFifaRepository.GetJugadoresBySearch(query);

            return Ok(mapper.Map<List<Jugador>, List<JugadoresSoFifaViewModel>>(jugadores));

        }

        [HttpGet("get-sofifa-teams")]
        public async Task<IActionResult> GetEquiposSoFifa()
        {

            List<EquipoSofifa> equipos = await soFifaRepository.GetEquiposSoFifa();

            return Ok(mapper.Map<List<EquipoSofifa>, List<EquipoSoFifaViewModel>>(equipos));

        }

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Roles.USER)]
        [HttpPost("set-teams-table")]
        public async Task<IActionResult> SetTeamsTable()
        {

            await soFifaRepository.SetEquiposSoFifa();

            return Ok();

        }

    }
}
