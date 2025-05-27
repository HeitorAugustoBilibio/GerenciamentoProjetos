using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;

namespace Sigma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        [Route("BuscarTodos")]
        public async Task<IActionResult> Buscar()
        {
            var projetos = await _projetoService.BuscarTodos();
            return Ok(projetos);
        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> Inserir([FromBody] ProjetoNovoDto model)
        {
            return new JsonResult(await _projetoService.InserirProjeto(model));
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] ProjetoNovoDto model, int id)
        {
            if (model == null || id <= 0) return BadRequest("Dados inválidos para atualização.");
            var result = await _projetoService.EditarProjeto(model, id);
            if (!result) return StatusCode(500, "Erro ao atualizar o projeto.");
            return Ok("Projeto atualizado com sucesso.");
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            if (id <= 0) return BadRequest("ID inválido para exclusão.");
            var projeto = await _projetoService.DeletarProjeto(id);
            if (!projeto) return NotFound($"Projeto com ID {id} não encontrado, ou não pode ser excluido.");
            return Ok($"Projeto com ID {id} excluído com sucesso.");
        }
    }
}
