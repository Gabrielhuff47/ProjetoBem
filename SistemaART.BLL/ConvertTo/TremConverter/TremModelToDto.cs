using SistemaART.BLL.ConvertTo.BacklogConverter;
using SistemaART.BLL.ConvertTo.EmAndamentoConverter;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.TremConverter;

public static class TremModelToDto
{
    public static TremDto Convert(this TremModel trem)
    {
        return new TremDto
        {
            NomeArea = trem.NomeArea,
            NomeTime = trem.NomeTime,
            NomeTribo = trem.NomeTribo,
            Backlogs = trem.Backlogs.Select(s => s.Convert()).ToList(),
            EmAndamentos = trem.EmAndamentos.Select(g => g.Convert()).ToList()
        };
    }
}

