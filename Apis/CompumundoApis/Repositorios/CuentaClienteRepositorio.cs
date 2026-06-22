


public class CuentaClienteRepositorio : ICuentaClienteRepositorio
{
    private readonly CompumundoDbContext _context;

    public CuentaClienteRepositorio(CompumundoDbContext context)
    {
        _context = context;
    }

    public async Task<CuentaCliente> PostCuentaClienteAsync(CuentaCliente cuentaCliente)
    {
        _context.CuentaClientes.Add(cuentaCliente);
        await _context.SaveChangesAsync();
        return cuentaCliente;
    }

    public async Task<CuentaCliente> GetCuentaClienteByIdAsync(int id)
    {
        return await _context.CuentaClientes.FindAsync(id);
    }

    public async Task<CuentaCliente> GetCuentaClienteAsync()
    {
        return await _context.CuentaClientes.FirstOrDefaultAsync();
    }

    public async Task<CuentaCliente> PutCuentaClienteAsync(CuentaCliente cuentaCliente)
    {
        _context.Entry(cuentaCliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return cuentaCliente;
    }

    public async Task<CuentaCliente> DeleteCuentaClienteAsync(int id)
    {
        var cuentaCliente = await _context.CuentaClientes.FindAsync(id);
        if (cuentaCliente != null)
        {
            _context.CuentaClientes.Remove(cuentaCliente);
            await _context.SaveChangesAsync();
        }
        return cuentaCliente;
    }
}