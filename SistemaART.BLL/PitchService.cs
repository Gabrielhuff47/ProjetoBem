using SistemaART.BLL.Contratos;
using SistemaART.BLL.ConvertTo.PitchConverter;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.BLL;

public class PitchService : IPitchService
{
    private readonly IPitchRepository _pitchRepository;
    public PitchService(IPitchRepository pitchRepository)
    {
        _pitchRepository = pitchRepository;
    }
    public async Task<IEnumerable<PitchReduzidoDto>> ListarPitchPorUsuario(string usuario)
    {
         var pitches = await _pitchRepository.ListarPitchPorUsuario(usuario);
        return pitches.Select(p => new PitchReduzidoDto
        {
            IdPitch = p.IdPitch,
            NomePitch = p.NomePitch,
        });
    }
    
    public async Task<PitchDto> ListarPitchPorId(int id)
    {
        return (await _pitchRepository.ListarPitchPorId(id)).Convert();
    }

    public async Task<IEnumerable<PitchDto>> ListarTodos()
    {
        return (await _pitchRepository.ListarTodos()).Convert();
    }

    public async Task AtualizarSituacaoPitch(int idPitch, int novaSituacao)
    {
        var pitch = await _pitchRepository.ListarPitchPorId(idPitch);
       if(pitch == null)
       {
         throw new ArgumentException("Pitch não encontrado");
       }
        pitch.Situacao = novaSituacao;
        await _pitchRepository.AtualizarPitchSituacao(pitch.IdPitch, novaSituacao);
    }
}
