using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;
using User.Domain.Types;
using User.Repository.Role;

namespace User.Repository.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public void Insert(CostumerEntity costumer)
        {
            try
            {
                _connection = GetConnection();
                _connection.Open();

                _command = new SqlCommand("InsertCostumer", _connection);

                _command.CommandType = CommandType.StoredProcedure;

                _command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = costumer.FirstName;
                _command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = costumer.LastName;
                _command.Parameters.Add("@DateBirth", SqlDbType.DateTime).Value = costumer.DateOfBirth;
                _command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = costumer.Address;
                _command.Parameters.Add("@ContactNumber", SqlDbType.NVarChar).Value = costumer.ContactNumber;
                _command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = costumer.EmailAddress;
                _command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = costumer.Salary;
                _command.Parameters.Add("@PanNumber", SqlDbType.Int).Value = costumer.PanNumber;
                _command.Parameters.Add("@EmployerType", SqlDbType.NVarChar).Value = costumer.EmployerType.ToString();
                _command.Parameters.Add("@EmployerName", SqlDbType.NVarChar).Value = costumer.EmployerName;

                _command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection?.Close();
            }
        }

    }
}
