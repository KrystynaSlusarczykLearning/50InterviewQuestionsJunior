namespace Goto
{
    public interface IDatabase
    {
        Person GetPerson(string personId);
        Pet GetPet(string petId);
    }
}
