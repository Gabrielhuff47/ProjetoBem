using SistemaART.BLL.DTO;

namespace SistemaART.BLL.Contratos;

public interface IEpicoService
{
    Task<IEnumerable<EpicoDto>> ListarEpico();
    Task  GravarEpico(EpicoDto epico);
    Task <EpicoDto?> ConsultarEpicoPorId(int id);
    Task<IEnumerable<EpicoDto?>> ConsultarEpicoPorCaracteres(string nomeFiltro);
    Task DeletarEpico(int id);
}
