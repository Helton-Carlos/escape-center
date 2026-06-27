using Microsoft.AspNetCore.Mvc;
using back_escape_center.Models;

namespace back_escape_center.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private static readonly List<RegisterModel> _users = new();

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterModel newUser)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (_users.Any(u => u.Email.Equals(newUser.Email, StringComparison.OrdinalIgnoreCase)))
            return Conflict(new { message = "Email já cadastrado" });

        newUser.Id = Guid.NewGuid();
        newUser.CreatedAt = DateTime.UtcNow;

        _users.Add(newUser);

        return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, new
        {
            newUser.Id,
            newUser.Email,
            newUser.CreatedAt
        });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel credentials)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = _users.FirstOrDefault(u =>
            u.Email.Equals(credentials.Email, StringComparison.OrdinalIgnoreCase) &&
            u.Password == credentials.Password);

        if (user == null)
            return Unauthorized(new { message = "Email ou senha inválidos" });

        return Ok(new
        {
            user.Id,
            user.Email,
            message = "Login realizado com sucesso"
        });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);

        if (user == null)
            return NotFound(new { message = "Usuário não encontrado" });

        return Ok(new
        {
            user.Id,
            user.Email,
            user.CreatedAt
        });
    }
}
