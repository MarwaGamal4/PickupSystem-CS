using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbCustomerAdress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Adress { get; set; }
        public int AreaId { get; set; }
        public bool DefaultAdress { get; set; }

        public virtual TbArea Area { get; set; }
        public virtual TbCustomer Customer { get; set; }
    }
}
