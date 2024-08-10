using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EmAndamentoConverter;

public static class EmAndamentoModelListToDtoList
{
    public static IEnumerable<EmAndamentoDto> Convert(this IEnumerable<EmAndamentoModel> emAndamentos)
    {
        // var list = emAndamentos.ToList();
        // var dtos = list.ConvertAll(emAndamento => emAndamento.Convert());
        // return emAndamentos.AsEnumerable();
        return emAndamentos.Select(emAndamento => emAndamento.Convert());
    }
}
