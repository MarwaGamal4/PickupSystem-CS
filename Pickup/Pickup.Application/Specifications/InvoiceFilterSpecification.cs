using Pickup.Application.Models;
using Pickup.Application.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Specifications
{
    public class InvoiceFilterSpecification : HeroSpecification<Invoice>
    {
        public InvoiceFilterSpecification(string searchString)
        {
            Includes.Add(a => a.Transactions);
            Includes.Add(a => a.branch);
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => (p.branch.BranchName.Contains(searchString));
            }
        }
    }
}