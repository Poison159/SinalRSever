using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    public class UpdateInfo
    {
        public int orderId { get; set; }
        public bool newOrder { get; set; }
        public string update { get; set; }
        public bool finished { get; set; }
    }
}