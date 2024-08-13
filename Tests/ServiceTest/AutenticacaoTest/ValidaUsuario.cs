using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.AutenticacaoTest;

public class ValidaUsuario
{
    [Fact]
    public async void ValidarAunteticao_Usuario_RetornaMensagemSucesso()
    {
        // Arrange
        var mockRepository = new Mock<IAutenticacaoRepository>();
        var usuario = "sistema";
        var senha = "senha_s";
        mockRepository.Setup(repo => repo.ValidarUsuario(usuario, senha)).ReturnsAsync("Usuario logou");
        var autenticacaoService = new AutenticacaoService(mockRepository.Object);
        
        // Act
        var result = await autenticacaoService.ValidarUsuario(usuario, senha);
        // Assert
        Assert.Equal("Usuario logou", result);

    }
}
