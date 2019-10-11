using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.Examples.SignalR.Server
{
    //It needs to be public, if not System.Net.Http.StreamContent, exception is thrown o_O
    public class ExampleHub : Hub
    {
        public void Send(string date)
        {
            Clients.All.send(date);
        }

        public override Task OnConnected()
        {
            Console.WriteLine(Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}
