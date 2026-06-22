


public static class AdministradorEndpoint
{
   public static void MapAdministradorEndpoints(this WebApplication app)
    {
        app.MapPost("/Administrador", async (IAdministradorLogica administradorLogica, Administrador administrador) =>
        {
           await administradorLogica.PostAdministradorAsync(administrador);
            return Results.Ok();
        }); 

        app.MapGet("/Administrador", async (IAdministradorLogica administradorLogica) =>
        {
            var administradores = await administradorLogica.GetAdministradoresAsync();
            return Results.Ok(administradores);
        });

        app.MapGet("/Administrador/{id}", async (IAdministradorLogica administradorLogica, int id) =>
        {
            var administrador = await administradorLogica.GetAdministradorByIdAsync(id);
            if (administrador == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(administrador);
        });

        app.MapPut("/Administrador/{id}", async (IAdministradorLogica administradorLogica, int id, Administrador administrador) =>
        {
            var existingAdministrador = await administradorLogica.GetAdministradorByIdAsync(id);
            if (existingAdministrador == null)
            {
                return Results.NotFound();
            }

            await administradorLogica.PutAdministradorAsync(id, administrador);
            return Results.Ok();
        });

        app.MapDelete("/Administrador/{id}", async (IAdministradorLogica administradorLogica, int id) =>
        {
            var existingAdministrador = await administradorLogica.GetAdministradorByIdAsync(id);
            if (existingAdministrador == null)
            {
                return Results.NotFound();
            }

            await administradorLogica.EliminarAdministradorAsync(id);
            return Results.Ok();
        });
}