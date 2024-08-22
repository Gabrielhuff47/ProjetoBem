namespace SistemaART.DAO.Dapper.Models;

public class PitchMensagemModel
{
    public int IdPitch { get; set; }
    public int IdTime { get; set; }
    public int? IdEpico { get; set; }
    public string  NomePitch { get; set; }
    public int Situacao { get; set; }
    public string ManualAutomatica { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime? DataComite { get; set; }
    public string Descricao { get; set; }
    public string UsuarioAtualizacao { get; set; }
}
