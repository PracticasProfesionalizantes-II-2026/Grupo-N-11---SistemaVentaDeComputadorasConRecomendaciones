


public class VentasLogicas : IVentasLogicas
{
    private readonly IVentasRepositorio _ventasRepositorio;

    public VentasLogicas(IVentasRepositorio ventasRepositorio)
    {
        _ventasRepositorio = ventasRepositorio;
    }

    public async Task<Venta> ObtenerVentaPorId(int id)
    {
        return await _ventasRepositorio.ObtenerVentaPorId(id);
    }

    public async Task<IEnumerable<Venta>> ObtenerTodasLasVentas()
    {
        return await _ventasRepositorio.ObtenerTodasLasVentas();
    }

    public async Task<Venta> CrearVenta(Venta venta)
    {
        return await _ventasRepositorio.CrearVenta(venta);
    }

    public async Task<Venta> ActualizarVenta(int id, Venta venta)
    {
        return await _ventasRepositorio.ActualizarVenta(id, venta);
    }

    public async Task<bool> EliminarVenta(int id)
    {
        return await _ventasRepositorio.EliminarVenta(id);
    }

    

}