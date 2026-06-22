


private class AdministradorLogica : IAdministradorLogica
{
    private readonly IAdministradorRepositorio _administradorRepositorio;

    public AdministradorLogica(IAdministradorRepositorio administradorRepositorio)
    {
        _administradorRepositorio = administradorRepositorio;
    }

    public Task<Administrador> PostAdministradorAsync(Administrador administrador)
    {
        return _administradorRepositorio.PostAdministradorAsync(administrador);
    }

    public Task<Administrador> GetAdministradorByIdAsync(int id)
    {
        return _administradorRepositorio.GetAdministradorByIdAsync(id);
    }
    public Task<Administrador> GetAdministradorAsync()
    {
        return _administradorRepositorio.GetAdministradorAsync();
    }

    public Task<Administrador> PutAdministradorAsync(Administrador administrador)
    {
        return _administradorRepositorio.PutAdministradorAsync(administrador);
    }
    public Task<Administrador> DeleteAdministradorAsync(int id)
    {
        return _administradorRepositorio.DeleteAdministradorAsync(id);
    }
}