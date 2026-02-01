namespace OrderManagementAPI.DTOs;

public class OrdenDto
{
    public long OrdenId { get; set; }
    public long ClienteId { get; set; }
    public List<DetalleOrdenDto> Detalle { get; set; } = new();
}

public class DetalleOrdenDto
{
    public long ProductoId { get; set; }
    public int Cantidad { get; set; }
}
