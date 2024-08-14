using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;

namespace Tests.RepositoryTest.ArtTest;

public class ListarArtTest
{
    private readonly Mock<IDapperWrapper> mockDapper;
    private readonly ArtRepository artRepository;
    public ListarArtTest()
    {
        mockDapper = new Mock<IDapperWrapper>();
        artRepository = new ArtRepository(mockDapper.Object);
    }

    [Fact]
    public async Task ListarArt_Retorna()
    {
        //Arrange
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
            } ,
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
        
        mockDapper.Setup(md => md.QueryAsync<ArtModel>(It.IsAny<string>(), It.IsAny<object>())).
        ReturnsAsync(artList);

        //Act
        var result = await artRepository.ListarTodos();

        //Assert
        Assert.NotNull(result);
        Assert.Equal("MASTER OF BUGS", result.First().NomeTime);
        Assert.Equal("CONTRATACAO", result.First().NomeTribo);
        Assert.Equal("SISTEMAS", result.First().NomeArea);
  
    }

}
