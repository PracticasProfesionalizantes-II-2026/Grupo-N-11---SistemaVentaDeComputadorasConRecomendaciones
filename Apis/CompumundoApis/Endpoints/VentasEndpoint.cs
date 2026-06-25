using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompumundoApis.Logica;
using CompumundoApis.Entidades;


namespace CompumundoApis.Endpoints;
public static class VentasEndpoint
{
   public static void MapVentasEndpoints(this WebApplication app)
    {
        app.MapPost("/Ventas", async (VentasLogica ventasLogica, Ventas venta) =>
        {
           await ventasLogica.CrearVenta(venta);
            return Results.Ok();
        }); 

        app.MapGet("/Ventas", async (VentasLogica ventasLogica) =>
        {
            var ventas = await ventasLogica.ObtenerTodasLasVentas();
            return Results.Ok(ventas);
        });

        app.MapGet("/Ventas/{id}", async (VentasLogica ventasLogica, int id) =>
        {
            var venta = await ventasLogica.ObtenerVentaPorId(id);
            if (venta == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(venta);
        });

        app.MapPut("/Ventas/{id}", async (VentasLogica ventasLogica, int id, Ventas venta) =>
        {
            var existingVenta = await ventasLogica.ObtenerVentaPorId(id);
            if (existingVenta == null)
            {
                return Results.NotFound();
            }

            await ventasLogica.ActualizarVenta(id, venta);
            return Results.Ok();
        });

        app.MapDelete("/Ventas/{id}", async (VentasLogica ventasLogica, int id) =>
        {
            var existingVenta = await ventasLogica.ObtenerVentaPorId(id);
            if (existingVenta == null)
            {
                return Results.NotFound();
            }

            await ventasLogica.EliminarVenta(id);
            return Results.Ok();
        });
    }
}