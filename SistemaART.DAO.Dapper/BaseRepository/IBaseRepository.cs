using Dapper;

namespace SistemaART.DAO.Dapper.BaseRepository;

public interface IBaseRepository<T> where T : class
{   
    Task<IEnumerable<T>> ListarArt(string selectQuery);
    Task<IEnumerable<T?>> ConsultarEpicoPorCaracteres(string nomeFiltro, string selectQuery);
    Task<T?> ConsultarEpicoPorId(int id, string selectQuery);
    Task  GravarEpico(object parameters, string insertQuery);
    Task<IEnumerable<T>> ListarEpico(string selectQuery);
    Task<IEnumerable<T>> ListarTodos(string selectQuery);
    Task<IEnumerable<T>> ListarPitchPorId(int id, string selectQuery);
    Task<IEnumerable<T>> ListarPitchPorUsuario(string usuario, string selectQuery);
    Task DeletarEpico(int id, string deleteQuery);
    Task<string> ValidarUsuario(string username, string password, string functionName);
    Task AtualizarPitchSituacao(DynamicParameters parameters, string UpdateQuery);


}
