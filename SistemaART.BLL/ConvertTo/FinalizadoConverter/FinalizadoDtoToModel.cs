using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.FinalizadoConverter;

public static class FinalizadoDtoToModel
{
    public static FinalizadoModel Convert(this FinalizadoDto finalizadoDto)
    {
        return new FinalizadoModel
        {
            NomeEpico = finalizadoDto.NomeEpico,
            EpicoDataFim = finalizadoDto.EpicoDataFim,
            Mensagem = finalizadoDto.Mensagem

        };
    }
}
