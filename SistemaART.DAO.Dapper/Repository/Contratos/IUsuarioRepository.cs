using SistemaART.DAO.Dapper.Models;

namespace SistemaART.DAO.Dapper.Repository.Contratos;

public interface IUsuarioRepository
{
    Task<IEnumerable<UsuarioModel>> ListarUsuarios();
    Task<UsuarioModel?> RetornarUsuarioPorId(int id);
    Task AdicionarUsuario (UsuarioModel usuario);
    Task AtualizarUsuario (UsuarioModel usuario);
    Task DeletarUsuario(int id);
    Task <string> ValidarUsuario(string usuario, string senha);

}
