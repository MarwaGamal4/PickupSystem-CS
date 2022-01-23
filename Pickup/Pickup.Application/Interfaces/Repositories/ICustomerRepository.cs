using Pickup.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool> IsCustomerExist(string Phone);
        Task<Customer> GetCustomerByPhone(string Phone);
        Task<Customer> GetCustomerByPlanID(int PlanID);
    }
}
