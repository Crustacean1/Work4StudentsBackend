namespace W4S.PostingService.Domain.ValueType
{
    public class ErrorAggregate
    {
        private readonly List<string> errorMessages = new();

        public bool HasErrors => errorMessages.Count != 0;

        public void AddError(string error)
        {
            errorMessages.Add(error);
        }

        public IEnumerable<string> ErrorMessages => errorMessages;
    }
}
