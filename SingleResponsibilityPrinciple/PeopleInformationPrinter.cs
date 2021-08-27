using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace SingleResponsibilityPrinciple
{
    public class PeopleInformationPrinter
    {
        private readonly IReader<Person> _reader;
        private readonly IPeopleTextFormatter _peopleTextFormatter;
        private readonly IWriter _writer;

        public void Print()
        {
            var people = _reader.Read();
            var text = _peopleTextFormatter.BuildText(people);
            _writer.Write(text);
        }
    }

    public class DatabaseReader : IReader<Person>
    {
        private readonly string _connectionString;
        public DatabaseReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> Read()
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
    }

    public interface IPeopleTextFormatter
    {
        string BuildText(IEnumerable<Person> people);
    }

    public class PeopleTextFormatter : IPeopleTextFormatter
    {
        public string BuildText(IEnumerable<Person> people)
        {
            return string.Join("\n", people.Select(person => person.ToString()));
        }
    }

    public class TextWriter : IWriter
    {
        private readonly string _filePath;

        public TextWriter(string resultFilePath)
        {
            _filePath = resultFilePath;
        }

        public void Write(string text)
        {
            File.WriteAllText(_filePath, text);
        }
    }

    public interface IReader<T>
    {
        IEnumerable<T> Read();
    }

    public interface IWriter
    {
        void Write(string text);
    }

}
