﻿using Pickup.Application.Requests.Identity;
using Pickup.Application.Responses.Identity;
using Pickup.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pickup.Shared.Constants.User;

namespace Pickup.Client.Infrastructure.Managers.Identity.Users
{
    public interface IUserManager : IManager
    {
        Task<IResult<List<UserResponse>>> GetAllAsync();

        Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request);

        Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);

        Task<IResult<UserResponse>> GetAsync(string userId);
        Task<IResult<UserConstants.UserType>> GetUserType();

        Task<IResult<UserRolesResponse>> GetRolesAsync(string userId);

        Task<IResult> RegisterUserAsync(RegisterRequest request);

        Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request);

        Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);
    }
}