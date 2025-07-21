using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeiraAPI.Application.ViewModel;
using PrimeiraAPI.Domain.DTOs;
using PrimeiraAPI.Domain.Models.FuncionarioAggregate;

namespace PrimeiraAPI.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiVersion("1.0")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ILogger<FuncionarioController> _logger;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioRepository employeeRepository, ILogger<FuncionarioController> logger, IMapper mapper)
        {
            _funcionarioRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] FuncionarioViewModel funcionarioViewModel)
        {
            var funcionario = new Funcionario(
                funcionarioViewModel.Nome,
                funcionarioViewModel.Idade,
                funcionarioViewModel.Cargo
            );

            _funcionarioRepository.add(funcionario);

            return Ok();
        }

        [HttpGet]
        [HttpGet]
        public IActionResult GetAll(int pageNumber, int pageQuantity)
        {
            var funcionarios = _funcionarioRepository.Get(pageNumber, pageQuantity);
            var funcionariosDTO = _mapper.Map<List<FuncionarioDTO>>(funcionarios);
            return Ok(funcionariosDTO);
        }


        [HttpGet("{id}")]
        public IActionResult Search(int id)
        {
            var funcionario = _funcionarioRepository.Get(id);
            var funcionarioDTOS = _mapper.Map<FuncionarioDTO>(funcionario);
            return Ok(funcionarioDTOS);
        }
    }
}
