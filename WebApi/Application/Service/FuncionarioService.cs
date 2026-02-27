using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
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
            _context.Add(funcionario);
            await _context.SaveChangesAsync();

            return new FuncionarioResponseDTO
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                Departamento = funcionario.Departamento,
                Turno = funcionario.Turno,
                Ativo = funcionario.Ativo,
                DataCriacao = funcionario.DataCriacao,
                DataAlteracao = funcionario.DataAlteracao
            };
        }
    
        public async Task<IEnumerable<FuncionarioResponseDTO>> BuscarTodos()
        {
            var funcionarios = await _context.Funcionarios.ToListAsync();
            return funcionarios.Select(f => new FuncionarioResponseDTO
            {
                Id = f.Id,
                Nome = f.Nome,
                Sobrenome = f.Sobrenome,
                Departamento = f.Departamento,
                Turno = f.Turno,
                Ativo = f.Ativo,
                DataCriacao = f.DataCriacao,
                DataAlteracao = f.DataAlteracao
            });
        }

        public async Task<FuncionarioResponseDTO> BuscarPorId(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
            
            if (funcionario == null)
                return null;

            return new FuncionarioResponseDTO
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                Departamento = funcionario.Departamento,
                Turno = funcionario.Turno,
                Ativo = funcionario.Ativo,
                DataCriacao = funcionario.DataCriacao,
                DataAlteracao = funcionario.DataAlteracao
            };
        }
        public async Task<FuncionarioResponseDTO> Atualizar(int id, FuncionarioRequestDTO funcionarioAtualizado)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
            
            if (funcionario == null)
                return null;

            funcionario.Nome = funcionarioAtualizado.Nome;
            funcionario.Sobrenome = funcionarioAtualizado.Sobrenome;
            funcionario.Departamento = funcionarioAtualizado.Departamento;
            funcionario.Turno = funcionarioAtualizado.Turno;
            funcionario.DataAlteracao = DateTime.Now.ToLocalTime();      
        
            await _context.SaveChangesAsync();
            return new FuncionarioResponseDTO
            {
                Id = funcionario.Id,
                Nome = funcionario.Nome,
                Sobrenome = funcionario.Sobrenome,
                Departamento = funcionario.Departamento,
                Turno = funcionario.Turno,
                Ativo = funcionario.Ativo,
                DataCriacao = funcionario.DataCriacao,
                DataAlteracao = funcionario.DataAlteracao
            };
        }

        public async Task<bool> Inativar(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);

            if (funcionario == null)
                return false;

            funcionario.Ativo = 0;
            funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
