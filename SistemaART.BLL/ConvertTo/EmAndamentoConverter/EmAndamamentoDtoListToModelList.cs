using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EmAndamentoConverter;

public static class EmAndamamentoDtoListToModelList
{
    public static IEnumerable<EmAndamentoModel> Convert(this IEnumerable<EmAndamentoDto> emAndamentos)
    {
        return emAndamentos.Select(emAndamento => emAndamento.Convert());
    }
}
