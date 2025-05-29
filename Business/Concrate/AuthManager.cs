using Business.Abstract;
using Entities.Concrate;
using Entities.DTOs.UserDTOs;
using Core.Utilities.Results;

namespace Business.Concrate
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public User Login(UserForLoginDto userDto)
        {
            var result = _userService.Login(userDto.UserName, userDto.Password);

            if (!result.Success || result.Data == null)
            {
                throw new Exception("Invalid username or password");
            }

            return result.Data;
        }

        public string CreateToken(User user)
        {
            
            return "token";
        }
    }
}
