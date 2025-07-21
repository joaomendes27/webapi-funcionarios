using AutoMapper;
using PrimeiraAPI.Domain.DTOs;
using PrimeiraAPI.Domain.Models.FuncionarioAggregate;

namespace PrimeiraAPI.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Funcionario, FuncionarioDTO>().ForMember(dest => dest.NomeFuncionario, m => m.MapFrom(orig => orig.Nome));
        }
    }
}
