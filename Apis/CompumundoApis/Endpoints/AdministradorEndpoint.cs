using CompumundoApis.Entidades;
using CompumundoApis.Logica;


namespace CompumundoApis.Endpoints;

public static class AdministradorEndpoint
{
   public static void MapAdministradorEndpoints(this WebApplication app)
    {
        app.MapPost("/Administrador", async (AdministradorLogica administradorLogica, Administrador administrador) =>
        {
           await administradorLogica.CrearAdministrador(administrador);
            return Results.Ok();
        }); 

        app.MapGet("/Administrador", async (AdministradorLogica administradorLogica) =>
        {
            var administradores = await administradorLogica.ObtenerTodosLosAdministradores();
            return Results.Ok(administradores);
        });

        app.MapGet("/Administrador/{id}", async (AdministradorLogica administradorLogica, int id) =>
        {
            var administrador = await administradorLogica.ObtenerAdministradorPorId(id);
            if (administrador == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(administrador);
        });

        app.MapPut("/Administrador/{id}", async (AdministradorLogica administradorLogica, int id, Administrador administrador) =>
        {
            var existingAdministrador = await administradorLogica.ObtenerAdministradorPorId(id);
            if (existingAdministrador == null)
            {
                return Results.NotFound();
            }

            await administradorLogica.ActualizarAdministrador(id, administrador);
            return Results.Ok();
        });

        app.MapDelete("/Administrador/{id}", async (AdministradorLogica administradorLogica, int id) =>
        {
            var existingAdministrador = await administradorLogica.ObtenerAdministradorPorId(id);
            if (existingAdministrador == null)
            {
                return Results.NotFound();
            }

            await administradorLogica.EliminarAdministrador(id);
            return Results.Ok();
        });
    }    
}