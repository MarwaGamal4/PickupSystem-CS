using Pickup.Domain.Contracts;
using Pickup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
   public class DeliveryRPT :  AuditableEntity
    {

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string BranchName { get; set; }
        public string DeliveryName { get; set; }
        public DateTime? PrintDate { get; set; }
        public string DriverLatitude { get; set; }
        public string DriverLongitude { get; set; }
        public DateTime? ActionTime { get; set; }
        public string DeliveryNote { get; set; }
        public int DeliveryStatus { get; set; }
        public string sender_from_driver { get; set; }

    }
}
