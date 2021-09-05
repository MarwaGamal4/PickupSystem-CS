using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Features.PlanTypes.Queries.GetAll
{
   public class GetAllPlanTypesResponse
    {
        public int Id { get; set; }
        public string PlanTypeName { get; set; }
        public string PlanSlogan { get; set; }
    }
}
