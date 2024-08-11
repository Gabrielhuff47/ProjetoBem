using AutoFixture;
using Moq;
using SistemaART.BLL;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest;

public class ListarPitchPorUsuarioTests
{
    [Fact]
  public async Task ListaPitch_Usuario_RetornaPitchReduzido()
        {
            // Arrange
            var usuario = "SISTEMA";
            var pitches = new List<PitchReduzidoModel>
            {
                new PitchReduzidoModel { IdPitch = 1, NomePitch = "Pitch 1" },
                new PitchReduzidoModel { IdPitch = 2, NomePitch = "Pitch 2" },
                new PitchReduzidoModel { IdPitch = 3, NomePitch = "Pitch 3" }
            };

            var pitchRepositoryMock = new Mock<IPitchRepository>();
         pitchRepositoryMock.Setup(repo => repo.ListarPitchPorUsuario(usuario))
                               .Returns(Task.FromResult<IEnumerable<PitchReduzidoModel>>(pitches));

            var pitchService = new PitchService(pitchRepositoryMock.Object);

            // Act
            var result = await pitchService.ListarPitchPorUsuario(usuario);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pitches.Count, result.Count());

            for (int i = 0; i < pitches.Count; i++)
            {
                Assert.Equal(pitches[i].IdPitch, result.ElementAt(i).IdPitch);
                Assert.Equal(pitches[i].NomePitch, result.ElementAt(i).NomePitch);
            }
        }
    }
