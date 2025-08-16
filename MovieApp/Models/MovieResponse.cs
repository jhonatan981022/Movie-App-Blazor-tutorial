using System.Text.Json.Serialization;

namespace MovieApp.Models
{
    /// <summary>
    /// Modelo que representa la respuesta completa de la API de TMDb para la lista de películas
    /// Incluye información de paginación y la lista de películas
    /// </summary>
    public class MovieResponse
    {
        /// <summary>
        /// Página actual de resultados
        /// </summary>
        [JsonPropertyName("page")]
        public int Page { get; set; }

        /// <summary>
        /// Lista de películas en la página actual
        /// </summary>
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; } = new List<Movie>();

        /// <summary>
        /// Número total de resultados disponibles
        /// </summary>
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        /// <summary>
        /// Número total de páginas disponibles
        /// </summary>
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
    }
}
