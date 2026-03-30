namespace Entidades.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contrasenia { get; set; }


        //Referencia Cardinalidades 1-N
        public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>(); // Contiene dependencias de navegacion

        //Referencia Cardinalidades 1-1
        public Cuenta Cuenta { get; set; }


        public Cliente(string Nombre,string Correo, string Contrasenia)
        {

            this.Nombre = Nombre;
            this.Correo = Correo;
            this.Contrasenia = Contrasenia;

        }
        


    }
}
