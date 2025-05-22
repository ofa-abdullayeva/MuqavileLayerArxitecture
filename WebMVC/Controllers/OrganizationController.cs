using AutoMapper;
using Business.Abstract;
using Entities.Concrate;
using Entities.DTOs.OrganizationDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;
        private readonly IMapper _mapper;

        public OrganizationController(IOrganizationService organizationService, IMapper mapper)
        {
            
            _organizationService = organizationService;
            _mapper = mapper;
        }

        public IActionResult Index(string searchName, string searchVoen)
        {
          
            var result = _organizationService.GetAll();
            var list = result.Data;

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                list = list.Where(x => x.OrganizationName != null &&
                                       x.OrganizationName.ToLower().Contains(searchName.ToLower()))
                           .ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchVoen))
            {
                list = list.Where(x => x.TaxNumber != null &&
                                       x.TaxNumber.Contains(searchVoen))
                           .ToList();
            }

            var dtoList = _mapper.Map<List<OrganizationGetDto>>(list);
            return View(dtoList);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _organizationService.GetById(id);
            if (!result.Success || result.Data == null)
            {
                TempData["Error"] = "Təşkilat tapılmadı.";
                return RedirectToAction("Index");
            }

            var dto = _mapper.Map<OrganizationGetDto>(result.Data);
            return View(dto);
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(OrganizationAddDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var nameExists = _organizationService.GetByName(dto.OrganizationName).Data != null;
            var voenExists = _organizationService.GetByVoen(dto.TaxNumber).Data != null;

            if (nameExists || voenExists)
            {
                TempData["Error"] = nameExists ? "Bu adda təşkilat artıq mövcuddur." : "Bu VÖEN ilə təşkilat artıq mövcuddur.";
                return RedirectToAction("Index");
            }

            var entity = _mapper.Map<Organization>(dto);
            var result = _organizationService.Add(entity);

            TempData[result.Success ? "Success" : "Error"] = result.Message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _organizationService.GetById(id);
            if (!result.Success || result.Data == null)
            {
                TempData["Error"] = "Təşkilat tapılmadı.";
                return RedirectToAction("Index");
            }
           
            var dto = _mapper.Map<OrganizationUpdateDto>(result.Data);
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(OrganizationUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var entity = _mapper.Map<Organization>(dto);
            var result = _organizationService.Update(entity);

            TempData[result.Success ? "Success" : "Error"] = result.Message;
            return RedirectToAction("Index");
        }

        //public IActionResult Delete(int id)
        //{
        //    var result = _organizationService.GetById(id);
        //    if (!result.Success || result.Data == null)
        //    {
        //        TempData["Error"] = "Təşkilat tapılmadı.";
        //        return RedirectToAction("Index");
        //    }

        //    var deleteResult = _organizationService.Delete(result.Data);
        //    TempData[deleteResult.Success ? "Success" : "Error"] = deleteResult.Message;

        //    return RedirectToAction("Index");
        //}
    }
}
