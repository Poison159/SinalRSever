using Microsoft.AspNet.SignalR;
using SignalR.Hubs;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SignalR.Controllers.API
{
    public class CoffeeController : ApiController
    {
        private static int OrderId;

        public int OrderCoffee(Order order)
        {
            //var hub = GlobalHost.ConnectionManager.GetHubContext<CoffeHub>();
            //hub.Clients.
            OrderId++;
            return OrderId;
        }
    }
}