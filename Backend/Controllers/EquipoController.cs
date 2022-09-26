﻿using System;
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
    public class EquipoController : ControllerBase
    {

        private readonly IEquipoRepository equipoRepository;
        private readonly IMapper mapper;

        public EquipoController(
            IEquipoRepository _equipoRepository,
            IMapper _mapper)
        {

            mapper = _mapper;
            equipoRepository = _equipoRepository;
        }

        
    

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Roles.USER)]
        [HttpGet("get-team")]
        public async Task<IActionResult> GetTeam()
        {
            Equipo equipoDt;
            int id = 1;
            //var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            
            equipoDt = await equipoRepository.GetEquipo(id);

            List<Jugador> jugadores = equipoDt.Jugadores;

            return Ok(mapper.Map<List<Jugador>, List<JugadoresSoFifaViewModel>>(jugadores));

        }

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = Roles.USER)]
        [HttpPost("comprar-jugador")]
         public async Task<IActionResult> comprarJugador([FromBody] JugadoresSoFifaViewModel model)
        {
            Jugador jugador = mapper.Map<JugadoresSoFifaViewModel, Jugador>(model);
            int id = 1;
            await equipoRepository.ComprarJugador(jugador,id);

            return Ok();

        }

    }
}