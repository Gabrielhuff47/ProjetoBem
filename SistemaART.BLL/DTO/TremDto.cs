namespace SistemaART.BLL.DTO;

public class TremDto
{
    public string NomeTime { get; set; }
    public string NomeArea { get; set; }
    public string NomeTribo { get; set; }
    public IList<BacklogDto> Backlogs{ get; set; }
    public IList<EmAndamentoDto> EmAndamentos{ get; set; }
    public IList<FinalizadoDto> Finalizados{ get; set; }
}
