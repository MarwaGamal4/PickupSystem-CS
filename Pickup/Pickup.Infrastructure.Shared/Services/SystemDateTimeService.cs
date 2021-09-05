using Pickup.Application.Interfaces.Services;
using System;

namespace Pickup.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}