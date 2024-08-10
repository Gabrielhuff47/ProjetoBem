using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EpicoConverter;

public static class EpicoGravarDtoToModel
{
    public static EpicoModel Convert(this EpicoGravarDto dto)
    {
        return new EpicoModel
        {
            NomeEpico = dto.NomeEpico.ToUpper(),
            DataInicio = dto.DataInicio,
            DataFim = dto.DataFim,
            IdSituacao = dto.IdSituacao,
            UsuarioAtualizacao = dto.UsuarioAtualizacao,
            DataAtualizacao = dto.DataAtualizacao,
            IdPitch = dto.IdPitch
        };
    }
}
