using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.FinalizadoConverter;

public static class FinalizadoDtoListToModelList
{
    public static IEnumerable<FinalizadoModel> Convert(this IEnumerable<FinalizadoDto> finalizados)
    {
        return finalizados.Select(finalizado => finalizado.Convert());
    }
}
