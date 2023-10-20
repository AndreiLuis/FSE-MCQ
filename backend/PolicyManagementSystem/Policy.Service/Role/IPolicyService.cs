using Policy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Service.Role
{
    public interface IPolicyService
    {
        void Register(PolicyEntity policy);
        List<PolicyEntity> GetAll();
        List<PolicyEntity> Searches(dynamic filter);
    }
}
