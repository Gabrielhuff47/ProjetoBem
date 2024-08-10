namespace SistemaART.BLL.DTO;

public class EpicoGravarDto
{
    public string NomeEpico { get; set; }
    public int IdPitch { get; set; }
    public int IdSituacao { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string UsuarioAtualizacao { get; set; }
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;

}
