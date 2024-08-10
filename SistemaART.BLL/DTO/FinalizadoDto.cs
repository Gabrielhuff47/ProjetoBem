namespace SistemaART.BLL.DTO;

public class FinalizadoDto
{
    public string NomeEpico { get; set; }
    public string Mensagem { get; set; } = "Em atraso";
    public DateTime? EpicoDataFim { get; set; }
}
