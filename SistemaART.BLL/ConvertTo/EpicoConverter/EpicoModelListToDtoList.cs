using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EpicoConverter;

public static class EpicoModelListToDtoList
{
  public static IEnumerable<EpicoDto> Convert(this IEnumerable<EpicoModel> epicos)
    {
        var list = epicos.ToList();
        var dtos = list.ConvertAll(epico => epico.Convert());
        return dtos.AsEnumerable();
    }
}
