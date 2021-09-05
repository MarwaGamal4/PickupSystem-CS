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
   public class PlanTypeRepository : IPlanTypeRepository
    {
        private readonly IRepositoryAsync<PlanType> _repository;
        private readonly BlazorHeroContext _dbContext;

        public PlanTypeRepository(IRepositoryAsync<PlanType> repository, BlazorHeroContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<bool> IsPlanSolganExist(string PlanSolgan)
        {
            return await _repository.Entities.AnyAsync(p => p.PlanSlogan == PlanSolgan);
        }

        public async Task<bool> IsPlanTypeExist(string PlanTypeName)
        {
            return await _repository.Entities.AnyAsync(p => p.PlanTypeName == PlanTypeName);
        }
    }
}
