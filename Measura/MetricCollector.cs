using System.Collections.Generic;
using System.Linq;

namespace Measura
{
    public class MetricCollector
    {
        private MetricQueue _metricQueue;

        public MetricCollector(MetricQueue metricQueue)
        {
            _metricQueue = metricQueue;
        }

        public IEnumerable<ItemUserVisit> GetItemUserVisits()
        {
            var distinctValues = _metricQueue.Get(50)
                .DistinctBy(i => new { i.ItemId, i.IpAddress });
            return distinctValues;
        }
    }
}