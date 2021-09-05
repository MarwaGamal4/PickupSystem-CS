using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
   public interface ITransactionRepository
    {
        Task<bool> IsCustomerHasCridet(int CustomerID);
    }
}
