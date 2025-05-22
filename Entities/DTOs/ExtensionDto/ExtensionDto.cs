using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Extension
{
    public class ExtensionDto
    {
        public int Id { get; set; }
        public DateTime? NewEndDate { get; set; }
        public string? Reason { get; set; }
    }
}
