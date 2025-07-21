using PrimeiraAPI.Domain.DTOs;
using PrimeiraAPI.Domain.Models.FuncionarioAggregate;

namespace PrimeiraAPI.Infraestrutura.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void add(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }

        public List<FuncionarioDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Funcionarios
                .Skip((pageNumber - 1) * pageQuantity)
                .Take(pageQuantity)
                .Select(b => new FuncionarioDTO()
                {
                    Id = b.Id,
                    NomeFuncionario = b.Nome,
                    Cargo = b.Cargo,
                    Idade = b.Idade  
                })
                .ToList();
        }
        public Funcionario? Get(int id)
        {
            return _context.Funcionarios.Find(id);
        }
    }
}
