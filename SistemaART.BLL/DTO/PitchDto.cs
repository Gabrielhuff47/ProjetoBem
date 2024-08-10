namespace SistemaART.BLL.DTO;

public class PitchDto
{
    public int IdPitch { get; set; }
    public int IdTime { get; set; }
    public string NomePitch { get; set; }
    public string NomeTime { get; set; }
    public string Descricao { get; set; }
    public DateTime DataComite { get; set; }
    public int Situacao { get; set; }
    public string SituacaoDescricao { get; set; }
    public string SituacaoAndamento { get; set; }
    private string _usuarioAtualizacao;
    public string UsuarioAtualizacao
    {
        get => _usuarioAtualizacao;
        set => _usuarioAtualizacao = value?.Trim();
    }
    public DateTime DataAtualizacao { get; set; } = DateTime.Now;
}
