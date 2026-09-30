using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CompumundoFront.Controllers;

[ApiController]
[Route("tienda")]
public class TiendaController : ControllerBase
{
    private readonly IHttpClientFactory _clients;
    public TiendaController(IHttpClientFactory clients) => _clients = clients;

    [HttpGet("pcs-armadas")]
    public Task<IActionResult> PcsArmadas() => Enviar(HttpMethod.Get, "PcArmada");
    [HttpPost("registro")]
    public Task<IActionResult> Registro([FromBody] JsonElement datos) => Enviar(HttpMethod.Post, "Auth/Registro", datos);
    [HttpPost("login")]
    public Task<IActionResult> Login([FromBody] JsonElement datos) => Enviar(HttpMethod.Post, "Auth/Login", datos);
    [HttpPost("admin/login")]
    public async Task<IActionResult> AdminLogin([FromBody] JsonElement datos)
    {
        try
        {
            var solicitud = new HttpRequestMessage(HttpMethod.Post, "Auth/AdminLogin")
            {
                Content = JsonContent.Create(datos)
            };
            var respuesta = await _clients.CreateClient("CompumundoApi").SendAsync(solicitud);
            var contenido = await respuesta.Content.ReadAsStringAsync();
            if (!respuesta.IsSuccessStatusCode)
                return new ContentResult { Content = contenido, ContentType = "application/json", StatusCode = (int)respuesta.StatusCode };

            using var admin = JsonDocument.Parse(contenido);
            HttpContext.Session.SetInt32("AdminId", admin.RootElement.GetProperty("id").GetInt32());
            return new ContentResult { Content = contenido, ContentType = "application/json", StatusCode = StatusCodes.Status200OK };
        }
        catch (HttpRequestException) { return StatusCode(503, new { mensaje = "No se pudo conectar con la API." }); }
    }
    [HttpPost("configurar-pc")]
    public Task<IActionResult> ConfigurarPc([FromBody] JsonElement datos) => Enviar(HttpMethod.Post, "PcArmada/Configurar", datos);
    [HttpPost("compra")]
    public Task<IActionResult> Compra([FromBody] JsonElement datos) => Enviar(HttpMethod.Post, "Compra", datos);
    [HttpGet("clientes/{id:int}/pedidos")]
    public Task<IActionResult> Pedidos(int id) => Enviar(HttpMethod.Get, $"Cliente/{id}/Pedidos");

    private async Task<IActionResult> Enviar(HttpMethod metodo, string ruta, JsonElement? datos = null)
    {
        try
        {
            var solicitud = new HttpRequestMessage(metodo, ruta);
            if (datos is not null) solicitud.Content = JsonContent.Create(datos.Value);
            var respuesta = await _clients.CreateClient("CompumundoApi").SendAsync(solicitud);
            return new ContentResult { Content = await respuesta.Content.ReadAsStringAsync(), ContentType = "application/json", StatusCode = (int)respuesta.StatusCode };
        }
        catch (HttpRequestException) { return StatusCode(503, new { mensaje = "No se pudo conectar con la API." }); }
    }
}
