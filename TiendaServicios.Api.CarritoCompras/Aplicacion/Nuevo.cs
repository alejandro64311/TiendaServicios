using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompras.Modelo;
using TiendaServicios.Api.CarritoCompras.Persistencia;

namespace TiendaServicios.Api.CarritoCompras.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        { 
            public List<string> ProductoLista { get; set; }

        }


        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CarritoContexto _contexto;

            public Manejador(CarritoContexto contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = DateTime.Now
                };

                _contexto.CarritoSesion.Add(carritoSesion);
                var value = await _contexto.SaveChangesAsync();

                if (value == 0)
                {
                    throw new Exception("Error en la insersion del carrito de compras");
                }

                int id = carritoSesion.CarritoSesionId;

                foreach(var obj in request.ProductoLista)
                {
                    var detalleSesion = new CarritoSesionDetalle
                    {
                        FechaCreacion = DateTime.Now,
                        CarritoSesionId = id,
                        ProductoSeleccionado = obj
                    };
                    _contexto.CarritoSesionDetalle.Add(detalleSesion);

                }

                value = await _contexto.SaveChangesAsync();

                if (value > 0)
                    return Unit.Value;

                throw new Exception("Error en la insersion del detalle del carrito de compras");

            }
        }
    }
}
