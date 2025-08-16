using System.Text.Json.Serialization;

namespace MovieApp.Models
{
    /// <summary>
    /// Modelo que representa los detalles completos de una película específica
    /// Incluye información adicional que no está disponible en la lista de películas
    /// </summary>
    public class MovieDetails
    {
        /// <summary>
        /// ID único de la película
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Título de la película
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción completa de la película
        /// </summary>
        [JsonPropertyName("overview")]
        public string Overview { get; set; } = string.Empty;

        /// <summary>
        /// Ruta del póster
        /// </summary>
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; } = string.Empty;

        /// <summary>
        /// Ruta de la imagen de fondo
        /// </summary>
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de lanzamiento
        /// </summary>
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = string.Empty;

        /// <summary>
        /// Duración de la película en minutos
        /// </summary>
        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }

        /// <summary>
        /// Puntuación promedio
        /// </summary>
        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        /// <summary>
        /// Número de votos
        /// </summary>
        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        /// <summary>
        /// Presupuesto de la película
        /// </summary>
        [JsonPropertyName("budget")]
        public long Budget { get; set; }

        /// <summary>
        /// Ingresos de la película
        /// </summary>
        [JsonPropertyName("revenue")]
        public long Revenue { get; set; }

        /// <summary>
        /// Lista de géneros de la película
        /// </summary>
        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; } = new List<Genre>();

        /// <summary>
        /// Tagline o eslogan de la película
        /// </summary>
        [JsonPropertyName("tagline")]
        public string Tagline { get; set; } = string.Empty;

        /// <summary>
        /// URL completa del póster
        /// </summary>
        public string FullPosterPath => 
            string.IsNullOrEmpty(PosterPath) 
                ? "/images/no-poster.jpg" 
                : $"https://image.tmdb.org/t/p/w500{PosterPath}";

        /// <summary>
        /// URL completa de la imagen de fondo
        /// </summary>
        public string FullBackdropPath => 
            string.IsNullOrEmpty(BackdropPath) 
                ? "" 
                : $"https://image.tmdb.org/t/p/w1280{BackdropPath}";

        /// <summary>
        /// Duración formateada en horas y minutos
        /// </summary>
        public string FormattedRuntime => 
            Runtime > 0 
                ? $"{Runtime / 60}h {Runtime % 60}m" 
                : "N/A";

        /// <summary>
        /// Géneros como string separado por comas
        /// </summary>
        public string GenresString => 
            string.Join(", ", Genres.Select(g => g.Name));
    }

    /// <summary>
    /// Modelo que representa un género de película
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// ID del género
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del género
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
