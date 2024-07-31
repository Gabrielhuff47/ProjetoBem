
// using Microsoft.AspNetCore.Mvc;
// using SistemaART.BLL;
// using SistemaART.DAO.Dapper.Models;

// namespace SistemaART.WebApp.Controllers;

// [ApiController]
// [Route("api/Usuario")]
// public class AuthController : ControllerBase
// {   
//     private readonly IUsuarioService _usuarioService;

//     public AuthController(IUsuarioService usuarioService)
//     {
//         _usuarioService = usuarioService;
//     }

//     [HttpPost("Entrar")]
//     public async Task<IActionResult> Login([FromBody] Autenticação Entrar)
//     {
//         var resultado = await _usuarioService.ValidarUsuario(Entrar.Usuario, Entrar.Senha);
//          if (resultado != "OK")
//          return Unauthorized (new {Message = resultado});

//         return Ok(new {Message = "Login bem-sucedido"});
    
//     }


    // private readonly IUsuarioService _usuarioService;

    // public UsuarioModelController(IUsuarioService usuarioService)
    // {
    //     _usuarioService = usuarioService;
    // }

    //     //Get
    // [HttpGet]
    // public async Task<IActionResult> Get()
    // {
    //     var usuario = await _usuarioService.ListarUsuarios();
    //     return Ok(usuario);
    // }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> Get(int id)
    // {
    //     var usuario = await _usuarioService.RetornarUsuarioPorId(id);

    //     if (usuario == null)
    //       return NotFound();

    //     return Ok(usuario);
    // }

    // //Post
    // [HttpPost]
    // public async Task<IActionResult> Post(UsuarioDTO usuario)
    // {
    //   await _usuarioService.AdicionarUsuario(usuario);
    //   return CreatedAtAction(nameof(Get), new {Id = usuario.IdUsuario}, usuario);

    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> Put(int id, UsuarioDTO usuario)
    // {
    //     if(id != usuario.IdUsuario)
        
    //         return BadRequest("O id informado não igual ao id do usuáro ifnormado no objeto!");

    //     await _usuarioService.AtualizarUsuario(usuario);

    //     return NoContent();
        
    // }

    // [HttpDelete ("{id}")]
    // public async Task<IActionResult> Delete(int id) 
    // {
    //     await _usuarioService.DeletarUsuario(id);
    //     return NoContent();
    // }



//}
