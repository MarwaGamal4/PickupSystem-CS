
using static Pickup.Shared.Constants.User.UserConstants;

namespace Pickup.Application.Requests.Identity
{
    public class ToggleUserStatusRequest
    {
        public bool ActivateUser { get; set; }
        public string UserId { get; set; }
        public UserType UserType { get; set; }
    }
}