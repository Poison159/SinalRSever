using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    public class Order
    {
        public int id { get; set; }
        public string product { get; set; }
        public string size { get; set; }
    }
}