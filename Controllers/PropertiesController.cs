using FortuneReality.Api.Business;
using Microsoft.AspNetCore.Mvc;

namespace FortuneReality.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PropertiesController(
    IPropertyService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPublished(
        CancellationToken cancellationToken)
    {
        var properties =
            await service.GetPublishedAsync(cancellationToken);

        return Ok(properties);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
    Guid id,
    CancellationToken cancellationToken)
    {
        var property =
            await service.GetByIdAsync(id, cancellationToken);

        if (property is null)
        {
            return NotFound(new { message = "Property not found." });
        }

        return Ok(property);
    }
}