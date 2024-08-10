using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.TremConverter;

public static class TremDtoListToModelList
{
    public static IEnumerable<TremModel> Convert(this IEnumerable<TremDto> trems )
    {
        return trems.Select(trem => trem.Convert());
    }  
}
