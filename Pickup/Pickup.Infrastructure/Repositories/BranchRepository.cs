using Microsoft.EntityFrameworkCore;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Application.Models.Identity;
using Pickup.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IRepositoryAsync<Branch> _repository;
        private readonly BlazorHeroContext _dbContext;
        private readonly ERBSYSTEMContext _ErpContext;
        public BranchRepository(IRepositoryAsync<Branch> repository, BlazorHeroContext dbContext, ERBSYSTEMContext eRBSYSTEMContext)
        {
            _repository = repository;
            _dbContext = dbContext;
            _ErpContext = eRBSYSTEMContext;
        }

        public async Task<int> AddBranchesToUserh(string UserId, IList<Branch> BranchesList)
        {
            var user = _dbContext.Users.Include(x => x.Branches).FirstOrDefault(x => x.Id == UserId);
            user.Branches.Clear();
            _dbContext.SaveChanges();

            foreach (var item in BranchesList)
            {
                user.Branches.Add(item);
            }
            return await Task.FromResult<int>(_dbContext.SaveChanges());
        }

        public async Task<int> AddUsersToBranch(int branchId, IList<BlazorHeroUser> UsersList)
        {
            var branch = _dbContext.Branches.Include(x => x.Users).FirstOrDefault(x => x.Id == branchId);
            branch.Users.Clear();
            _dbContext.SaveChanges();

            foreach (var item in UsersList)
            {
                branch.Users.Add(item);
            }
            return await Task.FromResult<int>(_dbContext.SaveChanges());
        }

        public async Task<string> GetBranchNameById(int BranchID)
        {
            var Branch = await _repository.Entities.FirstOrDefaultAsync(x => x.Id == BranchID);
            return Branch.BranchName;
        }

        public async Task<bool> IsBranchExist(string BranchName)
        {
            return await _repository.Entities.AnyAsync(b => b.BranchName == BranchName);
        }

        public async Task<bool> IsBranchInuse(int BranchId)
        {
            return await Task.FromResult<bool>(false);
        }
    }
}
