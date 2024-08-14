using Microsoft.IdentityModel.Tokens;
using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.EpicoTests;

public class ListarEpicoPorUsuarioTest
{
    private readonly Mock<IEpicoRepository> epicoRepositoryMock;
    private readonly EpicoService epicoService;
    public ListarEpicoPorUsuarioTest()
    {
        epicoRepositoryMock = new Mock<IEpicoRepository>();
        epicoService = new EpicoService(epicoRepositoryMock.Object);
    }


    [Fact]
    public async Task ListarEpicoUsuario_Usuario_RetornaListaEpicoReduzido()
    {
        // Arrange
     
        var usuarioAtualizacao = "SISTEMA";
        var epicos = new List<EpicoReduzidoModel>
        {
            new EpicoReduzidoModel {IdEpico = 1, NomeEpico ="Portal"},
            new EpicoReduzidoModel { IdEpico = 2, NomeEpico = "Home Banking"}
        };
        epicoRepositoryMock.Setup(repo => repo.ListarEpico(It.IsAny<string>()))
                          .ReturnsAsync((string user) => user == "" ? new List<EpicoReduzidoModel>() : epicos);

       

        // Act
        var result = await epicoService.ListarEpico(usuarioAtualizacao);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal(epicos[0].IdEpico, result.ElementAt(0).IdEpico);
        Assert.Equal(epicos[0].NomeEpico, result.ElementAt(0).NomeEpico);
        Assert.Equal(epicos[1].IdEpico, result.ElementAt(1).IdEpico);
        Assert.Equal(epicos[1].NomeEpico, result.ElementAt(1).NomeEpico);
    }

    [Fact]
    public async Task ListarEpico_UsuarioAtualizacaoNuloOuVazio_DeveLancarArgumentException()
    {
        // Arrange
        string usuarioAtualizacao = null;

        // Act
        var exessao = await Assert.ThrowsAsync<ArgumentException>(() => epicoService.ListarEpico(usuarioAtualizacao));

        //Assert 
        Assert.Equal("O usuarioAtualização não pode ser nulo ou vazio", exessao.Message);

    }
}
