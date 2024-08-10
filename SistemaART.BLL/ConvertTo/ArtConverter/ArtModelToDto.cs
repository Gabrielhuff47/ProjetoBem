using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.ArtConverter;

public static class ArtModelToDto
{
    public static ArtDto Convert(this ArtModel art)
    {
        return new ArtDto
        {
            NomePitch = art.NomePitch, 
            NomeEpico = art.NomeEpico,
            NomeTime = art.NomeTime,
            NomeTribo = art.NomeTribo,
            NomeArea = art.NomeArea,
            Mensagem = art.Mensagem,
            PitchSituacao = art.PitchSituacao,
            EpicoSituacao = art.EpicoSituacao,
            PitchDataAtualizacao = art.PitchDataAtualizacao,
            EpicoDataAtualizacao = art.EpicoDataAtualizacao,
            EpicoDataInicio = art.EpicoDataInicio,
            EpicoDataFim = art.EpicoDataFim
        };
}
}