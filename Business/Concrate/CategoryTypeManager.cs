using Business.Abstract;
using Business.Constants;
using Business.Concrate;

using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class CategoryTypeManager: ICategoryTypeService
    {
        private readonly ICategoryTypeDal _categoryTypeDal;

        public CategoryTypeManager(ICategoryTypeDal categoryTypeDal)
        {
            _categoryTypeDal = categoryTypeDal;
        }

        public IDataResult<List<CategoryType>> GetAll()
        {
            return new SuccessDataResult<List<CategoryType>>(
                _categoryTypeDal.GetAll(),
                Messages.CategoriesListed
            );
        }
    }
}
