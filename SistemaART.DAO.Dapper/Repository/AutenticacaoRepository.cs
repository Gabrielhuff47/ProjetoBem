using System.Data;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.DAO.Dapper.Repository;

public class AutenticacaoRepository : BaseRepository<Autenticacao>, IAutenticacaoRepository
{
    public AutenticacaoRepository(IDbConnection connection) : base(connection)
    {
    }

    public async Task<string> ValidarUsuario(string usuario, string senha)
    {
         return await base.ValidarUsuario(usuario, senha, "F_USUARIO_VALIDA_LOGIN");
    }

}
