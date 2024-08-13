using System.Data;
using Dapper;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.DAO.Dapper.Repository;

public class DapperWrapper : IDapperWrapper
{
    private readonly IDbConnection _connection;

    public DapperWrapper(IDbConnection connection)
    {
        _connection = connection;
    }
    public IDbConnection GetDbConnection()
    {
        return _connection;
    }
    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
    {
        return await _connection.QueryAsync<T>(sql, param);
    }

    public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null)
    {
          return await _connection.QuerySingleOrDefaultAsync<T>(sql, param);
    }

    public Task<int> ExecuteAsync(string sql, object param = null)
    {
       return _connection.ExecuteAsync(sql, param);
    }

}
