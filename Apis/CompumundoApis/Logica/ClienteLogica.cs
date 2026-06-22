

public class ClienteLogica : IClienteLogica
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ClienteLogica(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

   public Task<Cliente> PostClienteAsync(Cliente cliente)
    {
        return _clienteRepositorio.PostClienteAsync(cliente);
    }

    public Task<Cliente> GetClienteByIdAsync(int id)
    {
        return _clienteRepositorio.GetClienteByIdAsync(id);
    }
    public Task<Cliente> GetClienteAsync()
    {
        return _clienteRepositorio.GetClienteAsync();
    }

    public Task<Cliente> PutClienteAsync(Cliente cliente)
    {
        return _clienteRepositorio.PutClienteAsync(cliente);
    }
    public Task<Cliente> DeleteClienteAsync(int id)
    {
        return _clienteRepositorio.DeleteClienteAsync(id);
    }

}