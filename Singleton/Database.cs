namespace Singleton
{
    internal class Database
    {
        private ILogger singleLoggerPerWholeApplication;

        public Database(ILogger singleLoggerPerWholeApplication)
        {
            this.singleLoggerPerWholeApplication = singleLoggerPerWholeApplication;
        }
    }
}