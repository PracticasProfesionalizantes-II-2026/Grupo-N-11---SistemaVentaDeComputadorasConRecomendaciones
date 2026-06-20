


public interface IClienteLogica
{
    Task<Cliente> PostClienteAsync(Cliente cliente);
    Task<Cliente> GetClienteByIdAsync(int id);
    Task<Cliente> GetClienteAsync();
    Task<Cliente> PutClienteAsync(Cliente cliente);
    Task<Cliente> DeleteClienteAsync(int id);
}