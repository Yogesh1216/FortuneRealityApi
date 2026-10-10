using FortuneReality.Api.Models;

namespace FortuneReality.Api.DataAccess;

public interface IPropertyRepository
{
    Task<IReadOnlyList<Property>> GetPublishedAsync(CancellationToken cancellationToken);
    Task<Property?> GetByIdAsync(
    Guid id,
    CancellationToken cancellationToken);
}