using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.BacklogConverter;

public static class BacklogDtoListToModelList
{
    public static IEnumerable<BacklogModel> Convert(this IEnumerable<BacklogDto> backlogs)

    {
        return backlogs.Select(backlog => backlog.Convert());
    }

}
