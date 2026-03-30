using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Componente
    {

        public int Id { get; set; }

        public string Tipo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Cantidad { get; set; }

        public float Precio { get; set; }


        // Referencias Cardinalidades Administrador

        public int Id_Admministrador { get; set; }

        public Administrador Administrador { get; set; }


        // Referencia cardinalidades Pedido 

        public int Id_DetalleVenta { get; set; }

        public DetalleVenta Detalleventa { get; set; } 


        //Referencia Cardinalidades Proveedor

        public int Id_Proveedor { get; set; }

        public Proveedor Proveedor { get; set; }
        

        //Referencia Cardinalidades 1-N

        public virtual ICollection<PcArmada> PcArmada { get; set; } = new List<PcArmada>();





        public Componente(string Tipo, string marca, string Modelo, float Precio, int Cantidad)
        {
            this.Tipo = Tipo;
            this.Marca = marca;
            this.Modelo = Modelo;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            

        }


    }
}
