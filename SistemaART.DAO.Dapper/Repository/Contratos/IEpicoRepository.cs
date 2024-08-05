using SistemaART.DAO.Dapper.Models;

namespace SistemaART.DAO.Dapper.Repository.Contratos;

public interface IEpicoRepository
{
    Task<IEnumerable<EpicoModel>> ListarEpico();
    Task GravarEpico(EpicoModel epico);
    Task <EpicoModel?> ConsultarEpicoPorId(int id);
    Task <IEnumerable<EpicoModel?>> ConsultarEpicoPorCaracteres(string nomeFiltro);
    Task DeletarEpico(int id);
}