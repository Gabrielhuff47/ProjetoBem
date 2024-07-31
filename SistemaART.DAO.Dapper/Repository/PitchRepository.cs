// using System.Data;
// using SistemaART.DAO.Dapper.BaseRepository;
// using SistemaART.DAO.Dapper.Models;
// using SistemaART.DAO.Dapper.Repository.Contratos;

// namespace SistemaART.DAO.Dapper.Repository;

// public class PitchRepository : BaseRepository<PitchModel>, IPitchRepository
// {
//     public PitchRepository(IDbConnection connection) : base(connection)
//     {
//     }


//     public Task<IEnumerable<PitchModel>> ListarPitch()
//     {
//         const string selectQuery = @"SELECT 
//                                     B.[NOME] AS NOME_PITCH, 
//                                     B.DESCRICAO AS PITCH_DESCRICAO, 
//                                     C.NOME AS NOME_TIME, 
//                                     B.SITUACAO AS SITUACAO_PITCH,
//                                     A. ID_EPICO,
//                                     A.NOME AS NOME_EPICO,  
//                                     A.DATA_INICIO, A.DATA_FIM, 
//                                     A.ID_SITUACAO,  A.USUARIO_ATUALIZACAO, 
//                                     A.DATA_ATUALIZACAO
//                                     FROM [dbo].[EPICO] A
//                                     INNER JOIN [dbo].[PITCH] B ON A.ID_PITCH  = B.ID_PITCH
//                                     INNER JOIN [dbo].[TIME] C ON B.ID_TIME = C.ID_TIME ";
        
//         throw new NotImplementedException();
//     }

//     public Task<PitchModel> ObterPitchPeloId(int id)
//     {
//         throw new NotImplementedException();
//     }
//     public Task<int> AdicionarPitch(PitchModel pitch)      //ESSE VAI SER O MEU METODO LISTA PITCH
//     {
//                 const string selectQuery = @"SELECT 
//                                             A.[NOME] AS NOME_PITCH, 
//                                             A.DESCRICAO , 
//                                             B.NOME AS NOME_TIME, 
//                                             A.SITUACAO 
//                                             FROM PITCH A INNER JOIN [dbo].[TIME] B
//                                             ON A.ID_TIME = B.ID_TIME ";

//     }

//     public Task AtualizarPitch(PitchModel pitch)
//     {
//         throw new NotImplementedException();
//     }

//     public Task DeletarPitch(int id)
//     {
//         throw new NotImplementedException();
//     }

// }
