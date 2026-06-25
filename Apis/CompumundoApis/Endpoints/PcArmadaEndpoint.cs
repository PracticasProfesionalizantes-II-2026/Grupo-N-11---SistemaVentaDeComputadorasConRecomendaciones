using CompumundoApis.Entidades;
using CompumundoApis.Logica;


namespace CompumundoApis.Endpoints;

public static class PcArmadaEndpoint
{
   public static void MapPcArmadaEndpoints(this WebApplication app)
    {
        app.MapPost("/PcArmada", async (PcArmadaLogica pcArmadaLogica, PcArmada pcArmada) =>
        {
           await pcArmadaLogica.CrearPcArmada(pcArmada);
            return Results.Ok();
        }); 

        app.MapGet("/PcArmada", async (PcArmadaLogica pcArmadaLogica) =>
        {
            var pcsArmadas = await pcArmadaLogica.ObtenerTodasLasPcsArmadas();
            return Results.Ok(pcsArmadas);
        });

        app.MapGet("/PcArmada/{id}", async (PcArmadaLogica pcArmadaLogica, int id) =>
        {
            var pcArmada = await pcArmadaLogica.ObtenerPcArmadaPorId(id);
            if (pcArmada == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(pcArmada);
        });

        app.MapPut("/PcArmada/{id}", async (PcArmadaLogica pcArmadaLogica, int id, PcArmada pcArmada) =>
        {
            var existingPcArmada = await pcArmadaLogica.ObtenerPcArmadaPorId(id);
            if (existingPcArmada == null)
            {
                return Results.NotFound();
            }

            await pcArmadaLogica.ActualizarPcArmada(id, pcArmada);
            return Results.Ok();
        });

        app.MapDelete("/PcArmada/{id}", async (PcArmadaLogica pcArmadaLogica, int id) =>
        {
            var existingPcArmada = await pcArmadaLogica.ObtenerPcArmadaPorId(id);
            if (existingPcArmada == null)
            {
                return Results.NotFound();
            }

            await pcArmadaLogica.EliminarPcArmada(id);
            return Results.Ok();
        });
    }
}