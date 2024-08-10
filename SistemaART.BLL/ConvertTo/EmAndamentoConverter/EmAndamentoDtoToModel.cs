using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EmAndamentoConverter;

public static class EmAndamentoDtoToModel
{
    public static EmAndamentoModel Convert(this EmAndamentoDto emAndamentoDto)
    {
        return new EmAndamentoModel
        {
            NomeEpico = emAndamentoDto.NomeEpico,
            Mensagem = emAndamentoDto.Mensagem
            
        };
    }
}
