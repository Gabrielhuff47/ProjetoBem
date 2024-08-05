using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EpicoConverter;

public static class EpicoDtoListToModelList
{
     public static IEnumerable<EpicoModel> Convert(this IEnumerable<EpicoDto> epicos)
    {
        return epicos.Select(epico => epico.Convert());
    }
}
