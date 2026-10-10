using Dapper;
using FortuneReality.Api.Models;
using Npgsql;

namespace FortuneReality.Api.DataAccess;

public sealed class PropertyRepository(
    NpgsqlDataSource dataSource) : IPropertyRepository
{
    public async Task<IReadOnlyList<Property>> GetPublishedAsync(
        CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT
                id AS "Id",
                title AS "Title",
                description AS "Description",
                property_type AS "PropertyType",
                listing_type AS "ListingType",
                price AS "Price",
                city AS "City",
                locality AS "Locality",
                bedrooms AS "Bedrooms",
                bathrooms AS "Bathrooms",
                area_sqft AS "AreaSqft",
                status AS "Status",
                is_featured AS "IsFeatured"
            FROM properties
            WHERE status = 'Published'
            ORDER BY is_featured DESC, created_at DESC;
            """;

        await using var connection =
            await dataSource.OpenConnectionAsync(cancellationToken);

        var command = new CommandDefinition(
            sql,
            cancellationToken: cancellationToken);

        var result = await connection.QueryAsync<Property>(command);

        return result.AsList();
    }

    public async Task<Property?> GetByIdAsync(
    Guid id,
    CancellationToken cancellationToken)
    {
        const string sql = """
        SELECT
            id AS "Id",
            title AS "Title",
            description AS "Description",
            property_type AS "PropertyType",
            listing_type AS "ListingType",
            price AS "Price",
            city AS "City",
            locality AS "Locality",
            bedrooms AS "Bedrooms",
            bathrooms AS "Bathrooms",
            area_sqft AS "AreaSqft",
            status AS "Status",
            is_featured AS "IsFeatured"
        FROM properties
        WHERE id = @Id
          AND status = 'Published';
        """;

        await using var connection =
            await dataSource.OpenConnectionAsync(cancellationToken);

        return await connection.QuerySingleOrDefaultAsync<Property>(
            new CommandDefinition(
                sql,
                new { Id = id },
                cancellationToken: cancellationToken));
    }
}