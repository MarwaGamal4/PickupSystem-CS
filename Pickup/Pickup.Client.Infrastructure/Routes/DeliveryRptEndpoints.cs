using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Routes
{
   public class DeliveryRptEndpoints
    {
        public static string GetByBranchName(string branchName) => $"api/v1/DeliveryRpt/branch/{branchName}";
        public static string GetByBranchName(string branchName , DateTime date) => $"api/v1/DeliveryRpt/branch/{branchName}/{date}";
        public static string GetByBranchName(string branchName , DateTime dateFrom , DateTime dateTo) => $"api/v1/DeliveryRpt/branch/{branchName}/{dateFrom}/{dateTo}";
        public static string GetByDriverName(string DriverhName) => $"api/v1/DeliveryRpt/Driver/{DriverhName}";
        public static string GetByDriverName(string DriverhName, DateTime date) => $"api/v1/DeliveryRpt/Driver/{DriverhName}/{date}";
        public static string GetByDriverName(string DriverhName , DateTime dateFrom, DateTime dateTo) => $"api/v1/DeliveryRpt/Driver/{DriverhName}/{dateFrom}/{dateTo}";
        public static string GetByCid(int cid) => $"api/v1/DeliveryRpt/CID/{cid}";
        public static string GetByCid(int cid, DateTime date) => $"api/v1/DeliveryRpt/CID/{cid}/{date}";
        public static string GetByCid(int cid , DateTime dateFrom, DateTime dateTo) => $"api/v1/DeliveryRpt/CID/{cid}/{dateFrom}/{dateTo}";
        public static string GetByPhone(string phone) => $"api/v1/DeliveryRpt/phone/{phone}";
        public static string GetByPhone(string phone, DateTime date) => $"api/v1/DeliveryRpt/phone/{phone}/{date}";
        public static string GetByPhone(string phone, DateTime dateFrom, DateTime dateTo) => $"api/v1/DeliveryRpt/phone/{phone}/{dateFrom}/{dateTo}";

    }
}
