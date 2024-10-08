using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaART.BLL.Contratos;


namespace SistemaART.WebApp.Controllers;

   [ApiController]
   [Route("Pitch")]
public class PitchController : ControllerBase
{
    private readonly IPitchService _pitchService;

    public PitchController(IPitchService pitchService)
    {
        _pitchService = pitchService;
    }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPitches()
        {
            var pitches = await _pitchService.ListarTodos();
            return Ok(pitches);
        }
        [HttpGet("ConsultaPitchUsuario")]
        [Authorize]
        public async Task<IActionResult> ListaPitchPorUsuario()
        {
                var usuario = User.FindFirst(ClaimTypes.Name)?.Value;
                var pitches = await _pitchService.ListarPitchPorUsuario(usuario);
                if (pitches == null || !pitches.Any())
                {
                    return NotFound("Nenhum pitch encontrado para o usuário.");
                }

                return Ok(pitches);  
        }
  
        [HttpGet("ConsultaPitchPorId")]
        [Authorize]
        public async Task<IActionResult> ListarPitchPorId(int id)
        {
            var pitch = await _pitchService.ListarPitchPorId(id);
            var usuario = User.FindFirst(ClaimTypes.Name)?.Value;

            if (pitch == null )
            {
                return NotFound("pitch não existente!");
            }

            if(pitch.SituacaoAndamento =="S" && pitch.UsuarioAtualizacao == usuario)
            {
                return Ok(pitch);
            } 
             return BadRequest("O pitch não permite que ÉPICO seja criado.");
        }
        // [HttpPut("AtualizarSituacao")]        //ESSE ENDPOINT VAI SAIR DO MEU CODIGO A ATUALIZACAO TEM QUE SER PELO EPICO
        // public async Task<IActionResult> AtualizarSituacaoPitch(int IdPitch, int novaSituacao)
        // {
        //     await _pitchService.AtualizarSituacaoPitch(IdPitch,novaSituacao);
        //     return Ok ("Situacao do pitch atualizada");
        // }

        [HttpPut("Robo")]
        public async Task<IActionResult> Put()
        {
            await _pitchService.AtualizarSituacaoPitchEmSegundoPlano();
            return Ok (new {Message = "Atualização enviada com sucesso"});
        }
        
    }   

