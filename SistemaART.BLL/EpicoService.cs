using SistemaART.BLL.Contratos;
using SistemaART.BLL.ConvertTo.EpicoConverter;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.BLL;

public class EpicoService : IEpicoService
{   
    private readonly IEpicoRepository _epicoRepository;
    public EpicoService(IEpicoRepository epicoRepository)
    {
        _epicoRepository = epicoRepository;
    }
    
    public async Task<EpicoDto?> ConsultarEpicoPorId(int id)
    {
        var epico = await _epicoRepository.ConsultarEpicoPorId(id);
        return epico?.Convert();
    }
    public async Task GravarEpico(EpicoDto epico)
    {
        //regras de negocio
         if (epico.DataFim.HasValue)
    {
        if (epico.DataFim < epico.DataInicio)
        {
            throw new ArgumentException("A data de finalização não pode ser menor que a data de início.");
        }
        if (epico.DataFim > DateTime.Now)
        {
            throw new ArgumentException("A data de finalização não pode ser maior que a data atual.");
        }
    }

        if(epico.DataInicio.HasValue && epico.DataInicio > DateTime.Now )
        {
            if(epico.IdSituacao == 4 || epico.IdSituacao == 5)
            {
                throw new ArgumentException("A situação não pode ser “Em andamento” ou “Finalizado” se a data de início for maior que a data atual.");
            }
            if (epico.IdSituacao == 3)
            {
                 throw new ArgumentException("A situação não pode ser “Backlog” se a data de início for maior que a atual");
            }
           

        }
             if (epico.IdSituacao == 5 && !epico.DataFim.HasValue)
        {
            throw new ArgumentException("A situação só pode ser 'Finalizado' se for preenchida uma data de finalização.");
        }
        

         epico.NomeEpico = epico.NomeEpico.ToUpper();
         await _epicoRepository.GravarEpico(epico.Convert());
    }
    public async Task<IEnumerable<EpicoDto>> ListarEpico()
    {
        return (await _epicoRepository.ListarEpico()).Convert();
    }

    public async Task<IEnumerable<EpicoDto?>> ConsultarEpicoPorCaracteres(string nomeFiltro)

        {
            return (await _epicoRepository.ConsultarEpicoPorCaracteres(nomeFiltro)).Convert();


        }
    
    public async Task DeletarEpico(int id)
    {
        if (id == 0)
        {
            throw new ArgumentException("O Id do Epico não pode estar em branco");
        }
        
        await _epicoRepository.DeletarEpico(id);
    }

}
