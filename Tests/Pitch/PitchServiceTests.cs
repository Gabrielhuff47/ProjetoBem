using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.Pitch;

public class PitchServiceTests
{
    private readonly Mock<IPitchRepository> pitchRepositoryMock;
    private readonly PitchService pitchService;
    public PitchServiceTests()
    {
        pitchRepositoryMock = new Mock<IPitchRepository>();
        pitchService = new PitchService(pitchRepositoryMock.Object);
    }

    [Fact]
    public async Task ListaPitchs_Usuario_RetornaPitchsReduzidos()
    {
        // Arrange
        var usuario = "SISTEMA";
        var pitches = new List<PitchReduzidoModel>
            {
                new PitchReduzidoModel { IdPitch = 1, NomePitch = "Pitch 1" },
                new PitchReduzidoModel { IdPitch = 2, NomePitch = "Pitch 2" },
                new PitchReduzidoModel { IdPitch = 3, NomePitch = "Pitch 3" }
            };

        pitchRepositoryMock.Setup(repo => repo.ListarPitchPorUsuario(usuario))
                              .Returns(Task.FromResult<IEnumerable<PitchReduzidoModel>>(pitches));

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

    [Fact]
    public async Task ListarPitch_Id_RetornaPitch()
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

        pitchRepositoryMock.Setup(repo => repo.ListarPitchPorId(It.IsAny<int>()))
                           .Returns<int>(id => Task.FromResult(id == pitch.IdPitch ? pitch : null));

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

    [Fact]
    public async Task AtualizarSituacaoPitch_Id_RetornarSituacaoAtualizada()
    {
        // Arrange
        var idPitch = 1;
        var novaSituacao = 6;

        var pitch = new PitchModel { IdPitch = idPitch, Situacao = 1 };
       
        pitchRepositoryMock.Setup(repo => repo.ListarPitchPorId(idPitch))
                           .ReturnsAsync(pitch);

        // Act
        await pitchService.AtualizarSituacaoPitch(idPitch, novaSituacao);

        // Assert
        pitchRepositoryMock.Verify(repo => repo.AtualizarPitchSituacao(idPitch, novaSituacao));
        Assert.Equal(novaSituacao, pitch.Situacao);
    }
















}
