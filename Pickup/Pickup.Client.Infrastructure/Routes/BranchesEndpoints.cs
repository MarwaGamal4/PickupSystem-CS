

using Pickup.Client.Infrastructure.Settings;

namespace Pickup.Client.Infrastructure.Routes
{
   public static class BranchesEndpoints
    {
        public static string getBranchUsers(int BranchId)
        {
            return $"{ApiVirsion.Api_Virsion}/Branches/{BranchId}";
        }
        public static string GetUserBranches(string Userid) 
        {
            return $"{ApiVirsion.Api_Virsion}/Branches/GetUserBranches/{Userid}";
        }
        public static string AddUsersToBranch = $"{ApiVirsion.Api_Virsion}/Branches/AddUsers/";
        public static string AddBranchsToUser = $"{ApiVirsion.Api_Virsion}/Branches/AddBranchsToUser/";
        public static string GetAll = $"{ApiVirsion.Api_Virsion}/branches";

        public static string Delete = $"{ApiVirsion.Api_Virsion}/branches";
        public static string Save = $"{ApiVirsion.Api_Virsion}/branches";
        public static string GetCount = $"{ApiVirsion.Api_Virsion}/branches/count";
    }
}
