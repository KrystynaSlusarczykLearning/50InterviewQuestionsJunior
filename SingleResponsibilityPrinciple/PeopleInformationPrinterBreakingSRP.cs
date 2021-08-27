using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace SingleResponsibilityPrinciple
{
    public class PeopleInformationPrinterBreakingSRP
    {
        private readonly string _connectionString;
        private readonly string _resultFilePath;

        public PeopleInformationPrinterBreakingSRP(string connectionString, string resultFilePath)
        {
            _connectionString = connectionString;
            _resultFilePath = resultFilePath;
        }

        public void Print()
        {
            var people = ReadFromDatabase();
            var text = BuildText(people);
            File.WriteAllText(_resultFilePath, text);
        }

        private IEnumerable<Person> ReadFromDatabase()
        {
            var people = new List<Person>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("select * from People", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            people.Add(
                                new Person(
                                    reader["Name"] as string,
                                    reader["LastName"] as string,
                                    (int)reader["Username"]));
                        }
                    }
                }
            }
            return people;
        }

        private string BuildText(IEnumerable<Person> people)
        {
            return string.Join("\n", people.Select(person => person.ToString()));
        }
    }
}
