using back_escape_center.Data;
using back_escape_center.Models;
using Microsoft.EntityFrameworkCore;

namespace back_escape_center.Routes;

public static class ServiceRoutes
{
    public static void MapServiceRoutes(this WebApplication app)
    {
        app.MapGet("/api/service", async (AppDbContext db) =>
            Results.Ok(await db.Services.ToListAsync()));

        app.MapGet("/api/service/{id}", async (Guid id, AppDbContext db) =>
        {
            var service = await db.Services.FindAsync(id);
            if (service == null)
                return Results.NotFound(new { message = "Service not found." });

            return Results.Ok(service);
        });

        app.MapPost("/api/service", async (ServiceModel newService, AppDbContext db) =>
        {
            newService.Id = Guid.NewGuid();
            newService.CreatedAt = DateTime.UtcNow;

            db.Services.Add(newService);
            await db.SaveChangesAsync();

            return Results.Created($"/api/service/{newService.Id}", newService);
        });

        app.MapPut("/api/service/{id}", async (Guid id, ServiceModel updatedService, AppDbContext db) =>
        {
            var existing = await db.Services.FindAsync(id);
            if (existing == null)
                return Results.NotFound(new { message = "Service not found." });

            existing.ClientId = updatedService.ClientId;
            existing.TypeService = updatedService.TypeService;
            existing.Budget = updatedService.Budget;
            existing.Status = updatedService.Status;
            existing.GetCar = updatedService.GetCar;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        app.MapDelete("/api/service/{id}", async (Guid id, AppDbContext db) =>
        {
            var service = await db.Services.FindAsync(id);
            if (service == null)
                return Results.NotFound(new { message = "Service not found." });

            db.Services.Remove(service);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
