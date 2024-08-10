using SistemaART.DAO.Dapper.Models;

namespace SistemaART.DAO.Dapper.Repository.Contratos;

public interface IArtRepository
{
        Task <IEnumerable<ArtModel>> ListarTodos();
}
