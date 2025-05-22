using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrate
{
    public class OrganizationManager : IOrganizationService
    {
        private readonly IOrganizationDal _organizationDal;

        public OrganizationManager(IOrganizationDal organizationDal)
        {
            _organizationDal = organizationDal;
        }

        public IResult Add(Organization organization)
        {
            try
            {
                _organizationDal.Add(organization);
                return new SuccessResult(Messages.OrganizationAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult("Əlavə zamanı xəta baş verdi: " + ex.Message);
            }
        }

        public IResult Update(Organization organization)
        {
            try
            {
                _organizationDal.Update(organization);
                return new SuccessResult(Messages.OrganizationUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult("Yenilənmə zamanı xəta baş verdi: " + ex.Message);
            }
        }

        public IResult Delete(Organization organization)
        {
            try
            {
                _organizationDal.Delete(organization);
                return new SuccessResult(Messages.OrganizationDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult("Silinmə zamanı xəta baş verdi: " + ex.Message);
            }
        }

        public IDataResult<List<OrganizationGetDto>> GetAll()
        {
            var data = _organizationDal.GetAll()
                .Select(o => new OrganizationGetDto
                {
                    OrganizationId = o.OrganizationId,
                    OrganizationName = o.OrganizationName,
                    TaxNumber = o.TaxNumber
                }).ToList();

            return new SuccessDataResult<List<OrganizationGetDto>>(data, Messages.OrganizationListed);
        }

        public IDataResult<OrganizationGetDto> GetById(int id)
        {
            var entity = _organizationDal.Get(o => o.OrganizationId == id);
            if (entity == null)
                return new ErrorDataResult<OrganizationGetDto>("Təşkilat tapılmadı");

            var dto = new OrganizationGetDto
            {
                OrganizationId = entity.OrganizationId,
                OrganizationName = entity.OrganizationName,
                TaxNumber = entity.TaxNumber
            };

            return new SuccessDataResult<OrganizationGetDto>(dto);
        }

        public IDataResult<List<OrganizationGetDto>> GetOrganizationDetails()
        {
            return new SuccessDataResult<List<OrganizationGetDto>>(_organizationDal.GetOrganizationDetails());
        }

        public IDataResult<Organization> GetByName(string name)
        {
            var result = _organizationDal.Get(o => o.OrganizationName == name);
            if (result == null)
                return new ErrorDataResult<Organization>("Təşkilat tapılmadı (ad ilə)");

            return new SuccessDataResult<Organization>(result);
        }

        public IDataResult<Organization> GetByVoen(string voen)
        {
            var result = _organizationDal.Get(o => o.TaxNumber == voen);
            if (result == null)
                return new ErrorDataResult<Organization>("Təşkilat tapılmadı (VÖEN ilə)");

            return new SuccessDataResult<Organization>(result);
        }
    }
}
