﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.Profiles.Update
{
    public class UpdateStudentProfileDtoWithId : UpdateStudentProfileDto
    {
        public Guid Id { get; set; }
    }
}