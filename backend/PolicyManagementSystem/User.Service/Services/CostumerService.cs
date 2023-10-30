using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;
using User.Repository.Repositories;
using User.Service.Role;

namespace User.Service.Services
{
    public class CostumerService : ICostumerService
    {
        public void Register(CostumerEntity costumer)
        {
            new UserRepository().Insert(costumer);
        }
    }
}
