﻿using Pickup.Client.Infrastructure.SiteModels.Requests;
using Pickup.Client.Infrastructure.SiteModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Client.Infrastructure.Managers.ManagerDashboard
{
    public interface ImanagerDashboardManager : IManager
    {
        Task<List<AgentsResponse>> GetAgents();
        Task<List<BranchesResponse>> GetBranches();
        Task<List<ProgramsResponse>> GetPrograms();
        Task<List<SubscriptionsResponse>> GetSubscriptions(ManagerRequest request, int PageSize, int PageNumber);
        Task<List<String>> GetPayments();
    }
}
