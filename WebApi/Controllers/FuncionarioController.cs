using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DTOs;
using WebApi.Application.Service;

namespace WebApi.Controllers
{
    [Route("api/funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _service;

        public FuncionarioController(IFuncionarioInterface service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioResponseDTO>> CriarFuncionario(FuncionarioRequestDTO novoFuncionario)
        {
            var funcionarioCriado = await _service.Criar(novoFuncionario);
            return CreatedAtAction(nameof(BuscarPorId), new { id = funcionarioCriado.Id }, funcionarioCriado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioResponseDTO>>> BuscarTodos()
        {
            var funcionarios = await _service.BuscarTodos();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioResponseDTO>> BuscarPorId(int id)
        {
            try
            {
                var funcionario = await _service.BuscarPorId(id);
                return Ok(funcionario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FuncionarioResponseDTO>> Atualizar(int id, FuncionarioUpdateDTO funcionarioAtualizado)
        {
            try
            {
                var funcionario = await _service.Atualizar(id, funcionarioAtualizado);
                return Ok(funcionario);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Funcionário não encontrado.");
            }
        }

        [HttpPatch("inativar/{id}")]
        public async Task<ActionResult> Inativar(int id)
        {
            var sucesso = await _service.Inativar(id);
            if (!sucesso) return NotFound();

            return NoContent();
        }
    }
}
