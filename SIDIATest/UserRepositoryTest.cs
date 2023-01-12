using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDIA.Repositories;
using SIDIA.Models;
using System.Net;
using MySql.Data.MySqlClient;

namespace SIDIATest
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void GetByUsername()
        {   
            UserRepository userRepository = new UserRepository();
            UserModel userModel = userRepository.GetByUsername("syahid");
            Assert.IsNotNull(userModel);
            UserModel userModelEmpty = userRepository.GetByUsername("wakwak");
            Assert.IsNull(userModelEmpty);
        }

        [TestMethod]
        public void AuthenticateUser()
        {
            UserRepository userRepository = new UserRepository();
            bool isValid = userRepository.AuthenticateUser(new NetworkCredential("syahid", "123"));
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void AddUser()
        {
            UserRepository userRepository = new UserRepository();
            userRepository.openConnection();
            MySqlTransaction trans = userRepository.getConnection().BeginTransaction();
            UserModel userModel = new UserModel()
            {
                Username = "syahid123",
                Password = "syahid123",
                Nama = "syahid",
                Domisili = "Yogyakarta",
                UserType = "admin"
            };
            int add = userRepository.Add(userModel);
            bool isValid = userRepository.AuthenticateUser(new NetworkCredential("syahid123", "syahid123"));
            Assert.IsTrue(isValid);
            trans.Rollback();
        }
    }
}