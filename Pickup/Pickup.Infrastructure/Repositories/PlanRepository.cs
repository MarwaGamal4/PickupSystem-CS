using Microsoft.EntityFrameworkCore;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
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
        private readonly BlazorHeroContext _dbContext;

        public PlanRepository(IRepositoryAsync<Plan> repository, BlazorHeroContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<bool> IsPlanExist(string PlanName, int PlanTypeId)
        {
            return await _repository.Entities.AnyAsync(p => p.PlanName == PlanName && p.PlanTypeId == PlanTypeId);
        }
    }
}
