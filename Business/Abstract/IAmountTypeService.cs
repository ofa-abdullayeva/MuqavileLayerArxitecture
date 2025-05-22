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
        //IDataResult<AmountTypeGetDto> GetById(int id);
        //IDataResult<List<AmountTypeGetDto>> GetAmountTypeDetails();
        //IResult Add(AmountType amountType);
        //IResult Update(AmountType amountType); 
        //IResult Delete(AmountType amountType); 

        //IDataResult<AmountType> GetByName(string name);
        //IDataResult<AmountType> GetByVoen(string voen);
    }
}
