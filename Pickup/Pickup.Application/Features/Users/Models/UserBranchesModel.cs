using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Users.Models
{
  public class UserBranchesModel
    {
        public int BranchId { get; set; }
        public bool Selected { get; set; }
        public string BranchName { get; set; }
    }
}
