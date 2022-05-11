using Pickup.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
    public class POS_Ver : AuditableEntity
    {

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch branch { get; set; }
        public string Verison { get; set; }
        public DateTime LastCheck { get; set; }
    }
}
