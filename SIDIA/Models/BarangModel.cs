using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDIA.Models
{
    public class BarangModel
    {
        public int? IdBarang { get; set; }
        public string? NamaBarang { get; set; }
        public string? Satuan { get; set; }
        public float? Harga { get; set; }
        public int? Stok { get; set; }
        public string? TanggalMasuk { get; set; }
        public string? TanggalKeluar { get; set; }
    }
}
