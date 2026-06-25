using Microsoft.EntityFrameworkCore;
using CompumundoApis.Entidades;

namespace CompumundoApis.Datos;
public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Administrador> Administradores { get; set; }
    public DbSet<DetallePedido> DetallesPedidos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Ventas> Ventas { get; set; }
    public DbSet<PcArmada> PcArmadas { get; set; }
    public DbSet<CuentaCliente> CuentaClientes { get; set; }
}