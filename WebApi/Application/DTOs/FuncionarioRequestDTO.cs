using System.ComponentModel.DataAnnotations;
using WebApi.Domain.Enums;

namespace WebApi.Application.DTOs
{
    public class FuncionarioRequestDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O campo do Departamento é obrigatório.")]
        public DepartamentoEnum Departamento { get; set; }
        [Required(ErrorMessage = "O campo do Turno é obrigatório.")]
        public TurnoEnum Turno { get; set; }
    }
}
