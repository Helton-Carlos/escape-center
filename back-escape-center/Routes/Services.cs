using back_escape_center.Models;

namespace back_escape_center.Routes;

public static class ServiceRoutes
{
    public static void MapServiceRoutes(this WebApplication app)
    {
        var services = new List<ServiceModel>();

        app.MapGet("/api/service", () => Results.Ok(services));

        app.MapGet("/api/service/{id}", (Guid id) =>
        {
            var service = services.FirstOrDefault(s => s.Id == id);
            if (service == null)
                return Results.NotFound(new { message = "Service not found." });

            return Results.Ok(service);
        });

        app.MapPost("/api/service", (ServiceModel newService) =>
        {
            newService.Id = Guid.NewGuid();
            newService.CreatedAt = DateTime.UtcNow;
            services.Add(newService);

            return Results.Created($"/api/service/{newService.Id}", newService);
        });

        app.MapPut("/api/service/{id}", (Guid id, ServiceModel updatedService) =>
        {
            var existing = services.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return Results.NotFound(new { message = "Service not found." });

            existing.ClientId = updatedService.ClientId;
            existing.TypeService = updatedService.TypeService;
            existing.Budget = updatedService.Budget;
            existing.Status = updatedService.Status;
            existing.GetCar = updatedService.GetCar;

            return Results.NoContent();
        });

        app.MapDelete("/api/service/{id}", (Guid id) =>
        {
            var service = services.FirstOrDefault(s => s.Id == id);
            if (service == null)
                return Results.NotFound(new { message = "Service not found." });

            services.Remove(service);
            return Results.NoContent();
        });
    }
}
