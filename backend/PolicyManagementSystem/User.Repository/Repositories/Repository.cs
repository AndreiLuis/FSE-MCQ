using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Repository.Repositories
{
    public abstract class Repository
    {
        protected SqlConnection? _connection;
        protected SqlCommand? _command;

        protected string? ConnectonString { get; set; }

        protected Repository()
        {
            ConnectonString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|User.Database.mdf;Integrated Security=True";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectonString);
        }
    }
}
