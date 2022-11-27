namespace W4SRegistrationMicroservice.API.Exceptions
{
    public class IncorrectNIPNumberException : Exception
    {
        public IncorrectNIPNumberException(string message) 
            : base (message)
        {

        }
    }
}
