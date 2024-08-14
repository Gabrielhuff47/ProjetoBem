using System.Data;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.DAO.Dapper.BaseRepository;

public interface IDapperWrapper
{
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
    Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null);
    Task<int> ExecuteAsync(string sql, object param = null);
     IDbConnection GetDbConnection();
     Task<T> QueryFirstOrDefaultAsync<T> (string sql, object param = null);
    //Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, CommandType? commandType = null);
}
