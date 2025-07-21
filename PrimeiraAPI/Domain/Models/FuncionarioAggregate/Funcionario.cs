using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace PrimeiraAPI.Domain.Models.FuncionarioAggregate
{
    [Table("Funcionario")]
    public class Funcionario
    {
        public int Id {  get; private set; }
        
        public string Nome { get; private set; }

        public int Idade { get; private set; }

        public string Cargo { get; private set; }

        public Funcionario() { }

        public Funcionario (string nome, int idade, string cargo)
        {
            Nome = nome;
            Idade = idade;
            Cargo = cargo;
        }
    }
}
