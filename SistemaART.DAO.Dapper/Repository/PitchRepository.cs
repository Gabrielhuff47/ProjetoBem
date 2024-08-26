using System.Reflection.Metadata.Ecma335;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.DAO.Dapper.BaseRepository;

public class PitchRepository : BaseRepository<PitchModel>, IPitchRepository
{   
    private readonly IDapperWrapper _dapper;
    public PitchRepository(IDapperWrapper dapper) : base(dapper.GetDbConnection())
    {
        _dapper = dapper;
    }


    public async Task<IEnumerable<PitchReduzidoModel>> ListarPitchPorUsuario(string usuario)
    {
        const string selectQuery = @"SELECT 
                                        ID_PITCH AS IdPitch, 
                                        NOME AS NomePitch
                                       
                                     FROM PITCH 
                                     WHERE USUARIO_ATUALIZACAO = @Usuario";
        
        var parameters = new { Usuario = usuario };
        var pitchResultado = await _dapper.QueryAsync<PitchReduzidoModel>(selectQuery, parameters);
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
                                    WHERE B.ID_PITCH =  @IdPitch";
        
        var parameters = new { IdPitch = id };
        var pitchResultado = await _dapper.QuerySingleOrDefaultAsync<PitchModel>(selectQuery, parameters);
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

    public async Task AtualizarPitchSituacao(int idPitch, int novaSituacao)
    {
         const string updateQuery = @"UPDATE PITCH
                                      SET SITUACAO = @NovaSituacao
                                      WHERE ID_PITCH = @IdPitch";

        var parameters = new { IdPitch = idPitch, NovaSituacao = novaSituacao};
        await _dapper.ExecuteAsync(updateQuery, parameters);       
    }
    public async Task<IEnumerable<PitchMensagemModel>> ObterPitchs()
    {
              const string selectQuery = @"SELECT 
                                            A.ID_PITCH AS IdPitch,
                                            A.NOME AS NomePitch,
                                            A.ID_TIME AS IdTime,
                                            C.ID_EPICO AS IdEPICO, 
										    B.DESCRICAO,
										    A.DATA_COMITE AS DataComite,
										    A.SITUACAO AS Situacao,
                                            A.USUARIO_ATUALIZACAO AS UsuarioAtualizacao,
                                            B.MANUAL_AUTOMATICA AS ManualAutomatica,
                                            A.DATA_ATUALIZACAO AS DataAtualizacao
                                        FROM PITCH A 
                                        INNER JOIN SITUACAO B 
                                        ON B.ID_SITUACAO = A.SITUACAO
                                        LEFT JOIN EPICO C
                                        ON C.ID_PITCH = A.ID_PITCH
                                        WHERE A.DATA_COMITE IS NULL AND
                                        B.MANUAL_AUTOMATICA = 'A'";
        
         return await  _dapper.QueryAsync<PitchMensagemModel>(selectQuery);
    }
}
//funcionando