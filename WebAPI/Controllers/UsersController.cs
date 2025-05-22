using Business.Abstract;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserForLoginDto UserForLoginDto)
        {
            var result = _userService.Login(UserForLoginDto.UserName, UserForLoginDto.Password);
            if (result.Success)
            {
                return Ok(result.Data);  // Uğurlu login, istifadəçi məlumatları qaytarılır
            }
            return BadRequest(result.Message);  // Xəta mesajı
        }
    }
   
}
