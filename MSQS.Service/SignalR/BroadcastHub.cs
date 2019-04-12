using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace MSQS.Service
{
    public class BroadcastHub : Hub
    {
        private readonly BroadcastContext broadcastContext;

        public BroadcastHub()
        {
            broadcastContext = BroadcastContext.Instance;
        }
    }
}
