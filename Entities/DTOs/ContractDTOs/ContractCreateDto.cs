//using Microsoft.AspNetCore.Http;
using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;


namespace Entities.DTOs.ContractDTOs
    {
        public class ContractCreateDto
        {
           
            public string ContractNumber { get; set; }

            [Required]
            public string ContractYear { get; set; }

            public string? TaxNumber { get; set; }

            [Required]
            public int OrganizationId { get; set; }

            public string? Subject { get; set; }

            public decimal? Amount { get; set; }

            public int? AmountTypeId { get; set; }

            public int? PaymentMethodId { get; set; }

            public DateTime? StartDate { get; set; }

            public DateTime? EndDate { get; set; }

            public int? CategoryId { get; set; }

            public int? CategoryTypeId { get; set; }

            public int? ContractStatusId { get; set; }

            public int? GuaranteeId { get; set; }

            public string? Fine { get; set; }

            public string? Notes { get; set; }
        


            ///// <summary>
            ///// Təşkilat üzrə əlaqələndirici şəxslərin ID-ləri
            ///// </summary>
            //public List<int>? SelectedOrgContactPersonIds { get; set; }

        ///// <summary>
        ///// İcra üzrə əlaqələndirici şəxslərin ID-ləri
        ///// </summary>
        //public List<int>? SelectedSecContactPersonIds { get; set; }

        ///// <summary>
        ///// Dövlət İmtahan Mərkəzi ilə əlaqəlidirmi?
        ///// </summary>
        //public bool IsDimRelated { get; set; }

        ///// <summary>
        ///// Yüklənən sənədlər (PDF, DOCX və s.)
        ///// </summary>

        }
    }


