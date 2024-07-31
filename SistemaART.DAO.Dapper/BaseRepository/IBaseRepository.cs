using Dapper;

namespace SistemaART.DAO.Dapper.BaseRepository;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> ListarTodos(string selectQuery);
    Task<T?> ObterPorId(int id, string selectQuery);
    Task Adicionar(DynamicParameters parameters, string selectQuery);
    Task AdicionarEmMultiplos(IEnumerable<T>TListEntity, string insertQuery);
    Task Atualizar(DynamicParameters parameters, string UpdateQuery);
    Task Deletar(int id, string deleteQuery);
    Task<string> ValidarUsuario(string username, string password, string functionName);

}
