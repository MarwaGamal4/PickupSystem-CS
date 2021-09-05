using Pickup.Application.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Models
{
   public class Inv_Images
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public UploadType ImageType { get; set; }
        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; }
    }
}
