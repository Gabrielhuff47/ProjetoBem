
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaART.BLL.Contratos;
using SistemaART.DAO.Dapper.Models;

namespace SistemaART.WebApp.Controllers;

[ApiController]
[Route("api/Usuario")]
public class AutenticacaoController : ControllerBase
{   
    private readonly IAutenticacaoService _autenticacaoService;
    private readonly ITokenService _tokenService;
    public AutenticacaoController(IAutenticacaoService autenticacaoService, ITokenService tokenService)
    {
        _autenticacaoService = autenticacaoService;
        _tokenService = tokenService;
    }

    [HttpPost("Entrar")]
    public async Task<IActionResult> Login([FromBody] Autenticacao Entrar)
    {
        var resultado = await _autenticacaoService.ValidarUsuario(Entrar.Usuario, Entrar.Senha);
         Console.WriteLine(resultado);
         if (resultado.Trim() != "Usuario logou")
         {Console.WriteLine(resultado + "RESULTADO2");

         return Unauthorized (new {Message = resultado.Trim()});
         }

         var token = _tokenService.GenerateToken(Entrar);
         Console.WriteLine($"Token gerado: {token}");
        return Ok(new {Message = "Login bem-sucedido", Token = token});
    
    }

    [HttpGet("Dados")]
        [Authorize]
        public IActionResult GetDados()
        {
            return Ok(new { Message = "Acesso autorizado", Data = "Aqui estão seus dados protegidos." });
        }
    }

   



