using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
  public  class Customer : AuditableEntity
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            Transactions = new HashSet<Transaction>();
            CustomerPlans = new HashSet<CustomerPlan>();
        }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }

        public int BranchId { get; set; }
        public Branch branch { get; set; }

        public string Notes { get; set; }


        public virtual ICollection<Invoice>Invoices { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<CustomerPlan> CustomerPlans { get; set; }

    }
}
