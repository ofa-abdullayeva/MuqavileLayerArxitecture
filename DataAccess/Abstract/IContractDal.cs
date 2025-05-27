using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs.ContractDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IContractDal : IEntityRepository<Contract>
    {
        List<ContractDetailsDto> GetContractDetails();
        ContractDetailsDto? GetContractDetailsById(int contractId); // <-- yeni method

        List<ContractListDto> GetContractList();

        IQueryable<Contract> GetQueryableContracts();

        //Contract? GetContractWithDetails(int contractId);
    }
}
