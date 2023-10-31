using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policy.Repository.Repositories
{
    public abstract class Repository
    {
        protected SqlConnection? _connection;
        protected SqlCommand? _command;
        protected readonly SqlDataAdapter? _sqlAdapter;

        private string ConnectonString { get; set; }

        public Repository()
        {
            ConnectonString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Policy.Database.mdf;Integrated Security=True";
        }

        protected SqlConnection GetConnection()
        {
            return  new SqlConnection(ConnectonString);
        }

    }
}
