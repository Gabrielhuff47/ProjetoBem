using SistemaART.DAO.Dapper.Models;

namespace SistemaART.QueuePitch;

public class PitchMensagemDto
{
    public int IdPitch { get; set; }
    public int IdTime { get; set; }
    public int? IdEpico { get; set; }
    public string NomePitch { get; set; }
    public int Situacao { get; set; }
    public string ManualAutomatica { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public DateTime? DataComite { get; set; }
    public string Descricao { get; set; }
    public string UsuarioAtualizacao { get; set; }



public PitchMensagemDto(PitchMensagemModel pitch)
{
    IdPitch = pitch.IdPitch;
    IdTime = pitch.IdTime;
    IdEpico = pitch.IdEpico;
    NomePitch = pitch.NomePitch;
    Situacao = pitch.Situacao;
    ManualAutomatica = pitch.ManualAutomatica;
    DataAtualizacao = pitch.DataAtualizacao;
    DataComite = pitch.DataComite;
    Descricao = pitch.Descricao;
    UsuarioAtualizacao = pitch.UsuarioAtualizacao;
    
}
}