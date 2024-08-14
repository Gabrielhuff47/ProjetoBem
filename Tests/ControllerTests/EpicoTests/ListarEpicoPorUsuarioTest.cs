using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;
using SistemaART.WebApp.Controllers;

namespace Tests.ControllerTests.EpicoTests;

public class ListarEpicoPorUsuarioTest
{
    private readonly Mock<IEpicoService> mockEpicoService;
    private readonly EpicoController controller;
    public ListarEpicoPorUsuarioTest()
    {
        mockEpicoService = new Mock<IEpicoService>();
        controller = new EpicoController(mockEpicoService.Object);
    }

    [Fact]
    public async Task ListarEpicoPorUsuario_RetornaOk()
    {
        //Arrange
        var usuario = "SISTEMA";
        var epicos = new List<EpicoReduzidoDto>
        {
            new EpicoReduzidoDto {IdEpico = 1, NomeEpico ="Portal"},
            new EpicoReduzidoDto { IdEpico = 2, NomeEpico = "Home Banking"}
        };
    
       mockEpicoService.Setup(me => me.ListarEpico(usuario))
       .ReturnsAsync(epicos);

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
        var result = await controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(epicos, okResult.Value);
    }



}
