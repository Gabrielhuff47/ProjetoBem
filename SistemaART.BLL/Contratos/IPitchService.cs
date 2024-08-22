using SistemaART.BLL.DTO;

namespace SistemaART.BLL.Contratos;

public interface IPitchService
{
    Task<IEnumerable<PitchReduzidoDto>> ListarPitchPorUsuario(string usuario);
    Task <PitchDto> ListarPitchPorId(int id);
    Task<IEnumerable<PitchDto>> ListarTodos();
    Task AtualizarSituacaoPitch(int idPitch, int novaSituacao);
    Task AtualizarSituacaoPitchEmSegundoPlano ();


}

