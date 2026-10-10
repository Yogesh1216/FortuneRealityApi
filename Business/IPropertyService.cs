using FortuneReality.Api.Models;

namespace FortuneReality.Api.Business;

public interface IPropertyService
{
    Task<IReadOnlyList<Property>> GetPublishedAsync(
        CancellationToken cancellationToken);

    Task<Property?> GetByIdAsync(
    Guid id,
    CancellationToken cancellationToken);
}