namespace Singleton
{
    internal class InterfaceHandler
    {
        private ILogger singleLoggerPerWholeApplication;

        public InterfaceHandler(ILogger singleLoggerPerWholeApplication)
        {
            this.singleLoggerPerWholeApplication = singleLoggerPerWholeApplication;
        }
    }
}