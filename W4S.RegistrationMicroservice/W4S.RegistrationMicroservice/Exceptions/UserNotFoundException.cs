namespace W4SRegistrationMicroservice.API.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) 
            : base(message)
        {

        }
        public UserNotFoundException(string message, Exception e) 
            : base(message, e)
        {

        }
    }
}
