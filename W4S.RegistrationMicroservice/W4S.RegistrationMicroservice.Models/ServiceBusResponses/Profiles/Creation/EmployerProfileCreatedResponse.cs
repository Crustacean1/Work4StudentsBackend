﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4S.RegistrationMicroservice.Models.ServiceBusResponses.Profiles.Creation
{
    public class EmployerProfileCreatedResponse : BaseResponse
    {
        public Guid? Id { get; set; }
    }
}
