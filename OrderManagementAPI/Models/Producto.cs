namespace OrderManagementAPI.Models;

public class Producto
{
    public long ProductoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Existencia { get; set; }
}
