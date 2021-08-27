namespace Singleton
{
    internal class NetworkConnector
    {
        private ILogger singleLoggerPerWholeApplication;

        public NetworkConnector(ILogger singleLoggerPerWholeApplication)
        {
            this.singleLoggerPerWholeApplication = singleLoggerPerWholeApplication;
        }
    }
}