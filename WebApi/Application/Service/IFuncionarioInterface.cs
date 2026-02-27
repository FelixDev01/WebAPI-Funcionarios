using WebApi.Application.DTOs;

namespace WebApi.Application.Service
{
    public interface IFuncionarioInterface
    {
        Task<IEnumerable<FuncionarioResponseDTO>> BuscarTodos();
        Task<FuncionarioResponseDTO> BuscarPorId(int id);
        Task<FuncionarioResponseDTO> Criar(FuncionarioRequestDTO novoFuncionario);
        Task<FuncionarioResponseDTO> Atualizar(int id, FuncionarioUpdateDTO funcionarioAtualizado);
        Task<bool> Inativar(int id);
    }
}
