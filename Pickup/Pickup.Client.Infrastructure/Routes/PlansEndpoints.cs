using Pickup.Client.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Routes
{
    public class PlansEndpoints
    {
        public static string GetAll(string langCode) => $"{ApiVirsion.Api_Virsion}/Plans/{langCode}";
    }
}
