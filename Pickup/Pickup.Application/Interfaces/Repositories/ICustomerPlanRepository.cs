using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
   public interface ICustomerPlanRepository
    {
        Task<bool> IsCustomerExist(string PhoneNumber);
        Task<bool> CustomerRecharge(int CustomerId , decimal Amount , int MealsCount);
    }
}
