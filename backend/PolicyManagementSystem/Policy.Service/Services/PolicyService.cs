using Policy.Domain.Entities;
using Policy.Service.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Service.Services
{
    public class PolicyService : IPolicyService
    {
        public void Register(PolicyEntity policy)
        {

        }

        public List<PolicyEntity> GetAll()
        {
            return new List<PolicyEntity>();
        }

        public List<PolicyEntity> Searches(dynamic filter)
        {
            return new List<PolicyEntity>();
        }
    }
}
