using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EpicoConverter;

public static class EpicoDtoToModel
{
        public static EpicoModel Convert(this EpicoDto epicoDto)
    {
        return new EpicoModel
        {
            IdEpico = epicoDto.IdEpico,
            IdPitch = epicoDto.IdPitch,
            IdSituacao = epicoDto.IdSituacao,
            NomeEpico = epicoDto.NomeEpico,
            Descricao = epicoDto.Descricao,
            DataInicio = epicoDto.DataInicio,
            DataFim = epicoDto.DataFim,
            UsuarioAtualizacao = epicoDto.UsuarioAtualizacao,
            DataAtualizacao = epicoDto.DataAtualizacao

        };
    }
}
