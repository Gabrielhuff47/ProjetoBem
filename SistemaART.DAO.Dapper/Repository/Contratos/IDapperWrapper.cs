using System.Data;

namespace SistemaART.DAO.Dapper.Repository.Contratos;

public interface IDapperWrapper
{
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
    Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null);
    Task<int> ExecuteAsync(string sql, object param = null);
     IDbConnection GetDbConnection();

}
