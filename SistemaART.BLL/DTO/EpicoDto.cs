using System.Text.Json.Serialization;

namespace SistemaART.BLL.DTO;

public class EpicoDto
{

    public int IdEpico { get; set; }
    public string NomeEpico { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public int IdSituacao  { get; set;}
    public string Descricao { get; set; }
    public string UsuarioAtualizacao { get; set; }
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    public int IdPitch { get; set;}
}

