namespace SistemaART.DAO.Dapper.Repository.Contratos;

public interface IAutenticacaoRepository
{
 Task <string> ValidarUsuario(string usuario, string senha);

}
