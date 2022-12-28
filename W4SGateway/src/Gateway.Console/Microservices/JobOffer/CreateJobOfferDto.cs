namespace Gateway.Console.Microservices.JobOffer
{
    public class CreateJobOfferDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Starts { get; set; }

        public DateTime Ends { get; set; }

        public Guid PosterId { get; set; }
    }
}
