


public class PcArmadaRepositorio : IPcArmadaRepositorio
{
    private readonly CompumundoDbContext _context;

    public PcArmadaRepositorio(CompumundoDbContext context)
    {
        _context = context;
    }

    public async Task<PcArmada> ObtenerPcArmadaPorId(int id)
    {
        return await _context.PcsArmadas.FindAsync(id);
    }

    public async Task<IEnumerable<PcArmada>> ObtenerTodasLasPcsArmadas()
    {
        return await _context.PcsArmadas.ToListAsync();
    }

    public async Task<PcArmada> CrearPcArmada(PcArmada pcArmada)
    {
        _context.PcsArmadas.Add(pcArmada);
        await _context.SaveChangesAsync();
        return pcArmada;
    }

    public async Task<PcArmada> ActualizarPcArmada(int id, PcArmada pcArmada)
    {
        var existingPcArmada = await _context.PcsArmadas.FindAsync(id);
        if (existingPcArmada == null)
        {
            return null;
        }

        // Actualizar las propiedades del objeto existente con los valores del objeto proporcionado
        existingPcArmada.Nombre = pcArmada.Nombre;
        existingPcArmada.Descripcion = pcArmada.Descripcion;
        existingPcArmada.Precio = pcArmada.Precio;

        await _context.SaveChangesAsync();
        return existingPcArmada;
    }

    public async Task<bool> EliminarPcArmada(int id)
    {
        var pcArmada = await _context.PcsArmadas.FindAsync(id);
        if (pcArmada == null)
        {
            return false;
        }

        _context.PcsArmadas.Remove(pcArmada);
        await _context.SaveChangesAsync();
        return true;
    }
}