using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.ArtConverter;

public static class ArtDtoListToModelList
{
        public static IEnumerable<ArtModel> Convert(this IEnumerable<ArtDto> arts)
    {
        return arts.Select(art => art.Convert());
    }
}
