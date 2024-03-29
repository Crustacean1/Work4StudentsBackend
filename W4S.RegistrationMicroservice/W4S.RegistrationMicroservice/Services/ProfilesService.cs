﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using W4S.RegistrationMicroservice.API.Exceptions;
using W4S.RegistrationMicroservice.API.Interfaces;
using W4S.RegistrationMicroservice.API.Validations.Interfaces;
using W4S.RegistrationMicroservice.Data.DbContexts;
using W4S.RegistrationMicroservice.Data.Entities.Profiles;
using W4S.RegistrationMicroservice.Data.Entities.Users;
using W4S.RegistrationMicroservice.Models.Profiles.Update;
using W4S.RegistrationMicroservice.Models.ServiceBusEvents.Profiles;
using W4S.ServiceBus.Abstractions;
using W4S.RegistrationMicroservice.Models.Users;
using W4S.RegistrationMicroservice.Models;
using W4SRegistrationMicroservice.API.Exceptions;
using System.Text;
using W4S.PostingService.Models.Events;

namespace W4S.RegistrationMicroservice.API.Services
{
    public class ProfilesService : IProfilesService
    {
        private const int HOURS_IN_A_DAY = 24;

        private readonly UserbaseDbContext _dbContext;
        private readonly ILogger<ProfilesService> _logger;
        private readonly IDataValidator _dataValidator;
        private readonly IClient _client;

        public ProfilesService(
            UserbaseDbContext dbContext,
            ILogger<ProfilesService> logger,
            IDataValidator dataValidator,
            IClient client)
        {
            _dbContext = dbContext;
            _logger = logger;
            _dataValidator = dataValidator;
            _client = client;
        }

        #region Students

        public Guid CreateStudentProfile(Data.Entities.Users.Student student)
        {
            _logger.LogInformation($"Creating a new profile for Student with Id: {student.Id}");


            var profile = new StudentProfile()
            {
                Id = Guid.NewGuid(),
                PhotoFile = null,
                Description = "",
                EmailAddress = student.EmailAddress,
                PhoneNumber = student.PhoneNumber,
                Rating = 0.0m,
                Education = "",
                Experience = "",
                Country = student.Country,
                Region = student.Region,
                City = student.City,
                Street = student.Street,
                Building = student.Building,
                ResumeFile = null,
                StudentId = student.Id,
                Student = student
            };

            _logger.LogInformation($"Profile with an Id: {profile.Id} created.");

            try
            {
                _logger.LogInformation("Adding to the database...");
                _dbContext.StudentProfiles.Add(profile);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong with adding to the db.");
                _logger.LogInformation(ex.Message, ex);
                throw;
            }

            return profile.Id;
        }

        public void UpdateStudentProfile(UpdateStudentProfileDtoWithId dto)
        {
            StudentProfile? studentProfile = null;

            try
            {
                studentProfile = _dbContext.StudentProfiles // include photos, update photo and profile
                    .Where(p => p.Id == dto.Id)
                    .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find a profile with this Id.");
                _logger.LogError(ex.Message, ex);
                throw;
            }

            if (studentProfile != null)
            {
                _logger.LogInformation($"Found a profile with id: {studentProfile.Id}");
                var student = _dbContext.Students
                    .Where(e => e.Id == studentProfile.StudentId)
                    .FirstOrDefault();

                if (student == null)
                {
                    throw new UserNotFoundException("Couldn't find a student connected to that profile."); // not gonna happen
                }

                if (dto.EmailAddress.IsNullOrEmpty() || dto.FirstName.IsNullOrEmpty() || dto.Surname.IsNullOrEmpty()
                    || dto.Country.IsNullOrEmpty() || dto.Region.IsNullOrEmpty() || dto.City.IsNullOrEmpty()
                    || dto.Street.IsNullOrEmpty() || dto.Building.IsNullOrEmpty())
                {
                    throw new Exception("Fields EmailAddress, FirstName, Surname, Country, Region, City, Street, Building cannot be empty or null.");
                }

                if (dto.EmailAddress != studentProfile.EmailAddress)
                {
                    try
                    {
                        _logger.LogInformation("Validating email correctness.");
                        _dataValidator.ValidateEmailCorrectness(dto.EmailAddress, studentProfile.StudentId);
                        _dataValidator.ValidateUniversity(dto.EmailAddress);
                        _logger.LogInformation("Validated email correctness.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, ex);
                        throw;
                    }
                    student.EmailAddress = dto.EmailAddress;
                    studentProfile.EmailAddress = dto.EmailAddress;
                }
                if (dto.PhoneNumber != studentProfile.PhoneNumber)
                {
                    _logger.LogInformation("Validating phone number.");
                    //_dataValidator.ValidatePhoneNumber(dto.PhoneNumber);
                    _logger.LogInformation("Validated phone number.");
                    student.PhoneNumber = dto.PhoneNumber;
                    studentProfile.PhoneNumber = dto.PhoneNumber;
                }
                if (dto.Country != studentProfile.Country)
                {
                    student.Country = dto.Country;
                    studentProfile.Country = dto.Country;
                }
                if (dto.Region != studentProfile.Region)
                {
                    student.Region = dto.Region;
                    studentProfile.Region = dto.Region;

                }
                if (dto.City != studentProfile.City)
                {
                    student.City = dto.City;
                    studentProfile.City = dto.City;

                }
                if (dto.Street != studentProfile.Street)
                {
                    student.Street = dto.Street;
                    studentProfile.Street = dto.Street;
                }
                if (dto.Building != studentProfile.Building)
                {
                    student.Building = dto.Building;
                    studentProfile.Building = dto.Building;
                }
                if (dto.Availability != studentProfile.Avaiability)
                {
                    if (dto.Availability != null)
                    {
                        if (!dto.Availability.Any())
                        {
                            _logger.LogInformation("Avaiability is empty.");
                        }

                        List<StudentSchedule> availability = new List<StudentSchedule>();
                        foreach (var item in dto.Availability)
                        {
                            availability.Add(new StudentSchedule()
                            {
                                Id = Guid.NewGuid(),
                                StartHour = item.StartHour,
                                DayOfWeek = item.DayOfWeek,
                                Duration = item.Duration,
                                StudentProfileId = studentProfile.Id
                            });
                        }

                        foreach (var item in availability)
                        {
                            var endOfWorkHour = item.StartHour + item.Duration;

                            if (HOURS_IN_A_DAY < endOfWorkHour)
                            {
                                throw new Exception($"Incorrect value, you can't start work before midnight and end it after midnight in the previous day.");
                            }


                            if (availability.Any(x => item.DayOfWeek == x.DayOfWeek && item.Id != x.Id))
                            {
                                if (availability.Any(x => item.StartHour > x.StartHour && endOfWorkHour <= (x.StartHour + x.Duration) && item.Id != x.Id))
                                {
                                    _logger.LogInformation($"Overlapping {item.StartHour} and {endOfWorkHour}.");
                                    throw new Exception($"Overlapping with another avaiability.");
                                }
                                if (availability.Any(x => endOfWorkHour > x.StartHour && endOfWorkHour < (x.StartHour + x.Duration) && item.Id != x.Id))
                                {
                                    _logger.LogInformation($"Overlapping {item.StartHour} and {endOfWorkHour}.");
                                    throw new Exception($"Overlapping with another avaiability.");
                                }
                            }
                        }

                        var availabilityToRemove = _dbContext.StudentSchedules
                            .Where(x => x.StudentProfileId == studentProfile.Id)
                            .ToList();

                        _logger.LogInformation($"Clearing {availabilityToRemove.Count()} schedules.");

                        foreach (var item in availabilityToRemove)
                        {
                            _logger.LogInformation($"Schedule with id: {item.Id} is to be removed.");
                            _dbContext.StudentSchedules.Remove(item);
                        }

                        _dbContext.StudentSchedules.AddRange(availability);
                        _dbContext.SaveChanges();
                        studentProfile.Avaiability = availability;
                    }
                    else
                    {
                        studentProfile.Avaiability = null;
                    }
                }

                if (dto.Description != studentProfile.Description)
                {
                    studentProfile.Description = dto.Description;
                }
                if (dto.Education != studentProfile.Education)
                {
                    studentProfile.Education = dto.Education;
                }
                if (dto.Experience != studentProfile.Experience)
                {
                    studentProfile.Experience = dto.Experience;
                }
                if (dto.FirstName != student.Name)
                {
                    student.Name = dto.FirstName;
                }
                if (dto.SecondName != student.SecondName)
                {
                    student.SecondName = dto.SecondName;
                }
                if (dto.Surname != student.Surname)
                {
                    student.Surname = dto.Surname;
                }

                if (dto.Image == null)
                {
                    _logger.LogInformation("This image is null, do something.");
                }
                else
                {
                    _logger.LogInformation("This image is not null yeah 8)");
                }

                if (dto.ResumeFile == null)
                {
                    _logger.LogInformation("This resume is null, do something.");
                }
                else
                {
                    _logger.LogInformation("This resume is not null yeah 8)");
                }
                _dbContext.Students.Update(student);
                _dbContext.StudentProfiles.Update(studentProfile);
                _dbContext.SaveChanges();

                if (dto.ResumeFile != studentProfile.ResumeFile)
                {
                    studentProfile.ResumeFile = null;
                    _dbContext.StudentProfiles.Update(studentProfile);
                    _dbContext.SaveChanges();

                    studentProfile.ResumeFile = dto.ResumeFile;
                    _dbContext.StudentProfiles.Update(studentProfile);
                    _dbContext.SaveChanges();
                }
                if (dto.Image != studentProfile.PhotoFile)
                {
                    studentProfile.PhotoFile = null;
                    _dbContext.StudentProfiles.Update(studentProfile);
                    _dbContext.SaveChanges();

                    studentProfile.PhotoFile = dto.Image;
                    _dbContext.StudentProfiles.Update(studentProfile);
                    _dbContext.SaveChanges();
                }

                var newEvent = new UserInfoUpdatedEvent()
                {
                    UserId = studentProfile.StudentId,
                    EmailAddress = dto.EmailAddress,
                    PhoneNumber = dto.PhoneNumber,
                    Country = dto.Country,
                    Region = dto.Region,
                    City = dto.City,
                    Street = dto.Street,
                    Building = dto.Building,
                    Availability = dto.Availability,
                    FirstName = dto.FirstName,
                    SecondName = dto.SecondName,
                    Surname = dto.Surname
                };

                _client.SendEvent<UserInfoUpdatedEvent>("registration.user.profile.updated", newEvent);
                _logger.LogInformation("Sent an event about updated user.");
            }
        }


        public void UpdateStudentProfilePhotosResumesCorrected(UpdateStudentProfileDtoWithId dto)
        {
            StudentProfile? studentProfile = null;

            try
            {
                studentProfile = _dbContext.StudentProfiles
                    .Where(p => p.Id == dto.Id)
                    .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find a profile with this Id.");
                _logger.LogError(ex.Message, ex);
                throw;
            }

            if (studentProfile != null)
            {
                _logger.LogInformation($"Found a profile with id: {studentProfile.Id}");
                var student = _dbContext.Students
                    .Where(e => e.Id == studentProfile.StudentId)
                    .FirstOrDefault();

                if (student == null)
                {
                    throw new UserNotFoundException("Couldn't find a student connected to that profile."); // not gonna happen
                }

                if (dto.EmailAddress.IsNullOrEmpty() || dto.FirstName.IsNullOrEmpty() || dto.Surname.IsNullOrEmpty()
                    || dto.Country.IsNullOrEmpty() || dto.Region.IsNullOrEmpty() || dto.City.IsNullOrEmpty()
                    || dto.Street.IsNullOrEmpty() || dto.Building.IsNullOrEmpty())
                {
                    throw new Exception("Fields EmailAddress, FirstName, Surname, Country, Region, City, Street, Building cannot be empty or null.");
                }
                if (dto.EmailAddress != studentProfile.EmailAddress)
                {
                    try
                    {
                        _logger.LogInformation("Validating email correctness.");
                        _dataValidator.ValidateEmailCorrectness(dto.EmailAddress, studentProfile.StudentId);
                        _dataValidator.ValidateUniversity(dto.EmailAddress);
                        _logger.LogInformation("Validated email correctness.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, ex);
                        throw;
                    }
                    student.EmailAddress = dto.EmailAddress;
                    studentProfile.EmailAddress = dto.EmailAddress;
                }
                if (dto.PhoneNumber != studentProfile.PhoneNumber)
                {
                    _logger.LogInformation("Validating phone number.");
                    //_dataValidator.ValidatePhoneNumber(dto.PhoneNumber);
                    _logger.LogInformation("Validated phone number.");
                    student.PhoneNumber = dto.PhoneNumber;
                    studentProfile.PhoneNumber = dto.PhoneNumber;
                }
                if (dto.Country != studentProfile.Country)
                {
                    student.Country = dto.Country;
                    studentProfile.Country = dto.Country;
                }
                if (dto.Region != studentProfile.Region)
                {
                    student.Region = dto.Region;
                    studentProfile.Region = dto.Region;

                }
                if (dto.City != studentProfile.City)
                {
                    student.City = dto.City;
                    studentProfile.City = dto.City;

                }
                if (dto.Street != studentProfile.Street)
                {
                    student.Street = dto.Street;
                    studentProfile.Street = dto.Street;
                }
                if (dto.Building != studentProfile.Building)
                {
                    student.Building = dto.Building;
                    studentProfile.Building = dto.Building;
                }
                if (dto.Availability != studentProfile.Avaiability)
                {
                    if (dto.Availability != null)
                    {
                        if (!dto.Availability.Any())
                        {
                            _logger.LogInformation("Avaiability is empty.");
                        }

                        List<StudentSchedule> availability = new List<StudentSchedule>();
                        foreach (var item in dto.Availability)
                        {
                            availability.Add(new StudentSchedule()
                            {
                                Id = Guid.NewGuid(),
                                StartHour = item.StartHour,
                                DayOfWeek = item.DayOfWeek,
                                Duration = item.Duration,
                                StudentProfileId = studentProfile.Id
                            });
                        }

                        foreach (var item in availability)
                        {
                            var endOfWorkHour = item.StartHour + item.Duration;

                            if (HOURS_IN_A_DAY < endOfWorkHour)
                            {
                                throw new Exception($"Incorrect value, you can't start work before midnight and end it after midnight in the previous day.");
                            }

                            if (availability.Any(x => item.DayOfWeek == x.DayOfWeek && item.Id != x.Id))
                            {
                                if (availability.Any(x => item.StartHour > x.StartHour && endOfWorkHour <= (x.StartHour + x.Duration) && item.Id != x.Id))
                                {
                                    _logger.LogInformation($"Overlapping {item.StartHour} and {endOfWorkHour}.");
                                    throw new Exception($"Overlapping with another avaiability.");
                                }
                                if (availability.Any(x => endOfWorkHour > x.StartHour && endOfWorkHour < (x.StartHour + x.Duration) && item.Id != x.Id))
                                {
                                    _logger.LogInformation($"Overlapping {item.StartHour} and {endOfWorkHour}.");
                                    throw new Exception($"Overlapping with another avaiability.");
                                }
                            }
                        }

                        var availabilityToRemove = _dbContext.StudentSchedules
                            .Where(x => x.StudentProfileId == studentProfile.Id)
                            .ToList();

                        _logger.LogInformation($"Clearing {availabilityToRemove.Count()} schedules.");

                        foreach (var item in availabilityToRemove)
                        {
                            _logger.LogInformation($"Schedule with id: {item.Id} is to be removed.");
                            _dbContext.StudentSchedules.Remove(item);
                        }

                        _dbContext.StudentSchedules.AddRange(availability);
                        _dbContext.SaveChanges();
                        studentProfile.Avaiability = availability;
                    }
                    else
                    {
                        studentProfile.Avaiability = null;
                    }
                }

                if (dto.Description != studentProfile.Description)
                {
                    studentProfile.Description = dto.Description;
                }
                if (dto.Education != studentProfile.Education)
                {
                    studentProfile.Education = dto.Education;
                }
                if (dto.Experience != studentProfile.Experience)
                {
                    studentProfile.Experience = dto.Experience;
                }
                if (dto.FirstName != student.Name)
                {
                    student.Name = dto.FirstName;
                }
                if (dto.SecondName != student.SecondName)
                {
                    student.SecondName = dto.SecondName;
                }
                if (dto.Surname != student.Surname)
                {
                    student.Surname = dto.Surname;
                }

                if (dto.Image == null)
                {
                    _logger.LogInformation("This image is null, do something.");
                }
                else
                {
                    _logger.LogInformation("This image is not null yeah 8)");
                }

                if (dto.ResumeFile == null)
                {
                    _logger.LogInformation("This resume is null, do something.");
                }
                else
                {
                    _logger.LogInformation("This resume is not null yeah 8)");
                }
                _dbContext.Students.Update(student);
                _dbContext.StudentProfiles.Update(studentProfile);
                _dbContext.SaveChanges();

                if (dto.ResumeFile != null)
                {
                    if (Convert.ToBase64String(dto.ResumeFile) != "")
                    {
                        studentProfile.ResumeFile = null;
                        _dbContext.StudentProfiles.Update(studentProfile);
                        _dbContext.SaveChanges();

                        studentProfile.ResumeFile = dto.ResumeFile;
                        _dbContext.StudentProfiles.Update(studentProfile);
                        _dbContext.SaveChanges();
                    }

                }
                if (dto.Image != null)
                {
                    if (Convert.ToBase64String(dto.Image) != "")
                    {
                        studentProfile.PhotoFile = null;
                        _dbContext.StudentProfiles.Update(studentProfile);
                        _dbContext.SaveChanges();

                        studentProfile.PhotoFile = dto.Image;
                        _dbContext.StudentProfiles.Update(studentProfile);
                        _dbContext.SaveChanges();
                    }
                }

                var newEvent = new UserInfoUpdatedEvent()
                {
                    UserId = studentProfile.StudentId,
                    EmailAddress = dto.EmailAddress,
                    PhoneNumber = dto.PhoneNumber,
                    Country = dto.Country,
                    Region = dto.Region,
                    City = dto.City,
                    Street = dto.Street,
                    Building = dto.Building,
                    Availability = dto.Availability,
                    FirstName = dto.FirstName,
                    SecondName = dto.SecondName,
                    Surname = dto.Surname
                };

                _client.SendEvent<UserInfoUpdatedEvent>("registration.user.profile.updated", newEvent);
                _logger.LogInformation("Sent an event about updated user.");
            }
        }

        public void UpdateStudentAvailability(UpdateStudentSchedule dto)
        {
            StudentProfile? studentProfile = null;

            try
            {
                studentProfile = _dbContext.StudentProfiles
                    .Where(p => p.StudentId == dto.StudentId)
                    .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find a profile with this Id.");
                _logger.LogError(ex.Message, ex);
                throw;
            }

            if (studentProfile != null)
            {
                _logger.LogInformation($"Found a profile with id: {studentProfile.Id}");
                var student = _dbContext.Students
                    .Where(e => e.Id == studentProfile.StudentId)
                    .FirstOrDefault();

                if (dto.Schedule != studentProfile.Avaiability)
                {
                    if (dto.Schedule != null)
                    {
                        if (!dto.Schedule.Any())
                        {
                            _logger.LogInformation("Avaiability is empty.");
                        }

                        List<StudentSchedule> availability = new List<StudentSchedule>();
                        foreach (var item in dto.Schedule)
                        {
                            availability.Add(new StudentSchedule()
                            {
                                Id = Guid.NewGuid(),
                                StartHour = item.StartHour,
                                DayOfWeek = item.DayOfWeek,
                                Duration = item.Duration,
                                StudentProfileId = studentProfile.Id
                            });
                        }

                        foreach (var item in availability)
                        {
                            var endOfWorkHour = item.StartHour + item.Duration;

                            if (HOURS_IN_A_DAY < endOfWorkHour)
                            {
                                throw new Exception($"Incorrect value, you can't start work before midnight and end it after midnight in the previous day.");
                            }

                            if (availability.Any(x => item.DayOfWeek == x.DayOfWeek && item.Id != x.Id))
                            {
                                if (availability.Any(x => item.StartHour > x.StartHour && endOfWorkHour <= (x.StartHour + x.Duration) && item.Id != x.Id))
                                {
                                    _logger.LogInformation($"Overlapping {item.StartHour} and {endOfWorkHour}.");
                                    throw new Exception($"Overlapping with another avaiability.");
                                }
                                if (availability.Any(x => endOfWorkHour > x.StartHour && endOfWorkHour < (x.StartHour + x.Duration) && item.Id != x.Id))
                                {
                                    _logger.LogInformation($"Overlapping {item.StartHour} and {endOfWorkHour}.");
                                    throw new Exception($"Overlapping with another avaiability.");
                                }
                            }
                        }

                        var availabilityToRemove = _dbContext.StudentSchedules
                            .Where(x => x.StudentProfileId == studentProfile.Id)
                            .ToList();

                        _logger.LogInformation($"Clearing {availabilityToRemove.Count()} schedules.");

                        foreach (var item in availabilityToRemove)
                        {
                            _logger.LogInformation($"Schedule with id: {item.Id} is to be removed.");
                            _dbContext.StudentSchedules.Remove(item);
                        }

                        _dbContext.StudentSchedules.AddRange(availability);
                        _dbContext.SaveChanges();
                        studentProfile.Avaiability = availability;
                    }
                    else
                    {
                        studentProfile.Avaiability = null;
                    }
                }

                var newEvent = new UserInfoUpdatedEvent()
                {
                    UserId = studentProfile.StudentId,
                    EmailAddress = studentProfile.EmailAddress,
                    PhoneNumber = studentProfile.PhoneNumber,
                    Country = studentProfile.Country,
                    Region = studentProfile.Region,
                    City = studentProfile.City,
                    Street = studentProfile.Street,
                    Building = studentProfile.Building,
                    Availability = dto.Schedule,
                    FirstName = student?.Name,
                    SecondName = student?.SecondName,
                    Surname = student?.Surname
                };
                _client.SendEvent<UserInfoUpdatedEvent>("registration.user.profile.updated", newEvent);
            }
        }
        public void UpdateStudentRating(UserRatingChangedEvent changedEvent)
        {
            var studentProfile = _dbContext.StudentProfiles.Where(x => x.StudentId == changedEvent.UserId).FirstOrDefault();

            if (studentProfile == null)
            {
                throw new UserNotFoundException("There is no student with this Id connected to any profile.");
            }

            studentProfile.Rating = changedEvent.Rating;
            _dbContext.StudentProfiles.Update(studentProfile);
            _dbContext.SaveChanges();
        }

        public StudentProfile GetStudentProfile(Guid id)
        {
            _logger.LogInformation("Getting student profile from the database.");
            try
            {
                var studentProfile = _dbContext.StudentProfiles
                    .Where(p => p.Id == id)
                    .First();
                _logger.LogInformation($"Found profile with id: {id}.");

                var student = _dbContext.Students
                    .Where(s => s.Id == studentProfile.StudentId)
                    .First();

                studentProfile.Student = student;

                return studentProfile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public StudentProfile GetStudentProfileByStudentId(Guid studentId)
        {

            _logger.LogInformation("Getting student profile from the database.");
            try
            {
                var studentProfile = _dbContext.StudentProfiles
                    .Where(p => p.StudentId == studentId)
                    .Include(x => x.Avaiability)
                    .First();

                _logger.LogInformation($"Found a profile with student id: {studentProfile.StudentId}");

                var student = _dbContext.Students
                    .Where(s => s.Id == studentProfile.StudentId)
                    .First();

                _logger.LogInformation($"Found a student with student id: {studentProfile.StudentId}");

                studentProfile.Student = student;
                return studentProfile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException?.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public void DeleteStudentResume(Guid studentId)
        {
            StudentProfile? studentProfile = null;
            try
            {
                studentProfile = _dbContext.StudentProfiles
                        .Where(p => p.StudentId == studentId)
                        .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find a profile with this Id.");
                _logger.LogError(ex.Message, ex);
                throw;
            }

            _logger.LogInformation($"Found a student with Id: {studentId}.");

            try
            {
                string empty = "";
                studentProfile.ResumeFile = Encoding.UTF8.GetBytes(empty);
                _dbContext.StudentProfiles.Update(studentProfile);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not delete a resume on profile of a student with Id: {studentId}.");
                _logger.LogError(ex.Message, ex);
                throw;
            }

        }

        public byte[]? GetStudentResume(Guid studentId)
        {
            var resume = _dbContext.StudentProfiles
                .Where(r => r.StudentId == studentId)
                .FirstOrDefault()?
                .ResumeFile;

            if (resume == null)
            {
                _logger.LogInformation("This resume is null.");
            }
            return resume;
        }

        #endregion

        #region Employer

        public Guid CreateEmployerProfile(Employer employer, string companyName)
        {
            try
            {
                CheckIfEntityProfileAlreadyExist(employer.Id);
            }
            catch (Exception)
            {
                throw;
            }

            _logger.LogInformation("Creating a new profile for Student with Id: ...");

            var profile = new EmployerProfile()
            {
                Id = Guid.NewGuid(),
                Description = "",
                EmailAddress = employer.EmailAddress,
                PhoneNumber = employer.PhoneNumber,
                Rating = 0.0m,
                Country = employer.Country,
                Region = employer.Region,
                City = employer.City,
                Street = employer.Street,
                Building = employer.Building,
                PositionName = employer.PositionName,
                CompanyName = companyName,
                EmployerId = employer.Id,
                Employer = employer
            };

            _logger.LogInformation($"Profile with an Id: {profile.Id} created.");

            try
            {
                _logger.LogInformation("Adding to the database...");
                _dbContext.EmployerProfiles.Add(profile);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Something went wrong with adding to the db.");
                _logger.LogInformation(ex.Message, ex);
                throw;
            }

            return profile.Id;
        }

        public void UpdateEmployerProfile(UpdateEmployerProfileDtoWithId dto)
        {
            EmployerProfile? employerProfile = null;
            try
            {
                employerProfile = _dbContext.EmployerProfiles
                        .Where(p => p.Id == dto.Id)
                        .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find a profile with this Id.");
                _logger.LogError(ex.Message, ex);
                throw;
            }


            if (dto.EmailAddress.IsNullOrEmpty() || dto.FirstName.IsNullOrEmpty() || dto.Surname.IsNullOrEmpty()
                || dto.Country.IsNullOrEmpty() || dto.Region.IsNullOrEmpty() || dto.City.IsNullOrEmpty()
                || dto.Street.IsNullOrEmpty() || dto.Building.IsNullOrEmpty() || dto.PositionName.IsNullOrEmpty())
            {
                throw new Exception("Fields EmailAddress, FirstName, Surname, Country, Region, City, Street, Building, PositionName cannot be empty or null.");
            }

            if (employerProfile != null)
            {
                _logger.LogInformation($"Found a profile with id: {employerProfile.Id}");

                var employer = _dbContext.Employers
                    .Where(e => e.Id == employerProfile.EmployerId)
                    .FirstOrDefault();

                if (employer == null)
                {
                    throw new UserNotFoundException("Couldn't find an employer connected to that profile."); // not gonna happen
                }

                if (dto.EmailAddress != employerProfile.EmailAddress)
                {
                    try
                    {
                        _logger.LogInformation("Validating email correctness.");
                        _dataValidator.ValidateEmailCorrectness(dto.EmailAddress, employerProfile.EmployerId);
                        _logger.LogInformation("Validated email correctness.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, ex);
                        throw;
                    }
                    employer.EmailAddress = dto.EmailAddress;
                    employerProfile.EmailAddress = dto.EmailAddress;
                }
                if (dto.PhoneNumber != employerProfile.PhoneNumber)
                {
                    _logger.LogInformation("Validating phone number.");
                    //_dataValidator.ValidatePhoneNumber(dto.PhoneNumber);
                    _logger.LogInformation("Validated phone number.");
                    employer.PhoneNumber = dto.PhoneNumber;
                    employerProfile.PhoneNumber = dto.PhoneNumber;
                }
                if (dto.Country != employerProfile.Country)
                {
                    employer.Country = dto.Country;
                    employerProfile.Country = dto.Country;
                }
                if (dto.Region != employerProfile.Region)
                {
                    employer.Region = dto.Region;
                    employerProfile.Region = dto.Region;

                }
                if (dto.City != employerProfile.City)
                {
                    employer.City = dto.City;
                    employerProfile.City = dto.City;

                }
                if (dto.Street != employerProfile.Street)
                {
                    employer.Street = dto.Street;
                    employerProfile.Street = dto.Street;
                }
                if (dto.Building != employerProfile.Building)
                {
                    employer.Building = dto.Building;
                    employerProfile.Building = dto.Building;
                }
                if (dto.Description != employerProfile.Description)
                {
                    employerProfile.Description = dto.Description;
                }
                if (dto.PositionName != employerProfile.PositionName)
                {
                    employer.PositionName = dto.PositionName;
                    employerProfile.PositionName = dto.PositionName;
                }
                if (dto.FirstName != employer.Name)
                {
                    employer.Name = dto.FirstName;
                }
                if (dto.SecondName != employer.SecondName)
                {
                    employer.SecondName = dto.SecondName;
                }
                if (dto.Surname != employer.Surname)
                {
                    employer.Surname = dto.Surname;
                }

                _logger.LogInformation("Trying to update employer and employerProfile.");

                if (dto.Image == null)
                {
                    _logger.LogInformation("This image is null, do something.");
                }
                else
                {
                    _logger.LogInformation("This image is not null yeah 8)");
                }

                if (dto.Image != employerProfile.PhotoFile)
                {
                    employerProfile.PhotoFile = null;
                    _dbContext.EmployerProfiles.Update(employerProfile);
                    _dbContext.SaveChanges();

                    employerProfile.PhotoFile = dto.Image;
                    _dbContext.EmployerProfiles.Update(employerProfile);
                    _dbContext.SaveChanges();
                }

                _dbContext.Employers.Update(employer);
                _dbContext.EmployerProfiles.Update(employerProfile);
                _dbContext.SaveChanges();

                var newEvent = new UserInfoUpdatedEvent()
                {
                    UserId = employerProfile.EmployerId,
                    EmailAddress = dto.EmailAddress,
                    PhoneNumber = dto.PhoneNumber,
                    Country = dto.Country,
                    Region = dto.Region,
                    City = dto.City,
                    Street = dto.Street,
                    Building = dto.Building,
                    Availability = null,
                    FirstName = dto.FirstName,
                    SecondName = dto.SecondName,
                    Surname = dto.Surname
                };

                _client.SendEvent<UserInfoUpdatedEvent>("registration.user.profile.updated", newEvent);
                _logger.LogInformation("Sent an event about updated user.");
            }
        }

        public void UpdateEmployerProfilePhotosCorrected(UpdateEmployerProfileDtoWithId dto)
        {
            EmployerProfile? employerProfile = null;
            try
            {
                employerProfile = _dbContext.EmployerProfiles
                        .Where(p => p.Id == dto.Id)
                        .First();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not find a profile with this Id.");
                _logger.LogError(ex.Message, ex);
                throw;
            }


            if (dto.EmailAddress.IsNullOrEmpty() || dto.FirstName.IsNullOrEmpty() || dto.Surname.IsNullOrEmpty()
                || dto.Country.IsNullOrEmpty() || dto.Region.IsNullOrEmpty() || dto.City.IsNullOrEmpty()
                || dto.Street.IsNullOrEmpty() || dto.Building.IsNullOrEmpty() || dto.PositionName.IsNullOrEmpty())
            {
                throw new Exception("Fields EmailAddress, FirstName, Surname, Country, Region, City, Street, Building, PositionName cannot be empty or null.");
            }

            if (employerProfile != null)
            {
                _logger.LogInformation($"Found a profile with id: {employerProfile.Id}");

                var employer = _dbContext.Employers
                    .Where(e => e.Id == employerProfile.EmployerId)
                    .FirstOrDefault();

                if (employer == null)
                {
                    throw new UserNotFoundException("Couldn't find an employer connected to that profile."); // not gonna happen
                }

                if (dto.EmailAddress != employerProfile.EmailAddress)
                {
                    try
                    {
                        _logger.LogInformation("Validating email correctness.");
                        _dataValidator.ValidateEmailCorrectness(dto.EmailAddress, employerProfile.EmployerId);
                        _logger.LogInformation("Validated email correctness.");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, ex);
                        throw;
                    }
                    employer.EmailAddress = dto.EmailAddress;
                    employerProfile.EmailAddress = dto.EmailAddress;
                }
                if (dto.PhoneNumber != employerProfile.PhoneNumber)
                {
                    _logger.LogInformation("Validating phone number.");
                    //_dataValidator.ValidatePhoneNumber(dto.PhoneNumber);
                    _logger.LogInformation("Validated phone number.");
                    employer.PhoneNumber = dto.PhoneNumber;
                    employerProfile.PhoneNumber = dto.PhoneNumber;
                }
                if (dto.Country != employerProfile.Country)
                {
                    employer.Country = dto.Country;
                    employerProfile.Country = dto.Country;
                }
                if (dto.Region != employerProfile.Region)
                {
                    employer.Region = dto.Region;
                    employerProfile.Region = dto.Region;

                }
                if (dto.City != employerProfile.City)
                {
                    employer.City = dto.City;
                    employerProfile.City = dto.City;

                }
                if (dto.Street != employerProfile.Street)
                {
                    employer.Street = dto.Street;
                    employerProfile.Street = dto.Street;
                }
                if (dto.Building != employerProfile.Building)
                {
                    employer.Building = dto.Building;
                    employerProfile.Building = dto.Building;
                }
                if (dto.Description != employerProfile.Description)
                {
                    employerProfile.Description = dto.Description;
                }
                if (dto.PositionName != employerProfile.PositionName)
                {
                    employer.PositionName = dto.PositionName;
                    employerProfile.PositionName = dto.PositionName;
                }
                if (dto.FirstName != employer.Name)
                {
                    employer.Name = dto.FirstName;
                }
                if (dto.SecondName != employer.SecondName)
                {
                    employer.SecondName = dto.SecondName;
                }
                if (dto.Surname != employer.Surname)
                {
                    employer.Surname = dto.Surname;
                }

                _logger.LogInformation("Trying to update employer and employerProfile.");

                if (dto.Image == null)
                {
                    _logger.LogInformation("This image is null, do something.");
                }
                else
                {
                    _logger.LogInformation("This image is not null yeah 8)");
                }

                if (dto.Image != null)
                {
                    if (Convert.ToBase64String(dto.Image) != "")
                    {
                        employerProfile.PhotoFile = null;
                        _dbContext.EmployerProfiles.Update(employerProfile);
                        _dbContext.SaveChanges();

                        employerProfile.PhotoFile = dto.Image;
                        _dbContext.EmployerProfiles.Update(employerProfile);
                        _dbContext.SaveChanges();
                    }
                }

                _dbContext.Employers.Update(employer);
                _dbContext.EmployerProfiles.Update(employerProfile);
                _dbContext.SaveChanges();

                var newEvent = new UserInfoUpdatedEvent()
                {
                    UserId = employerProfile.EmployerId,
                    EmailAddress = dto.EmailAddress,
                    PhoneNumber = dto.PhoneNumber,
                    Country = dto.Country,
                    Region = dto.Region,
                    City = dto.City,
                    Street = dto.Street,
                    Building = dto.Building,
                    Availability = null,
                    FirstName = dto.FirstName,
                    SecondName = dto.SecondName,
                    Surname = dto.Surname
                };

                _client.SendEvent<UserInfoUpdatedEvent>("registration.user.profile.updated", newEvent);
                _logger.LogInformation("Sent an event about updated user.");
            }
        }
        public void UpdateEmployerRating(UserRatingChangedEvent changedEvent)
        {
            var employerProfile = _dbContext.EmployerProfiles.Where(x => x.EmployerId == changedEvent.UserId).FirstOrDefault();

            if (employerProfile == null)
            {
                throw new UserNotFoundException("There is no employer with this Id connected to any profile.");
            }

            employerProfile.Rating = changedEvent.Rating;
            _dbContext.EmployerProfiles.Update(employerProfile);
            _dbContext.SaveChanges();
        }

        public EmployerProfile GetEmployerProfile(Guid id)
        {
            _logger.LogInformation("Getting employer profile from the database.");
            try
            {
                var employerProfile = _dbContext.EmployerProfiles
                    .Where(p => p.Id == id)
                    .First();

                var employer = _dbContext.Employers
                    .Where(s => s.Id == employerProfile.EmployerId)
                    .First();

                employerProfile.Employer = employer;
                return employerProfile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public EmployerProfile GetEmployerProfileByEmployerId(Guid employerId)
        {

            _logger.LogInformation("Getting employer profile from the database.");
            try
            {
                var employerProfile = _dbContext.EmployerProfiles
                    .Where(p => p.EmployerId == employerId)
                    .First();

                var employer = _dbContext.Employers
                    .Where(s => s.Id == employerProfile.EmployerId)
                    .First();

                employerProfile.Employer = employer;
                return employerProfile;
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        public List<EmployerProfile> GetEmployerProfiles(Guid[] ids) // this should return all users, but paginated
        {
            _logger.LogInformation("Getting student profiles from the database.");
            try
            {
                var studentProfile = _dbContext.EmployerProfiles
                    .Where(p => ids.Contains(p.Id));
                return studentProfile.ToList();
            }
            catch (Exception ex)
            {
                var message = ex.InnerException.Message ?? ex.Message;
                _logger.LogError(message, ex);
                throw;
            }
        }

        #endregion

        #region Common methods

        public byte[]? GetUserPhoto(Guid profileId)
        {
            var photo = _dbContext.Profiles
                .Where(p => p.Id == profileId)
                .FirstOrDefault()?.PhotoFile;

            if (photo == null)
            {
                _logger.LogInformation("This photo is null.");
            }
            return photo;
        }

        private void CheckIfEntityProfileAlreadyExist(Guid entityId)
        {
            _logger.LogInformation("Checking if a profile for this entity already exists.");

            if (_dbContext.StudentProfiles.Where(p => p.StudentId == entityId).Any())
            {
                throw new ProfileAlreadyExistsException("Profile for this entity is already set up.");
            }
            else if (_dbContext.EmployerProfiles.Where(p => p.EmployerId == entityId).Any())
            {
                throw new ProfileAlreadyExistsException("Profile for this entity is already set up.");
            }
        }

        #endregion

        public PaginatedList<UserDto> GetUsers(PaginatedQuery query)
        {
            var totalCount = _dbContext.Users
                .Where(u => u.Name.Contains(query.Query) || u.Surname.Contains(query.Query) || u.EmailAddress.Contains(query.Query))
                .Count();

            var roles = _dbContext.Roles.ToList();

            var items = _dbContext.Users
                .Where(u => u.Name.Contains(query.Query) || u.Surname.Contains(query.Query) || u.EmailAddress.Contains(query.Query))
                .Join(_dbContext.Roles, u => u.RoleId, r => r.Id, (User, Role) => new { User, Role })
                .OrderBy(ag => ag.User.Surname + ag.User.Name)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .Select(ag => new UserDto
                {
                    UserId = ag.User.Id,
                    UserType = ag.Role.Description == "Administrator" ? 2 : ag.Role.Description == "Employer" ? 1 : 0,
                    FirstName = ag.User.Name,
                    Surname = ag.User.Surname,
                    EmailAddress = ag.User.EmailAddress
                });

            return new PaginatedList<UserDto>
            {
                Items = items.ToList(),
                MetaData = new MetaData
                {
                    TotalCount = totalCount,
                    Page = query.Page,
                    PageSize = query.PageSize
                }
            };
        }

    }
}
