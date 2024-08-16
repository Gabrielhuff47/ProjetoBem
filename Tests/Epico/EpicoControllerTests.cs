using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;

namespace Tests.Epico;

public class EpicoControllerTests
{
    private readonly Mock<IEpicoService> epicoServiceMock;
    private readonly EpicoController epicoController;
    public EpicoControllerTests()
    {
        epicoServiceMock = new Mock<IEpicoService>();
        epicoController = new EpicoController(epicoServiceMock.Object);
    }

    [Fact]
    public async Task ListarEpicoPorCaracteres_RetornaOk()
    {
        //Arrange 

        var usuarioAtualizacao = "SISTEMA";
        var nomeFiltro = "Epi";

        var epicos = new List<EpicoDto>
        {
            new EpicoDto
            {
                    IdEpico = 1,
                    IdPitch = 2,
                    IdSituacao = 2,
                    NomeEpico = "Epico",
                    DataInicio = new DateTime(2024, 08, 03),
                    DataFim = new DateTime(2024, 08, 10),
                    UsuarioAtualizacao = "SISTEMA",
                    DataAtualizacao = DateTime.Now,
            },
            new EpicoDto
                {
                    IdEpico = 2,
                    IdPitch = 3,
                    IdSituacao = 1,
                    NomeEpico = "PORTAL",
                    DataInicio = new DateTime(2024, 08, 05),
                    DataFim = new DateTime(2024, 08, 11),
                    UsuarioAtualizacao = "SISTEMA",
                    DataAtualizacao = DateTime.Now,
        }
    };

    epicoServiceMock.Setup(me => me.ConsultarEpicoPorCaracteres(nomeFiltro, usuarioAtualizacao))
    .ReturnsAsync(epicos);

        epicoController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioAtualizacao)
                }, "autenticacao falsa"))
            }
        };

    //Act
    var result = await epicoController.Get(nomeFiltro);

    //Assert 
    var okResult = Assert.IsType<OkObjectResult>(result);
    Assert.NotNull(result);
   

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
        epicoServiceMock.Setup(me => me.ConsultarEpicoPorId(idEpico))
        .ReturnsAsync(epico);

         epicoController.ControllerContext = new ControllerContext
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
        var result = await epicoController.Get(idEpico);

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
    
       epicoServiceMock.Setup(me => me.ListarEpico(usuario))
       .ReturnsAsync(epicos);

       epicoController.ControllerContext = new ControllerContext
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
        var result = await epicoController.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(epicos, okResult.Value);
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

        epicoServiceMock.Setup(me => me.ConsultarEpicoPorId(id))
        .ReturnsAsync(epico);


        epicoController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, usuario)
               }, "autenticacao falsa"))
            }

        };

        epicoServiceMock.Setup(me => me.DeletarEpico(id)).Returns(Task.CompletedTask);

        // Act
        var result = await epicoController.Delete(id) as NoContentResult;

        //Assert
        Assert.NotNull(result);
        Assert.Equal(204, result.StatusCode);
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

         epicoController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "sistema")
                }, "autenticacao falsa"))
            }
           
        };

             epicoServiceMock.Setup(s => s.GravarEpico(It.IsAny<EpicoGravarDto>()))
                             .Returns(Task.CompletedTask);
            
            // Act
            var result = await epicoController.Post(epico) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
             Assert.Equal(epico, result.Value);

    }
}
