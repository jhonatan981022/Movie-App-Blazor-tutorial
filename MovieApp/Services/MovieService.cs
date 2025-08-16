using MovieApp.Models;
using System.Text.Json;

namespace MovieApp.Services
{
    /// <summary>
    /// Servicio responsable de consumir la API de The Movie Database (TMDb)
    /// Maneja todas las operaciones relacionadas con películas
    /// </summary>
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "2f1f4e67102c4a38734580cc851bfdbc";
        private const string BaseUrl = "https://api.themoviedb.org/3";

        /// <summary>
        /// Constructor que recibe HttpClient por inyección de dependencias
        /// </summary>
        /// <param name="httpClient">Cliente HTTP para realizar peticiones</param>
        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Obtiene una lista de películas populares de TMDb
        /// Implementa paginación para el lazy loading
        /// </summary>
        /// <param name="page">Número de página a obtener (por defecto 1)</param>
        /// <returns>Respuesta con la lista de películas y información de paginación</returns>
        public async Task<MovieResponse?> GetPopularMoviesAsync(int page = 1)
        {
            try
            {
                // Construir la URL con la clave de API y el número de página
                var url = $"{BaseUrl}/movie/popular?api_key={ApiKey}&page={page}&language=es-ES";
                
                // Realizar la petición HTTP GET
                var response = await _httpClient.GetAsync(url);
                
                // Verificar que la respuesta sea exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer el contenido JSON de la respuesta
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    
                    // Configurar opciones de deserialización JSON
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    
                    // Deserializar el JSON a nuestro modelo MovieResponse
                    return JsonSerializer.Deserialize<MovieResponse>(jsonContent, options);
                }
                else
                {
                    // Log del error (en una aplicación real usarías un logger)
                    Console.WriteLine($"Error al obtener películas: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (en una aplicación real usarías un logger)
                Console.WriteLine($"Excepción al obtener películas: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Obtiene los detalles completos de una película específica
        /// </summary>
        /// <param name="movieId">ID de la película</param>
        /// <returns>Detalles completos de la película</returns>
        public async Task<MovieDetails?> GetMovieDetailsAsync(int movieId)
        {
            try
            {
                // Construir la URL para obtener detalles de una película específica
                var url = $"{BaseUrl}/movie/{movieId}?api_key={ApiKey}&language=es-ES";
                
                // Realizar la petición HTTP GET
                var response = await _httpClient.GetAsync(url);
                
                // Verificar que la respuesta sea exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer el contenido JSON
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    
                    // Configurar opciones de deserialización
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    
                    // Deserializar a nuestro modelo MovieDetails
                    return JsonSerializer.Deserialize<MovieDetails>(jsonContent, options);
                }
                else
                {
                    Console.WriteLine($"Error al obtener detalles de película: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al obtener detalles de película: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Busca películas por título
        /// Funcionalidad adicional para futuras mejoras
        /// </summary>
        /// <param name="query">Término de búsqueda</param>
        /// <param name="page">Página de resultados</param>
        /// <returns>Resultados de búsqueda</returns>
        public async Task<MovieResponse?> SearchMoviesAsync(string query, int page = 1)
        {
            try
            {
                // URL para búsqueda de películas
                var url = $"{BaseUrl}/search/movie?api_key={ApiKey}&query={Uri.EscapeDataString(query)}&page={page}&language=es-ES";
                
                var response = await _httpClient.GetAsync(url);
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    
                    return JsonSerializer.Deserialize<MovieResponse>(jsonContent, options);
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en búsqueda: {ex.Message}");
                return null;
            }
        }
    }
}
