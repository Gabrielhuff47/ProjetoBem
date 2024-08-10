using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.FinalizadoConverter;

public static class FinalizadoModelToDto
{
    public static FinalizadoDto Convert(this FinalizadoModel finalizado)
    {
        return new FinalizadoDto
        {
            NomeEpico = finalizado.NomeEpico,
            EpicoDataFim = finalizado.EpicoDataFim,
            Mensagem = finalizado.Mensagem
        };
    }
}
