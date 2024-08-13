using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.PitchTests;

public class AtualizarPitchSituacaoPorIdTest
{
    [Fact]
    public async Task AtualizarSituacaoPitch_Id_RetornarSituacaoAtualizada()
    {
        // Arrange
        var idPitch = 1;
        var novaSituacao = 6;

        var pitch = new PitchModel { IdPitch = idPitch, Situacao = 1 };
        var pitchRepositoryMock = new Mock<IPitchRepository>();
        pitchRepositoryMock.Setup(repo => repo.ListarPitchPorId(idPitch))
                           .ReturnsAsync(pitch);

        var pitchService = new PitchService(pitchRepositoryMock.Object);
        // Act
        await pitchService.AtualizarSituacaoPitch(idPitch, novaSituacao);

        // Assert
        pitchRepositoryMock.Verify(repo => repo.AtualizarPitchSituacao(idPitch, novaSituacao));
        Assert.Equal(novaSituacao, pitch.Situacao);
    }

}

