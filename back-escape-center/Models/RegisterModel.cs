using System.ComponentModel.DataAnnotations;

namespace back_escape_center.Models;

public class RegisterModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha é obrigatória")]
    [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres")]
    public string Password { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}
