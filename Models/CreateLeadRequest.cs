using System.ComponentModel.DataAnnotations;

namespace FortuneReality.Api.Models;

public sealed class CreateLeadRequest
{
    public Guid? PropertyId { get; init; }

    [Required, StringLength(150, MinimumLength = 2)]
    public string Name { get; init; } = string.Empty;

    [Required, Phone, StringLength(20)]
    public string Phone { get; init; } = string.Empty;

    [EmailAddress, StringLength(255)]
    public string? Email { get; init; }

    [StringLength(2000)]
    public string? Message { get; init; }
}