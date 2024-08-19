using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;

namespace Tests.Autenticacao;

public class ValidaUsuarioRepositoryTest
{
    private readonly Mock<IDapperWrapper> autenticacaoDapperMock;
    private readonly AutenticacaoRepository autenticacaoRepository;

    public ValidaUsuarioRepositoryTest()
    {
        autenticacaoDapperMock = new Mock<IDapperWrapper>();
        autenticacaoRepository = new AutenticacaoRepository(autenticacaoDapperMock.Object);
    }

    [Fact]
    public async Task ValidaAutenticao_RetornaAutenticacao()
    {
        var usuario = "GABRIEL";
        var senha = "GABRIEL1";
        var mensagem = "autenticado";

        autenticacaoDapperMock.Setup(ad => ad.QueryFirstOrDefaultAsync<string>(
            It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(mensagem);

        var resultado = await autenticacaoRepository.ValidarUsuario("GABRIEL", "GABRIEL1");

       Assert.NotNull(resultado);
       Assert.Equal(mensagem, resultado);
    }
}
