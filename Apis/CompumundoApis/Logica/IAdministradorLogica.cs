


public interface IAdministradorLogica
{
    Task<Administrador> ObtenerAdministradorPorId(int id);
    Task<IEnumerable<Administrador>> ObtenerTodosLosAdministradores();
    Task<Administrador> CrearAdministrador(Administrador administrador);
    Task<Administrador> ActualizarAdministrador(int id, Administrador administrador);
    Task<IEnumerable<Administrador>> EliminarAdministrador(int id);
}