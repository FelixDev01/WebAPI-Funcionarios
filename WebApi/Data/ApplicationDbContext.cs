using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
