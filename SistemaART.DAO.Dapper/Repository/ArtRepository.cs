using System.Data;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.DAO.Dapper.Repository;

public class ArtRepository : BaseRepository<ArtModel>, IArtRepository
{   
    private readonly IDbConnection _connection;
    public ArtRepository(IDbConnection connection) : base(connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<ArtModel>> ListarTodos()
    {
        const string selectQuery = @"SELECT 
                                NomePitch,
                                NomeEpico,
                                NomeTime,
                                NomeTribo,
                                NomeArea,
                                PitchSituacao,
                                EpicoSituacao,
                                PitchDataAtualizacao,
                                EpicoDataAtualizacao,
                                EpicoDataInicio,
                                EpicoDataFim
                              FROM V_Art ";

        return await ListarTodos(selectQuery);
    }

}
