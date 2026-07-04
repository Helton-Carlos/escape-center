namespace back_escape_center.Models;

public class ClientModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateBorn { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
