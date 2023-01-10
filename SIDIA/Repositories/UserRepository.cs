using SIDIA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SIDIA.Models;

namespace SIDIA.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            DataTable tbl = new DataTable();
            MySqlDataAdapter adpt = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("select * from users where username = @username and password = @password", this.getConnection());
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = credential.UserName;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = credential.Password;

            adpt.SelectCommand = cmd;
            adpt.Fill(tbl);

            return tbl.Rows.Count > 0;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
