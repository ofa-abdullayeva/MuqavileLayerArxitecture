using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs.ContractDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrate
{
    public class ContractManager : IContractService
    {
        private readonly IContractDal _contractDal;

        public ContractManager(IContractDal contractDal)
        {
            _contractDal = contractDal;
        }

        public IDataResult<List<ContractListDto>> GetContractList()
        {
            var result = _contractDal.GetContractList();
            return new SuccessDataResult<List<ContractListDto>>(result);
        }

        public IDataResult<List<ContractListDto>> GetFilteredContracts(ContractFilterDto filter)
        {
            var query = _contractDal.GetQueryableContracts();

            if (!string.IsNullOrWhiteSpace(filter.ContractNumber))
                query = query.Where(x => x.ContractNumber.ToLower().Contains(filter.ContractNumber.ToLower().Trim()));

            if (!string.IsNullOrWhiteSpace(filter.ContractYear))
                query = query.Where(x => x.ContractYear.Contains(filter.ContractYear));

            if (!string.IsNullOrWhiteSpace(filter.TaxNumber))
                query = query.Where(x => x.TaxNumber.Contains(filter.TaxNumber));

            if (filter.OrganizationId.HasValue)
                query = query.Where(x => x.OrganizationId == filter.OrganizationId.Value);

            if (!string.IsNullOrWhiteSpace(filter.Subject))
                query = query.Where(x => x.Subject.ToLower().Contains(filter.Subject.ToLower()));

            if (filter.AmountMin.HasValue)
                query = query.Where(x => x.Amount >= filter.AmountMin.Value);

            if (filter.AmountMax.HasValue)
                query = query.Where(x => x.Amount <= filter.AmountMax.Value);

            if (filter.AmountTypeId.HasValue)
                query = query.Where(x => x.AmountTypeId == filter.AmountTypeId.Value);

            if (filter.PaymentMethodId.HasValue)
                query = query.Where(x => x.PaymentMethodId == filter.PaymentMethodId.Value);

            if (filter.StartDate.HasValue)
                query = query.Where(x => x.StartDate >= filter.StartDate.Value);

            if (filter.EndDate.HasValue)
                query = query.Where(x => x.EndDate <= filter.EndDate.Value);

            if (filter.CategoryId.HasValue)
                query = query.Where(x => x.CategoryId == filter.CategoryId.Value);

            if (filter.CategoryTypeId.HasValue)
                query = query.Where(x => x.CategoryTypeId == filter.CategoryTypeId.Value);

            if (filter.ContractStatusId.HasValue)
                query = query.Where(x => x.ContractStatusId == filter.ContractStatusId.Value);

            var result = query.Select(x => new ContractListDto
            {
                ContractId = x.ContractId,
                ContractNumber = x.ContractNumber,
                ContractYear = x.ContractYear,
                TaxNumber = x.TaxNumber,
                OrganizationId = x.OrganizationId,
                OrganizationName = x.Organization.OrganizationName,
                Subject = x.Subject,
                Amount = x.Amount,
                AmountTypeId = x.AmountTypeId.Value,
                AmountTypeName = x.AmountType.AmountTypeName,
                PaymentMethodId = x.PaymentMethodId.Value,
                PaymentMethodName = x.PaymentMethod.PaymentMethodName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                CategoryId = x.CategoryId.Value,
                CategoryName = x.Category.CategoryName,
                CategoryTypeId = x.CategoryTypeId.Value,
                CategoryTypeName = x.CategoryType.CategoryTypeName,
                ContractStatusId = x.ContractStatusId.Value,
                StatusName = x.ContractStatus.ContractStatusName,
                GuaranteeName = x.Guarantee != null ? x.Guarantee.GuaranteeName : null
            }).ToList();

            return new SuccessDataResult<List<ContractListDto>>(result);
        }

        public IDataResult<int> Add(ContractCreateDto dto)
        {
            var contract = new Contract
            {
                ContractNumber = dto.ContractNumber,
                ContractYear = dto.ContractYear,
                TaxNumber = dto.TaxNumber,
                OrganizationId = dto.OrganizationId,
                Subject = dto.Subject,
                Amount = dto.Amount,
                AmountTypeId = dto.AmountTypeId,
                PaymentMethodId = dto.PaymentMethodId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CategoryId = dto.CategoryId,
                CategoryTypeId = dto.CategoryTypeId,
                ContractStatusId = dto.ContractStatusId,
                GuaranteeId = dto.GuaranteeId,
                Fine = dto.Fine,
                Notes = dto.Notes
                // Əgər əlavə əlaqəli cədvəllər varsa (şəxslər, fayllar və s.), sonra əlavə ediləcək
            };

            _contractDal.Add(contract);

            return new SuccessDataResult<int>(contract.ContractId, "Müqavilə əlavə olundu.");
        }
    }
}
