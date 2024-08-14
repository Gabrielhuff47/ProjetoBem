using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;

namespace Tests.ControllerTests.PitchTests;

public class ListarPitchPorUsuarioControllerTest
{
    private readonly Mock<IPitchService> mockPitchService;
    private readonly PitchController controller;
    public ListarPitchPorUsuarioControllerTest()
    {
        mockPitchService = new Mock<IPitchService>();
        controller = new PitchController(mockPitchService.Object);
    }
    [Fact]
    public async Task ListarPitchPorUsuarioController_RetornarOk()
    {
        var usuario = "SISTEMA";
        var pitches = new List<PitchReduzidoDto>
        {
            new PitchReduzidoDto { IdPitch = 1, NomePitch = "Pitch 1" },
            new PitchReduzidoDto { IdPitch = 2, NomePitch = "Pitch 2" },
            new PitchReduzidoDto { IdPitch = 3, NomePitch = "Pitch 3" }
        };
    
         mockPitchService.Setup(mp => mp.ListarPitchPorUsuario(usuario)).
         ReturnsAsync(pitches);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario)
                }, "autenticacao falsa"))
            }
        };

        //Act
        var result = await controller.ListaPitchPorUsuario();

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<PitchReduzidoDto>>(okResult.Value);
        Assert.Equal(pitches, returnValue);


    }

}
