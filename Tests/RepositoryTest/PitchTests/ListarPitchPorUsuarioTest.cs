using System.Data;
using Dapper;
using Moq;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.RepositoryTest.PitchTests;

public class ListarPitchPorUsuarioTest
{
      private readonly Mock<IDapperWrapper> mockDapper;
        private readonly PitchRepository pitchRepository;
    public ListarPitchPorUsuarioTest()
    {
      mockDapper = new Mock<IDapperWrapper>();
      pitchRepository = new PitchRepository(mockDapper.Object);
    }

    [Fact]
    public async Task ListarPitchPorUsuario_Usuario_RetornaListaPitchReduzido()
    {
        // Arrange 
        string usuario = "SISTEMA";
        var pitchList = new List<PitchReduzidoModel>
        {
            new PitchReduzidoModel {IdPitch = 1, NomePitch = "Portal de Análise"},
            new PitchReduzidoModel {IdPitch = 2, NomePitch = "BPN"},
        };

        mockDapper.Setup(md => md.QueryAsync<PitchReduzidoModel>
        (It.IsAny<string>(), It.IsAny<object>()
        )).ReturnsAsync(pitchList);
        
        //Act
        var result = await pitchRepository.ListarPitchPorUsuario(usuario);

        //Assert
        Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Portal de Análise", result.First().NomePitch);
            mockDapper.Verify(db => db.QueryAsync<PitchReduzidoModel>(
                It.IsAny<string>(),
                It.IsAny<object>()
            ), Times.Once);
        }
    }

