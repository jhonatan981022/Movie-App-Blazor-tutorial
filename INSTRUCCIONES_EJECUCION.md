# 🚀 Instrucciones de Ejecución - MovieApp Blazor Tutorial

## 📋 Pasos Rápidos para Ejecutar el Proyecto

### 1. Verificar Requisitos
Asegúrate de tener instalado:
- **.NET 9 SDK** (verificar con `dotnet --version`)
- **Navegador web moderno**

### 2. Navegar al Proyecto
```bash
cd MovieApp-Blazor-Tutorial/MovieApp
```

### 3. Restaurar Dependencias (Opcional)
```bash
dotnet restore
```

### 4. Compilar el Proyecto
```bash
dotnet build
```

### 5. Ejecutar la Aplicación
```bash
dotnet run
```

### 6. Abrir en el Navegador
La aplicación estará disponible en:
- **HTTP**: http://localhost:5000
- **HTTPS**: https://localhost:5001

## 🎯 Funcionalidades a Probar

### ✅ Lista de Películas
- Al cargar, deberías ver películas populares
- Cada película muestra: póster, título, año, puntuación

### ✅ Scroll Infinito (Lazy Loading)
- Desplázate hacia abajo en la página
- Automáticamente se cargarán más películas
- Verás un indicador de "Cargando más películas..."

### ✅ Navegación a Detalles
- Haz clic en cualquier película
- Se abrirá la página de detalles con información completa
- Incluye: sinopsis, géneros, duración, presupuesto, etc.

### ✅ Navegación de Regreso
- En la página de detalles, usa el botón "Volver a películas"
- Regresarás a la lista principal

### ✅ Diseño Responsivo
- Prueba redimensionar la ventana del navegador
- La aplicación se adapta a diferentes tamaños de pantalla

## 🐛 Solución de Problemas

### Problema: "No se pueden cargar las películas"
**Posibles causas:**
- Sin conexión a internet
- API de TMDb temporalmente no disponible
- Firewall bloqueando la conexión

**Soluciones:**
1. Verificar conexión a internet
2. Esperar unos minutos y recargar
3. Verificar que no hay firewall bloqueando

### Problema: "Tailwind CSS no se aplica"
**Causa:** CDN de Tailwind no cargado
**Solución:** Verificar conexión a internet y recargar la página

### Problema: "Scroll infinito no funciona"
**Causa:** JavaScript no configurado
**Solución:** Verificar que el script está en `wwwroot/index.html`

### Problema: Error de compilación
**Solución:**
```bash
dotnet clean
dotnet restore
dotnet build
```

## 📱 Pruebas en Diferentes Dispositivos

### Desktop
- Resolución completa con todas las características
- Grid de 5 columnas en pantallas grandes

### Tablet
- Grid de 3-4 columnas
- Navegación adaptada

### Móvil
- Grid de 2 columnas
- Menú hamburguesa (si se implementa)

## 🔧 Comandos Útiles

### Limpiar y Reconstruir
```bash
dotnet clean
dotnet restore
dotnet build
```

### Ejecutar en Modo Desarrollo
```bash
dotnet run --environment Development
```

### Ver Logs Detallados
```bash
dotnet run --verbosity detailed
```

## 📊 Métricas de Rendimiento Esperadas

### Carga Inicial
- **Tiempo de carga**: 2-5 segundos
- **Películas mostradas**: 20 películas

### Lazy Loading
- **Tiempo de carga adicional**: 1-2 segundos
- **Películas por página**: 20 películas

### Navegación
- **Tiempo de navegación**: Instantáneo
- **Carga de detalles**: 1-2 segundos

## 🎓 Objetivos de Aprendizaje Cumplidos

Al ejecutar este proyecto, habrás experimentado:

### Frontend Moderno
- ✅ **Blazor WebAssembly**: SPA con C#
- ✅ **Tailwind CSS**: Framework de utilidades CSS
- ✅ **Diseño Responsivo**: Adaptación a diferentes pantallas

### Consumo de APIs
- ✅ **HTTP Requests**: Peticiones GET a API REST
- ✅ **JSON Deserialization**: Conversión de JSON a objetos C#
- ✅ **Error Handling**: Manejo de errores de red

### Experiencia de Usuario
- ✅ **Lazy Loading**: Carga perezosa para mejor rendimiento
- ✅ **Navigation**: Navegación SPA sin recargas
- ✅ **Loading States**: Indicadores de carga

### Interoperabilidad
- ✅ **JavaScript Interop**: Comunicación C# ↔ JavaScript
- ✅ **Event Handling**: Manejo de eventos de scroll

## 🚀 Próximos Pasos

### Mejoras Sugeridas
1. **Búsqueda**: Agregar barra de búsqueda
2. **Filtros**: Filtrar por género o año
3. **Favoritos**: Sistema de películas favoritas
4. **PWA**: Convertir en Progressive Web App

### Tecnologías Adicionales
1. **State Management**: Fluxor o similar
2. **Authentication**: Login con Auth0 o Identity
3. **Caching**: Implementar caché local
4. **Testing**: Pruebas unitarias con bUnit

## 📞 Soporte

Si encuentras problemas:
1. Revisa la documentación en `README.md`
2. Verifica los requisitos del sistema
3. Consulta la sección de solución de problemas
4. Revisa los logs en la consola del navegador

---

**¡Disfruta explorando el mundo del cine con tu nueva aplicación! 🎬**
