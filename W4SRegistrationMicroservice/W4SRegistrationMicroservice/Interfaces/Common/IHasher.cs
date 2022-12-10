namespace W4SRegistrationMicroservice.API.Interfaces.Common
{
    public interface IHasher
    {
        string HashText(string password);
    }
}
