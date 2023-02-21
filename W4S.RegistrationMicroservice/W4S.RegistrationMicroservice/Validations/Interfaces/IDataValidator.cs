namespace W4S.RegistrationMicroservice.API.Validations.Interfaces
{
    public interface IDataValidator
    {
        string CheckDomain(string studentEmail);
        void ValidateEmailCorrectness(string email, Guid? userId);
        void ValidateNIPNumber(string nipNumber);
        Guid ValidateUniversity(string studentEmail);
    }
}