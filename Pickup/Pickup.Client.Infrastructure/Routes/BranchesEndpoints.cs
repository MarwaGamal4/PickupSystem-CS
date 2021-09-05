

namespace Pickup.Client.Infrastructure.Routes
{
   public static class BranchesEndpoints
    {
        public static string getBranchUsers(int BranchId)
        {
            return $"api/v1/Branches/{BranchId}";
        }
        public static string GetUserBranches(string Userid) 
        {
            return $"api/v1/Branches/GetUserBranches/{Userid}";
        }
        public static string AddUsersToBranch = "api/v1/Branches/AddUsers/";
        public static string AddBranchsToUser = "api/v1/Branches/AddBranchsToUser/";
        public static string GetAll = "api/v1/branches";

        public static string Delete = "api/v1/branches";
        public static string Save = "api/v1/branches";
        public static string GetCount = "api/v1/branches/count";
    }
}
