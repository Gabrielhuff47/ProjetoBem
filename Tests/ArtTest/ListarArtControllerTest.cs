using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;
using SistemaART.WebApp.Controllers;

namespace Tests.ArtTest;

public class ListarArtControllerTest
{
    private readonly Mock<IArtService> mockArtService;
    private readonly ArtController controller;
    public ListarArtControllerTest()
    {
        mockArtService = new Mock<IArtService>();
        controller = new ArtController(mockArtService.Object);
    }

    [Fact]
    public async Task ListarArt_RetornaOk()
    {
        //Arrange
        var artList = new List<TremDto>
        {
             new TremDto
             {
                NomeTime = "MASTER OF BUGS",
                NomeTribo = "CONTRATACAO",
                NomeArea = "SISTEMAS",
            } ,
              new TremDto 
            { NomeTime = "MASTER OF BUGS",
             NomeTribo = "CONTRATACAO", 
             NomeArea = "SISTEMAS",
              },

        };

        mockArtService.Setup( ma => ma.ListarTodosAgrupados())
        .ReturnsAsync(artList);

        // Act
        var result = await controller.GetAllArt() as OkObjectResult;

        // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(artList, result.Value);
    }



}
