using Moq;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.BaseRepository;


namespace Tests.RepositoryTest.PitchTests;

public class ListarPitchPorIdTest
{
    private readonly Mock<IDapperWrapper> mockDapper;
    private readonly PitchRepository pitchRepository;
    public ListarPitchPorIdTest()
    {
        mockDapper = new Mock<IDapperWrapper>();
        pitchRepository = new PitchRepository(mockDapper.Object);
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

        mockDapper.Setup(d => d.QuerySingleOrDefaultAsync<PitchModel>(
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
        
        mockDapper.Verify(d => d.QuerySingleOrDefaultAsync<PitchModel>(
            It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }
}
