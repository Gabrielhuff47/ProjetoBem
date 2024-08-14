using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;

namespace Tests.RepositoryTest.EpicoTests;

public class DeletarEpicoTest
{
    
    private readonly Mock<IDapperWrapper> mockDapper;
    private readonly EpicoRepository epicoRepository;
    public DeletarEpicoTest()
    {
        mockDapper = new Mock<IDapperWrapper>();
        epicoRepository = new EpicoRepository(mockDapper.Object);
    }
    [Fact]
    public async Task Deletar_IdEpico()
    {
        //Arrange
        var IdEpico = 1;
        var epico = new EpicoModel 
        {
            IdEpico = 1,
            DataInicio = DateTime.Now,
            IdSituacao = 1,
            IdPitch = 1,
            NomeEpico = "Novo Epico",
            UsuarioAtualizacao = "SISTEMA",
            DataAtualizacao = DateTime.Now
        };

        //Act
        await epicoRepository.DeletarEpico(IdEpico);

        //Assert
       
        mockDapper.Verify(md => md.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once());
    }
}


