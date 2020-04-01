using System;
using System.Collections.Generic;
using System.Text;

namespace InsurancePoliciesLibrary.Contracts.DTOs
{
    public class ClientPolicy
    {
        public string Id { get; set; }

        public string ClientId { get; set; }

        public decimal AmountInsured { get; set; }

        public string Email { get; set; }

        public DateTime InceptionDate { get; set; }

        public bool InstallmentPayment { get; set; }
    }
}
