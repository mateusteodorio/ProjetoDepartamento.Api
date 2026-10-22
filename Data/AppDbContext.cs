using Microsoft.EntityFrameworkCore;
using ProjetoDepartamento.Api.Models;

namespace ProjetoDepartamento.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Departamento> Departamentos { get; set; }
        
       public DbSet<Funcionario>  Funcionarios { get; set; }

    }
}
