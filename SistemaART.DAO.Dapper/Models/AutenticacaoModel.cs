using System.ComponentModel.DataAnnotations;

namespace SistemaART.DAO.Dapper.Models;

public class AutenticacaoModel
{
    [Required(ErrorMessage = "O Campo de usuário é obrigatório")]
    public string Usuario { get; set; }

    [Required(ErrorMessage = "O Campo de senha é obrigatório")]
    public string Senha { get; set; }
    
}
