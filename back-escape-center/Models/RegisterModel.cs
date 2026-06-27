namespace back_escape_center.Models;

public class RegisterModel {
  public Guid id { get; set; }
  public string email { get; set; } = string.Empty;
  public string password { get; set; } = string.Empty;
}