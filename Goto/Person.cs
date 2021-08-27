using System;

namespace Goto
{
    public class Person
    {
        public string Name { get; }
        public string LastName { get; }
        public DateTime? DateOfBirth { get; }
        public string PetId { get; }
        public string FamilyPetId { get; }

        public Person(string name, string lastName, DateTime? dateOfBirth, string petId, string familyPetId)
        {
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PetId = petId;
            FamilyPetId = familyPetId;
        }
    }
}
