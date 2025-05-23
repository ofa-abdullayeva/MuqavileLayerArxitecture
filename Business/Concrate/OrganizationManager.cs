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

        public IResult Update(OrganizationUpdateDto dto)
        {
            try
            {
                var existing = _organizationDal.Get(o => o.OrganizationId == dto.OrganizationId);
                if (existing == null)
                    return new ErrorResult("Təşkilat tapılmadı");

                // DTO-dan gələn məlumatlarla güncəllə
                existing.OrganizationName = dto.OrganizationName;
                existing.TaxNumber = dto.TaxNumber;
                existing.ContractYear = dto.ContractYear;
                existing.Country = dto.Country;
                existing.City = dto.City;
                existing.StreetAptNo = dto.StreetAptNo;

                _organizationDal.Update(existing);
                return new SuccessResult("Təşkilat yeniləndi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Xəta baş verdi: " + ex.Message);
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

        //public IDataResult<List<OrganizationGetDto>> GetAll()
        //{
        //    var data = _organizationDal.GetAll()
        //        .Select(o => new OrganizationGetDto
        //        {
        //            OrganizationId = o.OrganizationId,
        //            OrganizationName = o.OrganizationName,
        //            TaxNumber = o.TaxNumber
        //        }).ToList();

        //    return new SuccessDataResult<List<OrganizationGetDto>>(data, Messages.OrganizationListed);
        //}
       

        public IDataResult<Organization> GetById(int id)
        {
            var entity = _organizationDal.Get(o => o.OrganizationId == id);
            if (entity == null)
                return new ErrorDataResult<Organization>("Təşkilat tapılmadı");

            return new SuccessDataResult<Organization>(entity);
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

        public IDataResult<List<OrganizationGetDto>> GetAll()
        {
            
                var entities = _organizationDal.GetAll();

                var dtoList = entities.Select(o => new OrganizationGetDto
                {
                    OrganizationId = o.OrganizationId,
                    OrganizationName = o.OrganizationName,
                    TaxNumber = o.TaxNumber,
                    ContractYear = o.ContractYear,
                    Country = o.Country,
                    City = o.City,
                    StreetAptNo = o.StreetAptNo,
                    Contracts = o.Contracts?.Select(c => new ContractMiniDto
                    {
                        ContractId = c.ContractId,
                        ContractNumber = c.ContractNumber,
                        Amount = c.Amount,
                        StartDate = c.StartDate
                    }).ToList()
                }).ToList();

                return new SuccessDataResult<List<OrganizationGetDto>>(dtoList, "Təşkilatlar siyahılandı.");
            }

        
    }
}
