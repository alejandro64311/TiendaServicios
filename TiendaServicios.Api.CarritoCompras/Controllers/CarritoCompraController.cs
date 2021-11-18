using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TiendaServicios.Api.CarritoCompras.Aplicacion;

namespace TiendaServicios.Api.CarritoCompras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarritoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CarritoCompraController> _logger;

        public CarritoCompraController(ILogger<CarritoCompraController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<CarritoDto>> GetCarrito(int id)
        {
            return await _mediator.Send(new Consulta.Ejecuta {CarritoSesionId=id });
        }
    }
}
