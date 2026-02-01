using System.ComponentModel.DataAnnotations.Schema;

[Table("Cliente")]
public class Cliente
{
    public long ClienteId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Identidad { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
