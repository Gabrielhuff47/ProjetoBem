using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using Dapper;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.DAO.Dapper.Repository;

public class EpicoRepository : BaseRepository<EpicoModel>, IEpicoRepository
{
    private readonly IDbConnection _connection;
    public EpicoRepository(IDbConnection connection) : base(connection)
    {
        _connection = connection;
    }


    public async Task<IEnumerable<EpicoModel>> ListarEpico(string usuario)
    {
        const string selectQuery = @"SELECT 
										A.ID_EPICO AS IdEpico,
										TRIM(A.NOME) AS NomeEpico,
                                        A.USUARIO_ATUALIZACAO AS usuarioAtualizacao
										FROM EPICO A
										INNER JOIN SITUACAO B ON B.ID_SITUACAO = A.ID_SITUACAO
                                        WHERE A.USUARIO_ATUALIZACAO =@Usuario
                                        ORDER BY NomeEpico";

        var parameters = new { Usuario = usuario};
        var epicoResultado = await _connection.QueryAsync<EpicoModel>(selectQuery, parameters);
        return epicoResultado;

    }
     public async Task<EpicoModel?> ObterEpicoPorPitchId(int idPitch)
    {
        const string query = "SELECT ID_PITCH FROM EPICO WHERE ID_PITCH = @idPitch";
         return await _connection.QueryFirstOrDefaultAsync<EpicoModel>(query, new { IdPitch = idPitch });
    }

    public async Task GravarEpico(EpicoModel epico)
    {
        const string insertQuery = @" INSERT INTO EPICO(ID_PITCH, ID_SITUACAO, NOME, DATA_INICIO, DATA_FIM, USUARIO_ATUALIZACAO, DATA_ATUALIZACAO)
                                        VALUES (@IdPitch, @IdSituacao, @Nome, @DataInicio, @DataFim, @UsuarioAtualizacao, @DataAtualizacao)";
                                   
    var parameters = new DynamicParameters();
    parameters.Add("@IdPitch", epico.IdPitch);
    parameters.Add("@IdSituacao", epico.IdSituacao);
    parameters.Add("@Nome", new DbString { Value = epico.NomeEpico, IsFixedLength = true, Length = 100, IsAnsi = true });
    parameters.Add("@DataInicio", epico.DataInicio.HasValue ? epico.DataInicio.Value : (object)null);
    parameters.Add("@DataFim", epico.DataFim.HasValue ? epico.DataFim.Value : (object)null);
    parameters.Add("@UsuarioAtualizacao", epico.UsuarioAtualizacao);
    parameters.Add("@DataAtualizacao", epico.DataAtualizacao);

    await GravarEpico(parameters, insertQuery);
    }
    
    public async Task<EpicoModel?> ConsultarEpicoPorId(int id)
    {
        const string selectQuery = @"SELECT 
										A.ID_EPICO AS IdEpico,
                                        A.ID_PITCH AS IdPitch,
										A.NOME AS NomeEpico,
										A.DATA_INICIO AS DataInicio,
										A.DATA_FIM AS DataFim,
										A.ID_SITUACAO AS IdSituacao,
										B.DESCRICAO As Descricao, 
										TRIM(A.USUARIO_ATUALIZACAO) AS UsuarioAtualizacao,
										A.DATA_ATUALIZACAO AS DataAtualizacao
										FROM EPICO A
										INNER JOIN SITUACAO B ON B.ID_SITUACAO = A.ID_SITUACAO
										WHERE A.ID_EPICO = @Id";
        return await ConsultarEpicoPorId(id, selectQuery);
    }

    public async Task<IEnumerable<EpicoModel?>> ConsultarEpicoPorCaracteres(string nomeFiltro)
    {
       const string selectQuery = @"
       SELECT 
										A.ID_EPICO AS IdEpico,
                                        A.ID_PITCH AS IdPitch,
										A.NOME AS NomeEpico,
										A.DATA_INICIO AS DataInicio,
										A.DATA_FIM AS DataFim,
										A.ID_SITUACAO AS IdSituacao,
										B.DESCRICAO As Descricao, 
										A.USUARIO_ATUALIZACAO AS UsuarioAtualizacao,
										A.DATA_ATUALIZACAO AS DataAtualizacao
										FROM EPICO A
										INNER JOIN SITUACAO B ON B.ID_SITUACAO = A.ID_SITUACAO
										WHERE A.NOME LIKE @NomeFiltro";
    
     var resultado = await _connection.QueryAsync<EpicoModel>(selectQuery, new { nomeFiltro = $"%{nomeFiltro}%" });
     return resultado;
}

    public async Task DeletarEpico (int id)
    {
        const string deleteQuery =@"DELETE FROM EPICO WHERE ID_EPICO = @Id";
        await DeletarEpico(id, deleteQuery);
    }
}
