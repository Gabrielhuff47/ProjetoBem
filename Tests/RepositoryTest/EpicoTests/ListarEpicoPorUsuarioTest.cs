using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;

namespace Tests.RepositoryTest.EpicoTests;

public class ListarEpicoPorUsuarioTest
{
    private readonly Mock<IDapperWrapper> mockDapper;
    private readonly EpicoRepository epicoRepository;
    public ListarEpicoPorUsuarioTest()
    {
        mockDapper = new Mock<IDapperWrapper>();
        epicoRepository = new EpicoRepository(mockDapper.Object);
    }

    [Fact]
    public async Task ListarEpico_Usuario_RetornaListaEpico()
    {
        //Arrange
        var usuarioAtualizacao = "SISTEMA";
        var epicos = new List<EpicoReduzidoModel> 
        {
            new EpicoReduzidoModel { IdEpico = 1, NomeEpico = "Portal"},
            new EpicoReduzidoModel { IdEpico = 2, NomeEpico = "Home Banking"}

        };
        mockDapper.Setup(md => md.QueryAsync<EpicoReduzidoModel>
        (It.IsAny<string>(), It.IsAny<object>()))
        .ReturnsAsync(epicos); 

        //Act 
        var result = await epicoRepository.ListarEpico(usuarioAtualizacao);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Portal", result.First().NomeEpico);
    }

}
