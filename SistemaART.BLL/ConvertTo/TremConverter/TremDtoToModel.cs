using SistemaART.BLL.ConvertTo.BacklogConverter;
using SistemaART.BLL.ConvertTo.EmAndamentoConverter;

using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.TremConverter;

public static class TremDtoToModel
{
        public static TremModel Convert(this TremDto tremDto )
    {
        return new TremModel
        {
            NomeArea = tremDto.NomeArea,
            NomeTime = tremDto.NomeTime,
            NomeTribo = tremDto.NomeTribo,
            Backlogs = tremDto.Backlogs.Select(s => s.Convert()).ToList(),
            EmAndamentos = tremDto.EmAndamentos.Select(g => g.Convert()).ToList()
        };
    }
}

