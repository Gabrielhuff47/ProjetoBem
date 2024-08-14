using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.ArtTest;

public class ListarArtTest
{
    private readonly Mock<IArtRepository> artRepositoryMock;
    private readonly ArtService artService;
    public ListarArtTest()
    {
        artRepositoryMock = new Mock<IArtRepository>();
        artService = new ArtService(artRepositoryMock.Object);
    }

    [Fact]
    public async Task ListarArt_DeveRetornarListaDeTremDto()
    {
        // Arrange
        var artList = new List<ArtModel>
        {
            new ArtModel
            { 
            NomeTime = "MASTER OF BUGS",
            NomeTribo = "CONTRATACAO",
            NomeArea = "SISTEMAS",
            PitchSituacao = 2,
            EpicoSituacao = 2,
            EpicoDataInicio = new DateTime (2024, 01, 25),
            EpicoDataFim = new DateTime (2024, 02, 28), 
            Mensagem = "Em atraso" 
            },
              new ArtModel 
            { NomeTime = "MASTER OF BUGS",
             NomeTribo = "CONTRATACAO", 
             NomeArea = "SISTEMAS",
              PitchSituacao = 3,
               EpicoSituacao = 3,
                EpicoDataInicio = new DateTime (2024, 04, 25), 
                EpicoDataFim = new DateTime (2024, 04, 28),
                 Mensagem = "" },
        };
        artRepositoryMock.Setup(ar => ar.ListarTodos()).ReturnsAsync(artList);

        // Act
        var result = await artService.ListarTodosAgrupados();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Count());
        Assert.Equal("MASTER OF BUGS", result.First().NomeTime);
        Assert.Equal("CONTRATACAO", result.First().NomeTribo);
        Assert.Equal("SISTEMAS", result.First().NomeArea);
        Assert.Equal(2, result.First().Backlogs.Count);
        Assert.Equal(0, result.First().EmAndamentos.Count);
        Assert.Equal(0, result.First().Finalizados.Count);
        artRepositoryMock.Verify(repo => repo.ListarTodos(), Times.Once);
    }
}

