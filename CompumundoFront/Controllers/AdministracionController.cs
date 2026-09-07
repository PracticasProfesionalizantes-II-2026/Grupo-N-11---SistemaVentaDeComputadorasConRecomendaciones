using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace CompumundoFront.Controllers;

public class AdministracionController : Controller
{
    public IActionResult Index() => View();
}

[ApiController]
[Route("administracion/api/{recurso}")]
public class AdministracionApiController : ControllerBase
{
    private static readonly Dictionary<string, string> Recursos = new(StringComparer.OrdinalIgnoreCase)
    {
        ["productos"] = "Producto", ["pcs-armadas"] = "PcArmada", ["pedidos"] = "Pedido",
        ["detalles-pedido"] = "DetallePedido", ["clientes"] = "Cliente", ["cuentas"] = "CuentaCliente",
        ["administradores"] = "Administrador", ["proveedores"] = "Proveedor", ["ventas"] = "Ventas"
    };
    private readonly IHttpClientFactory _httpClientFactory;

    public AdministracionApiController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    [HttpGet]
    public Task<IActionResult> Listar(string recurso) => Enviar(recurso, HttpMethod.Get);

    [HttpGet("{id:int}")]
    public Task<IActionResult> Obtener(string recurso, int id) => Enviar(recurso, HttpMethod.Get, id);

    [HttpPost]
    public Task<IActionResult> Crear(string recurso, [FromBody] JsonElement datos) => Enviar(recurso, HttpMethod.Post, null, datos);

    [HttpPut("{id:int}")]
    public Task<IActionResult> Actualizar(string recurso, int id, [FromBody] JsonElement datos) => Enviar(recurso, HttpMethod.Put, id, datos);

    [HttpDelete("{id:int}")]
    public Task<IActionResult> Eliminar(string recurso, int id) => Enviar(recurso, HttpMethod.Delete, id);

    private async Task<IActionResult> Enviar(string recurso, HttpMethod metodo, int? id = null, JsonElement? datos = null)
    {
        if (!Recursos.TryGetValue(recurso, out var ruta)) return NotFound(new { mensaje = "Recurso no encontrado." });
        try
        {
            var solicitud = new HttpRequestMessage(metodo, id is null ? ruta : $"{ruta}/{id}");
            if (datos is not null) solicitud.Content = JsonContent.Create(datos.Value);
            var respuesta = await _httpClientFactory.CreateClient("CompumundoApi").SendAsync(solicitud);
            var contenido = await respuesta.Content.ReadAsStringAsync();
            return new ContentResult { Content = contenido, ContentType = "application/json", StatusCode = (int)respuesta.StatusCode };
        }
        catch (HttpRequestException)
        {
            return StatusCode((int)HttpStatusCode.ServiceUnavailable, new { mensaje = "No se pudo conectar con la API." });
        }
    }
}
