using Pickup.Application.Features.DeliveryRpt.Queries.GetAll;
using Pickup.Client.Infrastructure.Extensions;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.DeliveryRPT
{
   public class DeliveryRptManager : IDeliveryRptManager
    {
        private readonly HttpClient _httpClient;

        public DeliveryRptManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByBranchName(string branchName)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByBranchName(branchName));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByBranchName(string branchName, DateTime date)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByBranchName(branchName , date));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByBranchName(string branchName, DateTime dateFrom, DateTime dateTo)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByBranchName(branchName , dateFrom,dateTo));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByCid(int Cid)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByCid(Cid));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByCid(int Cid, DateTime date)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByCid(Cid, date));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByCid(int Cid, DateTime dateFrom, DateTime dateTo)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByCid(Cid, dateFrom, dateTo));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByDriverName(string DriverName)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByDriverName(DriverName));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByDriverName(string DriverName, DateTime date)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByDriverName(DriverName , date));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByDriverName(string DriverName, DateTime dateFrom, DateTime dateTo)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByDriverName(DriverName ,dateFrom,dateTo));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByPhone(string Phone)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByPhone(Phone));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByPhone(string Phone, DateTime date)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByPhone(Phone, date));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }

        public async Task<IResult<List<GetAllDeliveryRptResponse>>> GetByPhone(string Phone, DateTime dateFrom, DateTime dateTo)
        {
            var response = await _httpClient.GetAsync(Routes.DeliveryRptEndpoints.GetByPhone(Phone , dateFrom , dateTo));
            return await response.ToResult<List<GetAllDeliveryRptResponse>>();
        }
    }
}
