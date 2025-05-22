using Core.Utilities.Results;
using Entities.DTOs.ContractDTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContractService
    {
        IDataResult<List<ContractListDto>> GetContractList();

        IDataResult<List<ContractListDto>> GetFilteredContracts(ContractFilterDto filter);

        IDataResult<int> Add(ContractCreateDto dto);

        //IDataResult<List<ContractListDto>> GetAll();
        //IDataResult<ContractListDto> GetById(int id);
        //IResult Add(Contract contract);
        //IResult Update(Contract contract);
        //IResult Delete(Contract contract);


        //IDataResult<ContractDetailsDto?> GetById(int contractId);
        ////ContractDetailsDto? GetById(int contractId);
        //IDataResult<List<ContractListDto>> GetAll();

        //IDataResult<List<ContractListDto>> GetByOrganizationId(int organizationId);
        //IDataResult<List<ContractListDto>> GetByUserId(int userId);
        //IDataResult<List<ContractListDto>> GetByStatus(string status);
        //IDataResult<List<ContractListDto>> GetByCategoryId(int categoryId);
        //IDataResult<List<ContractListDto>> GetByCategoryTypeId(int categoryTypeId);
        //IDataResult<List<ContractListDto>> GetByAmountTypeId(int amountTypeId);
        //IDataResult<List<ContractListDto>> GetByStartDate(DateTime startDate);
        //IDataResult<List<ContractListDto>> GetByEndDate(DateTime endDate);
        //IDataResult<List<ContractListDto>> GetByStartDateAndEndDate(DateTime startDate, DateTime endDate);
        //IDataResult<List<ContractListDto>> GetByContractYear(string contractYear);
        //IDataResult<List<ContractListDto>> GetByContractNumber(string contractNumber);
        //IDataResult<List<ContractListDto>> GetByTaxNumber(string taxNumber);
        //IDataResult<List<ContractListDto>> GetByOrganizationName(string organizationName);
        //IDataResult<List<ContractListDto>> GetBySubject(string subject);
        //IDataResult<List<ContractListDto>> GetByAmount(decimal amount);
        //IDataResult<List<ContractListDto>> GetByAmountTypeName(string amountTypeName);
        //IDataResult<List<ContractListDto>> GetByCategoryName(string categoryName);
        //IDataResult<List<ContractListDto>> GetByCategoryTypeName(string categoryTypeName);
        //IDataResult<List<ContractListDto>> GetByStatusAndCategoryId(string status, int categoryId);
        //IDataResult<List<ContractListDto>> GetByStatusAndCategoryTypeId(string status, int categoryTypeId);
        //IDataResult<List<ContractListDto>> GetByStatusAndAmountTypeId(string status, int amountTypeId);
        //IDataResult<List<ContractListDto>> GetByStatusAndStartDate(string status, DateTime startDate);
        //IResult Add(Contract contract);
        //IResult Update(Contract contract);
        //IResult Delete(int contractId);
    }
}
