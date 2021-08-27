using System;

namespace Goto
{
    class VeryUglyPersonalDataFormatter
    {
        private readonly IDatabase _database;

        public VeryUglyPersonalDataFormatter(IDatabase database)
        {
            _database = database;
        }

        public string FormatPersonalData(string personId)
        {
            var person = _database.GetPerson(personId);
            if (person == null)
            {
                goto HandleError;
            }

            var petId = person.PetId;
            ReadPet:
            var personsPet = _database.GetPet(petId);
            if (personsPet == null)
            {
                if (person.FamilyPetId != null && petId != person.FamilyPetId)
                {
                    petId = person.FamilyPetId;
                    goto ReadPet;
                }
                goto HandleError;
            }

            if (person.DateOfBirth == null)
            {
                Console.WriteLine("The date of birth is not known");
                goto FormatPersonWithUnknownDateOfBirthText;
            }
            else
            {
                goto FormatPersonText;
            }

            FormatPersonText:
            return $"{person.Name} {person.LastName} with pet " +
                $"{(personsPet.PetId == null ? "unknown" : personsPet.PetId)}" +
                $" born in {person.DateOfBirth.Value.Year}";

            FormatPersonWithUnknownDateOfBirthText:
            return $"{person.Name} {person.LastName} with pet " +
                $"{(personsPet.PetId == null ? "unknown" : personsPet.PetId)}" +
                $" (date of birth is unknown)";

            HandleError:
            Console.WriteLine("Database read error occured");
            return null;
        }
    }
}
