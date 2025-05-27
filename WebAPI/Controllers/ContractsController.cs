using Microsoft.AspNetCore.Mvc;
using Entities.Concrate;
using Business.Abstract;
using Entities.DTOs.ContractDTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        // 🟢 POST: api/contracts
        [HttpPost]
        public IActionResult Add([FromBody] ContractCreateDto dto)
        {
            var result = _contractService.Add(dto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        // 🟢 GET: api/contracts
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _contractService.GetContractList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        // 🟢 GET: api/contracts/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Əgər ContractDetailsDto əlavə etmisənsə istifadə edə bilərsən.
            return Ok(); // implement et
        }

        // Əlavə olaraq PUT və DELETE lazım olarsa aşağıda əlavə et.
    }
}
