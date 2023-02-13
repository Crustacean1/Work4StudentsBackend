namespace W4S.RegistrationMicroservice.API.Exceptions
{
    public class IncorrectPhoneNumberException : Exception
    {
        public IncorrectPhoneNumberException(string message) : base(message) { }
    }
}
