using Microsoft.AspNetCore.Mvc;

public class VentasController : Controller
{
    public IActionResult ConsultarVentas()
    {
        return View();
    }
}