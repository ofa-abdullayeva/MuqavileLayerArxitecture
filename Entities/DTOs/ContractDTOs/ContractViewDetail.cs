using Entities.DTOs.ContractPerson;
using Entities.DTOs.ContractAttachFile;
using Entities.DTOs.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ContractDTOs
{
    public class ContractViewDetail
    {
        public int ContractId { get; set; }

        public string? ContractYear { get; set; }

        public string? ContractNumber { get; set; }

        public string? TaxNumber { get; set; }

        public int? OrganizationId { get; set; }
        public string? OrganizationName { get; set; }  

        public string? Subject { get; set; }

        public decimal? Amount { get; set; }

        public int? AmountTypeId { get; set; }
        public string? AmountTypeName { get; set; } 

        public int? PaymentMethodId { get; set; }
        public string? PaymentMethodName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public int? CategoryTypeId { get; set; }
        public string? CategoryTypeName { get; set; }

        public int? ContractStatusId { get; set; }
        public string? StatusName { get; set; }

        public int? GuaranteeId { get; set; }
        public string? GuaranteeName { get; set; }

        public string? Fine { get; set; }

        public string? Notes { get; set; }

      
        public List<ContractPersonDto>? ContactPersonsOrg { get; set; }
        public List<ContractPersonDto>? ContactPersonsSec { get; set; }
        public List<ContractAttachFileDto>? AttachFiles { get; set; }
        public List<ExtensionDto>? Extensions { get; set; }
        //public List<InvoiceDto>? Invoices { get; set; }
    }
}
