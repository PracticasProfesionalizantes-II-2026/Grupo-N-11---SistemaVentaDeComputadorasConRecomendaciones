using CompumundoApis.Entidades;
using CompumundoApis.Logica;
using CompumundoApis.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;




namespace CompumundoApis.Endpoints;
public static class PedidoEndpoint
{
   public static void MapPedidoEndpoints(this WebApplication app)
    {
        app.MapPut("/Pedido/{id}/Estado", async (int id, EstadoPedidoRequest request, AppDbContext db) =>
        {
            var pedido = await db.Pedidos.Include(p => p.Detalles).FirstOrDefaultAsync(p => p.Id == id);
            if (pedido is null) return Results.NotFound();
            if (!Enum.IsDefined(typeof(Pedido.EstadoPedido), request.Estado))
                return Results.BadRequest(new { mensaje = "Estado de pedido inválido." });
            if (pedido.Estado is Pedido.EstadoPedido.Entregado or Pedido.EstadoPedido.Cancelado)
                return Results.BadRequest(new { mensaje = "Un pedido entregado o cancelado no puede modificarse." });
            if (request.Estado == Pedido.EstadoPedido.Cancelado)
            {
                foreach (var detalle in pedido.Detalles)
                {
                    var producto = await db.Productos.FindAsync(detalle.IdProducto);
                    if (producto is not null) producto.Stock += detalle.Cantidad;
                }
            }
            pedido.Estado = request.Estado;
            await db.SaveChangesAsync();
            return Results.Ok(new { pedido.Id, Estado = pedido.Estado.ToString(), pedido.Total });
        });
        // 1. Obtener todos los pedidos (GET)
        app.MapGet("/Pedido", async (
            [FromServices] IPedidoLogica pedidoLogica) =>
        {
            var pedidos = await pedidoLogica.ObtenerTodosLosPedidos();
            return Results.Ok(pedidos);
        });

        // 2. Obtener pedido por ID (GET)
        app.MapGet("/Pedido/{id}", async (
            [FromServices] IPedidoLogica pedidoLogica, 
            [FromRoute] int id) =>
        {
            var pedido = await pedidoLogica.ObtenerPedidoPorId(id);
            
            if (pedido == null)
            {
                return Results.NotFound();
            }
            
            return Results.Ok(pedido);
        });

        // 3. Crear pedido (POST)
        app.MapPost("/Pedido", async (
            [FromServices] IPedidoLogica pedidoLogica, 
            [FromBody] Pedido pedido) =>
        {
            var nuevoPedido = await pedidoLogica.CrearPedido(pedido);
            
            return Results.Created($"/Pedido/{nuevoPedido.Id}", nuevoPedido); 
        });

        // 4. Actualizar pedido (PUT)
        app.MapPut("/Pedido/{id}", async (
            [FromServices] IPedidoLogica pedidoLogica, 
            [FromRoute] int id, 
            [FromBody] Pedido pedido) =>
        {
            var pedidoActualizado = await pedidoLogica.ActualizarPedido(id, pedido);
            
            if (pedidoActualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(pedidoActualizado);
        });

        // 5. Eliminar pedido (DELETE)
        app.MapDelete("/Pedido/{id}", async (
            [FromServices] IPedidoLogica pedidoLogica, 
            [FromRoute] int id) =>
        {
            var eliminado = await pedidoLogica.EliminarPedido(id);
            
            if (!eliminado)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }

    public record EstadoPedidoRequest(Pedido.EstadoPedido Estado);
}
