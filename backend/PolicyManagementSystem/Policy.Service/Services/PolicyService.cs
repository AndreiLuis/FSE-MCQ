using Policy.Domain.Entities;
using Policy.Repository.Repositories;
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
        public string Register(PolicyEntity policy)
        {
            policy.PolicyId = GeneratePolicyId(policy);
            var result = new PolicyRepository().Insert(policy);
            var policyCount = new PolicyRepository().GetPolicyCreationOrder(result.PolicyId);
            return GenerateSuccessMessage(result, policyCount);
        }

        private string GenerateSuccessMessage(PolicyEntity policy, int policyCount)
        {
            string policyId = policy.PolicyId;
            string startDate = policy.StartDate.ToString("dd-MM-yyyy");
            string endDate = policy.StartDate.AddYears(policy.Duration).ToString("dd-MM-yyyy");
            string policyType = policy.PolicyType.ToString();

            string content = $@"
        <html>
        <body>
            <p>Caro Admin,</p>
            <p>A política foi registrada com sucesso</p>
            <p>A política {policyId} está disponível para os usuários de {startDate} a {endDate}.</p>
            <p>Esta é a {policyCount}ª política no {policyType}. Para adicionar mais, clique em <a href='URL_DO_SEU_SITE'>Registro de Política</a>.</p>
        </body>
        </html>";

            return content;
        }


        private string GeneratePolicyId(PolicyEntity policy)
        {
            string policyTypeId = policy.PolicyType.ToString(); 
            string yearOfPolicyStart = policy.StartDate.Year.ToString();
            string lastPolicyId = new PolicyRepository().GetLastPolicyId();

            int lastNumber = int.Parse(lastPolicyId.Split('-').Last());
            int newNumber = lastNumber + 1;
            string newPolicyId = $"{policyTypeId}-{yearOfPolicyStart}-{newNumber.ToString("D3")}";

            return newPolicyId;
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
