using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;


namespace Tests.PitchTests;

public class PitchRepositoryTests
{
    private readonly Mock<IDapperWrapper> dapperMock;
    private readonly PitchRepository pitchRepository;
    
    public PitchRepositoryTests()
    {
        dapperMock = new Mock<IDapperWrapper>();
        pitchRepository = new PitchRepository(dapperMock.Object);
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

        dapperMock.Setup(md => md.QueryAsync<PitchReduzidoModel>
        (It.IsAny<string>(), It.IsAny<object>()
        )).ReturnsAsync(pitchList);
        
        //Act
        var result = await pitchRepository.ListarPitchPorUsuario(usuario);

        //Assert
        Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Portal de Análise", result.First().NomePitch);
            dapperMock.Verify(db => db.QueryAsync<PitchReduzidoModel>(
                It.IsAny<string>(),
                It.IsAny<object>()
            ), Times.Once);
        }

          [Fact]
    public async Task ListarPitch_Id_RetornaPitch()
    {
        //Arrange

        var idPitch = 1;
        var pitch = new PitchModel
        {
            IdPitch = idPitch,
            NomePitch = "Portabilidade",
            NomeTime = "PDV-DIGITAÇÃO",
            Descricao = "Descrição genérica",
            DataComite = new DateTime(2020, 01, 11),
            Situacao = 5,
            SituacaoDescricao = "Finalizado",
            SituacaoAndamento = "N",
            UsuarioAtualizacao = "SISTEMA",
            DataAtualizacao = new DateTime(2021, 10, 05)
        };

        dapperMock.Setup(d => d.QuerySingleOrDefaultAsync<PitchModel>(
            It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(pitch);

        //Act
        var result = await pitchRepository.ListarPitchPorId(idPitch);

        //Assert 
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
        
        dapperMock.Verify(d => d.QuerySingleOrDefaultAsync<PitchModel>(
            It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

        [Fact]
    public async Task AtualizarPitchSituacao_Id_RetornaPitchSituacaoAtualizada()
    {
        // Arrange
        var idPitch = 1;
        var novaSituacao = 2;

       dapperMock.Setup(d => d.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                     .ReturnsAsync(1); 

    // Act
    await pitchRepository.AtualizarPitchSituacao(idPitch, novaSituacao);

    // Assert
    dapperMock.Verify(d => d.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
}

}
