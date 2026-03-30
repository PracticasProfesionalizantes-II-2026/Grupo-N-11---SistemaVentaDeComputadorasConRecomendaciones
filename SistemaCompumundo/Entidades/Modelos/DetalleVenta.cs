using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        public decimal preciototal { get; set; }

        public int idProducto { get; set; }

        //Referencia Cardinalidades 1-N

        public virtual ICollection<Componente> Componentes { get; set; } = new List<Componente>();

        //Referencia Cardinalidades 1-N

        public virtual ICollection<PcArmada> PcArmada { get; set; } = new List<PcArmada>();


        // referencia class pedido

        public int id_pedido { get; set; }

        public Pedido Pedido { get; set; }
    }



}
