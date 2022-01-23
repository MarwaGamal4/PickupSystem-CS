using Pickup.Application.Models.ERP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
    public interface IPlanRepository
    {
        Task<bool> IsPlanExist(string PlanName, int PlanTypeId);
        Task<TbPlanMasterHdr> AddAsync(TbPlanMasterHdr planMasterHdr);
        Task<TbPlanMasterHdr> UpdateAsync(TbPlanMasterHdr planMasterHdr);
        Task<List<TbPlanMasterHdr>> GetAllAsync(string LanguageCode);
        Task<TbPlanMasterHdr> GetAsync(int id);

    }
}
