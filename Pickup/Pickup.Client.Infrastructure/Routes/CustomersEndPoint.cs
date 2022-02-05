using Pickup.Client.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Routes
{
    public static class CustomersEndPoint
    {
        public static string AddNew = $"{ApiVirsion.Api_Virsion}/Customer/";
        public static string AddSubscription = $"{ApiVirsion.Api_Virsion}/Customer/AddSubscription";
        public static string GetCustomer = $"{ApiVirsion.Api_Virsion}/Customer/GetCustmer";
        public static string RenewSubscription = $"{ApiVirsion.Api_Virsion}/Customer/RenewPickup";
        public static string AddTransaction = $"{ApiVirsion.Api_Virsion}/Customer/AddTransaction";
        public static string GetInvoice = $"{ApiVirsion.Api_Virsion}/Customer/GetInvoices";
        public static string GetTransaction = $"{ApiVirsion.Api_Virsion}/Customer/GetTransaction";
        public static string GetTimeline = $"{ApiVirsion.Api_Virsion}/Customer/GetTimeline";
    }
}
