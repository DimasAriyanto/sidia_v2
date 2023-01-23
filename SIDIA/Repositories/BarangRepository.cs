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

        public bool DeleteBarang(int IdBarang)
        {
            this.openConnection();

            string sql = "delete from barang where id_barang = @idBarang";
            int rowAffected = this.getConnection().ExecuteScalar<int>(sql, new { idBarang = IdBarang });
            return rowAffected > 0;
        }

        public bool UpdateBarang(int IdBarang, BarangModel barang)
        {
            this.openConnection();

            string sql = "update barang set nama_barang = @namaBarang, harga = @harga, satuan = @satuan, stok = @stok, tanggal_keluar = @tanggalKeluar, tanggal_masuk = @tanggalMasuk where id_barang = @idBarang";
            int rowAffected = this.getConnection().ExecuteScalar<int>(sql, new
            {
                namaBarang = barang.NamaBarang,
                harga = barang.Harga,
                satuan = barang.Satuan,
                stok = barang.Stok,
                tanggalKeluar = barang.TanggalKeluar,
                tanggalMasuk = barang.TanggalMasuk,
                idBarang = barang.IdBarang
            });
            return rowAffected > 0;
        }

        public void InsertBarang(BarangModel barang)
        {
            this.openConnection();

            string sql = "insert into barang (nama_barang, harga, satuan, stok, tanggal_keluar, tanggal_masuk) values (@namaBarang, @harga, @satuan, @stok, @tanggalKeluar, @tanggalMasuk)";
            this.getConnection().Execute(sql, new
            {
                namaBarang = barang.NamaBarang,
                harga = barang.Harga,
                satuan = barang.Satuan,
                stok = barang.Stok,
                tanggalKeluar = barang.TanggalKeluar,
                tanggalMasuk = barang.TanggalMasuk
            });

        }
    }
}
