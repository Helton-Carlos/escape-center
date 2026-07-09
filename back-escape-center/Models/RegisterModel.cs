using System.ComponentModel.DataAnnotations;

namespace back_escape_center.Models;

public class RegisterModel : PersonModel
{
    [Required(ErrorMessage = "Senha é obrigatória")]
    [MinLength(6, ErrorMessage = "Senha deve ter no mínimo 6 caracteres")]
    public string Password { get; set; } = string.Empty;
}
