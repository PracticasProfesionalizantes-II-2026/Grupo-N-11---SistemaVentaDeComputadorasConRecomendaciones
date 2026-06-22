


public interface ICuentaCliente
{
        public Task<CuentaCliente> PostCuentaClienteAsync(CuentaCliente cuentaCliente);
        public Task<CuentaCliente> GetCuentaClienteByIdAsync(int id);   
        public Task<CuentaCliente> GetCuentaClienteAsync();
        public Task<CuentaCliente> PutCuentaClienteAsync(CuentaCliente cuentaCliente);
        public Task<CuentaCliente> DeleteCuentaClienteAsync(int id);



}