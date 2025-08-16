using System.Text.Json.Serialization;

namespace MovieApp.Models
{
    /// <summary>
    /// Modelo que representa una película en la lista de películas populares
    /// Mapea la respuesta JSON de la API de TMDb para cada película individual
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// ID único de la película en TMDb
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Título de la película
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción/sinopsis de la película
        /// </summary>
        [JsonPropertyName("overview")]
        public string Overview { get; set; } = string.Empty;

        /// <summary>
        /// Ruta del póster de la película (se debe concatenar con la URL base de imágenes)
        /// </summary>
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de lanzamiento de la película
        /// </summary>
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = string.Empty;

        /// <summary>
        /// Puntuación promedio de la película (0-10)
        /// </summary>
        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        /// <summary>
        /// Número total de votos
        /// </summary>
        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        /// <summary>
        /// Popularidad de la película (número calculado por TMDb)
        /// </summary>
        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        /// <summary>
        /// Propiedad calculada que devuelve la URL completa del póster
        /// </summary>
        public string FullPosterPath => 
            string.IsNullOrEmpty(PosterPath) 
                ? "/images/no-poster.jpg" 
                : $"https://image.tmdb.org/t/p/w500{PosterPath}";

        /// <summary>
        /// Propiedad calculada que devuelve el año de lanzamiento
        /// </summary>
        public string ReleaseYear => 
            DateTime.TryParse(ReleaseDate, out var date) 
                ? date.Year.ToString() 
                : "N/A";
    }
}
