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
    public async Task<IActionResult> Post(EpicoDto epico)
    {
        var usuarioAtualizacao = User.FindFirst(ClaimTypes.Name)?.Value;
        epico.UsuarioAtualizacao = usuarioAtualizacao.Trim();
        await _epicoService.GravarEpico(epico);
        return CreatedAtAction(nameof(Post), new { id = epico.IdEpico }, epico);

    }

    [HttpGet("id")]
    public async Task<IActionResult> Get(int id)
    {
        var epico = await _epicoService.ConsultarEpicoPorId(id);

        return Ok(epico);
    }

    [HttpGet("ListarEpicos")]
    public async Task<IActionResult> Get()
    {
        var usuario = User.FindFirst(ClaimTypes.Name)?.Value;
        var epicos = await _epicoService.ListarEpico();
        return Ok(epicos);
    }

    [HttpGet("ConsultaEpicoPorCaracteres")]
    public async Task<IActionResult> Get(string nomeFiltro)
    {
        var epicos = await _epicoService.ConsultarEpicoPorCaracteres(nomeFiltro);
        if (!epicos.Any())
        {
            return NotFound("Épico inexistente");
        }

        return Ok(epicos);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _epicoService.DeletarEpico(id);
        return NoContent();
    }
}
