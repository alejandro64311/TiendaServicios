using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Modelo.Dtos;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await this._mediator.Send(data);
        }
        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetAutores( )
        {
            return await this._mediator.Send(new Consulta.ListaAutor());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutorById(string id)
        {
            return await this._mediator.Send(new ConsultaFiltro.AutorUnico {AutorGuid= id });
        }
    }
}