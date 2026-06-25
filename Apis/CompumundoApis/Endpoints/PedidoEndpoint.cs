using CompumundoApis.Entidades;
using CompumundoApis.Logica;

namespace CompumundoApis.Endpoints;
public static class PedidoEndpoint
{
   public static void MapPedidoEndpoints(this WebApplication app)
    {
        app.MapPost("/Pedido", async (PedidoLogica pedidoLogica, Pedido pedido) =>
        {
           await pedidoLogica.CrearPedido(pedido);
            return Results.Ok();
        }); 

        app.MapGet("/Pedido", async (PedidoLogica pedidoLogica) =>
        {
            var pedidos = await pedidoLogica.ObtenerTodosLosPedidos();
            return Results.Ok(pedidos);
        });

        app.MapGet("/Pedido/{id}", async (PedidoLogica pedidoLogica, int id) =>
        {
            var pedido = await pedidoLogica.ObtenerPedidoPorId(id);
            if (pedido == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(pedido);
        });

        app.MapPut("/Pedido/{id}", async (PedidoLogica pedidoLogica, int id, Pedido pedido) =>
        {
            var existingPedido = await pedidoLogica.ObtenerPedidoPorId(id);
            if (existingPedido == null)
            {
                return Results.NotFound();
            }

            await pedidoLogica.ActualizarPedido(id, pedido);
            return Results.Ok();
        });

        app.MapDelete("/Pedido/{id}", async (PedidoLogica pedidoLogica, int id) =>
        {
            var existingPedido = await pedidoLogica.ObtenerPedidoPorId(id);
            if (existingPedido == null)
            {
                return Results.NotFound();
            }

            await pedidoLogica.EliminarPedido(id);
            return Results.Ok();
        });
    }
}