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

 
    [HttpPost]
    public IActionResult Login(UserForLoginDto userForLoginDto)
    {
        if (string.IsNullOrWhiteSpace(userForLoginDto.UserName) ||
            string.IsNullOrWhiteSpace(userForLoginDto.Password))
        {
            ViewBag.ErrorMessage = "İstifadəçi adı və ya şifrə boş ola bilməz.";
            return View(userForLoginDto);
        }

        var result = _userService.Login(userForLoginDto.UserName, userForLoginDto.Password);

        if (result.Success)
        {
            HttpContext.Session.SetString("UserName", result.Data.UserName);

            TempData["LoginSuccess"] = $"Xoş gəldiniz, {result.Data.UserName}!";
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
