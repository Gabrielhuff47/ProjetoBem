using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo.EmAndamentoConverter;

public static class EmAndamentoModelToDto
{
    public static EmAndamentoDto Convert(this EmAndamentoModel emAndamento)
    {
        return new EmAndamentoDto
        {
            NomeEpico = emAndamento.NomeEpico,
            Mensagem = emAndamento.Mensagem
        };
    }
}
