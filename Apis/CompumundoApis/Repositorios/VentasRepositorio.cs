


public class VentasRepositorio : IVentasLogica
{
    private readonly CompumundoContext _context;

    public VentasRepositorio(CompumundoContext context)
    {
        _context = context;
    }

    public async Task<Venta> ObtenerVentaPorId(int id)
    {
        return await _context.Ventas.FindAsync(id);
    }

    public async Task<IEnumerable<Venta>> ObtenerTodasLasVentas()
    {
        return await _context.Ventas.ToListAsync();
    }

    public async Task<Venta> CrearVenta(Venta venta)
    {
        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();
        return venta;
    }

    public async Task<Venta> ActualizarVenta(int id, Venta venta)
    {
        var ventaExistente = await _context.Ventas.FindAsync(id);
        if (ventaExistente == null)
        {
            return null;
        }

        // Actualizar las propiedades de la venta existente
        ventaExistente.Fecha = venta.Fecha;
        ventaExistente.Total = venta.Total;
        // Actualizar otras propiedades según sea necesario

        await _context.SaveChangesAsync();
        return ventaExistente;
    }

    public async Task<bool> EliminarVenta(int id)
    {
        var venta = await _context.Ventas.FindAsync(id);
        if (venta == null)
        {
            return false;
        }

        _context.Ventas.Remove(venta);
        await _context.SaveChangesAsync();
        return true;
    }
}