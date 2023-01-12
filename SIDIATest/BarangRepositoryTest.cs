using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIDIA.Repositories;
using System.Collections.Generic;
using SIDIA.Models;
using System.Net;
using MySql.Data.MySqlClient;

namespace SIDIATest
{
    [TestClass]
    public class BarangRepositoryTest
    {
        [TestMethod]
        public void GetBarang()
        {
            var barangRepository = new BarangRepository();
            List<BarangModel> barang = barangRepository.Getbarang();
            Assert.IsTrue(barang.Count > 0);    
        }
    }
}