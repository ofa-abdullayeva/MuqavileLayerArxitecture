using AutoMapper;
using Business.Abstract;
using Entities.DTOs.ContractDTOs;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebMVC.Controllers
{
    public class ContractController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IContractService _contractService;
        private readonly IOrganizationService _organizationService;
        private readonly IAmountTypeService _amountTypeService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryTypeService _categoryTypeService;
        private readonly IContractStatusService _contractStatusService;
        private readonly IGuaranteeService _guaranteeService;



        public ContractController(
            IMapper mapper,
            IContractService contractService,
            IOrganizationService organizationService,
            IAmountTypeService amountTypeService,
            IPaymentMethodService paymentMethodService,
            ICategoryService categoryService,
            ICategoryTypeService categoryTypeService,
            IContractStatusService contractStatusService,
            IGuaranteeService guaranteeService)
        {
            _mapper = mapper;
            _contractService = contractService;
            _organizationService = organizationService;
            _amountTypeService = amountTypeService;
            _paymentMethodService = paymentMethodService;
            _categoryService = categoryService;
            _categoryTypeService = categoryTypeService;
            _contractStatusService = contractStatusService;
            _guaranteeService = guaranteeService;
        }



        // 🟦 GET: Müqavilə siyahısı
        [HttpGet]
        public IActionResult Index(ContractFilterDto filter)
        {
            FillViewBags(); // ViewBag-ləri yüklə
            var list = _contractService.GetFilteredContracts(filter).Data;
            return View(list);
        }

        //// 🟩 POST: Yeni müqavilə əlavə etmək
        //[HttpPost]
        //public IActionResult Create(ContractCreateViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        FillViewBags(); // səhv olduqda ViewBag-ləri yenidən doldur
        //        return View(model);
        //    }

        //    // ViewModel → DTO mapping
        //    var dto = new ContractCreateDto
        //    {
        //        ContractNumber = model.ContractNumber,
        //        ContractYear = model.ContractYear,
        //        TaxNumber = model.TaxNumber,
        //        OrganizationId = model.OrganizationId,
        //        Subject = model.Subject,
        //        Amount = model.Amount,
        //        AmountTypeId = model.AmountTypeId,
        //        PaymentMethodId = model.PaymentMethodId,
        //        StartDate = model.StartDate,
        //        EndDate = model.EndDate,
        //        CategoryId = model.CategoryId,
        //        CategoryTypeId = model.CategoryTypeId,
        //        ContractStatusId = model.ContractStatusId,
        //        GuaranteeId = model.GuaranteeId,
        //        Fine = model.Fine,
        //        Notes = model.Notes,
        //        SelectedOrgContactPersonIds = model.SelectedOrgContactPersonIds,
        //        SelectedSecContactPersonIds = model.SelectedSecContactPersonIds,
        //        IsDimRelated = model.IsDimRelated
        //    };

        //    var result = _contractService.Add(dto);

        //    // Burada fayl yükləmə və əlaqəli şəxsləri əlavə etmək olacaq (növbəti addım)

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Create(ContractCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                FillViewBags();
                return View(model);
            }

            // MAPPER istifadə et
            var dto = _mapper.Map<ContractCreateDto>(model);

            var result = _contractService.Add(dto);

            return RedirectToAction("Index");
        }


        // ✅ ViewBag-ləri dolduran ortaq metod
        private void FillViewBags()
        {
            ViewBag.Organizations = _organizationService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.OrganizationId.ToString(),
                Text = x.OrganizationName
            }).ToList();

            ViewBag.AmountTypes = _amountTypeService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.AmountTypeId.ToString(),
                Text = x.AmountTypeName
            }).ToList();

            ViewBag.PaymentMethods = _paymentMethodService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.PaymentMethodId.ToString(),
                Text = x.PaymentMethodName
            }).ToList();

            ViewBag.Categories = _categoryService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName
            }).ToList();

            ViewBag.CategoryTypes = _categoryTypeService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.CategoryTypeId.ToString(),
                Text = x.CategoryTypeName
            }).ToList();

            ViewBag.ContractStatuses = _contractStatusService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.ContractStatusId.ToString(),
                Text = x.ContractStatusName
            }).ToList();

            ViewBag.Guarantees = _guaranteeService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.GuaranteeId.ToString(),
                Text = x.GuaranteeName
            }).ToList();
        }
    }
}
