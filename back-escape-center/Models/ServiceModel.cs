using System.ComponentModel.DataAnnotations;

namespace back_escape_center.Models;

public class ServiceModel
{
    public Guid Id { get; set; }
    [Required]
    public int ClientId { get; set; }
    public ClientModel? Client { get; set; }
    [Required]
    public string TypeService { get; set; } = string.Empty;
    public string Budget { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? GetCar { get; set; } 
}