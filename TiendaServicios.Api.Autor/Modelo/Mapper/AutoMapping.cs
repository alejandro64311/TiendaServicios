using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo.Dtos;

namespace TiendaServicios.Api.Autor.Modelo.Mapper
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            CreateMap<AutorLibro, AutorDto>();

        }
    }
}
