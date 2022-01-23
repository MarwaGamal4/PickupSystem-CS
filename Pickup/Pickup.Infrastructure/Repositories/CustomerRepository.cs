using Microsoft.EntityFrameworkCore;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IRepositoryAsync<Customer> _repository;
        private readonly IRepositoryAsync<CustomerPlan> _Planrepository;

        public CustomerRepository(IRepositoryAsync<Customer> repository, IRepositoryAsync<CustomerPlan> planrepository)
        {
            _repository = repository;
            _Planrepository = planrepository;
        }

        public async Task<Customer> GetCustomerByPhone(string Phone)
        {
            return await _repository.Entities.Include(x=>x.CustomerPlans).FirstOrDefaultAsync(x=>x.Phone1 == Phone || x.Phone2 == Phone);
        }

        public async Task<Customer> GetCustomerByPlanID(int PlanID)
        {
            var Plan = await _Planrepository.Entities.Include(x=>x.customer).FirstOrDefaultAsync(x=>x.Id == PlanID);
            if (Plan != null) 
            {
                return Plan.customer;
            }
            else
            {
                return new Customer();
            }
        }

        public async Task<bool> IsCustomerExist(string Phone)
        {
            if (string.IsNullOrEmpty(Phone))
            {
                return await Task.FromResult<bool>(false);
            }
            return await _repository.Entities.AnyAsync(x => x.Phone1 == Phone || x.Phone2 == Phone);
        }
    }
}
