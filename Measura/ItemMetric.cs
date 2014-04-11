using System;
using System.Net;

namespace Measura
{
    public class ItemMetric
    {
        public static void RegisterView(int itemId, IPAddress ipAddress, DateTime dateTime)
        {
            var itemUserVisit = new ItemUserVisit(itemId, ipAddress, dateTime);
            MetricQueue.Default.Enqueue(itemUserVisit);
        }
    }
}