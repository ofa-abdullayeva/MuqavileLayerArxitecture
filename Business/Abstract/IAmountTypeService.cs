using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAmountTypeService
    {
        IDataResult<List<AmountType>> GetAll();
       
    }
}
