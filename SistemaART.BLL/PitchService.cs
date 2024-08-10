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
    
    public async Task<IEnumerable<PitchDto>> ListarPitchPorId(int id)
    {
        return (await _pitchRepository.ListarPitchPorId(id)).Convert();
    }

    public async Task<IEnumerable<PitchDto>> ListarTodos()
    {
        return (await _pitchRepository.ListarTodos()).Convert();
    }

}
