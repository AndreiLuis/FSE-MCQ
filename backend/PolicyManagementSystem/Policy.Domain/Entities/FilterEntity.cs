using Policy.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Domain.Entities
{
    public class FilterEntity
    {
        public int NumberOfYears { get; set; }
        public string Company { get; set; }
        public PolicyType PolicyType { get; set; }
        public string PolicyId { get; set; }
        public string PolicyName { get; set; }
    }
}
