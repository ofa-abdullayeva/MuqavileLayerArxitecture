using Entities.Concrate;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        User Login(UserForLoginDto userDto);
        string CreateToken(User user);
    }
}
