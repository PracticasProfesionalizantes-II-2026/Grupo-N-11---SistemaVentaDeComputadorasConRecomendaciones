


public interface IClienteLogica
{
    public Task<Cliente> PostClienteAsync(Cliente cliente);
    public Task<Cliente> GetClienteByIdAsync(int id);
    public Task<Cliente> GetClienteAsync();
    public Task<Cliente> PutClienteAsync(Cliente cliente);  
    public Task<Cliente> DeleteClienteAsync(int id);
    
}