using FortuneReality.Api.Models;

namespace FortuneReality.Api.DataAccess;

public interface ILeadRepository
{
    Task<Guid> CreateAsync(
        CreateLeadRequest request,
        CancellationToken cancellationToken);
}