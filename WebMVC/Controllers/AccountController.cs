using Business.Abstract;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    //[HttpPost]
    //public IActionResult Login(UserForLoginDto userForLoginDto)
    //{
    //    var result = _userService.Login(userForLoginDto.UserName, userForLoginDto.Password);
    //    if (result.Success)
    //    {
    //        // Sessiya və ya cookie burada qoyula bilər
    //        return RedirectToAction("Index", "Home");
    //    }

    //    ViewBag.Error = result.Message;
    //    return View();
    //}
    //[HttpPost]
    //public IActionResult Login(UserForLoginDto userForLoginDto)
    //{
    //    var result = _userService.Login(userForLoginDto.UserName, userForLoginDto.Password);

    //    if (result.Success)
    //    {
    //        // Məsələn sessiyaya yaz, sonra yönləndir
    //        HttpContext.Session.SetString("UserName", result.Data.UserName);
    //        return RedirectToAction("Index", "Home"); // Uğurlu giriş
    //    }

    //    // Xəta mesajı göstərmək üçün ViewBag istifadə edirik
    //    ViewBag.ErrorMessage = result.Message;
    //    return View(userForLoginDto); // səhifəyə yenidən qayıt
    //}

    [HttpPost]
    public IActionResult Login(UserForLoginDto userForLoginDto)
    {
        // 🟡 1. Əvvəlcə boşluğa qarşı yoxla
        if (string.IsNullOrWhiteSpace(userForLoginDto.UserName) ||
            string.IsNullOrWhiteSpace(userForLoginDto.Password))
        {
            ViewBag.ErrorMessage = "İstifadəçi adı və ya şifrə boş ola bilməz.";
            return View(userForLoginDto);
        }

        // 🟢 2. Əgər boş deyilsə, davam et
        var result = _userService.Login(userForLoginDto.UserName, userForLoginDto.Password);

        if (result.Success)
        {
            HttpContext.Session.SetString("UserName", result.Data.UserName);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = result.Message;
        return View(userForLoginDto);
    }


    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); // bütün session-ları sil
        return RedirectToAction("Login", "Account"); // Login səhifəsinə qaytar
    }


}
