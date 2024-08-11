using System.Data;
using Dapper;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.DAO.Dapper.Repository;

public class PitchRepository : BaseRepository<PitchModel>, IPitchRepository
{   
    private readonly IDbConnection _connection;
    public PitchRepository(IDbConnection connection) : base(connection)
    {
        _connection = connection;
    }


    public async Task<IEnumerable<PitchReduzidoModel>> ListarPitchPorUsuario(string usuario)
    {
        const string selectQuery = @"SELECT 
                                        B.ID_PITCH AS IdPitch, 
                                        B.NOME AS NomePitch, 
                                        B.USUARIO_ATUALIZACAO AS UsuarioAtualizacao                                        
                                    FROM SITUACAO A
                                    INNER JOIN PITCH B ON B.SITUACAO = A.ID_SITUACAO 
                                    INNER JOIN [TIME] C ON B.ID_TIME = C.ID_TIME
                                    WHERE B.USUARIO_ATUALIZACAO =  @Usuario";
        
        var parameters = new { Usuario = usuario };
        var pitchResultado = await _connection.QueryAsync<PitchReduzidoModel>(selectQuery, parameters);
        return pitchResultado;
    }
        public async Task<PitchModel> ListarPitchPorId(int id)
    {
        const string selectQuery = @"SELECT 
                                        B.ID_PITCH AS IdPitch, 
                                        C.ID_TIME AS IdTime,
                                        B.NOME AS NomePitch, 
                                        C.NOME AS NomeTime, 
                                        B.DESCRICAO AS Descricao, 
                                        B.DATA_COMITE AS DataComite,
                                        B.SITUACAO AS Situacao, 
                                        A.DESCRICAO AS SituacaoDescricao, 
                                        A.PERMITE_ANDAMENTO AS SituacaoAndamento, 
                                        B.USUARIO_ATUALIZACAO AS UsuarioAtualizacao, 
                                        B.DATA_ATUALIZACAO AS DataAtualizacao  
                                    FROM SITUACAO A
                                    INNER JOIN PITCH B ON B.SITUACAO = A.ID_SITUACAO 
                                    INNER JOIN [TIME] C ON B.ID_TIME = C.ID_TIME
                                    WHERE B.ID_PITCH =  @PitchId";
        
        var parameters = new { PitchId = id };
        var pitchResultado = await _connection.QuerySingleOrDefaultAsync<PitchModel>(selectQuery, parameters);
        return pitchResultado;
    }

    public async Task<IEnumerable<PitchModel>> ListarTodos()
    {
        const string selectQuery = @"SELECT 
                                        B.ID_PITCH AS IdPitch, 
                                        C.ID_TIME AS IdTime,
                                        B.NOME AS NomePitch, 
                                        C.NOME AS NomeTime, 
                                        B.DESCRICAO AS Descricao, 
                                        B.DATA_COMITE AS DataComite,
                                        B.SITUACAO AS Situacao, 
                                        A.DESCRICAO AS SituacaoDescricao, 
                                        A.PERMITE_ANDAMENTO AS SituacaoAndamento, 
                                        B.USUARIO_ATUALIZACAO AS UsuarioAtualizacao, 
                                        B.DATA_ATUALIZACAO AS DataAtualizacao  
                                    FROM SITUACAO A
                                    INNER JOIN PITCH B ON B.SITUACAO = A.ID_SITUACAO 
                                    INNER JOIN [TIME] C ON B.ID_TIME = C.ID_TIME
                                    ";
        return await ListarTodos(selectQuery);
    }

}
