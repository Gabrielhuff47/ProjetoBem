using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo;

public static class UsuarioDtoToModel
{
    public static UsuarioModel Convert(this UsuarioDTO usuarioDto)
    {
        return new UsuarioModel
        {
            IdUsuario = usuarioDto.IdUsuario,
            Usuario = usuarioDto.Usuario,
            Nome = usuarioDto.Nome,
            Senha = usuarioDto.Senha,
            UsuarioAtualizacao = usuarioDto.UsuarioAtualizacao,
            DataAtualizacao = usuarioDto.DataAtualizacao
        };
    }
}
