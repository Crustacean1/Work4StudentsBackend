namespace W4S.PostingService.Domain.Helpers
{
    public class UpdateProcessor
    {
        public static void Update<T>(T entity, T update) where T : class, new()
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var newValue = property.GetValue(update);

                if (newValue is not null)
                {
                    property.SetValue(entity, newValue);
                }
            }
        }
    }
}
