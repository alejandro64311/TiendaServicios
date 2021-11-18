using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Modelo.Dtos;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/LibroMaterial
        [HttpGet]
        public async Task<ActionResult<List<LibreriaMaterialDto>>> Get()
        {
            return await _mediator.Send(new Consulta.Ejecuta ());
        }

        // GET: api/LibroMaterial/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<LibreriaMaterialDto>> Get(Guid id)
        {
            return await _mediator.Send(new ConsultaFiltro.Ejecuta { LibreriaMaterialId = id });
        }

        // POST: api/LibroMaterial
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear([FromBody] Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        // PUT: api/LibroMaterial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
