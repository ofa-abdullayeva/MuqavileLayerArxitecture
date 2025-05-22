using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrate;
using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrate.EntityFramework.Context;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ContractContext>, ICategoryDal
    {
       


    }
}
