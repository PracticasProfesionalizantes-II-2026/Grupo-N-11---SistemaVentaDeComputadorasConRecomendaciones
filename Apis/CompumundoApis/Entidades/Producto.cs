


public class Producto
{
    public int id { get; set; }
    public string Nombre { get; set; }
    public float Precio { get; set; }
    public int Stock { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Especificaciones { get; set; }
    public int idDetallePedido { get; set; }
    public int idProveedor { get; set; }
    public int IdAdministrador { get; set; }
}