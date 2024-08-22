using MassTransit;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.ConvertTo.PitchConverter;
using SistemaART.BLL.DTO;
using SistemaART.DAO.Dapper.Repository.Contratos;
using SistemaART.QueuePitch;

namespace SistemaART.BLL;

public class PitchService : IPitchService
{
     private readonly ILogger<PitchService> _logger;
    private readonly IPitchRepository _pitchRepository;
    private readonly IBusControl _busControl;
    public PitchService(IPitchRepository pitchRepository, IBusControl busControl, ILogger<PitchService>logger)
    {
        _pitchRepository = pitchRepository;
        _busControl = busControl;
        _logger = logger;
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
        if (pitch == null)
        {
            throw new ArgumentException("Pitch não encontrado");
        }
        pitch.Situacao = novaSituacao;
        await _pitchRepository.AtualizarPitchSituacao(pitch.IdPitch, novaSituacao);
    }
    public async Task AtualizarSituacaoPitchEmSegundoPlano()
    {
        var pitchs = await _pitchRepository.ObterPitchs();
    
        if (pitchs.IsNullOrEmpty())
            return;

        foreach (var pitch in pitchs)
        {
            var mensagem = new PitchMensagemDto(pitch);
             _logger.LogInformation($"Publicando pitch Nome: {mensagem.NomePitch}");
             _logger.LogInformation($"Publicando pitch com Id: {mensagem.IdPitch}");
            await _busControl.Publish(mensagem);
             
            _logger.LogInformation($"Pitch com nome: {mensagem.NomePitch} publicado com sucesso.");
            _logger.LogInformation($"Pitch com o Id: {mensagem.IdPitch} publicado com sucesso.");
        }


    }
}
