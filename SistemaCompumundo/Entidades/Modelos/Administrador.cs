using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Administrador
    {

        public int Id { get; set; }

        public string CodigoAdmin {  get; set; }

        public string ContraseniaAdmin { get; set; }


        // cardinalidad pedido 1-N

        public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();  

        // Cardinalidad Componente 1-N

        public virtual ICollection<Componente> Componentes { get; set; } = new List<Componente>();





        public Administrador(string CodigoAdmin, string ContraseniaAdmin)
        {
            this.CodigoAdmin = CodigoAdmin;
            this.ContraseniaAdmin = ContraseniaAdmin;

        }

    }
}
