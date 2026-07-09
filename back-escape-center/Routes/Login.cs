using back_escape_center.Models;

namespace back_escape_center.Routes;

public static class LoginRoutes
{
    public static void MapLoginRoutes(this WebApplication app)
    {
        var users = new List<RegisterModel>();

        app.MapPost("/api/login/register", (RegisterModel newUser) =>
        {
            if (users.Any(u => u.Email.Equals(newUser.Email, StringComparison.OrdinalIgnoreCase)))
                return Results.Conflict(new { message = "Email já cadastrado" });

            newUser.Id = Guid.NewGuid();
            newUser.CreatedAt = DateTime.UtcNow;
            users.Add(newUser);

            return Results.Created($"/api/login/{newUser.Id}", new
            {
                newUser.Id,
                newUser.Email,
                newUser.CreatedAt
            });
        });

        app.MapPost("/api/login", (LoginModel credentials) =>
        {
            var user = users.FirstOrDefault(u =>
                u.Email.Equals(credentials.Email, StringComparison.OrdinalIgnoreCase) &&
                u.Password == credentials.Password);

            if (user == null)
                return Results.Json(new { message = "Email ou senha inválidos" }, statusCode: 401);

            return Results.Ok(new
            {
                user.Id,
                user.Email,
                message = "Login realizado com sucesso"
            });
        });

        app.MapGet("/api/login/{id}", (Guid id) =>
        {
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return Results.NotFound(new { message = "Usuário não encontrado" });

            return Results.Ok(new
            {
                user.Id,
                user.Email,
                user.CreatedAt
            });
        });
    }
}
