using Microsoft.EntityFrameworkCore;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Application.Models.ERP;
using Pickup.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {

        private readonly IRepositoryAsync<Plan> _repository;
        private readonly ERBSYSTEMContext _dbContext;

        public PlanRepository(IRepositoryAsync<Plan> repository, ERBSYSTEMContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<TbPlanMasterHdr> AddAsync(TbPlanMasterHdr planMasterHdr)
        {
            await _dbContext.TbPlanMasterHdrs.AddAsync(planMasterHdr);
            await _dbContext.SaveChangesAsync();
            return planMasterHdr;
        }

        public async Task<List<TbPlanMasterHdr>> GetAllAsync()
        {
            var Plans = await _dbContext.TbPlanMasterHdrs.Include(x => x.TbPlanMasterLines).Include(x => x.TbPlanPrices).ToListAsync();
            var Meals = await _dbContext.TbMeals.ToListAsync();
            foreach (var item in Plans)
            {
                foreach (var plan in item.TbPlanMasterLines)
                {
                    plan.MealName = Meals.FirstOrDefault(x => x.Id == plan.MealId).MealName;
                }
            }
            return Plans;
        }

        public async Task<TbPlanMasterHdr> GetAsync(int id)
        {
            return await _dbContext.TbPlanMasterHdrs.Include(x => x.TbPlanMasterLines).Include(x => x.TbPlanPrices).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> IsPlanExist(string PlanName, int PlanTypeId)
        {
            return await _repository.Entities.AnyAsync(p => p.PlanName == PlanName && p.PlanTypeId == PlanTypeId);
        }

        public Task<TbPlanMasterHdr> UpdateAsync(TbPlanMasterHdr planMasterHdr)
        {
            var exist = _dbContext.Set<TbPlanMasterHdr>().Find(planMasterHdr.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(planMasterHdr);
            return Task.FromResult(planMasterHdr);
        }
    }
}
