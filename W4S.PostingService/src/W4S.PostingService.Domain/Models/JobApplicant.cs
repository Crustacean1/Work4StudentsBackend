namespace PostingService.Domain.Models
{
    public class JobApplicant
    {
        public uint Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public IEnumerable<TimeSpan> Schedule { get; set; }
    }
}
