namespace W4S.RegistrationMicroservice.API.Exceptions
{
    public class IncorrectNIPNumberException : Exception
    {
        public IncorrectNIPNumberException(string message) 
            : base (message)
        {

        }
    }
}
