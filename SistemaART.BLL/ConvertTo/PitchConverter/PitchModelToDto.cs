using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.PitchConverter;

public static class PitchModelToDto
{
    public static PitchDto Convert(this PitchModel pitch)
    {
        return new PitchDto
        {
            IdPitch = pitch.IdPitch,
            IdTime = pitch.IdTime,
            NomePitch = pitch.NomePitch,
            NomeTime = pitch.NomeTime,
            Descricao = pitch.Descricao,
            DataComite = pitch.DataComite,
            Situacao = pitch.Situacao,
            SituacaoDescricao = pitch.SituacaoDescricao,
            SituacaoAndamento = pitch.SituacaoAndamento,
            UsuarioAtualizacao = pitch.UsuarioAtualizacao,
            DataAtualizacao = pitch.DataAtualizacao
        };
    }
}
