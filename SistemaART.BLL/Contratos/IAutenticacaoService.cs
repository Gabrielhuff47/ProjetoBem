namespace SistemaART.BLL.Contratos;

    public interface IAutenticacaoService
    {
        Task<string> ValidarUsuario(string usuario, string senha);
    }
