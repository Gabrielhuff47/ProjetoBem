using Microsoft.AspNetCore.Mvc;
using SistemaART.BLL.Contratos;


namespace SistemaART.WebApp.Controllers;


[ApiController]
[Route("Art")]
public class ArtController : ControllerBase
{
    private readonly IArtService _artService;

    public ArtController(IArtService artService)
    {
        _artService = artService;
    }

      [HttpGet("all")]
        public async Task<IActionResult> GetAllArt()
        {
            var arts = await _artService.ListarTodosAgrupados();
            return Ok(arts);
        }
        
        [HttpGet("all/test")]
        public async Task<IActionResult> GetAllArtTest()
        {
            var pitches = await _artService.ListarTodos();
            return Ok(pitches);
        }

}
