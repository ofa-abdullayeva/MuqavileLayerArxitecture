using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

     

        public IDataResult<User> Login(string userName, string password)
        {
            var user = _userDal.Get(u => u.UserName == userName);

            if (user == null)
                return new ErrorDataResult<User>("İstifadəçi tapılmadı.");

           
            string hashedPassword = PasswordHasher.Hash(password);

            if (user.Password != hashedPassword)
                return new ErrorDataResult<User>("İstifadəçi adı və ya şifrə səhvdir.");

            return new SuccessDataResult<User>(user, "Giriş uğurludur.");
        }

    }

}
