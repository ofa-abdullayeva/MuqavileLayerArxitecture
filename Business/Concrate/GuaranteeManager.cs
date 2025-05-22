using Business.Abstract;
using Business.Constants;
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
    public class GuaranteeManager:IGuaranteeService
    {
        private readonly IGuaranteeDal _guaranteeDal;

        public GuaranteeManager(IGuaranteeDal guaranteeDal)
        {
            _guaranteeDal = guaranteeDal;
        }

        public IDataResult<List<Guarantee>> GetAll()
        {
            return new SuccessDataResult<List<Guarantee>>(
                _guaranteeDal.GetAll(),
                Messages.GuaranteeListed
            );
        }
    }
}
