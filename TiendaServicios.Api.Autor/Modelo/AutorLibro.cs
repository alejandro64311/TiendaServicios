using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Autor.Modelo
{
    public class AutorLibro
    {
        public int AutorLibroId { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public DateTime? FechaNacimiento { set; get; }

        public ICollection<GradoAcademico> ListaGradoAcademico { set; get; }

        public string AutorLibroGuid { set; get; }
    }
}
