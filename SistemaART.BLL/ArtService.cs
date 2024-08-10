using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.ConvertTo.ArtConverter;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.BLL;

public class ArtService : IArtService
{
    private readonly IArtRepository _artRepository;
    public ArtService(IArtRepository artRepository)
    {
        _artRepository = artRepository;
    }



    public async Task<IEnumerable<ArtDto>> ListarTodos()
    {
        return (await _artRepository.ListarTodos()).Convert();
    }
    public async Task<IEnumerable<TremDto>> ListarTodosAgrupados()
    {
        var dados = await _artRepository.ListarTodos();

        var groupedData = dados
            .GroupBy(d => new { d.NomeTime, d.NomeTribo, d.NomeArea })
            .Select(g => new TremDto
            {
                NomeTime = g.Key.NomeTime,
                NomeTribo = g.Key.NomeTribo,
                NomeArea = g.Key.NomeArea,
                Backlogs = g.Where(d => d.PitchSituacao == 2 || d.PitchSituacao == 3)
                   .OrderBy(d => d.PitchDataAtualizacao)
                   .Take(3)
                   .Select(d => new BacklogDto
                   {
                       NomeTime = d.NomeTime,
                       NomePitch = d.NomePitch
                   })
                   .ToList(),
                EmAndamentos = g.Where(d => d.EpicoSituacao == 04)
                       .OrderByDescending(d => d.EpicoDataAtualizacao)
                       .Take(3)
                       .Select(d =>
                       {

                           var atraso = (DateTime.UtcNow - d.EpicoDataInicio.GetValueOrDefault()).TotalDays >= 30;
                            Console.WriteLine(atraso);
                            var Mensagem = d.Mensagem;
                            Console.WriteLine(Mensagem);
                           return new EmAndamentoDto
                           {
                               NomeEpico = d.NomeEpico,
                               Mensagem = atraso ? d.Mensagem : null
                           };

                       })
                       .ToList(),
                Finalizados = g.Where(d => d.EpicoSituacao == 05)
                      .OrderByDescending(d => d.EpicoDataFim)
                      .Take(5)
                      .Select(d =>
                      {
                          var atraso = (d.EpicoDataFim.GetValueOrDefault() - d.EpicoDataInicio.GetValueOrDefault()).TotalDays >= 30;
                          return new FinalizadoDto
                          {
                              NomeEpico = d.NomeEpico,
                              EpicoDataFim = d.EpicoDataFim,
                              Mensagem = atraso ? d.Mensagem : null

                          };

                      })
                      .ToList()
            })
            .ToList();

        return groupedData;
    }
}




