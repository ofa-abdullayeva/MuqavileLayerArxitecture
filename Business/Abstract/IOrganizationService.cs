using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrganizationService
    {
        IDataResult<List<OrganizationGetDto>> GetAll();
        IDataResult<Organization> GetById(int id);
        IDataResult<List<OrganizationGetDto>> GetOrganizationDetails();
        IResult Update(OrganizationUpdateDto dto);

        IResult Add(Organization organization);
        //IResult Update(Organization organization); 
        IResult Delete(Organization organization); 


        IDataResult<Organization> GetByName(string name);
        IDataResult<Organization> GetByVoen(string voen);
    }
}
