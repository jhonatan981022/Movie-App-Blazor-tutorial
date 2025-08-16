# 🎬 CineStream - MovieApp Blazor Tutorial

<div align="center">

![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=for-the-badge&logo=blazor&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)
![TMDb](https://img.shields.io/badge/TMDb-01B4E4?style=for-the-badge&logo=themoviedatabase&logoColor=white)

**Una aplicación moderna de películas con interfaz estilo streaming premium**

[🚀 Usar Plantilla](https://github.com/JohanCalaT/MovieApp-Blazor-Tutorial/generate) • [📚 Tutorial Completo](./TUTORIAL_COMPLETO.md) • [🎨 Mejoras Visuales](./MEJORAS_VISUALES.md) • [⚡ Ejecución Rápida](./INSTRUCCIONES_EJECUCION.md)

</div>

---

## 🌟 Características Principales

### 🎭 **Interfaz Premium**
- **Diseño Cinematográfico**: Hero section a pantalla completa estilo Netflix
- **Efectos Visuales Avanzados**: Glassmorphism, gradientes animados, hover effects
- **Responsive Design**: Adaptación perfecta a todos los dispositivos
- **Tema Oscuro**: Experiencia inmersiva para amantes del cine

### ⚡ **Funcionalidades Modernas**
- **Lazy Loading**: Scroll infinito para carga optimizada
- **Navegación SPA**: Transiciones fluidas sin recargas
- **Estados Interactivos**: Loading states y micro-animaciones
- **API Real**: Consumo de The Movie Database (TMDb)

### 🛠️ **Stack Tecnológico**
- **Frontend**: Blazor WebAssembly (.NET 9)
- **Estilos**: Tailwind CSS con configuración personalizada
- **API**: The Movie Database (TMDb)
- **Arquitectura**: Clean Architecture con separación de responsabilidades

---

## 📸 Capturas de Pantalla

### 🏠 Página Principal
![Hero Section](https://via.placeholder.com/800x400/1a1a1a/ffffff?text=Hero+Section+Cinematográfico)

### 🎬 Detalles de Película
![Movie Details](https://via.placeholder.com/800x400/1a1a1a/ffffff?text=Página+de+Detalles+Inmersiva)

### 📱 Diseño Responsivo
![Responsive Design](https://via.placeholder.com/800x400/1a1a1a/ffffff?text=Diseño+Responsivo+Perfecto)

---

## 🚀 Inicio Rápido

### 🎯 **Opción 1: Usar como Plantilla (Recomendado)**

1. **Clic en "Use this template"** → [Crear nuevo repositorio](https://github.com/JohanCalaT/MovieApp-Blazor-Tutorial/generate)
2. **Nombra tu proyecto** y configura la visibilidad
3. **Clona tu nuevo repositorio**:
```bash
git clone https://github.com/TU-USUARIO/TU-PROYECTO.git
cd TU-PROYECTO/MovieApp
dotnet run
```

### 🔄 **Opción 2: Clonar Directamente**

```bash
# Clonar el repositorio
git clone https://github.com/JohanCalaT/MovieApp-Blazor-Tutorial.git

# Navegar al proyecto
cd MovieApp-Blazor-Tutorial/MovieApp

# Ejecutar la aplicación
dotnet run
```

### Prerrequisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- Editor de código (VS Code, Visual Studio)
- Navegador web moderno

🌐 **Abrir en el navegador**: `https://localhost:5001`

---

## 📚 Documentación

| Documento | Descripción |
|-----------|-------------|
| [📖 Tutorial Completo](./TUTORIAL_COMPLETO.md) | Guía académica paso a paso (10 secciones) |
| [🎨 Mejoras Visuales](./MEJORAS_VISUALES.md) | Documentación de la interfaz moderna |
| [⚡ Ejecución Rápida](./INSTRUCCIONES_EJECUCION.md) | Guía rápida para ejecutar el proyecto |
| [📋 Resumen Técnico](./RESUMEN_PROYECTO.md) | Documentación técnica completa |

---

## 🎯 Objetivos Educativos

### 🎓 **Para Estudiantes**
- Aprender Blazor WebAssembly desde cero
- Consumir APIs REST reales
- Implementar lazy loading y scroll infinito
- Crear interfaces modernas con Tailwind CSS
- Manejar estado en aplicaciones SPA

### 👨‍🏫 **Para Educadores**
- Material didáctico completo y estructurado
- Proyecto hands-on para talleres
- Código comentado y documentado
- Progresión de dificultad gradual

### 💼 **Para Desarrolladores**
- Referencia de mejores prácticas en Blazor
- Patrones de diseño modernos
- Arquitectura escalable y mantenible
- Integración con APIs externas

---

## 🏗️ Arquitectura del Proyecto

```
MovieApp/
├── 📁 Models/           # Modelos de datos (Movie, MovieDetails, etc.)
├── 📁 Services/         # Servicios de negocio (MovieService)
├── 📁 Pages/           # Páginas Blazor (Home, MovieDetails)
├── 📁 Layout/          # Layouts y componentes compartidos
└── 📁 wwwroot/         # Archivos estáticos y configuración
```

### 🔄 **Flujo de Datos**
1. **UI (Blazor)** → Interacción del usuario
2. **Services** → Lógica de negocio y llamadas API
3. **Models** → Mapeo de datos JSON
4. **TMDb API** → Fuente de datos externa

---

## 🎨 Características Visuales

### ✨ **Efectos Modernos**
- **Glassmorphism**: Efectos de cristal en overlays
- **Gradientes Animados**: Fondos dinámicos
- **Hover Effects**: Interacciones fluidas
- **Micro-animaciones**: Feedback visual inmediato

### 📱 **Responsive Breakpoints**
- **Mobile**: 320px - 767px (2 columnas)
- **Tablet**: 768px - 1023px (3-4 columnas)
- **Desktop**: 1024px+ (5-6 columnas)

---

## 📋 Usar como Plantilla

Este repositorio está configurado como **GitHub Template Repository**, lo que significa que puedes usarlo como base para crear tu propio proyecto.

### 🎯 **Ventajas de usar la plantilla:**
- ✅ **Proyecto base completo** con toda la estructura
- ✅ **Documentación incluida** y personalizable
- ✅ **Issues templates** configurados
- ✅ **Pull request template** incluido
- ✅ **Licencia MIT** ya configurada
- ✅ **Gitignore optimizado** para .NET

### 🚀 **Pasos para usar la plantilla:**

1. **Clic en "Use this template"** en la parte superior del repositorio
2. **Configura tu nuevo repositorio:**
   - Nombre del repositorio
   - Descripción personalizada
   - Visibilidad (público/privado)
3. **Clona tu nuevo repositorio**
4. **Personaliza el proyecto:**
   - Actualiza el README con tu información
   - Modifica la configuración según tus necesidades
   - Agrega tus propias funcionalidades

### 🎓 **Casos de uso ideales:**
- **Talleres educativos** de Blazor
- **Proyectos estudiantiles** de desarrollo web
- **Prototipos rápidos** de aplicaciones de películas
- **Base para aplicaciones** de entretenimiento
- **Ejemplos de arquitectura** Clean Architecture

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Este proyecto es educativo y está abierto a mejoras.

### 🔧 **Cómo Contribuir**
1. **Usar como plantilla** o hacer fork del proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

📋 **Ver la [Guía de Contribución](./CONTRIBUTING.md) completa**

### 💡 **Ideas para Contribuir**
- Nuevas funcionalidades (búsqueda, filtros, favoritos)
- Mejoras en la UI/UX
- Optimizaciones de rendimiento
- Documentación adicional
- Tests unitarios

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo [LICENSE](LICENSE) para más detalles.

---

## 🙏 Agradecimientos

- **[The Movie Database (TMDb)](https://www.themoviedb.org/)** - Por proporcionar la API gratuita
- **[Microsoft](https://dotnet.microsoft.com/)** - Por Blazor y .NET
- **[Tailwind CSS](https://tailwindcss.com/)** - Por el framework de CSS
- **Comunidad de desarrolladores** - Por compartir conocimiento y mejores prácticas

---

## 📞 Contacto

**Johan Cala** - [@JohanCalaT](https://github.com/JohanCalaT)

**Link del Proyecto**: [https://github.com/JohanCalaT/MovieApp-Blazor-Tutorial](https://github.com/JohanCalaT/MovieApp-Blazor-Tutorial)

---

<div align="center">

**⭐ Si este proyecto te ayudó, considera darle una estrella ⭐**

**🎬 ¡Disfruta explorando el mundo del cine con Blazor! 🚀**

</div>
