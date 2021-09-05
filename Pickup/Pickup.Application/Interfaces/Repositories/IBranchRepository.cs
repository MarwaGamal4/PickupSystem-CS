using Pickup.Application.Models;
using Pickup.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task<bool> IsBranchExist(string BranchName);
        Task<bool> IsBranchInuse(int BranchId);
        Task<int> AddUsersToBranch(int branchId, IList<BlazorHeroUser> UsersList);
        Task<int> AddBranchesToUserh(string UserId, IList<Branch> BranchesList);
    }
}
