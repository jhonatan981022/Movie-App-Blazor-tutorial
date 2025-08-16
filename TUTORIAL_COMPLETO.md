# 🎬 Tutorial: Construyendo una Aplicación de Películas con Blazor, Tailwind CSS y la API de TMDb

## 📋 Introducción

Este tutorial te guiará paso a paso para crear una aplicación web moderna que consume la API de **The Movie Database (TMDb)** usando **Blazor WebAssembly** y **Tailwind CSS**. Aprenderás conceptos fundamentales del desarrollo frontend moderno, incluyendo:

- ✅ Consumo de APIs REST
- ✅ Lazy Loading (carga perezosa) con scroll infinito
- ✅ Navegación entre páginas
- ✅ Diseño responsivo con Tailwind CSS
- ✅ Manejo de estado en Blazor
- ✅ Interoperabilidad con JavaScript

### 🎯 Resultado Final
Una aplicación que muestra películas populares con:
- Lista infinita de películas con scroll automático
- Página de detalles para cada película
- Diseño moderno y responsivo
- Navegación fluida entre páginas

---

## 🛠️ Sección 1: Requisitos Previos

Antes de comenzar, asegúrate de tener instalado:

### Software Necesario
- **.NET 9 SDK** - [Descargar aquí](https://dotnet.microsoft.com/download)
- **Visual Studio Code** o **Visual Studio 2022**
- **Navegador web moderno** (Chrome, Firefox, Edge)

### Verificar Instalación
Abre una terminal y ejecuta:
```bash
dotnet --version
```
Deberías ver la versión 9.0.x o superior.

---

## 🏗️ Sección 2: Creación del Proyecto

### Paso 1: Crear el Proyecto Blazor WebAssembly
```bash
# Crear carpeta del proyecto
mkdir MovieApp-Blazor-Tutorial
cd MovieApp-Blazor-Tutorial

# Crear proyecto Blazor WebAssembly
dotnet new blazorwasm -n MovieApp

# Navegar al proyecto
cd MovieApp
```

### Paso 2: Verificar la Estructura Inicial
Tu proyecto debería tener esta estructura:
```
MovieApp/
├── Pages/
├── Layout/
├── wwwroot/
├── Program.cs
├── App.razor
├── _Imports.razor
└── MovieApp.csproj
```

---

## 📁 Sección 3: Estructura del Proyecto

### Crear Carpetas Organizacionales
```bash
# Crear carpetas para organizar el código
mkdir Models
mkdir Services
```

### Estructura Final Recomendada
```
MovieApp/
├── Models/           # Clases para mapear datos de la API
├── Services/         # Lógica de consumo de API
├── Pages/           # Páginas de la aplicación
├── Layout/          # Layouts y componentes compartidos
└── wwwroot/         # Archivos estáticos
```

**¿Por qué esta estructura?**
- **Separación de responsabilidades**: Cada carpeta tiene un propósito específico
- **Mantenibilidad**: Fácil localizar y modificar código
- **Escalabilidad**: Estructura preparada para crecer

---

## 🎨 Sección 4: Integrando Tailwind CSS

### Paso 1: Modificar wwwroot/index.html
Reemplaza el contenido del archivo `wwwroot/index.html`:

```html
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>MovieApp - Aplicación de Películas</title>
    <base href="/" />
    
    <!-- Tailwind CSS CDN -->
    <script src="https://cdn.tailwindcss.com"></script>
    
    <!-- Configuración personalizada de Tailwind -->
    <script>
        tailwind.config = {
            theme: {
                extend: {
                    colors: {
                        'movie-dark': '#0f172a',
                        'movie-blue': '#1e40af',
                        'movie-gold': '#fbbf24'
                    }
                }
            }
        }
    </script>
    
    <link rel="stylesheet" href="css/app.css" />
    <link rel="icon" type="image/png" href="favicon.png" />
    <link href="MovieApp.styles.css" rel="stylesheet" />
</head>
<body class="bg-gray-900 text-white">
    <div id="app">
        <!-- Loading spinner personalizado -->
        <div class="flex items-center justify-center min-h-screen bg-gray-900">
            <div class="text-center">
                <div class="animate-spin rounded-full h-16 w-16 border-b-2 border-blue-500 mx-auto mb-4"></div>
                <p class="text-gray-300 text-lg">Cargando películas...</p>
            </div>
        </div>
    </div>

    <div id="blazor-error-ui" class="bg-red-600 text-white p-4 fixed top-0 left-0 right-0 z-50">
        Ha ocurrido un error inesperado.
        <a href="." class="reload underline ml-2">Recargar</a>
        <span class="dismiss ml-2 cursor-pointer">🗙</span>
    </div>

    <script src="_framework/blazor.webassembly.js"></script>
    
    <!-- Script para detectar scroll infinito -->
    <script>
        window.scrollFunctions = {
            addScrollListener: function (dotNetObjectReference) {
                window.addEventListener('scroll', function () {
                    if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight - 1000) {
                        dotNetObjectReference.invokeMethodAsync('LoadMoreMovies');
                    }
                });
            }
        };
    </script>
</body>
</html>
```

### ¿Qué hace este código?
- **CDN de Tailwind**: Carga Tailwind CSS desde internet
- **Configuración personalizada**: Define colores específicos para la aplicación
- **Script de scroll**: JavaScript para detectar cuando el usuario llega al final de la página
- **Estilos base**: Fondo oscuro y texto blanco para el tema cinematográfico

---

## 📊 Sección 5: Creando los Modelos de Datos

Los modelos son clases C# que representan la estructura de los datos que recibimos de la API de TMDb.

### Paso 1: Crear Models/Movie.cs
```csharp
using System.Text.Json.Serialization;

namespace MovieApp.Models
{
    /// <summary>
    /// Modelo que representa una película en la lista de películas populares
    /// </summary>
    public class Movie
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("overview")]
        public string Overview { get; set; } = string.Empty;

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; } = string.Empty;

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = string.Empty;

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        // Propiedades calculadas
        public string FullPosterPath => 
            string.IsNullOrEmpty(PosterPath) 
                ? "/images/no-poster.jpg" 
                : $"https://image.tmdb.org/t/p/w500{PosterPath}";

        public string ReleaseYear => 
            DateTime.TryParse(ReleaseDate, out var date) 
                ? date.Year.ToString() 
                : "N/A";
    }
}
```

### Paso 2: Crear Models/MovieResponse.cs
```csharp
using System.Text.Json.Serialization;

namespace MovieApp.Models
{
    /// <summary>
    /// Modelo que representa la respuesta de la API para la lista de películas
    /// </summary>
    public class MovieResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; } = new List<Movie>();

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
    }
}
```

### Paso 3: Crear Models/MovieDetails.cs
```csharp
using System.Text.Json.Serialization;

namespace MovieApp.Models
{
    /// <summary>
    /// Modelo para los detalles completos de una película
    /// </summary>
    public class MovieDetails
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("overview")]
        public string Overview { get; set; } = string.Empty;

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; } = string.Empty;

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; } = string.Empty;

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = string.Empty;

        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        [JsonPropertyName("budget")]
        public long Budget { get; set; }

        [JsonPropertyName("revenue")]
        public long Revenue { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; } = new List<Genre>();

        [JsonPropertyName("tagline")]
        public string Tagline { get; set; } = string.Empty;

        // Propiedades calculadas
        public string FullPosterPath => 
            string.IsNullOrEmpty(PosterPath) 
                ? "/images/no-poster.jpg" 
                : $"https://image.tmdb.org/t/p/w500{PosterPath}";

        public string FullBackdropPath => 
            string.IsNullOrEmpty(BackdropPath) 
                ? "" 
                : $"https://image.tmdb.org/t/p/w1280{BackdropPath}";

        public string FormattedRuntime => 
            Runtime > 0 
                ? $"{Runtime / 60}h {Runtime % 60}m" 
                : "N/A";

        public string GenresString => 
            string.Join(", ", Genres.Select(g => g.Name));
    }

    public class Genre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
```

### 🔍 Explicación de los Modelos

**JsonPropertyName**: Este atributo mapea las propiedades C# con los nombres de campos JSON de la API.

**Propiedades Calculadas**: Como `FullPosterPath`, procesan datos para mostrarlos de manera más conveniente.

**Tipos de Datos**: Usamos tipos apropiados (`int`, `string`, `double`, `List<T>`) según lo que esperamos de la API.

---

## 🔌 Sección 6: El Servicio de la API

El servicio maneja toda la comunicación con la API de TMDb. Es el corazón de nuestra aplicación.

### Paso 1: Crear Services/MovieService.cs

```csharp
using MovieApp.Models;
using System.Text.Json;

namespace MovieApp.Services
{
    /// <summary>
    /// Servicio para consumir la API de The Movie Database (TMDb)
    /// </summary>
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "2f1f4e67102c4a38734580cc851bfdbc";
        private const string BaseUrl = "https://api.themoviedb.org/3";

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Obtiene películas populares con paginación
        /// </summary>
        public async Task<MovieResponse?> GetPopularMoviesAsync(int page = 1)
        {
            try
            {
                var url = $"{BaseUrl}/movie/popular?api_key={ApiKey}&page={page}&language=es-ES";
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
                Console.WriteLine($"Error al obtener películas: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Obtiene detalles de una película específica
        /// </summary>
        public async Task<MovieDetails?> GetMovieDetailsAsync(int movieId)
        {
            try
            {
                var url = $"{BaseUrl}/movie/{movieId}?api_key={ApiKey}&language=es-ES";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    return JsonSerializer.Deserialize<MovieDetails>(jsonContent, options);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener detalles: {ex.Message}");
                return null;
            }
        }
    }
}
```

### Paso 2: Registrar el Servicio en Program.cs

Modifica `Program.cs`:

```csharp
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MovieApp;
using MovieApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registrar el servicio de películas
builder.Services.AddScoped<MovieService>();

await builder.Build().RunAsync();
```

### 🔍 Explicación del Servicio

**HttpClient**: Herramienta de .NET para hacer peticiones HTTP.

**API Key**: Clave proporcionada por TMDb para acceder a su API.

**Async/Await**: Patrón para operaciones asíncronas que no bloquean la UI.

**Manejo de Errores**: Try-catch para capturar y manejar errores de red.

**Deserialización JSON**: Convierte la respuesta JSON en objetos C#.

---

## 🏠 Sección 7: La Página Principal (Home.razor)

### Conceptos Clave del Lazy Loading

El **Lazy Loading** o carga perezosa es una técnica que carga contenido solo cuando es necesario. En nuestro caso:

1. **Carga inicial**: Mostramos las primeras 20 películas
2. **Detección de scroll**: JavaScript detecta cuando el usuario llega al final
3. **Carga automática**: Se cargan automáticamente las siguientes 20 películas
4. **Experiencia fluida**: El usuario nunca ve una página de carga

### Paso 1: Modificar Pages/Home.razor

El archivo completo está en el proyecto, pero aquí están las partes clave:

#### Inyección de Dependencias
```csharp
@inject MovieService MovieService
@inject IJSRuntime JSRuntime
@inject NavigationManager Navigation
@implements IAsyncDisposable
```

#### Estado del Componente
```csharp
@code {
    private List<Movie> movies = new List<Movie>();
    private bool isLoading = false;
    private bool isLoadingMore = false;
    private bool hasReachedEnd = false;
    private int currentPage = 1;
    private DotNetObjectReference<Home>? dotNetObjectReference;
}
```

#### Método de Lazy Loading
```csharp
[JSInvokable]
public async Task LoadMoreMovies()
{
    if (isLoadingMore || hasReachedEnd || isLoading)
        return;

    try
    {
        isLoadingMore = true;
        StateHasChanged();

        var nextPage = currentPage + 1;
        var response = await MovieService.GetPopularMoviesAsync(nextPage);

        if (response != null && response.Results.Any())
        {
            movies.AddRange(response.Results);
            currentPage = response.Page;
            hasReachedEnd = currentPage >= response.TotalPages;
        }
    }
    finally
    {
        isLoadingMore = false;
        StateHasChanged();
    }
}
```

### 🔍 Explicación del Lazy Loading

**JSInvokable**: Permite que JavaScript llame a métodos C#.

**StateHasChanged()**: Notifica a Blazor que debe actualizar la UI.

**AddRange()**: Agrega las nuevas películas a la lista existente.

**Banderas de Estado**: Evitan múltiples cargas simultáneas.

---

## 🎬 Sección 8: La Página de Detalles (MovieDetails.razor)

### Conceptos de Navegación con Parámetros

Blazor permite pasar parámetros en la URL usando la sintaxis `{parametro:tipo}`.

### Paso 1: Definir la Ruta con Parámetro

```csharp
@page "/movie/{MovieId:int}"
[Parameter] public int MovieId { get; set; }
```

### Paso 2: Cargar Datos Basados en el Parámetro

```csharp
protected override async Task OnParametersSetAsync()
{
    await LoadMovieDetails();
}

private async Task LoadMovieDetails()
{
    var details = await MovieService.GetMovieDetailsAsync(MovieId);
    if (details != null)
    {
        movieDetails = details;
    }
}
```

### Paso 3: Navegación desde la Lista

En `Home.razor`:
```csharp
private void NavigateToDetails(int movieId)
{
    Navigation.NavigateTo($"/movie/{movieId}");
}
```

### 🔍 Explicación de la Navegación

**Parámetros de Ruta**: `{MovieId:int}` captura números enteros de la URL.

**OnParametersSetAsync**: Se ejecuta cuando cambian los parámetros.

**NavigationManager**: Servicio de Blazor para navegar entre páginas.

**URL Amigables**: `/movie/123` es más legible que `/details?id=123`.

---

## 🚀 Sección 9: Ejecutando el Proyecto

### Paso 1: Compilar y Ejecutar

```bash
# Desde la carpeta MovieApp
dotnet run
```

### Paso 2: Abrir en el Navegador

La aplicación se ejecutará en:
- **HTTP**: `http://localhost:5000`
- **HTTPS**: `https://localhost:5001`

### Paso 3: Verificar Funcionalidades

✅ **Lista de películas**: Deberías ver películas populares cargándose
✅ **Scroll infinito**: Al llegar al final, se cargan más películas
✅ **Navegación**: Hacer clic en una película abre sus detalles
✅ **Diseño responsivo**: La aplicación se adapta a diferentes tamaños de pantalla

### 🐛 Solución de Problemas Comunes

#### Error: "No se pueden cargar las películas"
- **Causa**: Problema de conexión a internet o API
- **Solución**: Verificar conexión y que la API key sea correcta

#### Error: "Tailwind CSS no se aplica"
- **Causa**: CDN no cargado o bloqueado
- **Solución**: Verificar conexión a internet y que el script esté en `index.html`

#### Error: "Scroll infinito no funciona"
- **Causa**: JavaScript no configurado correctamente
- **Solución**: Verificar que el script de scroll esté en `index.html`

---

## 🎯 Sección 10: Conclusión y Desafíos Adicionales

### 🎉 ¡Felicitaciones!

Has creado exitosamente una aplicación moderna de películas que incluye:

- ✅ **Consumo de API REST** con manejo de errores
- ✅ **Lazy Loading** para optimizar rendimiento
- ✅ **Navegación SPA** (Single Page Application)
- ✅ **Diseño responsivo** con Tailwind CSS
- ✅ **Interoperabilidad JavaScript-C#**

### 🚀 Desafíos Adicionales para Practicar

#### Nivel Principiante
1. **Búsqueda de películas**: Agregar una barra de búsqueda
2. **Favoritos**: Permitir marcar películas como favoritas (localStorage)
3. **Filtros**: Filtrar por género o año

#### Nivel Intermedio
4. **Paginación tradicional**: Agregar botones "Anterior/Siguiente"
5. **Modo oscuro/claro**: Toggle entre temas
6. **Compartir**: Botones para compartir películas en redes sociales

#### Nivel Avanzado
7. **PWA**: Convertir en Progressive Web App
8. **Caché**: Implementar caché local para mejor rendimiento
9. **Animaciones**: Agregar transiciones y animaciones CSS
10. **Testing**: Escribir pruebas unitarias para los servicios

### 📚 Conceptos Aprendidos

#### Frontend
- **Blazor WebAssembly**: Framework para crear SPAs con C#
- **Tailwind CSS**: Framework de utilidades CSS
- **Responsive Design**: Diseño que se adapta a diferentes dispositivos

#### Programación
- **Async/Await**: Programación asíncrona en C#
- **Dependency Injection**: Inyección de dependencias
- **JSON Serialization**: Conversión entre JSON y objetos C#

#### Arquitectura
- **Separation of Concerns**: Separación de responsabilidades
- **Service Layer**: Capa de servicios para lógica de negocio
- **Component-Based Architecture**: Arquitectura basada en componentes

### 🔗 Recursos Adicionales

#### Documentación Oficial
- [Blazor Documentation](https://docs.microsoft.com/aspnet/core/blazor/)
- [Tailwind CSS Documentation](https://tailwindcss.com/docs)
- [TMDb API Documentation](https://developers.themoviedb.org/3)

#### Tutoriales Avanzados
- [Blazor Authentication](https://docs.microsoft.com/aspnet/core/blazor/security/)
- [Blazor State Management](https://docs.microsoft.com/aspnet/core/blazor/state-management)
- [Progressive Web Apps with Blazor](https://docs.microsoft.com/aspnet/core/blazor/progressive-web-app)

### 💡 Próximos Pasos

1. **Experimenta**: Modifica colores, layouts y funcionalidades
2. **Expande**: Agrega nuevas páginas y características
3. **Optimiza**: Mejora el rendimiento y la experiencia de usuario
4. **Comparte**: Sube tu proyecto a GitHub y compártelo

### 🤝 Contribuciones

Este proyecto es educativo y está abierto a mejoras. Si encuentras errores o tienes sugerencias:

1. Crea un issue describiendo el problema
2. Propón mejoras o nuevas características
3. Comparte tu versión mejorada

---

## 📄 Licencia

Este proyecto es de uso educativo y está disponible bajo la licencia MIT.

---

## 🙏 Agradecimientos

- **The Movie Database (TMDb)** por proporcionar la API gratuita
- **Microsoft** por Blazor y .NET
- **Tailwind Labs** por Tailwind CSS
- **Comunidad de desarrolladores** por compartir conocimiento

---

**¡Feliz programación! 🚀**

*Recuerda: La mejor manera de aprender es practicando. No tengas miedo de experimentar y romper cosas. ¡Es parte del proceso de aprendizaje!*
