using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIDIA.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace SIDIA.Repositories
{
    public class BarangRepository: RepositoryBase
    {
        public List<BarangModel> Getbarang()
        {
            this.openConnection();

            string sql = "select id_barang IdBarang, nama_barang NamaBarang, harga, satuan, stok, tanggal_keluar TanggalKeluar, tanggal_masuk TanggalMasuk from barang";
            return this.getConnection().Query<BarangModel>(sql).ToList();
        }
    }
}
