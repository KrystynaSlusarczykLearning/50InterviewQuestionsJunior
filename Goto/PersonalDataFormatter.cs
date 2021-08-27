using System;

namespace Goto
{
    class PersonalDataFormatter
    {
        private readonly IDatabase _database;

        public PersonalDataFormatter(IDatabase database)
        {
            _database = database;
        }

        public string FormatPersonalData(string personId)
        {
            var person = _database.GetPerson(personId);
            var personsPet = GetPet(person);
            if (person == null || personsPet == null)
            {
                Console.WriteLine("Database read error occured");
                return null;
            }

            return person.DateOfBirth == null ?
                FormatPersonWithUnknownDateOfBirth(person, personsPet) :
                FormatPerson(person, personsPet);
        }

        private Pet GetPet(Person person)
        {
            return person == null ? null : _database.GetPet(person.PetId ?? person.FamilyPetId);
        }

        private static string FormatPerson(Person person, Pet personsPet)
        {
            return FormatPerson(person, personsPet, $"born in {person.DateOfBirth.Value.Year}");
        }

        private static string FormatPersonWithUnknownDateOfBirth(Person person, Pet personsPet)
        {
            Console.WriteLine("The date of birth is not known");
            return FormatPerson(person, personsPet, $"(date of birth is unknown)");
        }

        private static string FormatPerson(Person person, Pet personsPet, string dateOfBirthInformation)
        {
            return $"{person.Name} {person.LastName} with pet " +
                   $"{(personsPet.PetId == null ? "unknown" : personsPet.PetId)}" +
                   $" {dateOfBirthInformation}";
        }
    }
}
