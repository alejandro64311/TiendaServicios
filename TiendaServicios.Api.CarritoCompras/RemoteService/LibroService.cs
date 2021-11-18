using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompras.RemoteInterace;
using TiendaServicios.Api.CarritoCompras.RemoteModel;

namespace TiendaServicios.Api.CarritoCompras.RemoteService
{
    public class LibroService : ILibroService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<LibroService> _logger;

        public LibroService(IHttpClientFactory httpClient, ILogger<LibroService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<(bool resultado, LibreriaRemote Libro, string ErrorMessage)> GetLibro(Guid LibroId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Libros");
                var response = await cliente.GetAsync($"api/LibroMaterial/{LibroId}");

                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive  = true
                    };

                    var resultado = JsonSerializer.Deserialize<LibreriaRemote>(contenido, options);
                    return (true, resultado, "");
                    
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.ToString());
            }
        }
    }
}
