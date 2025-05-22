using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrganizationDal : IEntityRepository<Organization>
    {

        // Add any additional methods specific to Organization data access here
        List<OrganizationGetDto> GetOrganizationDetails();
    }
    
}
