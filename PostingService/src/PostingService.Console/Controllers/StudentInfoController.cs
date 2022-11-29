using PostingService.Console.ServiceBus;
using PostingService.Persistence.Entities;

namespace PostingService.Console.Controllers
{
    public class StudentInfoController
    {
        public StudentInfoController()
        {

        }

        [ServiceBusEventHandler("GetStudentsApplications")]
        public IEnumerable<Application> GetStudentsApplications()
        {
            return new List<Application>{
              new Application{
                Id = 1,
                JobApplicant = null,
                JobPosting = null,
                DateOfApplication = DateTime.Now,
                ScheduleCoverage = 0.5M,
                LocationOverlap = true
              }
            };
        }
    }
}
