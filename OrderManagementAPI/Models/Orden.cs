namespace OrderManagementAPI.Models;

public class Orden
{
    public long OrdenId { get; set; }
    public long ClienteId { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

    public List<DetalleOrden> Detalles { get; set; } = new();
}
