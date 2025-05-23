using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework.Context;
using Entities.Concrate;
using Entities.DTOs.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfOrganizationDal : EfEntityRepositoryBase<Organization, ContractContext>, IOrganizationDal
    {
        public List<OrganizationGetDto> GetOrganizationDetails()
        {
            using (var context = new ContractContext())
            {
                return context.Organizations
                    .Select(o => new OrganizationGetDto
                    {
                        OrganizationId = o.OrganizationId,
                        OrganizationName = o.OrganizationName,
                        TaxNumber = o.TaxNumber,
                        // Əgər Organization cədvəldə əlavə sahələr varsa, buraya əlavə edə bilərsən.
                    })
                    .ToList();
            }
        }

        public void Update(Organization entity)
        {
            using (var context = new ContractContext())
            {
                var existing = context.Organizations.FirstOrDefault(x => x.OrganizationId == entity.OrganizationId);
                if (existing != null)
                {
                    context.Entry(existing).CurrentValues.SetValues(entity);
                    context.SaveChanges(); // Ən önəmli hissə
                }
            }
        }


    }

}
 