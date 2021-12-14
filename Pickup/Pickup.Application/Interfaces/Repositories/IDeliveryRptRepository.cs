using Pickup.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Application.Interfaces.Repositories
{
   public interface IDeliveryRptRepository
    {
        Task<List<DeliveryRPT>> GetRPTByBranch(string BranchName);
        Task<List<DeliveryRPT>> GetRPTByBranch(string BranchName , DateTime? date);
        Task<List<DeliveryRPT>> GetRPTByBranch(string BranchName, DateTime? dateFrom , DateTime? dateTo);
        Task<List<DeliveryRPT>> GetRPTByDriver(string DriverName, string BranchName);
        Task<List<DeliveryRPT>> GetRPTByDriver(string DriverName,string BranchName, DateTime? date);
        Task<List<DeliveryRPT>> GetRPTByDriver(string DriverName, string BranchName, DateTime? dateFrom, DateTime? dateTo);
        Task<List<DeliveryRPT>> GetRPTByCID(int? CID);
        Task<List<DeliveryRPT>> GetRPTByCID(int? CID, DateTime? date);
        Task<List<DeliveryRPT>> GetRPTByCID(int? CID, DateTime? dateFrom, DateTime? dateTo);
        Task<List<DeliveryRPT>> GetRPTByCustomerPhone(string CustomerPhone);
        Task<List<DeliveryRPT>> GetRPTByCustomerPhone(string CustomerPhone, DateTime? date);
        Task<List<DeliveryRPT>> GetRPTByCustomerPhone(string CustomerPhone, DateTime? dateFrom, DateTime? dateTo);
        Task<DeliveryRPT> FindById(int id);
        Task<int> ChangeDeliverdState(int LineId , int DeliveryStatus ,string Note,string LAT , string LONG, string Driver);

    }
}
