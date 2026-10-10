using Dapper;
using FortuneReality.Api.Models;
using Npgsql;

namespace FortuneReality.Api.DataAccess;

public sealed class LeadRepository(
    NpgsqlDataSource dataSource) : ILeadRepository
{
    public async Task<Guid> CreateAsync(
        CreateLeadRequest request,
        CancellationToken cancellationToken)
    {
        const string sql = """
            INSERT INTO leads (
                property_id, name, phone, email, message
            )
            VALUES (
                @PropertyId, @Name, @Phone, @Email, @Message
            )
            RETURNING id;
            """;

        await using var connection =
            await dataSource.OpenConnectionAsync(cancellationToken);

        return await connection.ExecuteScalarAsync<Guid>(
            new CommandDefinition(
                sql,
                new
                {
                    request.PropertyId,
                    Name = request.Name.Trim(),
                    Phone = request.Phone.Trim(),
                    Email = request.Email?.Trim(),
                    Message = request.Message?.Trim()
                },
                cancellationToken: cancellationToken));
    }
}