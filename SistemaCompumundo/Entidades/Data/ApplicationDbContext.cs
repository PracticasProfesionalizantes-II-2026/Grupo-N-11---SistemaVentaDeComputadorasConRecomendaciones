using Entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Modelos;

namespace Entidades.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Administrador> Administrador { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Componente> Componente { get; set; }

        public DbSet<Cuenta> Cuenta { get; set; }

        public DbSet<PcArmada> PcArmada { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Proveedor> proveedor { get; set; } 

        public DbSet<Ventas> Ventas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=Compumundo;Trusted_Connection=True;TrustServerCertificate=True"
                );
        }
        

    }
}
