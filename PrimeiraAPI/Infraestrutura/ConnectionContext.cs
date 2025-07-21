using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Domain.Models.FuncionarioAggregate;
using PrimeiraAPI.Domain.Models.CompanyAggregate;

namespace PrimeiraAPI.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
    "Server=localhost\\SQLEXPRESS;Database=FuncionariosBD;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
