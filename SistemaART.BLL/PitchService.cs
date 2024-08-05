using SistemaART.BLL.Contratos;
using SistemaART.BLL.ConvertTo.PitchConverter;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Repository.Contratos;

namespace SistemaART.BLL;

public class PitchService : IPitchService
{
    private readonly IPitchRepository _pitchrepository;
    public PitchService(IPitchRepository pitchRepository)
    {
        _pitchrepository = pitchRepository;
    }
    public async Task<IEnumerable<PitchReduzidoDto>> ListarPitchPorUsuario(string usuario)
    {
         var pitches = await _pitchrepository.ListarPitchPorUsuario(usuario);
        return pitches.Select(p => new PitchReduzidoDto
        {
            IdPitch = p.IdPitch,
            NomePitch = p.NomePitch,
            UsuarioAtualizacao = p.UsuarioAtualizacao
        });
    }//return (await _pitchrepository.ListarPitchPorUsuario(usuario)).Convert();
    
    public async Task<IEnumerable<PitchDto>> ListarPitchPorId(int id)
    {
        return (await _pitchrepository.ListarPitchPorId(id)).Convert();
    }

    public async Task<IEnumerable<PitchDto>> ListarTodos()
    {
        return (await _pitchrepository.ListarTodos()).Convert();
    }

}
