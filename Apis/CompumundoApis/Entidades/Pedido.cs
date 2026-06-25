
namespace CompumundoApis.Entidades;

public class Pedido
{
    public int Id { get; set; }
    public string Remitente { get; set; }
    public int ClienteId { get; set; }
    public int IdAdministrador { get; set; }
    public DateTime FechaPedido { get; set; }
    public Enum EstadoPedido { get; set; }
    public decimal Total { get; set; }
}