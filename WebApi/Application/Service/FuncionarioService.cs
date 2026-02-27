using WebApi.Application.DTOs;
using WebApi.Data;
using WebApi.Domain.Entities;

namespace WebApi.Application.Service
{
    public class FuncionarioService : IFuncionarioInterface
    {

        private readonly ApplicationDbContext _context;

        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FuncionarioResponseDTO> Criar(FuncionarioRequestDTO novoFuncionario)
        {
            var funcionario = new FuncionarioModel
            {
                Nome = novoFuncionario.Nome,
                Sobrenome = novoFuncionario.Sobrenome,
                Departamento = novoFuncionario.Departamento,
                Turno = novoFuncionario.Turno,
                Ativo = 1

            }; 
        }
        public Task<FuncionarioResponseDTO> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<FuncionarioResponseDTO>> BuscarTodos()
        {
            throw new NotImplementedException();
        }
        public Task<FuncionarioResponseDTO> Atualizar(int id, FuncionarioRequestDTO funcionarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Inativar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
