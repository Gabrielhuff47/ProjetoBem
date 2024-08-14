using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.WebApp.Controllers;

namespace Tests.ControllerTests.PitchTests;

public class AtualizarPitchSituacaoPorIdControllerTest
{
    private readonly Mock<IPitchService> mockPitchService;
    private readonly PitchController controller;
    public AtualizarPitchSituacaoPorIdControllerTest()
    {
        mockPitchService = new Mock<IPitchService>();
        controller = new PitchController(mockPitchService.Object);
    }

    [Fact]
    public async Task AtualizarPitchSituacao_RetornaOk()
    {
        //Arrange
        var idPitch = 1;
        var novaSituacao = 2;

        mockPitchService.Setup(mp=> mp.AtualizarSituacaoPitch(idPitch, novaSituacao))
        .Returns(Task.CompletedTask);

        //Act 
        var result = await controller.AtualizarSituacaoPitch(idPitch, novaSituacao);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Situacao do pitch atualizada", okResult.Value);
    }
}
