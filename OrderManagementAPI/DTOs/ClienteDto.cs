namespace OrderManagementAPI.DTOs;

public class ClienteDto
{
    public long ClienteId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Identidad { get; set; } = string.Empty;
}
