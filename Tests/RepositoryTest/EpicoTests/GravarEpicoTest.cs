using Microsoft.AspNetCore.Authorization;
using Moq;
using SistemaART.DAO.Dapper.BaseRepository;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository;

namespace Tests.RepositoryTest.EpicoTests;

public class GravarEpicoTest
{
    private readonly Mock<IDapperWrapper> mockDapper;
    private readonly EpicoRepository epicoRepository;
    public GravarEpicoTest()
    {
        mockDapper = new Mock<IDapperWrapper>();
        epicoRepository = new EpicoRepository(mockDapper.Object);
    }
    [Fact]

    public async Task GravarEpico_Epico_EpicoGravado()
    {
        //Arrange
        var epico = new EpicoModel 
        {
            DataInicio = DateTime.Now,
            IdSituacao = 1,
            IdPitch = 1,
            NomeEpico = "Novo Epico",
            UsuarioAtualizacao = "SISTEMA",
            DataAtualizacao = DateTime.Now
        };

        //Act
        await epicoRepository.GravarEpico(epico);

        //Assert
        mockDapper.Verify(md => md.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once());
    }
}
