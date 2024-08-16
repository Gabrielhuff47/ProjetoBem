using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;

namespace Tests.EpicoTests;

public class EpicoRepositoryTests
{
    private readonly Mock<IDapperWrapper> epicoDapperMock;
    private readonly EpicoRepository epicoRepository;

    public EpicoRepositoryTests()
    {
        epicoDapperMock = new Mock<IDapperWrapper>();
        epicoRepository = new EpicoRepository(epicoDapperMock.Object);
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

        epicoDapperMock.Setup(md => md.QuerySingleOrDefaultAsync<EpicoModel>(
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
        epicoDapperMock.Setup(md => md.QueryAsync<EpicoReduzidoModel>
        (It.IsAny<string>(), It.IsAny<object>()))
        .ReturnsAsync(epicos); 

        //Act 
        var result = await epicoRepository.ListarEpico(usuarioAtualizacao);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Portal", result.First().NomeEpico);
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
            epicoDapperMock.Setup(md => md.QueryAsync<EpicoModel>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(epicos.Where(e => e.NomeEpico.Contains(nomeFiltro)).ToList());

        //Act
        var result = await epicoRepository.ConsultarEpicoPorCaracteres(nomeFiltro);

        //Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

     [Fact]

    public async Task GravarEpico_Epico_EpicoGravado()
    {
        //Arrange
        var epico = new EpicoModel 
        {
            DataInicio = DateTime.Now,
            IdSituacao = 1,
            IdPitch = 1,
            NomeEpico = "Novo Epico",
            UsuarioAtualizacao = "SISTEMA",
            DataAtualizacao = DateTime.Now
        };

        //Act
        await epicoRepository.GravarEpico(epico);

        //Assert
        epicoDapperMock.Verify(md => md.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once());
    }

     [Fact]
    public async Task Deletar_IdEpico()
    {
        //Arrange
        var IdEpico = 1;
        var epico = new EpicoModel 
        {
            IdEpico = 1,
            DataInicio = DateTime.Now,
            IdSituacao = 1,
            IdPitch = 1,
            NomeEpico = "Novo Epico",
            UsuarioAtualizacao = "SISTEMA",
            DataAtualizacao = DateTime.Now
        };

        //Act
        await epicoRepository.DeletarEpico(IdEpico);

        //Assert
       
        epicoDapperMock.Verify(md => md.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once());
    }


}
