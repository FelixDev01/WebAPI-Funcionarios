using System.ComponentModel.DataAnnotations;
using WebApi.Domain.Enums;

namespace WebApi.Application.DTOs
{
    public class FuncionarioUpdateDTO
    {
        [Required(ErrorMessage = "O campo do Departamento é obrigatório.")]
        public DepartamentoEnum Departamento { get; set; }
        [Required(ErrorMessage = "O campo do Turno é obrigatório.")]
        public TurnoEnum Turno { get; set; }
    }
}
