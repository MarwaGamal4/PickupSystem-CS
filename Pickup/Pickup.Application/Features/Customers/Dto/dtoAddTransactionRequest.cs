using Pickup.Application.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Dto
{
    public class dtoAddTransactionRequest
    {
        [Required]
        public int BranchId { get; set; }
        [Required]
        public int PlanID { get; set; }
        public int MealsCount { get; set; } = 0;
        public int SnacksCount { get; set; } = 0;
        public UploadRequest Invoice_Image { get; set; }
        public string Inv_url { get; set; }
    }
}
