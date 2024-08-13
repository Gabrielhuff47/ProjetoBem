using Moq;
using SistemaART.DAO.Dapper.Repository;
using SistemaART.DAO.Dapper.Repository.Contratos;
using Xunit;

namespace Tests.RepositoryTest.PitchTests;

public class AtualizarPitchSituacaoPorIdTest
{
    private readonly Mock<IDapperWrapper> mockDapper;
    private readonly PitchRepository pitchRepository;

    public AtualizarPitchSituacaoPorIdTest()
    {
        mockDapper = new Mock<IDapperWrapper>();
        pitchRepository = new PitchRepository(mockDapper.Object);
    }

    [Fact]
    public async Task AtualizarPitchSituacao_Id_RetornaPitchSituacaoAtualizada()
    {
        // Arrange
        var idPitch = 1;
        var novaSituacao = 2;

       mockDapper.Setup(d => d.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
                     .ReturnsAsync(1); 

    // Act
    await pitchRepository.AtualizarPitchSituacao(idPitch, novaSituacao);

    // Assert
    mockDapper.Verify(d => d.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
}
    
}

