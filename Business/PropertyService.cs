using FortuneReality.Api.DataAccess;
using FortuneReality.Api.Models;

namespace FortuneReality.Api.Business;

public sealed class PropertyService(
    IPropertyRepository repository) : IPropertyService
{
    public Task<IReadOnlyList<Property>> GetPublishedAsync(
        CancellationToken cancellationToken)
    {
        return repository.GetPublishedAsync(cancellationToken);
    }

    public Task<Property?> GetByIdAsync(
    Guid id,
    CancellationToken cancellationToken)
    {
        return repository.GetByIdAsync(id, cancellationToken);
    }
}