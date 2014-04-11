namespace Measura
{
    public static class ItemUserVisitMonitoringService
    {
        private static readonly MongoMetricWriter MongoMetricWriter = new MongoMetricWriter();

        public static void Start()
        {
            MongoMetricWriter.Start();
        }

        public static void Stop()
        {
            MongoMetricWriter.Stop();
        }
    }
}