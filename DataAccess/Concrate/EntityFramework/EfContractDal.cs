using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework.Context;
using Entities.Concrate;
using Entities.DTOs.ContractDTOs;
using Entities.DTOs.OrganizationDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contract = Entities.Concrate.Contract;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfContractDal : EfEntityRepositoryBase<Contract, ContractContext>, IContractDal
    {
        private readonly ContractContext _context;
        public EfContractDal(ContractContext context)
        {
            _context = context;
        }
        public List<ContractListDto> GetContractList()
        {
            return _context.Contracts
                .Include(c => c.Organization)
                .Include(c => c.AmountType)
                .Include(c => c.PaymentMethod)
                .Include(c => c.Category)
                .Include(c => c.CategoryType)
                .Include(c => c.ContractStatus)
                .Include(c => c.Guarantee)
                .Select(c => new ContractListDto
                {
                    ContractId = c.ContractId,
                    ContractNumber = c.ContractNumber,
                    ContractYear = c.ContractYear,
                    TaxNumber = c.TaxNumber,
                    OrganizationId = c.OrganizationId,  // Mütləq map et!
                    OrganizationName = c.Organization.OrganizationName,
                    Subject = c.Subject,
                    Amount = c.Amount,
                    AmountTypeName = c.AmountType.AmountTypeName,
                    PaymentMethodName = c.PaymentMethod.PaymentMethodName,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    CategoryName = c.Category.CategoryName,
                    CategoryTypeName = c.CategoryType.CategoryTypeName,
                    GuaranteeName = c.Guarantee.GuaranteeName,
                    StatusName = c.ContractStatus.ContractStatusName
                })
                .OrderByDescending(x => x.ContractId)
                .ToList();
        }

        public ContractDetailsDto? GetContractDetailsById(int contractId)
        {
            return _context.Contracts
                .Where(c => c.ContractId == contractId)
                .Include(c => c.Organization)
                .Include(c => c.AmountType)
                .Include(c => c.PaymentMethod)
                .Include(c => c.Category)
                .Include(c => c.CategoryType)
                .Include(c => c.ContractStatus)
                .Include(c => c.Guarantee)
                .Select(c => new ContractDetailsDto
                {
                    ContractId = c.ContractId,
                    ContractNumber = c.ContractNumber,
                    ContractYear = c.ContractYear,
                    TaxNumber = c.TaxNumber,
                    OrganizationId = c.OrganizationId,
                    OrganizationName = c.Organization.OrganizationName,
                    Subject = c.Subject,
                    Amount = c.Amount,
                    AmountTypeId = c.AmountTypeId,
                    AmountTypeName = c.AmountType.AmountTypeName,
                    PaymentMethodId = c.PaymentMethodId,
                    PaymentMethodName = c.PaymentMethod.PaymentMethodName,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    CategoryId = c.CategoryId,
                    CategoryName = c.Category.CategoryName,
                    CategoryTypeId = c.CategoryTypeId,
                    CategoryTypeName = c.CategoryType.CategoryTypeName,
                    ContractStatusId = c.ContractStatusId,
                    ContractStatusName = c.ContractStatus.ContractStatusName,
                    GuaranteeId = c.GuaranteeId,
                    GuaranteeName = c.Guarantee.GuaranteeName,
                    Fine = c.Fine,
                    Notes = c.Notes
                })
                .FirstOrDefault();
        }


        public IQueryable<Contract> GetQueryableContracts()
        {
            return _context.Contracts
                .Include(x => x.Organization)
                .Include(x => x.AmountType)
                .Include(x => x.PaymentMethod)
                .Include(x => x.Category)
                .Include(x => x.CategoryType)
                .Include(x => x.ContractStatus)
                .AsNoTracking(); // performans üçün
        }

        public List<ContractDetailsDto> GetContractDetails()
        {
            throw new NotImplementedException();
        }


    }
}
