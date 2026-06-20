


public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<DetallePedido> DetallesPedidos { get; set; }

    
}