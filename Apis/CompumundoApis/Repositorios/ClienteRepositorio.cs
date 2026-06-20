


public class ClienteRepositorio : IClienteRepositorio
{


    private readonly List<Cliente> clientes;

    private readonly AppdbContext _context;
    
    public task<Cliente> PostClienteAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }
    public task<Cliente> GetClienteByIdAsync(int id)
    {
        var cliente = _context.Clientes.Find(id);
        return Task.FromResult(cliente);
    }
    public task<Cliente> GetClienteAsync()
    {
        return Task.FromResult(_context.Clientes.AsEnumerable());
    }
    public task<Cliente> PutClienteAsync(Cliente cliente)
    {
        _Context.Clientes.Update(cliente);
        _Context.SaveChanges();
        return Task.FromResult(Context.Clientes.AsEnumerable());
    }
    public task<Cliente> DeleteClienteAsync(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente != null)     
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            
        }
        return Task.FromResult<Cliente>(null);
    }
}