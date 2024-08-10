namespace SistemaART.DAO.Dapper.Models;

public class TremModel
{
    public string NomeTime { get; set; }
    public string NomeArea { get; set; }
    public string NomeTribo { get; set; }  
    public IList<BacklogModel> Backlogs { get; set; }
    public IList<EmAndamentoModel> EmAndamentos { get; set; }
    public IList<FinalizadoModel> finalizados { get; set; }
}
