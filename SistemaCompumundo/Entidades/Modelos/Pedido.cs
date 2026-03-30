using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Pedido
    {

        public int Id { get; set; }

        public string Remitente { get; set; }

        public DateTime FechaPedido { get; set; }


        public float TotalPedido { get; set; }


        //Referencias de Cardinalidades Cliente
        public int Id_Cliente { get; set; } // Fk de la clase correspondiente

        public Cliente cliente { get; set; } // Referencia de navegacion hacia el principal

        // Referencia Cardinalidades Administrador
        public int Id_Administrador { get; set; }

        public Administrador administrador { get; set; }


       

        //Referencia Cardinalidades 1-1 

        public Ventas Ventas { get; set; }


        //referencia cardinalidad Detalleventa

        public DetalleVenta detalleventa { get; set; }


        public Pedido(string Remitente,DateTime FechaPedido,float TotalPedido)
        {

            this.Remitente = Remitente;
            this.FechaPedido = FechaPedido;
            this.TotalPedido = TotalPedido;


        }


    }
}
