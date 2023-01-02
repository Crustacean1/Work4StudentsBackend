namespace W4SRegistrationMicroservice.API.Exceptions
{
    public class CompanyNotInDatabaseException : Exception
    {
        public CompanyNotInDatabaseException(string message) 
            : base(message)
        {
        }
    }
}
