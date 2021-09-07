using Pickup.Application.Features.DeliveryRpt.Queries.GetAll;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.DeliveryRPT
{
   public interface IDeliveryRptManager :IManager
    {
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByBranchName(string branchName );
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByBranchName(string branchName, DateTime date);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByBranchName(string branchName, DateTime dateFrom, DateTime dateTo);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByDriverName(string DriverName);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByDriverName(string DriverName, DateTime date);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByDriverName(string DriverName, DateTime dateFrom, DateTime dateTo);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByCid(int Cid);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByCid(int Cid, DateTime date);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByCid(int Cid, DateTime dateFrom, DateTime dateTo);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByPhone(string Phone);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByPhone(string Phone, DateTime date);
        public Task<IResult<List<GetAllDeliveryRptResponse>>> GetByPhone(string Phone, DateTime dateFrom, DateTime dateTo);

    }
}
