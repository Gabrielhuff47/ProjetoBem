using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;

namespace Tests.RepositoryTest.EpicoTests;

public class ConsultarEpicoPorIdTest
{
    private readonly Mock<IDapperWrapper> mockDapper;
    private readonly EpicoRepository epicoRepository;
    public ConsultarEpicoPorIdTest()
    {
        mockDapper = new Mock<IDapperWrapper>();
        epicoRepository = new EpicoRepository(mockDapper.Object);
    }
    [Fact]
    public async Task ConsultarEpico_Id_RetornaEpicoModel()
    {
        // Arrange
        var epico = new EpicoModel
        {
            IdEpico = 1,
            IdPitch = 2,
            IdSituacao = 2,
            NomeEpico = "Epico",
            DataInicio = new DateTime(2024, 08, 03),
            DataFim = new DateTime(2024, 08, 10),
            Descricao = "generica",
            UsuarioAtualizacao = "GABRIEL",
            DataAtualizacao = DateTime.Now,
        };

        mockDapper.Setup(md => md.QuerySingleOrDefaultAsync<EpicoModel>(
            It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(epico);

        // Act
        var result = await epicoRepository.ConsultarEpicoPorId(1);

        // Assert
       
        Assert.Equal(epico.IdEpico, result.IdEpico);
        Assert.Equal(epico.IdPitch, result.IdPitch);
        Assert.Equal(epico.IdSituacao, result.IdSituacao);
        Assert.Equal(epico.NomeEpico, result.NomeEpico);
        Assert.Equal(epico.DataInicio, result.DataInicio);
        Assert.Equal(epico.DataFim, result.DataFim);
        Assert.Equal(epico.Descricao, result.Descricao);
        Assert.Equal(epico.UsuarioAtualizacao, result.UsuarioAtualizacao);
        Assert.Equal(epico.DataAtualizacao, result.DataAtualizacao);

    }
}

