using SistemaART.BLL.DTO;

namespace SistemaART.BLL.Contratos;

public interface IEpicoService
{
    Task<IEnumerable<EpicoReduzidoDto>> ListarEpico(string usuarioAtualizacao);
    Task  GravarEpico(EpicoGravarDto epico);
    Task <EpicoDto?> ConsultarEpicoPorId(int id);
    Task<IEnumerable<EpicoDto?>> ConsultarEpicoPorCaracteres(string nomeFiltro);
    Task DeletarEpico(int id);
}
