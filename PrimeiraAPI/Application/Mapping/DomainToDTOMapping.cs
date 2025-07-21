using AutoMapper;
using PrimeiraAPI.Domain.DTOs;
using PrimeiraAPI.Domain.Models.FuncionarioAggregate;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping()
    {
        CreateMap<Funcionario, FuncionarioDTO>()
            .ConstructUsing(src => new FuncionarioDTO
            {
                Id = src.Id,
                NomeFuncionario = src.Nome,
                Idade = src.Idade,
                Cargo = src.Cargo
            });
    }
}
