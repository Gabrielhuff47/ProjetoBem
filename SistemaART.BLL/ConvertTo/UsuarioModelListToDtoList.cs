using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.BLL.ConvertTo;

public static class UsuarioModelListToDtoList
{
        public static IEnumerable<UsuarioDTO> Convert(this IEnumerable<UsuarioModel> listaUsuarioModel)
        {
            return listaUsuarioModel.Select(usuarioModel => usuarioModel.Convert()).ToList();
        }

    // public static IEnumerable<UsuarioDTO> Convert(this IEnumerable<UsuarioModel> listaUsuarioModel)
    // {
    //     List<UsuarioDTO> listaUsuarioDTO = new ();

    //     foreach(var UsuarioModel in listaUsuarioModel)
    //     {
    //         listaUsuarioDTO.Add (new UsuarioDTO
    //         {
    //          IdUsuario = UsuarioModel.IdUsuario,
    //         Usuario = UsuarioModel.Usuario,
    //         Nome = UsuarioModel.Nome,
    //         Senha = UsuarioModel.Senha,
    //         UsuarioAtualizacao = UsuarioModel.UsuarioAtualizacao,
    //         DataAtualizacao = UsuarioModel.DataAtualizacao
    //         });
    //     }
    //     return listaUsuarioDTO;
    // }  
}
