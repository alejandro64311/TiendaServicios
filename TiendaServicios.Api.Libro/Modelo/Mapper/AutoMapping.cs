using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo.Dtos;

namespace TiendaServicios.Api.Libro.Modelo.Mapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<LibreriaMaterial, LibreriaMaterialDto>();

        }
    }
}
