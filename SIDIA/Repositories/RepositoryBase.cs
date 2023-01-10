using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SIDIA.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase()
        {
        }
        private MySqlConnection _connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=fp_sidia");
        
        public void openConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void closeConnection()
        {
            if ( _connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return _connection;
        }
    }
}
