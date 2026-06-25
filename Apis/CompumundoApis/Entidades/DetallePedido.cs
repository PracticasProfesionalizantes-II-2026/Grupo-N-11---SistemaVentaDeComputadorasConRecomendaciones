
namespace CompumundoApis.Entidades;

public class DetallePedido
{
    public int IdDetallePedido { get; set; }
    public int IdProducto { get; set; }
    public Decimal PrecioTotal { get; set; }
    public List<Producto> Productos { get; set; }
    
}