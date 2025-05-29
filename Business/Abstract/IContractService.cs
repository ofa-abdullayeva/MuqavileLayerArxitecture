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

        IDataResult<ContractDetailsDto?> GetDetailsById(int contractId); 


        IDataResult<List<ContractListDto>> GetFilteredContracts(ContractFilterDto filter);

        IDataResult<int> Add(ContractCreateDto dto);

        IResult Update(ContractUpdateDto dto);
        IResult Delete(int contractId);

    }
}
