using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Proveedor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string NombreEmpresa { get; set; }

        public string NumeroContacto { get; set; }

        public string Correo {  get; set; }


        //Referencia Cardinalidades 1-N
        public virtual ICollection<Componente> componentes { get; set; } = new List<Componente>();  


        public Proveedor(string Nombre, string NombreEmpresa, string NumeroContacto, string Correo)
        {
            this.Nombre = Nombre;
            this.NombreEmpresa = NombreEmpresa;
            this.NumeroContacto = NumeroContacto;
            this.Correo = Correo;
            

        }


    }
}
