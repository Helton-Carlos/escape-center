using back_escape_center.Data;
using back_escape_center.Models;
using Microsoft.EntityFrameworkCore;

namespace back_escape_center.Routes;

public static class LoginRoutes
{
    public static void MapLoginRoutes(this WebApplication app)
    {
        app.MapPost("/api/login/register", async (RegisterModel newUser, AppDbContext db) =>
        {
            if (await db.Users.AnyAsync(u => u.Email.ToLower() == newUser.Email.ToLower()))
                return Results.Conflict(new { message = "Email já cadastrado" });

            newUser.Id = Guid.NewGuid();
            newUser.CreatedAt = DateTime.UtcNow;

            db.Users.Add(newUser);
            await db.SaveChangesAsync();

            return Results.Created($"/api/login/{newUser.Id}", new
            {
                newUser.Id,
                newUser.Email,
                newUser.CreatedAt
            });
        });

        app.MapPost("/api/login", async (LoginModel credentials, AppDbContext db) =>
        {
            var user = await db.Users.FirstOrDefaultAsync(u =>
                u.Email.ToLower() == credentials.Email.ToLower() &&
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

        app.MapGet("/api/login/{id}", async (Guid id, AppDbContext db) =>
        {
            var user = await db.Users.FindAsync(id);

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
