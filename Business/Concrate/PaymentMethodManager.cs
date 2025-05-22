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
    public class PaymentMethodManager : IPaymentMethodService
    {
        private readonly IPaymentMethodDal _paymentMethodDal;

        public PaymentMethodManager(IPaymentMethodDal paymentMethodDal)
        {
            _paymentMethodDal = paymentMethodDal;
        }

        public IDataResult<List<PaymentMethod>> GetAll()
        {
            return new SuccessDataResult<List<PaymentMethod>>(_paymentMethodDal.GetAll());
        }
    }
}
