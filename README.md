# Order Management API – Prueba Técnica (.NET Core)

Este proyecto corresponde a la **Prueba Técnica – .NET Core**, cuyo objetivo es desarrollar una API REST para la gestión de **Clientes, Productos y Órdenes**, aplicando buenas prácticas de backend, separación de responsabilidades y validaciones de negocio.

---

## 📌 Tecnologías Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **Swagger (Swashbuckle)**
- **Postman** (pruebas de endpoints)

---

## 🧩 Descripción de la Solución

La solución implementa una **API REST** con arquitectura en capas:

- **Controllers**: Exponen los endpoints HTTP.
- **Services**: Contienen la lógica de negocio.
- **Data**: Manejo del contexto de base de datos (EF Core).
- **Models**: Entidades del dominio.
- **DTOs**: Objetos de transferencia para requests/responses.

La API permite:
- CRUD de **Clientes**
- CRUD de **Productos**
- Creación y consulta de **Órdenes**, incluyendo su detalle

Las órdenes aplican reglas de negocio como:
- Validación de cliente existente
- Validación de productos
- Control de stock
- Cálculo de subtotal, impuesto y total

---

## 🗂️ Estructura del Proyecto

OrderManagementAPI
│
├── Controllers
│ ├── ClientesController.cs
│ ├── ProductosController.cs
│ └── OrdenesController.cs
│
├── Services
│ ├── ClienteService.cs
│ ├── ProductoService.cs
│ └── OrdenService.cs
│
├── Data
│ └── ApplicationDbContext.cs
│
├── Models
│ ├── Cliente.cs
│ ├── Producto.cs
│ ├── Orden.cs
│ └── DetalleOrden.cs
│
├── DTOs
│ ├── ClienteDto.cs
│ ├── ProductoDto.cs
│ └── OrdenDto.cs
│
├── Program.cs
├── appsettings.json
└── README.md

