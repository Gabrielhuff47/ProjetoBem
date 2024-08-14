using Moq;
using SistemaART.BLL;
using SistemaART.DAO.Dapper.Models;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace Tests.ServiceTest.EpicoTests;

public class ListarEpicoPorCaracteresTest
{
    [Fact]
    public async Task ConsultarEpicoPorCaracteres_NomeFiltro_RetornarListaDeEpicos()
    {
        // Arrange
            
            var nomeFiltro = "Epi";
            var usuarioAtualizacao = "GABRIEL";
            var epicos = new List<EpicoModel>
            {
                new EpicoModel
                {
                    IdEpico = 1,
                    IdPitch = 2,
                    IdSituacao = 2,
                    NomeEpico = "Epico",
                    DataInicio = new DateTime(2024, 08, 03),
                    DataFim = new DateTime(2024, 08, 10),
                    UsuarioAtualizacao = "SISTEMA",
                    DataAtualizacao = DateTime.Now,
                },
                new EpicoModel
                {
                    IdEpico = 2,
                    IdPitch = 3,
                    IdSituacao = 1,
                    NomeEpico = "Epico 2",
                    DataInicio = new DateTime(2024, 08, 05),
                    DataFim = new DateTime(2024, 08, 11),
                    UsuarioAtualizacao = "GABRIEL",
                    DataAtualizacao = DateTime.Now,
                }
            };

            var epicoRepositoryMock = new Mock<IEpicoRepository>();
            epicoRepositoryMock.Setup(repo => repo.ConsultarEpicoPorCaracteres(nomeFiltro))
                               .ReturnsAsync(epicos);

            var epicoService = new EpicoService(epicoRepositoryMock.Object);

            // Act
            var result = await epicoService.ConsultarEpicoPorCaracteres(nomeFiltro, usuarioAtualizacao);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); 

            var epico = result.First();
            Assert.Equal(epicos[1].IdEpico, epico.IdEpico);
            Assert.Equal(epicos[1].IdPitch, epico.IdPitch);
            Assert.Equal(epicos[1].IdSituacao, epico.IdSituacao);
            Assert.Equal(epicos[1].NomeEpico, epico.NomeEpico);
            Assert.Equal(epicos[1].DataInicio, epico.DataInicio);
            Assert.Equal(epicos[1].DataFim, epico.DataFim);
            Assert.Equal(epicos[1].UsuarioAtualizacao, epico.UsuarioAtualizacao);
            Assert.Equal(epicos[1].DataAtualizacao, epico.DataAtualizacao);

            epicoRepositoryMock.Verify(repo => repo.ConsultarEpicoPorCaracteres(nomeFiltro), Times.Once);
        }
    }
