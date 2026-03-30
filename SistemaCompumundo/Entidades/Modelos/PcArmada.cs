using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class PcArmada
    {

        public int Id { get; set; }   

        public string Tipo { get; set; }

        public List<string> Componentes { get; set; }

        public int Cantidad { get; set; }

        public float PrecioTotal { get; set; }



        //Referencia Cardinalidades Componente 

        public int Id_Componente { get; set; }

        public Componente Componente { get; set; }


        // Referencia Cardinalidades Pedido 

        public int Id_DetalleVenta { get; set; }

        public DetalleVenta detalleventa { get; set; }






        public PcArmada(string Tipo, List<string> Componentes, int Cantidad, float PrecioTotal)
        {

            this.Tipo = Tipo;
            this.Componentes = new List<string>();
            this.Cantidad = Cantidad;
            this.PrecioTotal = PrecioTotal;



        }





    }
}
