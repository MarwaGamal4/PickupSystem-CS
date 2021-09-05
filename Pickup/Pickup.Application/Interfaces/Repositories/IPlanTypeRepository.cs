using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
   public interface IPlanTypeRepository
    {
        Task<bool> IsPlanTypeExist(string PlanTypeName);
        Task<bool> IsPlanSolganExist(string PlanSolgan);
    }
}
