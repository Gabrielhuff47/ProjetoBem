using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.ArtConverter;

public static class ArtModelListToDtoList
{
        public static IEnumerable<ArtDto> Convert(this IEnumerable<ArtModel> arts)
    {
        var list = arts.ToList();
        var dtos = list.ConvertAll(art => art.Convert());
        return dtos.AsEnumerable();
    }
}
