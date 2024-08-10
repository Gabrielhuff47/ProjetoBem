using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.BacklogConverter;

public static class BacklogDtoToModel
{
    public static BacklogModel Convert(this BacklogDto backlogDto)
    {
        return new BacklogModel
        {
            NomeTime = backlogDto.NomeTime,
            NomePitch = backlogDto.NomePitch
        };
    }
}
