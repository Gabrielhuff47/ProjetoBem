using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;

namespace Tests.ControllerTests.EpicoTests;

public class DeletarEpicoControllerTest
{
    private readonly Mock<IEpicoService> mockEpicoService;
    private readonly EpicoController controller;
    public DeletarEpicoControllerTest()
    {
        mockEpicoService = new Mock<IEpicoService>();
        controller = new EpicoController(mockEpicoService.Object);
    }

    [Fact]
    public async Task DeletarEpico_RetornaNoContent()
    {
        var id = 1;
        var usuario = "SISTEMA";
        var epico = new EpicoDto
        {
            IdEpico = id,
            IdPitch = 2,
            IdSituacao = 2,
            NomeEpico = "Epico",
            DataInicio = new DateTime(2024, 08, 03),
            DataFim = new DateTime(2024, 08, 10),
            UsuarioAtualizacao = usuario,
            DataAtualizacao = DateTime.Now,
        };

        mockEpicoService.Setup(me => me.ConsultarEpicoPorId(id))
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

        mockEpicoService.Setup(me => me.DeletarEpico(id)).Returns(Task.CompletedTask);

        // Act
        var result = await controller.Delete(id) as NoContentResult;

        //Assert
        Assert.NotNull(result);
        Assert.Equal(204, result.StatusCode);
    }

}

