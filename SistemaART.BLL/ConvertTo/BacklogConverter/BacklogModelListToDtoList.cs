using SistemaART.BLL.DTO;

namespace SistemaART.BLL.ConvertTo.BacklogConverter;

public static class BacklogModelListToDtoList
{
    public static IEnumerable<BacklogDto> Convert(this IEnumerable<BacklogDto> backlogs)
    {
        var list = backlogs.ToList();
        var dtos = list.ConvertAll(backlog => backlog.Convert());
        return backlogs.AsEnumerable();
    }
}
