namespace back_escape_center.Models;

public class ServiceModel
{
    public int Id { get; set; }
    public int Client { get; set; }
    public string Email { get; set; } = string.Empty;
    public string phone { get; set; } = string.Empty;
    public string dress { get; set; } = string.Empty;
    public DateTime DateBorn { get; set; }
    public DateTime createdAt { get; set; } = DateTime.Now;
    public DateTime getCar { get; set; }
}
