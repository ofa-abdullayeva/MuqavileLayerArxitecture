using Business.Abstract;
using Business.Constants;
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
    public class ContractStatusManager: IContractStatusService
    {
        private readonly IContractStatusDal _contractStatusDal;

        public ContractStatusManager(IContractStatusDal contractStatusDal)
        {
            _contractStatusDal = contractStatusDal;
        }

        public IDataResult<List<ContractStatus>> GetAll()
        {
            return new SuccessDataResult<List<ContractStatus>>(_contractStatusDal.GetAll(), Messages.CategoriesListed);
        }
    }
}
