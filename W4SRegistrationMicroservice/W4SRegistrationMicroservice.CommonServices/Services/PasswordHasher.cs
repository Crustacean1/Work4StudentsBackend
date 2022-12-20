using System.Security.Cryptography;
using System.Text;
using W4SRegistrationMicroservice.CommonServices.Interfaces;

namespace W4SRegistrationMicroservice.CommonServices.Services
{
    public class PasswordHasher : IHasher
    {
        public string HashText(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            StringBuilder stringBuilder = new StringBuilder();
            using (SHA256 hashstring = SHA256.Create())
            {
                byte[] hash = hashstring.ComputeHash(bytes);
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}
