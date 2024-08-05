using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.PitchConverter;

public static class PitchDtoListToModelList
{
    public static IEnumerable<PitchModel> Convert(this IEnumerable<PitchDto> pitchs)
    {
        return pitchs.Select(pitch => pitch.Convert());
    }
}
