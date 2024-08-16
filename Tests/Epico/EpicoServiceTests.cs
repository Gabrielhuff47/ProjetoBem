using Moq;
using SistemaART.BLL;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.Epico;

public class EpicoServiceTests
{
    private readonly Mock<IEpicoRepository> epicoRepositoryMock;
    private readonly EpicoService epicoService;
    public EpicoServiceTests()
    {
        epicoRepositoryMock = new Mock<IEpicoRepository>();
        epicoService = new EpicoService(epicoRepositoryMock.Object);
    }

    [Fact]
    public async Task ConsultarEpico_Id_RetornaEpicoModel()
    {
        //Arrange
        var mockRepository = new Mock<IEpicoRepository>();
        var epico = new EpicoModel
        {
            IdEpico = 1,
            IdPitch = 2,
            IdSituacao = 2,
            NomeEpico = "Epico",
            DataInicio = new DateTime(2024, 08, 03),
            DataFim = new DateTime(2024, 08, 10),
            UsuarioAtualizacao = "sistema",
            DataAtualizacao = DateTime.Now,
        };

        mockRepository.Setup(repo => repo.ConsultarEpicoPorId(1))
        .ReturnsAsync(epico);

        var epicoService = new EpicoService(mockRepository.Object);

        //Act 
        var resultado = await epicoService.ConsultarEpicoPorId(1);

        //Assert
        Assert.NotNull(resultado);
        Assert.Equal(epico.IdEpico, resultado.IdEpico);
        Assert.Equal(epico.IdPitch, resultado.IdPitch);
        Assert.Equal(epico.IdSituacao, resultado.IdSituacao);
        Assert.Equal(epico.NomeEpico, resultado.NomeEpico);
        Assert.Equal(epico.DataInicio, resultado.DataInicio);
        Assert.Equal(epico.DataFim, resultado.DataFim);
        Assert.Equal(epico.UsuarioAtualizacao, resultado.UsuarioAtualizacao);
        Assert.Equal(epico.DataAtualizacao, resultado.DataAtualizacao);
    }

    [Fact]
    public async Task ConsultarEpicoPorCaracteres_NomeFiltro_RetornarListaDeEpicos()
    {
        // Arrange

        var nomeFiltro = "Epi";
        var usuarioAtualizacao = "GABRIEL";
        var epicos = new List<EpicoModel>
            {
                new EpicoModel
                {
                    IdEpico = 1,
                    IdPitch = 2,
                    IdSituacao = 2,
                    NomeEpico = "Epico",
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
                    NomeEpico = "Epico 2",
                    DataInicio = new DateTime(2024, 08, 05),
                    DataFim = new DateTime(2024, 08, 11),
                    UsuarioAtualizacao = "GABRIEL",
                    DataAtualizacao = DateTime.Now,
                }
            };

        var epicoRepositoryMock = new Mock<IEpicoRepository>();
        epicoRepositoryMock.Setup(repo => repo.ConsultarEpicoPorCaracteres(nomeFiltro))
                           .ReturnsAsync(epicos);

        var epicoService = new EpicoService(epicoRepositoryMock.Object);

        // Act
        var result = await epicoService.ConsultarEpicoPorCaracteres(nomeFiltro, usuarioAtualizacao);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);

        var epico = result.First();
        Assert.Equal(epicos[1].IdEpico, epico.IdEpico);
        Assert.Equal(epicos[1].IdPitch, epico.IdPitch);
        Assert.Equal(epicos[1].IdSituacao, epico.IdSituacao);
        Assert.Equal(epicos[1].NomeEpico, epico.NomeEpico);
        Assert.Equal(epicos[1].DataInicio, epico.DataInicio);
        Assert.Equal(epicos[1].DataFim, epico.DataFim);
        Assert.Equal(epicos[1].UsuarioAtualizacao, epico.UsuarioAtualizacao);
        Assert.Equal(epicos[1].DataAtualizacao, epico.DataAtualizacao);

        epicoRepositoryMock.Verify(repo => repo.ConsultarEpicoPorCaracteres(nomeFiltro), Times.Once);
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
        epicoRepositoryMock.Setup(ep => ep.ListarEpico(It.IsAny<string>()))
                          .ReturnsAsync((string usuario) => usuario == usuarioAtualizacao ? epicos : new List<EpicoReduzidoModel>());

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
        var resultado = await Assert.ThrowsAsync<ArgumentException>(() => epicoService.ListarEpico(usuarioAtualizacao));

        //Assert 
        Assert.Equal("O usuarioAtualização não pode ser nulo ou vazio", resultado.Message);
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

    [Fact]
    public async Task GravarEpico_Epico_DeveGravarEpico()
    {
        // Arrange
        var epico = new EpicoGravarDto
        {
            DataInicio = DateTime.Now,
            IdSituacao = 1,
            IdPitch = 1,
            NomeEpico = "Novo Epico",
            UsuarioAtualizacao = "sistema",
            DataAtualizacao = DateTime.Now
        };

        epicoRepositoryMock.Setup(repo => repo.ObterEpicoPorPitchId(epico.IdPitch))
                           .ReturnsAsync((EpicoModel?)null);

        // Act
        await epicoService.GravarEpico(epico);

        // Assert
        epicoRepositoryMock.Verify(repo => repo.GravarEpico(It.Is<EpicoModel>(e => e.NomeEpico == epico.NomeEpico.ToUpper())));
    }
}
