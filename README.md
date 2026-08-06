Tienda de Videojuegos

Aplicación web completa con módulo de administración CRUD, desarrollada con arquitectura en capas (N-Layer) y separación total entre Front End y Back End.

Backend
Framework: ASP.NET Core 8 Web API
Arquitectura en capas:
	Abstracciones — entidades (Modelos/VideoJuego) e interfaces de contrato para cada capa
	
	DA (Data Access) — acceso a datos con Entity Framework Core
	
	Reglas — validaciones de negocio
	
	Flujo — orquesta Reglas + DA
	
	Servicios — capa de exposición hacia la API
	
	Api — controladores REST + configuración (inyección de dependencias, CORS, Swagger)

ORM: Entity Framework Core 8
Documentación de API: Swagger / Swashbuckle

Base de datos: SQL Server

Frontend
Framework: React (con Vite)
Librerías: axios (consumo de la API REST), react-router-dom (rutas)

Herramientas de desarrollo
IDE: Visual Studio 2026
Control de puertos y ejecución conjunta: script start.bat para levantar la API y el frontend con un solo comando

Cumplimiento de requisitos:
CRUD completo sobre la entidad VideoJuego (crear, leer, actualizar, eliminar)
Manejo de errores y códigos HTTP apropiados (200, 201, 400, 404, 204) en cada endpoint
Arquitectura organizada por capas con separación de responsabilidades e interfaces como contratos
Frontend que consume la API vía HTTP
Formularios con validaciones (campos obligatorios, precio y stock numéricos válidos)
Diseño responsivo con navegación clara entre catálogo y administración
