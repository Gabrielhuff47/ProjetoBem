namespace SistemaART.DAO.Dapper.Models;

public class FinalizadoModel
{
    public string NomeEpico { get; set; }
    public string Mensagem { get; set; } = "Em atraso";
    public DateTime? EpicoDataFim { get; set; }
}
