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

        
        [HttpPost]
        public IActionResult Add([FromBody] ContractCreateDto dto)
        {
            var result = _contractService.Add(dto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _contractService.GetContractList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

      
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _contractService.GetDetailsById(id);
            if (result.Success && result.Data != null)
                return Ok(result);

            return NotFound(result.Message ?? "Müqavilə tapılmadı");
        }


        [HttpPut]
        public IActionResult Update([FromBody] ContractUpdateDto dto)
        {
            var result = _contractService.Update(dto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _contractService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }



    }
}
