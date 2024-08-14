using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaART.BLL.Contratos;
using SistemaART.BLL.DTO;

namespace SistemaART.WebApp.Controllers;

[ApiController]
[Route("Epico")]
public class EpicoController : ControllerBase
{

    private readonly IEpicoService _epicoService;

    public EpicoController(IEpicoService epicoService)
    {
        _epicoService = epicoService;
    }

    [HttpPost("GravarEpico")]
    [Authorize]
    public async Task<IActionResult> Post(EpicoGravarDto epico)
    {
        var usuarioAtualizacao = User.FindFirst(ClaimTypes.Name)?.Value;
        epico.UsuarioAtualizacao = usuarioAtualizacao.Trim();
        await _epicoService.GravarEpico(epico);
        return CreatedAtAction(nameof(Post), new { }, epico);

    }

    [HttpGet("id")]
    [Authorize]
    public async Task<IActionResult> Get(int id)
    {
        var usuario = User.FindFirst(ClaimTypes.Name)?.Value.Trim();
        var epico = await _epicoService.ConsultarEpicoPorId(id);

        if (epico == null)
        {
            return NotFound();
        }

        if (epico.UsuarioAtualizacao.Trim() != usuario)
        {
            return Unauthorized();
        }

        return Ok(epico);
    }

    [HttpGet("ListarEpicos")]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var usuario = User.FindFirst(ClaimTypes.Name)?.Value.Trim();
        var epicosDoUsuario = await _epicoService.ListarEpico(usuario);

        return Ok(epicosDoUsuario);
    }

    [HttpGet("ConsultaEpicoPorCaracteres")]
    [Authorize]
    public async Task<IActionResult> Get(string nomeFiltro)
    {
        var usuarioAtualizacao = User.FindFirst(ClaimTypes.Name)?.Value.Trim();
        var epicos = await _epicoService.ConsultarEpicoPorCaracteres(nomeFiltro, usuarioAtualizacao);
        if (!epicos.Any())
        {
            return NotFound("Épico inexistente");
        }

        return Ok(epicos);

    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = User.FindFirst(ClaimTypes.Name)?.Value.Trim();
        var epico = await _epicoService.ConsultarEpicoPorId(id);

        if (epico == null)
        {
            return NotFound("Épico não encontrado.");
        }

        if (epico.UsuarioAtualizacao.Trim() != usuario)
        {
            return Unauthorized("Voce nao tem permissão para deletar esse epico!");
        }

        await _epicoService.DeletarEpico(id);
        return NoContent();
    }
}
