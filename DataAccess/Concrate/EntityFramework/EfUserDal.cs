using Core.DataAccess.EntityFramework;
using Core.Utilities.Security;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework.Context;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ContractContext>, IUserDal
    {
       
        public User GetByUsernameAndPassword(string username, string password)
        {
            using (var context = new ContractContext())
            {
                var hash = PasswordHasher.Hash(password);
                return context.Users
                    .Include(u => u.AccessLevel)
                    .FirstOrDefault(u => u.UserName == username && u.Password == hash);
            }
        }

    }
}
