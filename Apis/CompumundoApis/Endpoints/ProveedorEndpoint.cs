using CompumundoApis.Entidades;
using CompumundoApis.Logica;


namespace CompumundoApis.Endpoints;
public static class ProveedorEndpoint
{
   public static void MapProveedorEndpoints(this WebApplication app)
    {
        app.MapPost("/Proveedor", async (ProveedorLogica proveedorLogica, Proveedor proveedor) =>
        {
           await proveedorLogica.CrearProveedor(proveedor);
            return Results.Ok();
        }); 

        app.MapGet("/Proveedor", async (ProveedorLogica proveedorLogica) =>
        {
            var proveedores = await proveedorLogica.ObtenerTodosLosProveedores();
            return Results.Ok(proveedores);
        });

        app.MapGet("/Proveedor/{id}", async (ProveedorLogica proveedorLogica, int id) =>
        {
            var proveedor = await proveedorLogica.ObtenerProveedorPorId(id);
            if (proveedor == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(proveedor);
        });

        app.MapPut("/Proveedor/{id}", async (ProveedorLogica proveedorLogica, int id, Proveedor proveedor) =>
        {
            var existingProveedor = await proveedorLogica.ObtenerProveedorPorId(id);
            if (existingProveedor == null)
            {
                return Results.NotFound();
            }

            await proveedorLogica.ActualizarProveedor(id, proveedor);
            return Results.Ok();
        });

        app.MapDelete("/Proveedor/{id}", async (ProveedorLogica proveedorLogica, int id) =>
        {
            var existingProveedor = await proveedorLogica.ObtenerProveedorPorId(id);
            if (existingProveedor == null)
            {
                return Results.NotFound();
            }

            await proveedorLogica.EliminarProveedor(id);
            return Results.Ok();
        });
    }
}