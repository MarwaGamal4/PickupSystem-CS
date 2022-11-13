using Pickup.Application.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Dto
{
    public class dtoRenewPlanRequest
    {
        [Required]
        public int BranchId { get; set; }
        public string Notes { get; set; }
        public int MealsQty { get; set; } = 0;
        public int SnacksQty { get; set; } = 0;
        public decimal MealsAmount { get; set; } = decimal.Zero;
        public decimal SnacksAmount { get; set; } = decimal.Zero;
        public string RefrenceId { get; set; }
        public string Inv_Url { get; set; }
        [Required]
        public int PlanID { get; set; }
        
        public UploadRequest Invoice_Image { get; set; }
    }
}
