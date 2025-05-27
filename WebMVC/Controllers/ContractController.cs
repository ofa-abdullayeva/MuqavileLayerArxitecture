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

        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _contractService.GetDetailsById(id);
            if (!result.Success || result.Data == null)
            {
                return NotFound(result.Message);
            }

            return View(result.Data); // Views/Contract/Details.cshtml faylına yönləndir
        }


        // 🟦 GET: Müqavilə siyahısı
        [HttpGet]
        public IActionResult Index(ContractFilterDto filter)
        {
            FillViewBags(); // ViewBag-ləri yüklə
            var list = _contractService.GetFilteredContracts(filter).Data;
            return View(list);
        }

     
        [HttpGet]
        public IActionResult Create()
        {
            FillViewBags();
            return View(); // Views/Contract/Create.cshtml olmalıdır
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _contractService.GetDetailsById(id);
            if (!result.Success || result.Data == null)
                return NotFound();

            FillViewBags();

            var viewModel = _mapper.Map<ContractUpdateViewModel>(result.Data);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ContractUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                FillViewBags();
                return View(model);
            }

            var dto = _mapper.Map<ContractUpdateDto>(model);
            var result = _contractService.Update(dto);

            if (!result.Success)
            {
                TempData["Error"] = result.Message;
                FillViewBags();
                return View(model);
            }

            TempData["Success"] = "Müqavilə uğurla yeniləndi.";
            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult Create(ContractCreateViewModel model)
        {
            Console.WriteLine("FORM GÖNDƏRİLDİ!"); // <-- buranı görürsə işləyir
            //if (!ModelState.IsValid)
            //{ 
            //    // Amma bu ife dusur. Ifin icinde de return var deye returndan sonra diger kodlar hec vaxt islemir.
            //    // Invalid olmasina sebeb sende ContrctCreateViewmodel organizationId kimi deyerler null gelir. Bu da invalid deyer sayilir
            //    FillViewBags();
            //    return View(model);
            //}

            // MAPPER istifadə et
            var dto = _mapper.Map<ContractCreateDto>(model);

            var result = _contractService.Add(dto); //Sende melumlatlari elave edilmesi ucun bu method gorulmelidi

            TempData["Success"] = "Müqavilə uğurla əlavə edildi.";
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
