using System.Security.Cryptography;
using System.Text;
using W4SRegistrationMicroservice.API.Interfaces.Common;

namespace W4SRegistrationMicroservice.API.Services.Common
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
