using Pickup.Application.Models;
using Pickup.Application.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Specifications
{
   public class DeliveryRPTFilterSpecification : HeroSpecification<DeliveryRPT>
    {
        public DeliveryRPTFilterSpecification(string searchString , int?[] status)
        {
            if (!string.IsNullOrEmpty(searchString) && status == null) 
            {
                Criteria = d => d.BranchName.Contains(searchString) || d.CustomerAddress.Contains(searchString) || d.CustomerName.Contains(searchString) || d.CustomerPhone.Contains(searchString) || d.DeliveryName.Contains(searchString);
            }
            else if (!string.IsNullOrEmpty(searchString) && status != null)
            {
                Criteria = d => (d.BranchName.Contains(searchString) || d.CustomerAddress.Contains(searchString) || d.CustomerName.Contains(searchString) || d.CustomerPhone.Contains(searchString) || d.DeliveryName.Contains(searchString)) && status.Contains(d.DeliveryStatus);
            }
            else if (string.IsNullOrEmpty(searchString) && status != null)
            {
                Criteria = d =>  status.Contains(d.DeliveryStatus);
            }
            else
            {
                Criteria = d => d.BranchName != null;
            }
            
        }
    }
}
