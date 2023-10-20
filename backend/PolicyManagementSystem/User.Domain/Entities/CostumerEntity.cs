using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Types;

namespace User.Domain.Entities
{
    public class CostumerEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public decimal Salary { get; set; }
        public int PanNumber { get; set; }
        public EmployerType EmployerType { get; set;}
        /// <summary>
        /// In case of 'salaried' or 'optional'
        /// </summary>
        public string EmployerName { get; set; }
    }
}
