using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.TremConverter;

public static class TremModelListToDtoList
{
    public static IEnumerable<TremDto> Convert(this IEnumerable<TremModel> trems)
    {
        var list = trems.ToList();
        var dtos = list.ConvertAll(trem => trem.Convert());
        return dtos.AsEnumerable();
    }
}
