using System.Text.Json.Serialization;

namespace SistemaART.DAO.Dapper.Models;

public class EpicoModel
{   
    public int IdEpico { get; set; }
    public int IdPitch { get; set;}
     public int IdSituacao  { get; set;}
    public string NomeEpico { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string Descricao { get; set; }
    public string UsuarioAtualizacao { get; set; }
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    
}
