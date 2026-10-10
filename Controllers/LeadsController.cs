using FortuneReality.Api.Business;
using FortuneReality.Api.DataAccess;
using FortuneReality.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FortuneReality.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class LeadsController(
    ILeadRepository leadRepository,
    IPropertyService propertyService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateLeadRequest request,
        CancellationToken cancellationToken)
    {
        if (request.PropertyId.HasValue)
        {
            var property = await propertyService.GetByIdAsync(
                request.PropertyId.Value, cancellationToken);

            if (property is null)
            {
                return BadRequest(new
                {
                    message = "The selected property is unavailable."
                });
            }
        }

        var id = await leadRepository.CreateAsync(
            request, cancellationToken);

        return Created($"/api/Leads/{id}", new
        {
            id,
            message = "Your enquiry has been submitted successfully."
        });
    }
}