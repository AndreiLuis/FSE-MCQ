using Policy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Repository.Role
{
    internal interface IPolicyRepository
    {
        PolicyEntity Insert(PolicyEntity policy);
        List<PolicyEntity> GetAll();
        List<PolicyEntity> Find(FilterEntity filter);
    }
}
