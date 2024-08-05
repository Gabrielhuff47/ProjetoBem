using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EpicoConverter;

public static class EpicoModelToDto
{
            public static EpicoDto Convert(this EpicoModel epico)
    {
        return new EpicoDto
        {
            IdEpico = epico.IdEpico,
            IdPitch = epico.IdPitch,
            IdSituacao = epico.IdSituacao,
            NomeEpico = epico.NomeEpico,
            Descricao = epico.Descricao,
            DataInicio = epico.DataInicio,
            DataFim = epico.DataFim,
            UsuarioAtualizacao = epico.UsuarioAtualizacao,
            DataAtualizacao = epico.DataAtualizacao

        };
    }
}
