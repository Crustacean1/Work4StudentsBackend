namespace W4S.RegistrationMicroservice.API.Exceptions
{
    public class UserAlreadyRegisteredException : Exception
    {
        public UserAlreadyRegisteredException(string message) 
            : base(message)
        {
        }
    }
}
