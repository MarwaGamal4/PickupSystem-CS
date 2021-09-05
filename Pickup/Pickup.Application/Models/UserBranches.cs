using Pickup.Application.Models.Identity;
using Pickup.Domain.Contracts;
using Pickup.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
   public class UserBranches : AuditableEntity
    {
        public int BranchId { get; set; }
        public string UserId { get; set; }


    }
}
