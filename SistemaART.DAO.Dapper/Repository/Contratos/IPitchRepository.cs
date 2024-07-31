using SistemaART.DAO.Dapper.Models;

namespace SistemaART.DAO.Dapper.Repository.Contratos;

public interface IPitchRepository
{
    Task<IEnumerable<PitchModel>> ListarPitch();
    Task<PitchModel> ObterPitchPeloId(int id);
    Task<int> AdicionarPitch(PitchModel pitch);
    Task AtualizarPitch (PitchModel pitch);
    Task DeletarPitch(int id);

}
