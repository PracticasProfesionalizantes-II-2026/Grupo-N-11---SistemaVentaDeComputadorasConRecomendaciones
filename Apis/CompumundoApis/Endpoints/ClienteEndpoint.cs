using CompumundoApis.Entidades;
using CompumundoApis.Logica;

namespace CompumundoApis.Endpoints;

public static class ClienteEndpoint
{
   public static void MapClienteEndpoints(this WebApplication app)
    {
        app.MapPost("/Cliente", async (ClienteLogica clienteLogica, Cliente cliente) =>
        {
           await clienteLogica.CrearCliente(cliente);
            return Results.Ok();
        }); 

        app.MapGet("/Cliente", async (ClienteLogica clienteLogica) =>
        {
            var clientes = await clienteLogica.ObtenerTodosLosClientes();
            return Results.Ok(clientes);
        });

        app.MapGet("/Cliente/{id}", async (ClienteLogica clienteLogica, int id) =>
        {
            var cliente = await clienteLogica.ObtenerClientePorId(id);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(cliente);
        });

        app.MapPut("/Cliente/{id}", async (ClienteLogica clienteLogica, int id, Cliente cliente) =>
        {
            var existingCliente = await clienteLogica.ObtenerClientePorId(id);
            if (existingCliente == null)
            {
                return Results.NotFound();
            }

            await clienteLogica.ActualizarCliente(id, cliente);
            return Results.Ok();
        });

        app.MapDelete("/Cliente/{id}", async (ClienteLogica clienteLogica, int id) =>
        {
            var existingCliente = await clienteLogica.ObtenerClientePorId(id);
            if (existingCliente == null)
            {
                return Results.NotFound();
            }

            await clienteLogica.EliminarCliente(id);
            return Results.Ok();
        });
    }
}