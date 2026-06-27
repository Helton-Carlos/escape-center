using Microsoft.AspNetCore.Mvc;
using back_escape_center.Models;

namespace back_escape_center.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private static readonly List<ServiceModel> _services = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_services);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var service = _services.FirstOrDefault(s => s.Id == id);
        if (service == null)
        {
            return NotFound(new { message = "Service not found." });
        }
        return Ok(service);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ServiceModel newService)
    {
        newService.Id = _services.Count + 1;
        newService.CreatedAt = DateTime.UtcNow;

        _services.Add(newService);

        return CreatedAtAction(nameof(GetById), new { id = newService.Id }, newService);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ServiceModel updatedService)
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
    public IActionResult Delete(int id)
    {
        var service = _services.FirstOrDefault(s => s.Id == id);
        if (service == null)
        {
            return NotFound(new { message = "Service not found." });
        }

        _services.Remove(service);
        return NoContent();
    }
}