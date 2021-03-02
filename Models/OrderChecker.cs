using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    public class OrderChecker
    {
        private readonly Random random;

        private readonly string[] Status = {"Grinding beans","Steaming Coffe","Taking a sip(quality control)" };
        private readonly Dictionary<int, int> StatusTracker = new Dictionary<int, int>();

        public OrderChecker(Random random) {
            this.random = random;
        }

        private int GetNextStatusIndex(int OrderNo) {
            if (!StatusTracker.ContainsKey(OrderNo)) {
                StatusTracker.Add(OrderNo, -1);
            }
            StatusTracker[OrderNo]++;
            return StatusTracker[OrderNo];
        }

        public UpdateInfo GetUpdate(Order order) {
            if (random.Next(1, 5) != 4) return new UpdateInfo { newOrder = false };
            var index = GetNextStatusIndex(order.id);

            if (Status.Length <= index) return new UpdateInfo { newOrder = false };

            var result = new UpdateInfo {
                orderId = order.id,
                newOrder = true,
                update = Status[index],
                finished = Status.Length - 1 == index
            };
            return result;
        }
    }
}