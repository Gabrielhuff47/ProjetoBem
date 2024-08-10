using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.FinalizadoConverter;

public static class FinalizadoModelListToDtoList
{
    public static IEnumerable<FinalizadoDto> Convert(this IEnumerable<FinalizadoModel> finalizados)
    {
        var list = finalizados.ToList();
        var dtos = list.ConvertAll(finalizado => finalizado.Convert());
        return dtos.AsEnumerable();
    }
}
