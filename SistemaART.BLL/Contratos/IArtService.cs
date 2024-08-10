using SistemaART.BLL.DTO;

namespace SistemaART.BLL.Contratos;

public interface IArtService
{
    Task<IEnumerable<ArtDto>> ListarTodos();
    Task <IEnumerable<TremDto>> ListarTodosAgrupados();
}
