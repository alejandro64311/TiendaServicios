using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo.Dtos;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class Ejecuta : IRequest<LibreriaMaterialDto>
        {
            public Guid LibreriaMaterialId { set; get; }
        }

        public class Manejador : IRequestHandler<Ejecuta, LibreriaMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibreriaMaterialDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autor = await this._contexto.LibreriaMaterial.Where(x => x.LibreriaMaterialId == request.LibreriaMaterialId).FirstOrDefaultAsync();
                return this._mapper.Map<LibreriaMaterialDto>(autor);
            }
        }
    }
}
