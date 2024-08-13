using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.EpicoTests;

public class ConsultarEpicoPorIdTest
{
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
            DataInicio = new DateTime(2024, 08,03),
            DataFim = new DateTime(2024,08, 10),
            UsuarioAtualizacao = "sistema",
            DataAtualizacao = DateTime.Now,
        };

        mockRepository.Setup(repo => repo.ConsultarEpicoPorId(1))
        .ReturnsAsync(epico);

        var epicoService = new EpicoService(mockRepository.Object);

        //Act 
        var result = await epicoService.ConsultarEpicoPorId(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(epico.IdEpico, result.IdEpico);
        Assert.Equal(epico.IdPitch, result.IdPitch);
        Assert.Equal(epico.IdSituacao, result.IdSituacao);
        Assert.Equal(epico.NomeEpico, result.NomeEpico);
        Assert.Equal(epico.DataInicio, result.DataInicio);
        Assert.Equal(epico.DataFim, result.DataFim);
        Assert.Equal(epico.UsuarioAtualizacao, result.UsuarioAtualizacao);
        Assert.Equal(epico.DataAtualizacao, result.DataAtualizacao);
    }
}
