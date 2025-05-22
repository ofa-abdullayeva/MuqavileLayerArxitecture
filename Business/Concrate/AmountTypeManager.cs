using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class AmountTypeManager : IAmountTypeService
    {
        private readonly IAmountTypeDal _amountTypeDal;

        public AmountTypeManager(IAmountTypeDal amountTypeDal)
        {
            _amountTypeDal = amountTypeDal;
        }

        public IDataResult<List<AmountType>> GetAll()
        {
            var result = _amountTypeDal.GetAll();
            return new SuccessDataResult<List<AmountType>>(result);
        }
    }
}
