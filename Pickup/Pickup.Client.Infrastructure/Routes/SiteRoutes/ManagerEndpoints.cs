using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Routes.SiteRoutes
{
    public static class ManagerEndpoints
    {
        public static string GetBranches = "api/Manager/GetAllBranches";
        public static string GetAgents = "api/Manager/GetAllAgents";
        public static string GetPaymentMethods = "api/Manager/GetAllMethods";
        public static string GetPrograms = "api/Manager/GetAllPrograms";
        public static string GetEmarits = "api/Manager/GetAllEmarits";
        public static string GetSubscriptions(int pageSize = 100, int pageNumber = 1) => $"api/Manager/GetAllSubscriptions?pageSize={pageSize}&pageNumber={pageNumber}";
    }
}
