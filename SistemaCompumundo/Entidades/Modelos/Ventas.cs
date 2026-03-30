using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Ventas
    {
        public int Id { get; set; }

        public string ProductoVendido { get; set; }

        public string ClienteComprador { get; set; }

        public DateTime FechaVenta { get; set; }


        //Referencia cardinalidades Pedido

        public int Id_pedido { get; set; }

        public Pedido Pedido { get; set; }



        public Ventas(int id,string productoVendido, string clienteComprador, DateTime fechaVenta)
        {
            this.Id = id;
            this.ProductoVendido = ProductoVendido;
            this.ClienteComprador = clienteComprador;
            this.FechaVenta = fechaVenta;
        }
    }
}
