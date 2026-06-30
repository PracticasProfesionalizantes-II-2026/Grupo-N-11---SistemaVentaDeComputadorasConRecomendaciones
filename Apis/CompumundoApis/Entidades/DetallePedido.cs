
namespace CompumundoApis.Entidades;

public class DetallePedido
{
    public int DetallePedidoId { get; set; }
    public int IdProducto { get; set; }
    public Decimal PrecioTotal { get; set; }
    public List<Producto> Productos { get; set; }
    
}