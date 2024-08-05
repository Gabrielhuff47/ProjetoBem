using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.PitchConverter;

public static class PitchDtoToModel
{
    public static PitchModel Convert(this PitchDto pitchDto)
    {
        return new PitchModel
        {
            IdPitch = pitchDto.IdPitch,
            IdTime = pitchDto.IdTime,
            NomePitch = pitchDto.NomePitch,
            NomeTime = pitchDto.NomeTime,
            Descricao = pitchDto.Descricao,
            DataComite = pitchDto.DataComite,
            Situacao = pitchDto.Situacao,
            SituacaoDescricao = pitchDto.SituacaoDescricao,
            SituacaoAndamento = pitchDto.SituacaoAndamento,
            UsuarioAtualizacao = pitchDto.UsuarioAtualizacao,
            DataAtualizacao = pitchDto.DataAtualizacao

        };
    }
}