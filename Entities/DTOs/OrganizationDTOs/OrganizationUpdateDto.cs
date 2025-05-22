using Core.Entities;

namespace Entities.DTOs.OrganizationDTOs
{
    public class OrganizationUpdateDto : IDto
    {
        public int OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
        public string? TaxNumber { get; set; }
        public string? ContractYear { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? StreetAptNo { get; set; }
    }
}
