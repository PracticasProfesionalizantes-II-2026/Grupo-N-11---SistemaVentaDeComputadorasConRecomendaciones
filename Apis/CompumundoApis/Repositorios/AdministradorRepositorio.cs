


public class AdministradorRepositorio : IAdministradorRepositorio
{
    private readonly CompumundoDbContext _context;

    public AdministradorRepositorio(CompumundoDbContext context)
    {
        _context = context;
    }

    public async Task<Administrador> PostAdministradorAsync(Administrador administrador)
    {
        _context.Administradores.Add(administrador);
        await _context.SaveChangesAsync();
        return administrador;
    }

    public async Task<Administrador> GetAdministradorByIdAsync(int id)
    {
        return await _context.Administradores.FindAsync(id);
    }
    public async Task<Administrador> GetAdministradorAsync()
    {
        return await _context.Administradores.FirstOrDefaultAsync();
    }

    public async Task<Administrador> PutAdministradorAsync(Administrador administrador)
    {
        _context.Entry(administrador).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return administrador;
    }
    public async Task<Administrador> DeleteAdministradorAsync(int id)
    {
        var administrador = await _context.Administradores.FindAsync(id);
        if (administrador == null)
        {
            return null;
        }
        _context.Administradores.Remove(administrador);
        await _context.SaveChangesAsync();
        return administrador;
    }
}