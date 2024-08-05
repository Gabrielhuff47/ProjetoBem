using SistemaART.DAO.Dapper.Models;

namespace SistemaART.DAO.Dapper.Repository.Contratos;

public interface IPitchRepository
{
  //  Task<IEnumerable<PitchModel>> ListarPitchPorId(int usuarioId);
    Task<IEnumerable<PitchModel>> ListarPitchPorUsuario(string usuario);
    Task<IEnumerable<PitchModel>> ListarTodos();
    Task<IEnumerable<PitchModel>> ListarPitchPorId(int id);
    // Task<int> AdicionarPitch(PitchModel pitch);
    // Task AtualizarPitch (PitchModel pitch);
    // Task DeletarPitch(int id);

}
