namespace W4S.RegistrationMicroservice.API.Exceptions
{
    public class UniversityDomainNotInDatabaseException : Exception
    {
        public UniversityDomainNotInDatabaseException(string message)
            : base(message)
        {

        }
    }
}
