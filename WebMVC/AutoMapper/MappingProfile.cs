using AutoMapper;
using Entities.Concrate;
using Entities.DTOs.ContractDTOs;
using Entities.DTOs.OrganizationDTOs;

namespace WebMVC.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Contract üçün
            CreateMap<Contract, ContractCreateDto>();
            CreateMap<ContractCreateViewModel, ContractCreateDto>();

            CreateMap<ContractCreateDto, ContractCreateViewModel>();
            CreateMap<Contract, ContractDetailsDto>().ReverseMap();
            CreateMap<Contract, ContractCreateDto>().ReverseMap();
            CreateMap<Contract, ContractFilterDto>().ReverseMap();
            CreateMap<ContractFilterDto, Contract>().ReverseMap();
            CreateMap<Contract, ContractMiniDto>();

            // Organization üçün
            CreateMap<Organization, OrganizationGetDto>()
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(src => src.Contracts));

            CreateMap<Organization, OrganizationUpdateDto>().ReverseMap();
            CreateMap<OrganizationUpdateDto, Organization>().ReverseMap();
            CreateMap<OrganizationGetDto, OrganizationUpdateDto>().ReverseMap();
            CreateMap<Organization, OrganizationAddDto>().ReverseMap();
            CreateMap<OrganizationAddDto, Organization>().ReverseMap();
           


        }
    }
}
