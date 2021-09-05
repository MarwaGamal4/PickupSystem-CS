using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.DeliveryRpt.Queries.GetAll
{
   public class GetAllDeliveryRptResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string BranchName { get; set; }
        public string DeliveryName { get; set; }
        public DateTime PrintDate { get; set; }
        public string DriverLatitude { get; set; }
        public string DriverLongitude { get; set; }
        public DateTime ActionTime { get; set; }
        public string DeliveryNote { get; set; }
        public int DeliveryStatus { get; set; }
    }
}
