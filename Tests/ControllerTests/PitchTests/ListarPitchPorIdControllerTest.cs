using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;


namespace Tests.ControllerTests.PitchTests;

public class ListarPitchPorIdControllerTest
{
    private readonly Mock<IPitchService> mockPitchService;
    private readonly PitchController controller;
    public ListarPitchPorIdControllerTest()
    {
        mockPitchService = new Mock<IPitchService>();
        controller = new PitchController(mockPitchService.Object);
    }

    [Fact]
    public async Task ListarPicth_Id_RetornaOk()
    {
        //Arrange
        var idPitch = 1;
        var usuario = "SISTEMA";
        var pitch = new PitchDto
        {
            IdPitch = idPitch,
            IdTime = 9,
            NomePitch = "BN",
            NomeTime = "BERLIM",
            Descricao = "UMA DESCRICAO GENERICA",
            DataComite = new DateTime(2023, 1, 3),
            Situacao = 4,
            SituacaoDescricao = "Em andamento",
            SituacaoAndamento = "S",
            UsuarioAtualizacao = usuario,
            DataAtualizacao = new DateTime(2024, 8, 5, 12, 26, 19, 847)

        };
        
        mockPitchService.Setup(mp => mp.ListarPitchPorId(idPitch))
        .ReturnsAsync(pitch);

        controller.ControllerContext = new ControllerContext
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
        var result = await controller.ListarPitchPorId(idPitch);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(pitch, okResult.Value);
    }

}
