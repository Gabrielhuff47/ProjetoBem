using SistemaART.DAO.Dapper.Models;

namespace SistemaART.DAO.Dapper.Repository.Contratos;

public interface IPitchRepository
{
  Task<IEnumerable<PitchReduzidoModel>> ListarPitchPorUsuario(string usuario);
  Task<IEnumerable<PitchModel>> ListarTodos();
  Task<PitchModel> ListarPitchPorId(int id);
  Task AtualizarPitchSituacao(int idPitch, int novaSituacao);
  Task <IEnumerable<PitchMensagemModel>> ObterPitchs();

}
