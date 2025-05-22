using Core.DataAccess;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        //Task<bool>GetUserControl(string username, string password);
        User GetByUsernameAndPassword(string username, string password);
    }
}
