using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
   public class PlanType : AuditableEntity
    {
        public string PlanTypeName { get; set; }
        public string PlanSlogan { get; set; }
    }
}
