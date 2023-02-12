namespace W4S.RegistrationMicroservice.API.Extensions
{
    public static class FormFileExtensions
    {
        public static byte[] ExtractFileContent(this IFormFile file)
        {
            byte[] pgmFileContent = null;
            if (file?.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    pgmFileContent = ms.ToArray();
                }
            }
            return pgmFileContent;
        }
    }
}
