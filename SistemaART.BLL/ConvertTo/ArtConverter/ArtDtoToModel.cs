using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.ArtConverter;

public static class ArtDtoToModel
{
    public static ArtModel Convert(this ArtDto artDto)
    {
        return new ArtModel
        {
            NomePitch = artDto.NomePitch, 
            NomeEpico = artDto.NomeEpico,
            NomeTime = artDto.NomeTime,
            NomeTribo = artDto.NomeTribo,
            NomeArea = artDto.NomeArea,
            Mensagem = artDto.Mensagem,
            PitchSituacao = artDto.PitchSituacao,
            EpicoSituacao = artDto.EpicoSituacao,
            PitchDataAtualizacao = artDto.PitchDataAtualizacao,
            EpicoDataAtualizacao = artDto.EpicoDataAtualizacao,
            EpicoDataInicio = artDto.EpicoDataInicio,
            EpicoDataFim = artDto.EpicoDataFim
        };
    }
}
