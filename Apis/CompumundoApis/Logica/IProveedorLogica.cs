


public interface IProveedorLogica
{
    Task<Proveedor> ObtenerProveedorPorId(int id);
    Task<IEnumerable<Proveedor>> ObtenerTodosLosProveedores();
    Task<Proveedor> CrearProveedor(Proveedor proveedor);
    Task<Proveedor> ActualizarProveedor(int id, Proveedor proveedor);
    Task<bool> EliminarProveedor(int id);
}