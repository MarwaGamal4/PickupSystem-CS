
using System.ComponentModel;

namespace Pickup.Shared.Constants.User
{
    public static class UserConstants
    {
        public const string DefaultPassword = "123Pa$$word!";
        public enum UserType { CustomerService, Branch, BranchOwner }
        public enum PlanType
        {
            [Description("LW")]
            LOSE_WEIGHT,
            [Description("GW")]
            GAIN_WEIGHT,
            [Description("CLW")]
            CUSTOM_LOSE_WEIGHT,
            [Description("CGW")]
            CUSTOM_GAIN_WEIGHT
        }
    }
}