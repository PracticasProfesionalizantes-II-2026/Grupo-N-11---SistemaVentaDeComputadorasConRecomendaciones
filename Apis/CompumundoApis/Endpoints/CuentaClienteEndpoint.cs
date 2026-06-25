using CompumundoApis.Entidades;
using CompumundoApis.Logica;



namespace CompumundoApis.Endpoints;
public static class CuentaClienteEndpoint
{
   public static void MapCuentaClienteEndpoints(this WebApplication app)
    {
        app.MapPost("/CuentaCliente", async (CuentaClienteLogica cuentaClienteLogica, CuentaCliente cuentaCliente) =>
        {
           await cuentaClienteLogica.CrearCuentaCliente(cuentaCliente);
            return Results.Ok();
        }); 

        app.MapGet("/CuentaCliente", async (CuentaClienteLogica cuentaClienteLogica) =>
        {
            var cuentasClientes = await cuentaClienteLogica.ObtenerTodasLasCuentasClientes();
            return Results.Ok(cuentasClientes);
        });

        app.MapGet("/CuentaCliente/{id}", async (CuentaClienteLogica cuentaClienteLogica, int id) =>
        {
            var cuentaCliente = await cuentaClienteLogica.ObtenerCuentaClientePorId(id);
            if (cuentaCliente == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(cuentaCliente);
        });

        app.MapPut("/CuentaCliente/{id}", async (CuentaClienteLogica cuentaClienteLogica, int id, CuentaCliente cuentaCliente) =>
        {
            var existingCuentaCliente = await cuentaClienteLogica.ObtenerCuentaClientePorId(id);
            if (existingCuentaCliente == null)
            {
                return Results.NotFound();
            }

            await cuentaClienteLogica.ActualizarCuentaCliente(id, cuentaCliente);
            return Results.Ok();
        });

        app.MapDelete("/CuentaCliente/{id}", async (CuentaClienteLogica cuentaClienteLogica, int id) =>
        {
            var existingCuentaCliente = await cuentaClienteLogica.ObtenerCuentaClientePorId(id);
            if (existingCuentaCliente == null)
            {
                return Results.NotFound();
            }

            await cuentaClienteLogica.EliminarCuentaCliente(id);
            return Results.Ok();
        });
    }
}