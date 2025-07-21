using PrimeiraAPI.Domain.DTOs;

namespace PrimeiraAPI.Domain.Models.FuncionarioAggregate
{
    public interface IFuncionarioRepository
    {
        void add (Funcionario funcionario);

        List<FuncionarioDTO> Get(int pageNumber,int pageQuantity);

        Funcionario? Get(int id);
    }
}
