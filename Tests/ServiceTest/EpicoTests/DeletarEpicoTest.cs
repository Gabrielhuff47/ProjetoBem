using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.EpicoTests;

public class DeletarEpicoTest

{
    private readonly Mock<IEpicoRepository> epicoRepositoryMock;
    private readonly EpicoService epicoService;
    public DeletarEpicoTest()
    {
        epicoRepositoryMock = new Mock<IEpicoRepository>();
        epicoService = new EpicoService(epicoRepositoryMock.Object);
    }

    [Fact]
    public async Task DeletarEpico_Id()
    {
        //Arrange 
        var epicoMockado = new EpicoModel()
        {
            IdEpico = 1,
            IdPitch = 2,
            IdSituacao = 4,
            NomeEpico = "Epico 1",
            DataInicio = new DateTime(2024, 01, 30),
            DataFim = new DateTime(2024, 02, 27),
            UsuarioAtualizacao = "SISTEMA",
            DataAtualizacao = DateTime.Now,
        };

        epicoRepositoryMock.Setup(er => er.ConsultarEpicoPorId(It.IsAny<int>())).ReturnsAsync(epicoMockado);

        //Act 
        var epico = await epicoService.ConsultarEpicoPorId(epicoMockado.IdEpico);
        await epicoService.DeletarEpico(1);

        //Assert
        Assert.NotNull(epico);
        epicoRepositoryMock.Verify(er => er.DeletarEpico(1), Times.Once());
    }

    [Fact]
    public async Task DeletarEpico_RetornaErro()
    {
        // Arrange
        var epicoMockado = new EpicoModel()
        {
            IdEpico = 1,
            IdPitch = 2,
            IdSituacao = 4,
            NomeEpico = "Epico 1",
            DataInicio = new DateTime(2024, 01, 30),
            DataFim = new DateTime(2024, 02, 27),
            UsuarioAtualizacao = "SISTEMA",
            DataAtualizacao = DateTime.Now,
        };

        epicoRepositoryMock.Setup(er => er.ConsultarEpicoPorId(It.IsAny<int>())).ReturnsAsync(epicoMockado);
        epicoRepositoryMock.Setup(er => er.DeletarEpico(0)).Throws(new ArgumentException("O Id do Epico não pode estar em branco"));

        // Act
        var epico = await epicoService.ConsultarEpicoPorId(epicoMockado.IdEpico);
        var exessao = await Assert.ThrowsAsync<ArgumentException>(() => epicoService.DeletarEpico(0));

        // Assert
        Assert.Equal("O Id do Epico não pode estar em branco", exessao.Message);
    }


}

