using Policy.Domain.Entities;
using Policy.Domain.Types;
using Policy.Repository.Role;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Repository.Repositories
{
    public class PolicyRepository : Repository, IPolicyRepository
    {
        public PolicyEntity Insert(PolicyEntity policy) 
        {
            try
            {
                _connection = GetConnection();
                _command = new SqlCommand("InsertIntoPolicy", _connection);
                _connection.Open();
                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.AddWithValue("@Id", policy.PolicyId);
                _command.Parameters.AddWithValue("@Name", policy.PolicyName);
                _command.Parameters.AddWithValue("@StartDate", policy.StartDate);
                _command.Parameters.AddWithValue("@Duration", policy.Duration);
                _command.Parameters.AddWithValue("@Company", policy.Company);
                _command.Parameters.AddWithValue("@InitialDeposit", policy.InitialDeposit);
                _command.Parameters.AddWithValue("@Type", (int)policy.PolicyType);
                _command.Parameters.AddWithValue("@UserType", (int)policy.UserType);
                _command.Parameters.AddWithValue("@TermsPerYear", policy.TermsPerYear);
                _command.Parameters.AddWithValue("@TermAmount", policy.TermAmount);
                _command.Parameters.AddWithValue("@Interest", policy.Interest);
                
                _command.ExecuteNonQuery();

                return policy;
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                _connection?.Close();
            }
        }

        public List<PolicyEntity> GetAll()
        {
            try
            {
                var policies = new List<PolicyEntity>();
                var query = "SELECT * FROM Policy";
                _connection = GetConnection();
                _command = new SqlCommand(query, _connection);

                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var policy = new PolicyEntity
                        {
                            PolicyId = reader["Id"].ToString(),
                            PolicyName = reader["Name"].ToString(),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            Duration = Convert.ToInt32(reader["Duration"]),
                            Company = reader["Company"].ToString(),
                            InitialDeposit = reader["InitialDeposit"].ToString(),
                            PolicyType = (PolicyType)Convert.ToInt32(reader["Type"]),
                            UserType = (UserType)Convert.ToInt32(reader["UserType"]),
                            TermsPerYear = Convert.ToInt32(reader["TermsPerYear"]),
                            TermAmount = Convert.ToDecimal(reader["TermAmount"]),
                            Interest = Convert.ToBoolean(reader["Interest"])
                        };

                        policies.Add(policy);
                    }
                }
                return policies;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                _connection?.Close();
            }
        }

        public List<PolicyEntity> Find(FilterEntity filter)
        {
            try
            {
                var policies = new List<PolicyEntity>();
                var query = new StringBuilder("SELECT * FROM Policy WHERE Id is NOT NULL");

                _connection = GetConnection();
                _command = new SqlCommand();
                _command.Connection = _connection;
                _connection.Open();

                if (filter.NumberOfYears != 0)
                    query.Append(" AND Duration = @NumberOfYears");
                    _command.Parameters.AddWithValue("@NumberOfYears", filter.NumberOfYears);
                if (!string.IsNullOrEmpty(filter.Company))
                    query.Append(" AND Company = @Company");
                    _command.Parameters.AddWithValue("@Company", filter.Company);
                if (!string.IsNullOrEmpty(filter.PolicyId))
                    query.Append(" AND Id = @PolicyId");
                    _command.Parameters.AddWithValue("@PolicyId", filter.PolicyId);
                if (!string.IsNullOrEmpty(filter.PolicyName))
                    query.Append(" AND Name = @PolicyName");
                    _command.Parameters.AddWithValue("@PolicyName", filter.PolicyName);

                query.Append(" AND Type = @PolicyType");
                _command.Parameters.AddWithValue("@PolicyType", (int)filter.PolicyType);

                _command.CommandText = query.ToString();

                using (var reader = _command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var policy = new PolicyEntity
                        {
                            PolicyId = reader["Id"].ToString(),
                            PolicyName = reader["Name"].ToString(),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            Duration = Convert.ToInt32(reader["Duration"]),
                            Company = reader["Company"].ToString(),
                            InitialDeposit = reader["InitialDeposit"].ToString(),
                            PolicyType = (PolicyType)Convert.ToInt32(reader["Type"]),
                            UserType = (UserType)Convert.ToInt32(reader["UserType"]),
                            TermsPerYear = Convert.ToInt32(reader["TermsPerYear"]),
                            TermAmount = Convert.ToDecimal(reader["TermAmount"]),
                            Interest = Convert.ToBoolean(reader["Interest"])
                        };

                        policies.Add(policy);
                    }
                }

                return policies;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                _connection?.Close();
            }
        }

        public string GetLastPolicyId()
        {
            string? lastPolicyId = null;

            try
            {
                _connection = GetConnection();
                _command = new SqlCommand("SELECT TOP 1 Id FROM Policy ORDER BY Id DESC", _connection);

                _connection.Open();

                var reader = _command.ExecuteReader();

                if (reader.Read())
                {
                    lastPolicyId = reader["Id"].ToString();
                }

                return lastPolicyId;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                _connection?.Close();
            }
        }

        public int GetPolicyCreationOrder(string policyId)
        {
            try
            {
                _connection = GetConnection();
                _command = new SqlCommand("SELECT COUNT(*) FROM Policy WHERE Id < @Id", _connection);
                _command.Parameters.AddWithValue("@Id", policyId);

                _connection.Open();

                return (int)_command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                _connection?.Close();
            }

        }


    }
}
