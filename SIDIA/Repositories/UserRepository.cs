using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SIDIA.Models;
using Dapper;

namespace SIDIA.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public int Add(UserModel userModel)
        {
            this.openConnection();

            MySqlCommand cmd;

            cmd = new MySqlCommand("insert into users (username, password, nama, domisili, user_type) " +
                "values (@username, @password, @nama, @domisili, @user_type)", this.getConnection());
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = userModel.Password;
            cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = userModel.Nama;
            cmd.Parameters.Add("@domisili", MySqlDbType.VarChar).Value = userModel.Domisili;
            cmd.Parameters.Add("@user_type", MySqlDbType.VarChar).Value = userModel.UserType;
            cmd.Prepare();

            return cmd.ExecuteNonQuery();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            this.openConnection();
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
            this.openConnection();

            MySqlCommand cmd;

            cmd = new MySqlCommand("insert into users (username, password, nama, domisili, user_type) " +
                "values (@username, @password, @nama, @domisili, @user_type)", this.getConnection());
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = userModel.Password;
            cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = userModel.Nama;
            cmd.Parameters.Add("@domisili", MySqlDbType.VarChar).Value = userModel.Domisili;
            cmd.Parameters.Add("@user_type", MySqlDbType.VarChar).Value = userModel.UserType;
            cmd.Prepare();

            cmd.ExecuteNonQuery();
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
            this.openConnection();
            DataTable tbl = new DataTable();
            MySqlDataAdapter adpt = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("select * from users where username = @username", this.getConnection());
            cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;

            adpt.SelectCommand = cmd;
            adpt.Fill(tbl);

            if (tbl.Rows.Count == 0)
            {
                return (UserModel)null;
            }

            DataRow row = tbl.Rows[0];
            UserModel userModel = new UserModel();

            userModel.Id = row["id"].ToString();
            userModel.Username = row["username"].ToString();
            userModel.Password = row["password"].ToString();
            userModel.Domisili = row["domisili"].ToString();
            userModel.UserType = row["user_type"].ToString();

            return userModel;
        }
        public List<UserModel> GetAdmins()
        {
            this.openConnection();

            string sql = "select id, username, password, nama, domisili, user_type UserType from users where user_type ='admin'";
            return this.getConnection().Query<UserModel>(sql).ToList();
        }
        public List<UserModel> GetPegawais()
        {
            this.openConnection();

            string sql = "select id, username, password, nama, domisili, user_type UserType from users where user_type ='pegawai'";
            return this.getConnection().Query<UserModel>(sql).ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
