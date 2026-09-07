using System.Net.Http.Json;
using CompumundoFront.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompumundoFront.Controllers;

[ApiController]
[Route("catalogo")]
public class CatalogoController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CatalogoController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    [HttpGet("productos")]
    public async Task<ActionResult<IEnumerable<ProductoCatalogo>>> Productos()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("CompumundoApi");
            var productos = await client.GetFromJsonAsync<List<ProductoCatalogo>>("Producto");
            return Ok(productos ?? []);
        }
        catch (HttpRequestException)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, new { mensaje = "No se pudo conectar con la API de productos." });
        }
        catch (TaskCanceledException)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, new { mensaje = "La API de productos tardó demasiado en responder." });
        }
    }
}
