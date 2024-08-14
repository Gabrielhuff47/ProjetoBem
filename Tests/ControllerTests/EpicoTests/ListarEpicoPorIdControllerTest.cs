using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;

namespace Tests.ControllerTests.EpicoTests;

public class ListarEpicoPorIdControllerTest
{
    private readonly Mock<IEpicoService> mockEpicoService;
    private readonly EpicoController controller;
    public ListarEpicoPorIdControllerTest()
    {
         mockEpicoService = new Mock<IEpicoService>();
        controller = new EpicoController(mockEpicoService.Object);
    }

    [Fact]
    public async Task ListarEpicoPorId_RetornaOk()
    {
        //Arrange 
        var idEpico = 1;
        var usuario = "SISTEMA";
        var epico = new EpicoDto
        {
            IdEpico = idEpico,
            IdPitch = 2,
            IdSituacao = 2,
            NomeEpico = "Epico",
            DataInicio = new DateTime(2024, 08,03),
            DataFim = new DateTime(2024,08, 10),
            UsuarioAtualizacao = usuario,
            DataAtualizacao = DateTime.Now,
        };
        mockEpicoService.Setup(me => me.ConsultarEpicoPorId(idEpico))
        .ReturnsAsync(epico);

         controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario)
                }, "autenticacao falsa"))
            }
        };
        // Act
        var result = await controller.Get(idEpico);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(epico, okResult.Value);
    }

      [Fact]
    public async Task ListarEpicoPorId_RetornaNaoEncontrado()
    {
        // Arrange
        var usuario = "usuario_teste";
        var id = 1;

        var mockEpicoService = new Mock<IEpicoService>();
        mockEpicoService.Setup(service => service.ConsultarEpicoPorId(id))
            .ReturnsAsync((EpicoDto)null);

        var controller = new EpicoController(mockEpicoService.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario)
                }, "autenticacao falsa"))
            }
        };

        // Act
        var result = await controller.Get(id);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

}
