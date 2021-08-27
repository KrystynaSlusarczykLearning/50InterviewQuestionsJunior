using System;
using System.Collections.Generic;

namespace Goto
{
    class GotoSimpleUse
    {
        public int? TransformNumberToNullWhenZero(int a)
        {
            if (a == 0)
            {
                goto HandleZeroCase;
            }

            return a;

            HandleZeroCase:
            return null;
        }
    }

    class GotoInfiniteLoop
    {
        public void InfiniteLoop()
        {
            GotoMarker:
            goto GotoMarker;
        }
    }

    class GotoNestedLoops
    {
        public int NestedLoops(int[][][] input)
        {
            int totalNumberOfCalculations = 0;
            int maxNumberOfCalculations = 500;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    for (int k = 0; k < input.Length; k++)
                    {
                        //do some calculations here...
                        ++totalNumberOfCalculations;
                        if (totalNumberOfCalculations == maxNumberOfCalculations)
                        {
                            //break; //unfortunately, this will only break from the inner-most loop
                           
                            goto AfterLoop;
                            //return totalNumberOfCalculations; //we can also return here to achieve the same effect without goto
                        }
                    }
                }
            }
            AfterLoop:
            return totalNumberOfCalculations;
        }
    }

    enum EntityType
    {
        Person, 
        Pet
    }

    class GotoCommonCleanupLogic
    {
        private readonly IDatabase _database;
        private readonly ILogger _logger;

        public GotoCommonCleanupLogic(IDatabase database, ILogger logger)
        {
            _database = database;
            _logger = logger;
        }

        public bool CheckIfAllIdsExistInTheDatabase(List<string> ids, EntityType entityType)
        {
            foreach (var id in ids)
            {
                switch (entityType)
                {
                    case EntityType.Person:
                        var person = _database.GetPerson(id);
                        if (person == null)
                        {
                            goto ReportError;
                        }
                        break;
                    case EntityType.Pet:
                        var pet = _database.GetPet(id);
                        if (pet == null)
                        {
                            goto ReportError;
                        }
                        break;
                    default:
                        goto ReportError;
                }
            }

            return true;

            ReportError:
            _logger.LogError("Database read error");
            return false;
        }
    }

    class CommonCleanupLogicWithoutGoto
    {
        private readonly IDatabase _database;
        private readonly ILogger _logger;

        public CommonCleanupLogicWithoutGoto(IDatabase database, ILogger logger)
        {
            _database = database;
            _logger = logger;
        }

        public bool CheckIfAllIdsExistInTheDatabase(List<string> ids, EntityType entityType)
        {
            foreach (var id in ids)
            {
                switch (entityType)
                {
                    case EntityType.Person:
                        var person = _database.GetPerson(id);
                        if (person == null)
                        {
                            LogError();
                            return false;
                        }
                        break;
                    case EntityType.Pet:
                        var pet = _database.GetPet(id);
                        if (pet == null)
                        {
                            LogError();
                            return false;
                        }
                        break;
                    default:
                        LogError();
                        return false;
                }
            }

            return true;
        }

        private void LogError()
        {
            _logger.LogError("Database read error");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //careful - this will freeze the program because of the infinite loop
            //new GotoInfiniteLoop().InfiniteLoop(); 

            var personalData = new VeryUglyPersonalDataFormatter(new DatabaseMock()).FormatPersonalData("John");
            Console.WriteLine(personalData);

            Console.ReadKey();
        }
    }
}
