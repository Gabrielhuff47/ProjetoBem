using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;

namespace Tests.ControllerTests.EpicoTests;

public class ListarEpicoPorCaracteresControllerTest
{

    private readonly Mock<IEpicoService> mockEpicoService;
    private readonly EpicoController controller;
    public ListarEpicoPorCaracteresControllerTest()
    {
        mockEpicoService = new Mock<IEpicoService>();
        controller = new EpicoController(mockEpicoService.Object);
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

    mockEpicoService.Setup(me => me.ConsultarEpicoPorCaracteres(nomeFiltro, usuarioAtualizacao))
    .ReturnsAsync(epicos);

        controller.ControllerContext = new ControllerContext
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
    var result = await controller.Get(nomeFiltro);

    //Assert 
    var okResult = Assert.IsType<OkObjectResult>(result);
    Assert.NotNull(result);
   

}
}
