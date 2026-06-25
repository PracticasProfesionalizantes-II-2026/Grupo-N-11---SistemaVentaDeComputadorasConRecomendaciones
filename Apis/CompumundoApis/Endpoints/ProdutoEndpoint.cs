using CompumundoApis.Entidades;
using CompumundoApis.Logica;


namespace CompumundoApis.Endpoints;
public static class ProductoEndpoint
{
   public static void MapProductoEndpoints(this WebApplication app)
    {
        app.MapPost("/Producto", async (ProductoLogica productoLogica, Producto producto) =>
        {
           await productoLogica.CrearProducto(producto);
            return Results.Ok();
        }); 

        app.MapGet("/Producto", async (ProductoLogica productoLogica) =>
        {
            var productos = await productoLogica.ObtenerTodosLosProductos();
            return Results.Ok(productos);
        });

        app.MapGet("/Producto/{id}", async (ProductoLogica productoLogica, int id) =>
        {
            var producto = await productoLogica.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(producto);
        });

        app.MapPut("/Producto/{id}", async (ProductoLogica productoLogica, int id, Producto producto) =>
        {
            var existingProducto = await productoLogica.ObtenerProductoPorId(id);
            if (existingProducto == null)
            {
                return Results.NotFound();
            }

            await productoLogica.ActualizarProducto(id, producto);
            return Results.Ok();
        });

        app.MapDelete("/Producto/{id}", async (ProductoLogica productoLogica, int id) =>
        {
            var existingProducto = await productoLogica.ObtenerProductoPorId(id);
            if (existingProducto == null)
            {
                return Results.NotFound();
            }

            await productoLogica.EliminarProducto(id);
            return Results.Ok();
        });
    }
}