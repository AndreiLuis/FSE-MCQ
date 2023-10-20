using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;

namespace User.Service.Role
{
    public interface ICostumerService
    {
        void Register(CostumerEntity costumer);
    }
}
