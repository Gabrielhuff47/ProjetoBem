using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.PitchConverter;

public static class PitchModelListToDtoList
{
    public static IEnumerable<PitchDto> Convert(this IEnumerable<PitchModel> pitchs)
    {
        var list = pitchs.ToList();
        var dtos = list.ConvertAll(pitch => pitch.Convert());
        return dtos.AsEnumerable();
    }
}
