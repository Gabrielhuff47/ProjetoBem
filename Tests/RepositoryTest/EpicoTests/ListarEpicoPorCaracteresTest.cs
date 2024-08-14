using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;

namespace Tests.RepositoryTest.EpicoTests;

public class ListarEpicoPorCaracteresTest
{
    private readonly Mock<IDapperWrapper> mockDapper;
    private readonly EpicoRepository epicoRepository;
    public ListarEpicoPorCaracteresTest()
    {
        mockDapper = new Mock<IDapperWrapper>();
        epicoRepository = new EpicoRepository(mockDapper.Object);
    }

    [Fact]
    public async Task ListarEpicoPorCaracteres_NomeFiltro_RetornaListaDeEpicos()
    {
        //Arrange 
        var nomeFiltro = "EPI";
        var epicos = new List<EpicoModel>{
            new EpicoModel
            {
                IdEpico = 1,
                IdPitch = 2,
                IdSituacao = 2,
                NomeEpico = "EPICO",
                DataInicio = new DateTime(2024, 08, 03),
                DataFim = new DateTime(2024, 08, 10),
                UsuarioAtualizacao = "SISTEMA",
                DataAtualizacao = DateTime.Now,

            },
            new EpicoModel
            {
                IdEpico = 2,
                IdPitch = 3,
                IdSituacao = 1,
                NomeEpico = "PORTAL DE NEGOCIOS",
                DataInicio = new DateTime(2024, 08, 05),
                DataFim = new DateTime(2024, 08, 11),
                UsuarioAtualizacao = "gabriel",
                DataAtualizacao = DateTime.Now,

            }
        };
            mockDapper.Setup(md => md.QueryAsync<EpicoModel>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(epicos.Where(e => e.NomeEpico.Contains(nomeFiltro)).ToList());

        //Act
        var result = await epicoRepository.ConsultarEpicoPorCaracteres(nomeFiltro);

        //Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }
}
