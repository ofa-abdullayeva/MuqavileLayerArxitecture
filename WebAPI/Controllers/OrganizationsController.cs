using Business.Abstract;
using Entities.Concrate;
using Entities.DTOs.OrganizationDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _organizationService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _organizationService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

 
        [HttpPost("add")]
        public IActionResult Add([FromBody] OrganizationAddDto dto)
        {
            var organization = new Organization
            {
                TaxNumber = dto.TaxNumber,
                OrganizationName = dto.OrganizationName,
                ContractYear = dto.ContractYear,
                Country = dto.Country,
                City = dto.City,
                StreetAptNo = dto.StreetAptNo
            };

            var result = _organizationService.Add(organization);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _organizationService.GetOrganizationDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }


}
