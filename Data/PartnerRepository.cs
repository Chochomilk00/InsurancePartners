using Dapper;
using Insurance.Data.Interface;
using Insurance.Models;
using Insurance.ViewModels;

namespace Insurance.Data;

public class PartnerRepository : IPartnerRepository
{
    private readonly DbConnection _dbConnection;

    public PartnerRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<PartnerViewModel>> GetPartners()
    {
        using var connection = _dbConnection.Create();

        const string sql = """
            SELECT p."ID", p."FirstName" || ' ' || p."LastName" AS "FullName", p."PartnerNumber", p."CroatianPIN",
                p."PartnerTypeID", p."CreatedAtUtc", p."IsForeign", p."Gender",
                CASE
                    WHEN COUNT(pol."ID") > 5
                      OR COALESCE(SUM(pol."PolicyAmount"), 0) > 5000
                    THEN TRUE
                    ELSE FALSE
                END AS "IsSpecial"
            FROM "Partners" p LEFT JOIN "Policies" pol ON pol."PartnerID" = p."ID"
            GROUP BY p."ID", p."FirstName", p."LastName", p."PartnerNumber",
                p."CroatianPIN", p."PartnerTypeID", p."CreatedAtUtc", p."IsForeign", p."Gender"
            ORDER BY p."CreatedAtUtc" DESC;
            """;

        return await connection.QueryAsync<PartnerViewModel>(sql);
    }

    public async Task<Partner?> GetPartnerByID(int ID)
    {
        using var connection = _dbConnection.Create();

        const string sql = """
            SELECT "ID", "FirstName", "LastName", "Address", "PartnerNumber", "CroatianPIN",
                "PartnerTypeID", "CreatedAtUtc", "CreatedByUser", "IsForeign", "ExternalCode", "Gender"
            FROM "Partners"
            WHERE "ID" = @ID;
            """;

        return await connection.QuerySingleOrDefaultAsync<Partner>(sql, new { ID = ID });
    }

    public async Task<int> CreatePartner(CreatePartnerViewModel partner)
    {
        using var connection = _dbConnection.Create();

        const string sql = """
        INSERT INTO "Partners" ("FirstName", "LastName", "Address", "PartnerNumber", "CroatianPIN",
            "PartnerTypeID", "CreatedByUser", "IsForeign", "ExternalCode", "Gender")
        VALUES (@FirstName, @LastName, @Address, @PartnerNumber, @CroatianPIN,
            @PartnerTypeID, @CreatedByUser, @IsForeign, @ExternalCode, @Gender)
        RETURNING "ID";
        """;

        return await connection.ExecuteScalarAsync<int>(sql, partner);
    }
}