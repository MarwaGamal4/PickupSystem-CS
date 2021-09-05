using Pickup.Application.Models.Identity;
using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
   public class Branch : AuditableEntity
    {
        public string BranchName { get; set; }

        public virtual ICollection<BlazorHeroUser> Users { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Invoice>Invoices { get; set; }
        [InverseProperty("CreditBranch")]
        public virtual ICollection<Transaction>CreditTransaction { get; set; }
        [InverseProperty("branch")]
        public virtual ICollection<Transaction> DepitTransaction { get; set; }


        public Branch()
        {
            Users = new HashSet<BlazorHeroUser>();
            Invoices = new HashSet<Invoice>();
            Customers = new HashSet<Customer>();
            CreditTransaction = new HashSet<Transaction>();
            DepitTransaction = new HashSet<Transaction>();
        }
    }
}
