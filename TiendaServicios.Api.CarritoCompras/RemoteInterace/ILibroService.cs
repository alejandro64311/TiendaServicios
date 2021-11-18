using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompras.RemoteModel;

namespace TiendaServicios.Api.CarritoCompras.RemoteInterace
{
    public interface ILibroService
    {
        Task<(bool resultado, LibreriaRemote Libro, string ErrorMessage )> GetLibro(Guid LibroId);
    }
}
