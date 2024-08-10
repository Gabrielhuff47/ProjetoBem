using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaART.BLL.Contratos;
using SistemaART.DAO.Dapper.Models;

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
            var pitchPorId = await _pitchService.ListarPitchPorId(id);
            var usuario = User.FindFirst(ClaimTypes.Name)?.Value;
            var pitch = pitchPorId.FirstOrDefault();

            if (pitch == null)
            {
                return NotFound("pitch não existente!");
            }

            if(pitch.SituacaoAndamento =="S" && pitch.UsuarioAtualizacao.Trim() == usuario.Trim())
            {
                return Ok(pitch);
            } 
             return BadRequest("O pitch não permite que ÉPICO seja criado.");
        }
    }   

