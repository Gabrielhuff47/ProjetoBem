using SistemaART.BLL.Contratos;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.BLL;

public class AutenticacaoService : IAutenticacaoService
{
       private readonly IAutenticacaoRepository _repository;

    public AutenticacaoService(IAutenticacaoRepository autenticacaoRepository)
    {
        _repository = autenticacaoRepository;
    }

    public async Task <string> ValidarUsuario(string usuario, string senha)
    {
       return await _repository.ValidarUsuario(usuario, senha);
    }
}
