using W4SRegistrationMicroservice.Data.DbContexts;

namespace W4SRegistrationMicroservice.API.Services
{
    public class SigningInService
    {
        private readonly W4SUserbaseDbContext _dbContext;

        public SigningInService(W4SUserbaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string SignIn()
        {


            return string.Empty; // placeholder
        }
    }
}
