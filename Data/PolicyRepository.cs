using Dapper;
using Insurance.Data.Interface;
using Insurance.ViewModels;

namespace Insurance.Data;

public class PolicyRepository : IPolicyRepository
{
    private readonly DbConnection _dbConnection;

    public PolicyRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task CreatePolicy(CreatePolicyViewModel policy)
    {
        using var connection = _dbConnection.Create();

        const string sql = """
            INSERT INTO "Policies" ("PartnerID", "PolicyNumber", "PolicyAmount")
            VALUES (@PartnerID, @PolicyNumber, @PolicyAmount);
            """;

        await connection.ExecuteAsync(sql, policy);
    }
}