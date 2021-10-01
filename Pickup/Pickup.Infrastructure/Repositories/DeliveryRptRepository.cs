using Microsoft.EntityFrameworkCore;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Repositories
{
    public class DeliveryRptRepository : IDeliveryRptRepository
    {
        private readonly BlazorHeroContext _dbContext;

        public DeliveryRptRepository(IRepositoryAsync<Branch> repository, BlazorHeroContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<DeliveryRPT>> getAll() 
        {
            return  _dbContext.DeliveryRpt.AsQueryable();
        }
        public async Task<int> ChangeDeliverdState(int LineId, int DeliveryStatus, string Note, string LAT, string LONG)
        {
            var line = await _dbContext.DeliveryRpt.FirstOrDefaultAsync(x => x.Id == LineId);
            if (line != null)
            {
                line.DeliveryStatus = DeliveryStatus;
                line.DeliveryNote = Note ?? "";
                line.DriverLatitude = LAT ?? "";
                line.DriverLongitude = LONG ?? "";
                line.ActionTime = DateTime.Now;
                return await _dbContext.SaveChangesAsync();
            }
              return await Task.FromResult<int>(0);
        }

        public async Task<DeliveryRPT> FindById(int id)
        {
            return await _dbContext.DeliveryRpt.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DeliveryRPT>> GetRPTByBranch(string BranchName)
        {
            return await _dbContext.DeliveryRpt.Where(b => b.BranchName == BranchName).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByBranch(string BranchName, DateTime? date)
        {
            return await _dbContext.DeliveryRpt.Where(b => b.BranchName == BranchName && b.PrintDate == date).OrderBy(x=>x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByBranch(string BranchName, DateTime? dateFrom, DateTime? dateTo)
        {
            return await _dbContext.DeliveryRpt.Where(b => b.BranchName == BranchName && b.PrintDate >= dateFrom && b.PrintDate <= dateTo).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByCID(int? CID)
        {
            return await _dbContext.DeliveryRpt.Where(c => c.CustomerId == CID).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByCID(int? CID, DateTime? date)
        {
            return await _dbContext.DeliveryRpt.Where(c => c.CustomerId == CID && c.PrintDate == date).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByCID(int? CID, DateTime? dateFrom, DateTime? dateTo)
        {
            return await _dbContext.DeliveryRpt.Where(c => c.CustomerId == CID && c.PrintDate >= dateFrom && c.PrintDate <= dateTo).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByCustomerPhone(string CustomerPhone)
        {
            return await _dbContext.DeliveryRpt.Where(c => c.CustomerPhone == CustomerPhone).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByCustomerPhone(string CustomerPhone, DateTime? date)
        {
            return await _dbContext.DeliveryRpt.Where(c => c.CustomerPhone == CustomerPhone && c.PrintDate == date).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByCustomerPhone(string CustomerPhone, DateTime? dateFrom, DateTime? dateTo)
        {
            return await _dbContext.DeliveryRpt.Where(c => c.CustomerPhone == CustomerPhone && c.PrintDate >= dateFrom && c.PrintDate <= dateTo).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByDriver(string DriverName, string BranchName)
        {
            return await _dbContext.DeliveryRpt.Where(d => d.DeliveryName == DriverName && d.BranchName == BranchName).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByDriver(string DriverName, string BranchName, DateTime? date)
        {
            return await _dbContext.DeliveryRpt.Where(d => d.DeliveryName == DriverName && d.BranchName == BranchName && d.PrintDate == date).OrderBy(x => x.PrintDate).ToListAsync();
        }

        public async Task<List<DeliveryRPT>> GetRPTByDriver(string DriverName, string BranchName, DateTime? dateFrom, DateTime? dateTo)
        {
            return await _dbContext.DeliveryRpt.Where(d => d.DeliveryName == DriverName && d.BranchName == BranchName && d.PrintDate >= dateFrom && d.PrintDate <= dateTo).OrderBy(x => x.PrintDate).ToListAsync();
        }
    }
}
