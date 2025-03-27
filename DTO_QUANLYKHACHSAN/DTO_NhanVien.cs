using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QUANLYKHACHSAN
{
    public class DTO_NhanVien
    {
        private string maNV;
        public string MaNV { get => maNV; set => maNV = value; }

        private string tenNV;
        public string TenNV { get => tenNV; set => tenNV = value; }

        private DateTime ngaySinh;
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        private string gioiTinh;
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        private string sdt;
        public string Sdt { get => sdt; set => sdt = value; }

        private string chucVu;
        public string ChucVu { get => chucVu; set => chucVu = value; }

        string tkhoan;
        public string Tkhoan { get => tkhoan; set => tkhoan = value; }
        string pass;
        public string Pass { get => pass; set => pass = value; }

        bool quyen;
        public bool Quyen { get => quyen; set => quyen = value; }

        public DTO_NhanVien()
        {

        }

        public DTO_NhanVien(string maNV, string tenNV, DateTime ngaySinh, string gioiTinh, string sdt, string tkhoan, string pass, bool quyen
            )
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.sdt = sdt;
            this.tkhoan = tkhoan;
            this.pass = pass;
            this.quyen = quyen;
        }
    }
}
