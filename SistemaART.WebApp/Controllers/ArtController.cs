using Microsoft.AspNetCore.Authorization;
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
      [Authorize]
        public async Task<IActionResult> GetAllArt()
        {
            var arts = await _artService.ListarTodosAgrupados();
            return Ok(arts);
        }
        
}
