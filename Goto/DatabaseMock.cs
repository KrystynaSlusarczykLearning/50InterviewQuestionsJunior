namespace Goto
{
    public class DatabaseMock : IDatabase
    {
        public Person GetPerson(string personId)
        {
            if(personId == "John")
            {
                return new Person("John", "Smith", null, null, "Rex");
            }

            return null;
        }

        public Pet GetPet(string petId)
        {
            if (petId == "Rex")
            {
                return new Pet("Rex");
            }

            return null;
        }
    }
}