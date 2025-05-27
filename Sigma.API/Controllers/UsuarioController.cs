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

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] UsuarioDTo model, int id)
        {
            if (model == null || id <= 0) return BadRequest("Dados inválidos para atualização.");
            var result = await _usuarioService.EditarProjeto(model, id);
            if (!result) return StatusCode(500, "Erro ao atualizar o projeto.");
            return Ok("Projeto atualizado com sucesso.");
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            if (id <= 0) return BadRequest("ID inválido para exclusão.");
            var usuario = await _usuarioService.DeletarUsuario(id);
            if (!usuario) return NotFound($"Usuário com ID {id} não encontrado, ou não pode ser excluído.");
            return Ok($"Usuário com ID {id} excluído com sucesso.");
        }
    }
}
