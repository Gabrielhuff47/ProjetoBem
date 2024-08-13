using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.PitchTests;

public class ListarPitchPorIdTest
{
    [Fact]
    public async Task ListaPitch_Id_RetornaPitch()
    {
        // Arrange
        var id = 3;
        var pitch = new PitchModel
        {
            IdPitch = 3,
            IdTime = 9,
            NomePitch = "BN",
            NomeTime = "BERLIM",
            Descricao = "UMA DESCRICAO GENERICA",
            DataComite = new DateTime(2023, 1, 3),
            Situacao = 4,
            SituacaoDescricao = "Em andamento",
            SituacaoAndamento = "S",
            UsuarioAtualizacao = "SISTEMA",
            DataAtualizacao = new DateTime(2024, 8, 5, 12, 26, 19, 847)
        };

        var pitchRepositoryMock = new Mock<IPitchRepository>();
        pitchRepositoryMock.Setup(repo => repo.ListarPitchPorId(It.IsAny<int>()))
                           .Returns<int>(id => Task.FromResult(id == pitch.IdPitch ? pitch : null));


        var pitchService = new PitchService(pitchRepositoryMock.Object);

        // Act
        var result = await pitchService.ListarPitchPorId(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(pitch.IdPitch, result.IdPitch);
        Assert.Equal(pitch.IdTime, result.IdTime);
        Assert.Equal(pitch.NomePitch, result.NomePitch);
        Assert.Equal(pitch.NomeTime, result.NomeTime);
        Assert.Equal(pitch.Descricao, result.Descricao);
        Assert.Equal(pitch.DataComite, result.DataComite);
        Assert.Equal(pitch.Situacao, result.Situacao);
        Assert.Equal(pitch.SituacaoDescricao, result.SituacaoDescricao);
        Assert.Equal(pitch.SituacaoAndamento, result.SituacaoAndamento);
        Assert.Equal(pitch.UsuarioAtualizacao, result.UsuarioAtualizacao);
        Assert.Equal(pitch.DataAtualizacao, result.DataAtualizacao);
    }
}

