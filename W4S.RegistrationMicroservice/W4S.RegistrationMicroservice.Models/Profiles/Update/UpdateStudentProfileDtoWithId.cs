﻿using W4S.PostingService.Models.Entities;

namespace W4S.RegistrationMicroservice.Models.Profiles.Update
{
    public class UpdateStudentProfileDtoWithId
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? Surname { get; set; }
        public Guid Id { get; set; }
        public byte[]? Image { get; set; }
        public string? Description { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Building { get; set; }
        public byte[]? ResumeFile { get; set; }
        public List<Schedule>? Availability { get; set; }
    }
}
