


public interface IVentasRepositorio
{
    Task<Venta> ObtenerVentaPorId(int id);
    Task<IEnumerable<Venta>> ObtenerTodasLasVentas();
    Task<Venta> CrearVenta(Venta venta);
    Task<Venta> ActualizarVenta(int id, Venta venta);
    Task<bool> EliminarVenta(int id);
}