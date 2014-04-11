using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Measura
{
    public class MongoMetricWriter
    {
        private Thread _writerThread;
        private MetricCollector _metricCollector;
        private bool _stopWriterThread;

        public void Start()
        {
            _metricCollector = new MetricCollector(MetricQueue.Default);
            _writerThread = new Thread(WriterThread) { Name = "carbon-sender", IsBackground = true };

            _writerThread.Start();
        }

        private void WriterThread()
        {
            Debug.WriteLine("Started writer thread");

            while (!_stopWriterThread)
            {
                var itemUserVisits = _metricCollector.GetItemUserVisits().ToList();
                Debug.WriteLine("Writing " + itemUserVisits.Count() + " to mongo ");
                itemUserVisits.ForEach(u => Debug.WriteLine(u));

                Thread.Sleep(5000);
            }

            Debug.WriteLine("Stopped writer thread");
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing) GC.SuppressFinalize(this);

            try
            {
                _stopWriterThread = true;

                if (_writerThread != null && _writerThread.IsAlive)
                    _writerThread.Join(2000);
            }
            catch(Exception ex)
            {
                Debug.Fail("Disposal issues", ex.Message);
            }
        }

        ~MongoMetricWriter()
        {
            Dispose(false);
        }

        public void Stop()
        {
            _stopWriterThread = true;
        }
    }
}