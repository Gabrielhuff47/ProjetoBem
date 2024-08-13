using Moq;
using SistemaART.BLL;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.EpicoTests;

public class GravarEpicoTest
{
    private readonly Mock<IEpicoRepository> epicoRepositoryMock;
    private readonly EpicoService epicoService;
    public GravarEpicoTest()
    {
        var epicoRepositoryMock = new Mock<IEpicoRepository>();
        var epicoService = new EpicoService(epicoRepositoryMock.Object);
    }

    [Fact]
    public async Task GravarEpico_DataFimMenorQueDataInicio_DeveLancarArgumentException()
    {
        // Arrange
        var epico = new EpicoGravarDto
        {
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now.AddDays(-1),
            IdSituacao = 1,
            IdPitch = 1
        };

        // Act 
        var exessao = await Assert.ThrowsAsync<ArgumentException>(() => epicoService.GravarEpico(epico));

        // Assert
        Assert.Equal("A data fim não pode ser menor que a data de início.", exessao.Message);
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