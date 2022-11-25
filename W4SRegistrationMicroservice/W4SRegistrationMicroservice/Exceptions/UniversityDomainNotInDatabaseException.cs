namespace W4SRegistrationMicroservice.API.Exceptions
{
    public class UniversityDomainNotInDatabaseException : Exception
    {
        public UniversityDomainNotInDatabaseException(string message)
            : base(message)
        {

        }
    }
}
