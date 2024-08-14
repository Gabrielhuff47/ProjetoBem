using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;

namespace Tests.ControllerTests.EpicoTests;

public class GravarEpicoControllerTest
{
    private readonly Mock<IEpicoService> mockEpicoService;
    private readonly EpicoController controller;
    public GravarEpicoControllerTest()
    {
        mockEpicoService = new Mock<IEpicoService>();
        controller = new EpicoController(mockEpicoService.Object);
    }

    [Fact]
    public async Task GravarEpico_RetornarCreatedAction()
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

         controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "sistema")
                }, "autenticacao falsa"))
            }
           
        };

             mockEpicoService.Setup(s => s.GravarEpico(It.IsAny<EpicoGravarDto>()))
                             .Returns(Task.CompletedTask);
            
            // Act
            var result = await controller.Post(epico) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
             Assert.Equal(epico, result.Value);

    }

}
