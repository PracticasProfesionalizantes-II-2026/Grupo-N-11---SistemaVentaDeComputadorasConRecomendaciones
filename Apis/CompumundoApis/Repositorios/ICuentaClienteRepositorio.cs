


public interface ICuentaClienteRepositorio
{
    Task<CuentaCliente> ObtenerCuentaClientePorId(int id);
    Task<IEnumerable<CuentaCliente>> ObtenerTodasLasCuentasClientes();
    Task<CuentaCliente> CrearCuentaCliente(CuentaCliente cuentaCliente);
    Task<CuentaCliente> ActualizarCuentaCliente(int id, CuentaCliente cuentaCliente);
    Task<bool> EliminarCuentaCliente(int id);
}