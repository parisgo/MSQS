using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using MSQS.Core;

namespace MSQS.Service
{
    public class BroadcastContext
    {
        private static readonly BroadcastContext instance = new BroadcastContext(GlobalHost.ConnectionManager.GetHubContext<BroadcastHub>());
        private readonly IHubContext context;

        public static BroadcastContext Instance
        {
            get { return instance; }
        }

        private BroadcastContext(IHubContext context)
        {
            this.context = context;
        }

        public void Send(LogItem log)
        {
            context.Clients.All.ReceiveMsg(log);
        }
    }
}
