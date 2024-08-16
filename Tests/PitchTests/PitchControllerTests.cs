using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;

namespace Tests.PitchTests;

public class PitchControllerTests
{
    private readonly Mock<IPitchService> pitchServiceMock;
    private readonly PitchController pitchController;
    public PitchControllerTests()
    {
        pitchServiceMock = new Mock<IPitchService>();
        pitchController = new PitchController(pitchServiceMock.Object);
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
        
        pitchServiceMock.Setup(mp => mp.ListarPitchPorId(idPitch))
        .ReturnsAsync(pitch);

        pitchController.ControllerContext = new ControllerContext
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
        var result = await pitchController.ListarPitchPorId(idPitch);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(pitch, okResult.Value);
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
    
         pitchServiceMock.Setup(mp => mp.ListarPitchPorUsuario(usuario)).
         ReturnsAsync(pitches);
        pitchController.ControllerContext = new ControllerContext()
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
        var result = await pitchController.ListaPitchPorUsuario();

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<PitchReduzidoDto>>(okResult.Value);
        Assert.Equal(pitches, returnValue);
    }

         [Fact]
    public async Task AtualizarPitchSituacao_RetornaOk()
    {
        //Arrange
        var idPitch = 1;
        var novaSituacao = 2;

        pitchServiceMock.Setup(mp=> mp.AtualizarSituacaoPitch(idPitch, novaSituacao))
        .Returns(Task.CompletedTask);

        //Act 
        var result = await pitchController.AtualizarSituacaoPitch(idPitch, novaSituacao);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Situacao do pitch atualizada", okResult.Value);
    }

}
