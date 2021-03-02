using Microsoft.AspNet.SignalR;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalR.Hubs
{
    public class CoffeHub : Hub
    {
        private static readonly OrderChecker _orderChecker = new OrderChecker(new Random());
        public async Task getUpdateForOrder(Order order) {
            await Clients.Others.NewOrder(order);
            UpdateInfo result;
            do
            {
                result = _orderChecker.GetUpdate(order);
                await Task.Delay(500);
                if (!result.newOrder) continue;
                await Clients.Caller.RecieveOderByUpdate(result);
            } while (!result.finished);
            await Clients.Caller.Finished(order);
        }
        public override Task OnConnected()
        {
            var connId = Context.ConnectionId;
            return base.OnConnected();
        }
    }
}