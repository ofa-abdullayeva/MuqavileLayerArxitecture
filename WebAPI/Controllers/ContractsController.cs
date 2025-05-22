
using Microsoft.AspNetCore.Mvc;
using Entities.Concrate;
using Business.Abstract;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }


        //public ContractsController(IContractService contractService)
        //{
        //    _contractService = contractService;
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var contracts = _contractService.GetAll();
        //    return Ok(contracts);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var contract = _contractService.GetById(id);
        //    if (contract == null)
        //        return NotFound();
        //    return Ok(contract);
        }

        //[HttpPost]
        //public IActionResult Add([FromBody] Contract contract)
        //{
        //    _contractService.Add(contract);
        //    return Ok();
        //}

        //[HttpPut]
        //public IActionResult Update([FromBody] Contract contract)
        //{
        //    _contractService.Update(contract);
        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _contractService.Delete(id);
        //    return Ok();
        //}
    
}
