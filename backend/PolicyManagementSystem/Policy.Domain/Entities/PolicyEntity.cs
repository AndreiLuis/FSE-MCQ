using Policy.Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Domain.Entities
{
    public class PolicyEntity
    {
        
        public string? PolicyId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? PolicyName { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Initial deposit is required.")]
        public string? InitialDeposit { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public PolicyType PolicyType { get; set; }

        [Required(ErrorMessage = "Type os user is required.")]
        public UserType UserType { get; set; }

        [Required(ErrorMessage = "Terms per year is required.")]
        public int TermsPerYear { get; set; }

        [Required(ErrorMessage = "Term amount is required.")]
        public decimal TermAmount { get; set; }

        [Required(ErrorMessage = "Interest is required.")]
        public bool Interest { get; set; }
    }
}
