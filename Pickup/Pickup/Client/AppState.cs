
using Pickup.Application.Responses.Identity;
using Pickup.Client.Infrastructure.Managers.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Client
{
    public class AppState
    {
        public int MessagesCounter { get; private set; } = 0;

        public event Action OnChange;

        public void SetMessageCounter(int Count)
        {
            MessagesCounter = Count;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();



    }
}
