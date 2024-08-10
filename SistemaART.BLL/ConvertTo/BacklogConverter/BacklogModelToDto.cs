using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.BacklogConverter;

public static class BacklogModelToDto
{
    public static BacklogDto Convert(this BacklogModel backlog)
    {
        return new BacklogDto
        {
            NomeTime = backlog.NomeTime,
            NomePitch = backlog.NomePitch
        };
    }
}
