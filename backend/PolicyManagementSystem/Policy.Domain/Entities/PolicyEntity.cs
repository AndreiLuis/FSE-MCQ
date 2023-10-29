using Policy.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Domain.Entities
{
    public class PolicyEntity
    {
        public string? PolicyId { get; set; }
        public string? PolicyName { get; set; }
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Duration in years
        /// </summary>
        public int Duration { get; set; }
        public string? Company { get; set; }
        public string? InitialDeposit { get; set; }
        public PolicyType PolicyType { get; set; }
        public UserType UserType { get; set; }
        public int TermsPerYear { get; set; }
        public decimal TermAmount { get; set; }
        /// <summary>
        /// Interest for the policy
        /// </summary>
        public bool Interest { get; set; }
    }
}
