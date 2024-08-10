namespace SistemaART.BLL.DTO;

public class ArtDto
{
    public string NomePitch { get; set; }
    public string? NomeEpico { get; set; }
    public string NomeTime { get; set; }
    public string NomeTribo { get; set; }   
    public string NomeArea { get; set; }
    public int PitchSituacao { get; set; }
    public int EpicoSituacao { get; set; }
    public string Mensagem { get; set; } = "Em atraso";
    public DateTime PitchDataAtualizacao { get; set; }
    public DateTime? EpicoDataAtualizacao { get; set; }
    public DateTime? EpicoDataInicio { get; set; }
    public DateTime? EpicoDataFim { get; set; }
}
