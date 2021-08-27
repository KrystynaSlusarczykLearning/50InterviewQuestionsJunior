using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //this is Singleton design pattern
            var singleton = Singleton.Instance;
            var nextSingleton = Singleton.Instance;
            Console.WriteLine($"singleton: {singleton.Id}");
            Console.WriteLine($"nextSingleton: {nextSingleton.Id}");

            //this is application singleton
            var singleLoggerPerWholeApplication = new Logger();
            var database = new Database(singleLoggerPerWholeApplication);
            var networkConnector = new NetworkConnector(singleLoggerPerWholeApplication);
            var interfaceHandler = new InterfaceHandler(singleLoggerPerWholeApplication);

            RunApplication(database, networkConnector, interfaceHandler);

            Console.ReadKey();
        }

        private static void RunApplication(
            Database database,
            NetworkConnector networkConnector, 
            InterfaceHandler interfaceHandler)
        {
            //run application
        }
    }

    public sealed class Singleton
    {
        private static Singleton instance = null;
        public string Id { get; } //only for presentation purposes

        private Singleton()
        {
            Id = Guid.NewGuid().ToString();
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
