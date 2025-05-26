using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Application.Services;
using Sigma.Domain.Dtos;

namespace Sigma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("BuscarTodos")]
        public async Task<IActionResult> Buscar()
        {
            var usuarios = await _usuarioService.BuscarTodos();
            return Ok(usuarios);
        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] UsuarioDTo model)
        {
            return new JsonResult(await _usuarioService.Inserir(model));
        }
    }
}
