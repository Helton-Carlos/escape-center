using back_escape_center.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_escape_center.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private static readonly List<ServiceModel> _services = [];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_services);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var service = _services.FirstOrDefault(item => item.Id == id);
        if (service == null)
        {
            return NotFound(new { message = "Service not found." });
        }
        return Ok(service);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ServiceModel newService)
    {
        newService.Id = Guid.NewGuid();
        newService.CreatedAt = DateTime.UtcNow;

        _services.Add(newService);

        return CreatedAtAction(nameof(GetById), new { id = newService.Id }, newService);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] ServiceModel updatedService)
    {
        var existingService = _services.FirstOrDefault(s => s.Id == id);
        if (existingService == null)
        {
            return NotFound(new { message = "Service not found." });
        }

        existingService.ClientId = updatedService.ClientId;
        existingService.TypeService = updatedService.TypeService;
        existingService.Budget = updatedService.Budget;
        existingService.Status = updatedService.Status;
        existingService.GetCar = updatedService.GetCar;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var service = _services.FirstOrDefault(item => item.Id == id);
        if (service == null)
        {
            return NotFound(new { message = "Service not found." });
        }

        _services.Remove(service);
        return NoContent();
    }
}