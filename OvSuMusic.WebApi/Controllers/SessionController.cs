using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OvSuMusic.Data.Contracts;
using OvSuMusic.Dtos;
using OvSuMusic.Models;
using OvSuMusic.WebApi.Services;

namespace OvSuMusic.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {

        private IUsuariosRepo _usuariosRepositorio;
        private IMapper _mapper;
        private TokenService _tokenService;

        public SessionController(IUsuariosRepo usuariosRepositorio,
                                IMapper mapper,
                                TokenService tokenService)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        //POST: api/sesion/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> PostLogin(LoginModelDto usuarioLogin)
        {
            var datosLoginUsuario = _mapper.Map<Usuario>(usuarioLogin);

            var resultadoValidacion = await _usuariosRepositorio.LoginDataValidation(datosLoginUsuario);
            if (!resultadoValidacion.result)
            {
                return BadRequest("Usuario/Contraseña Inválidos.");
            }
            return _tokenService.GenerarToken(resultadoValidacion.usuario);

        }

    }
}
