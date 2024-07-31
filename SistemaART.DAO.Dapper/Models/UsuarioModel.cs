namespace SistemaART.DAO.Dapper.Models;

public class UsuarioModel
{
    public int IdUsuario { get; set; }
    public string Usuario { get; set; } 
    public string Nome { get; set; } 
    public string Senha { get; set; } 
    public string UsuarioAtualizacao { get; set; } 
    public DateTime DataAtualizacao {get; set; } = DateTime.Now;
    public DateTime DataValidade { get; set; } 
}
