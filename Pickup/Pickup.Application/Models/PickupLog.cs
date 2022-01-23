using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
    public class PickupLog : AuditableEntity
    {
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer customer { get; set; }
        public int InvoiceID { get; set; }
        [ForeignKey("InvoiceID")]
        public Invoice invoice { get; set; }
        public virtual ICollection<Inv_Images> Inv_Images { get; set; }
        public int BranchID { get; set; }
        [ForeignKey("BranchID")]
        public Branch branch { get; set; }
        public int POS_res_Id { get; set; }
        public int MealsCount { get; set; }
        public int SnacksCount { get; set; }
    }
}
