using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Measura
{
    public class MetricQueue
    {
        private MetricQueue() { }

        public static MetricQueue Default = new MetricQueue();

        private ConcurrentQueue<ItemUserVisit> _queue = new ConcurrentQueue<ItemUserVisit>();

        public ConcurrentQueue<ItemUserVisit> Queue
        {
            get { return _queue; }
        }

        public void Enqueue(ItemUserVisit itemUserVisit)
        {
            _queue.Enqueue(itemUserVisit);
        }

        public ItemUserVisit Get()
        {
            ItemUserVisit itemUserVisit;
            _queue.TryDequeue(out itemUserVisit);
            return itemUserVisit;
        }

        public IEnumerable<ItemUserVisit> Get(int count)
        {
            while (!_queue.IsEmpty && count-- > 0)
            {
                ItemUserVisit itemUserVisit;
                _queue.TryDequeue(out itemUserVisit);    
                yield return itemUserVisit;
            }
        }
    }
}