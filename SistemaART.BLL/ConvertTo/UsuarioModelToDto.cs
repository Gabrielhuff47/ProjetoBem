using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo;

public static class UsuarioModelToDto
{
    public static UsuarioDTO Convert (this UsuarioModel usuarioModel)
    {
        return new UsuarioDTO
        {
            IdUsuario = usuarioModel.IdUsuario,
            Usuario = usuarioModel.Usuario,
            Nome = usuarioModel.Nome,
            Senha = usuarioModel.Senha,
            UsuarioAtualizacao = usuarioModel.UsuarioAtualizacao,
            DataAtualizacao = usuarioModel.DataAtualizacao
        };
    }
}
