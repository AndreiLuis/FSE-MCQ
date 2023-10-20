using Policy.Domain.Entities;
using Policy.Repository.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Repository.Repositories
{
    public class PolicyRepository : Repository, IPolicyRepository
    {
        public void Insert(PolicyEntity policy) 
        {

        }

        public List<PolicyEntity> GetAll()
        {
            return new List<PolicyEntity>();
        }

        public List<PolicyEntity> Find(FilterEntity filter)
        {
            return new List<PolicyEntity>();
        }

    }
}
