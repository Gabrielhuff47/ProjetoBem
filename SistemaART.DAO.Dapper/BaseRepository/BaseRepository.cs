
using System.Data;
using System.Data.Common;
using Dapper;

namespace SistemaART.DAO.Dapper.BaseRepository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly IDbConnection _connection;
    public BaseRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<IEnumerable<T>> ListarArt(string selectQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        return await dbConnection.QueryAsync<T>(selectQuery);
    }
    public async Task<IEnumerable<T?>> ConsultarEpicoPorCaracteres(string nomeFiltro, string selectQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();   
        
         return await dbConnection.QueryAsync<T>(selectQuery);
    }
    public async Task <T?> ConsultarEpicoPorId(int id, string selectQuery)
    {
        return await _connection.QueryFirstOrDefaultAsync<T?>(selectQuery, new {Id = id});
    }
    public async Task GravarEpico(object parameters, string insertQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

         await _connection.ExecuteAsync(insertQuery, parameters);
    }
    public async Task<IEnumerable<T>> ListarEpico(string selectQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

          return await dbConnection.QueryAsync<T>(selectQuery);
    }
    public async Task<IEnumerable<T>> ListarPitchPorUsuario(string usuario, string selectQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        var param = new DynamicParameters();
        param.Add("Usuario", usuario);       //Previne SQl Injection

        return await dbConnection.QueryAsync<T>(selectQuery, param);
    }

        public async Task<IEnumerable<T>> ListarPitchPorId(int id, string selectQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        var param = new DynamicParameters();
        param.Add("id", id);       //Previne SQl Injection

        return await dbConnection.QueryAsync<T>(selectQuery, param);
    }
    public async Task<string> ValidarUsuario(string usuario, string senha, string F_USUARIO_VALIDA_LOGIN)
    {
        var query = $"SELECT dbo.{F_USUARIO_VALIDA_LOGIN}(@Usuario, @Senha)";
        var parameters = new { Usuario = usuario, Senha = senha };
        return await _connection.ExecuteScalarAsync<string>(query, parameters);
    }
    public async Task<IEnumerable<T>> ListarTodos(string selectQuery)
    {
        using (IDbConnection dbConnection = _connection)
        {

            return await dbConnection.QueryAsync<T>(selectQuery);
        }
    }

    public async Task<T?> ObterPorId(int id, string selectQuery)    //T? => pode retornar um nullo
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        var param = new DynamicParameters();
        param.Add("Id", id)        //Previne SQl Injection
;
        return await dbConnection.QueryFirstOrDefaultAsync<T>(selectQuery, param);
    }

    public async Task Adicionar(DynamicParameters parameters, string insertQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        await dbConnection.ExecuteAsync(insertQuery, parameters);
    }

    public async Task AdicionarEmMultiplos(IEnumerable<T>TListEntity, string insertQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        await _connection.ExecuteAsync(insertQuery, TListEntity);
    }
    public async Task Atualizar(DynamicParameters parameters, string updateQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        await dbConnection.ExecuteAsync(updateQuery, parameters);
    }

    public async Task DeletarEpico(int id, string deleteQuery)
    {
        using IDbConnection dbConnection = _connection;
        dbConnection.Open();

        await dbConnection.ExecuteAsync(deleteQuery, new { Id = id });       //Id = id criacao de um objeto anonimo
    }



}