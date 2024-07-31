using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.Contratos;

public interface ITokenService
{
    string GenerateToken(Autenticacao usuario);
}
