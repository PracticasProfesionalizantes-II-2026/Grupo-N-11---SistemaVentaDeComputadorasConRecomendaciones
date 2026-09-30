# Grupo-N-11---SistemaVentaDeComputadorasConRecomendaciones
Matias Windey, Gabriel Ferrero y Lucio Pavan 


2025

[Documentacion v1](https://docs.google.com/document/d/1WdauFxjPpRJTAW-eYFkg1aFqtVTf9Siu0gV_0LxP3ck/edit?tab=t.0#heading=h.z6ne0og04bp5)

[Mock ups](https://www.figma.com/design/4wHdI5Yu0W1so6PUcutItE/Proyecto-compumundo?node-id=0-1&p=f&m=draw)

[Casos de uso](https://docs.google.com/document/d/1EnKGazQfmV0StYz9pNWcCtSch1HhHeQ0Oy6eX6vEAkI/edit?tab=t.0)

[Diagrama](https://lucid.app/lucidchart/f2065a37-c3dc-48bb-a114-80b9d9f00008/edit?invitationId=inv_76ceefda-7387-42b3-a384-6ad3876a220d&page=0_0#)




2026

[Documentacion v2](https://docs.google.com/document/d/1WdauFxjPpRJTAW-eYFkg1aFqtVTf9Siu0gV_0LxP3ck/edit?tab=t.0#heading=h.z6ne0og04bp5)

[Documentacion Apis](https://docs.google.com/document/d/16MAnE_AXPwHJ2vYbzj2iSbfpEPhxyw0lgFYeC1fT6W0/edit?tab=t.0)

## Ejecución del proyecto

El proyecto usado para la entrega está formado por dos aplicaciones:

1. `Apis/CompumundoApis`: API y base de datos.
2. `CompumundoFront`: tienda web y panel de administración.

Primero se debe configurar la cadena `DefaultConnection` en `Apis/CompumundoApis/appsettings.Development.json`. Para SQL Server LocalDB se puede utilizar:

```json
"DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=CompumundoDB;Trusted_Connection=True;TrustServerCertificate=True;"
```

Después, desde la carpeta de la API, aplicar las migraciones:

```powershell
dotnet ef database update
dotnet run --launch-profile http
```

En otra terminal, iniciar el frontend:

```powershell
cd CompumundoFront
dotnet run --launch-profile http
```

La propiedad `Api:BaseUrl` de `CompumundoFront/appsettings.Development.json` debe coincidir con la URL HTTP donde se inició la API.

## Funcionalidades implementadas

- Registro e inicio de sesión de clientes.
- Catálogo con búsqueda, filtros por hardware, presupuesto y uso, detalle, imágenes, comparador y carrito persistente.
- Checkout con cuatro medios de pago, IVA automático, dirección de entrega, stock, pedido e historial de compras.
- PCs prearmadas y configurador con verificación básica de categorías compatibles.
- Panel de administración para clientes, staff, productos, proveedores, PCs, pedidos, cuentas, detalles y ventas.
- Carga de imágenes JPG, PNG o WEBP para productos desde Administración.

