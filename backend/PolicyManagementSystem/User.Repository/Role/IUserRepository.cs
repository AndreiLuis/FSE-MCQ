using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;

namespace User.Repository.Role
{
    public interface IUserRepository
    {
        void Insert(CostumerEntity costumer);
    }
}
