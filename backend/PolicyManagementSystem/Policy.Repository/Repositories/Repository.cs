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
        protected readonly SqlCommand _command;
        protected readonly SqlConnection _connection;
        protected readonly SqlDataAdapter _sqlAdapter;
        protected readonly DataTable _dataTable;

        protected Repository()
        {
            ConnectonString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Policy.Database.mdf;Integrated Security=True";
        }

        protected string ConnectonString { get; set; }
    }
}
