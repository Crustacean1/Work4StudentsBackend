namespace W4SRegistrationMicroservice.CommonServices.Interfaces
{
    public interface IHasher
    {
        string HashText(string password);
    }
}
