namespace FortuneReality.Api.Models;

public sealed class Property
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string PropertyType { get; set; } = string.Empty;
    public string ListingType { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string City { get; set; } = string.Empty;
    public string Locality { get; set; } = string.Empty;
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public decimal AreaSqft { get; set; }
    public string Status { get; set; } = "Draft";
    public bool IsFeatured { get; set; }
}