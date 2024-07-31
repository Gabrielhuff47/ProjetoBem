namespace SistemaART.DAO.Dapper.Models;

public class PitchModel
{
    public int IdPitch { get; set;}
    public int IdTime  { get; set;}
    public string Nome { get; set; }
    public string Descricao { get; set; } 
    public DateTime DataComite { get; set; }
    public int Situacao { get; set; }
    public string UsuarioAtualizacao { get; set; }
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;
}
