using System.Data;
using Dapper;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.DAO.Dapper.Repository;

public class AutenticacaoRepository : BaseRepository<AutenticacaoModel>, IAutenticacaoRepository
{
    private readonly IDapperWrapper _dapper;
    public AutenticacaoRepository(IDapperWrapper dapper) : base(dapper.GetDbConnection())
    {
        _dapper = dapper;
    }

    public async Task<string> ValidarUsuario(string usuario, string senha)
    {
        const string selectQuery = @"SELECT dbo.F_USUARIO_VALIDA_LOGIN(@Usuario, @Senha)";
         var parameters = new DynamicParameters();
         parameters.Add("@Usuario", usuario);
         parameters.Add("@Senha", senha);

         var resultado = await _dapper.QueryFirstOrDefaultAsync<string>(selectQuery, parameters);
         return resultado;
    }

}
