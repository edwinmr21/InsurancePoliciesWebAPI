﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InsurancePoliciesRepository.Contracts.Model
{
    public class InsuranceClientModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
