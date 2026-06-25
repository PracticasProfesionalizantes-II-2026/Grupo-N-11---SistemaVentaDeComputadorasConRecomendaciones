using CompumundoApis.Entidades;
using CompumundoApis.Logica;


namespace CompumundoApis.Endpoints;
public static class DetallePedidoEndpoint
{
   public static void MapDetallePedidoEndpoints(this WebApplication app)
    {
        app.MapPost("/DetallePedido", async (DetallePedidoLogica detallePedidoLogica, DetallePedido detallePedido) =>
        {
           await detallePedidoLogica.CrearDetallePedido(detallePedido);
            return Results.Ok();
        }); 

        app.MapGet("/DetallePedido", async (DetallePedidoLogica detallePedidoLogica) =>
        {
            var detallesPedidos = await detallePedidoLogica.ObtenerTodosLosDetallesPedidos();
            return Results.Ok(detallesPedidos);
        });

        app.MapGet("/DetallePedido/{id}", async (DetallePedidoLogica detallePedidoLogica, int id) =>
        {
            var detallePedido = await detallePedidoLogica.ObtenerDetallePedidoPorId(id);
            if (detallePedido == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(detallePedido);
        });

        app.MapPut("/DetallePedido/{id}", async (DetallePedidoLogica detallePedidoLogica, int id, DetallePedido detallePedido) =>
        {
            var existingDetallePedido = await detallePedidoLogica.ObtenerDetallePedidoPorId(id);
            if (existingDetallePedido == null)
            {
                return Results.NotFound();
            }

            await detallePedidoLogica.ActualizarDetallePedido(id, detallePedido);
            return Results.Ok();
        });

        app.MapDelete("/DetallePedido/{id}", async (DetallePedidoLogica detallePedidoLogica, int id) =>
        {
            var existingDetallePedido = await detallePedidoLogica.ObtenerDetallePedidoPorId(id);
            if (existingDetallePedido == null)
            {
                return Results.NotFound();
            }

            await detallePedidoLogica.EliminarDetallePedido(id);
            return Results.Ok();
        });
    }
}