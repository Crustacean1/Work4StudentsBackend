namespace W4S.RegistrationMicroservice.API.Exceptions
{
    public class ProfileAlreadyExistsException : Exception
    {
        public ProfileAlreadyExistsException(string message)
            : base(message)
        {

        }
    }
}
