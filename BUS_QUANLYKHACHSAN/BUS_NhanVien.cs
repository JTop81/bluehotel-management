using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QUANLYKHACHSAN;
using DAL_QUANLYKHACHSAN;
using System.Data;

namespace BUS_QUANLYKHACHSAN
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dal_NhanVien = new DAL_NhanVien();

        public DTO_NhanVien GetNV(string maNV)
        {
            return dal_NhanVien.GetNV(maNV);
        }

        public DataTable getAll()
        {
            return dal_NhanVien.GetAll();
        }

        public DataTable SearchNV(string maNV)
        {
            return dal_NhanVien.SearchNV(maNV);
        }

        public bool ThemNV(DTO_NhanVien dto_NhanVien)
        {
            return dal_NhanVien.ThemNV(dto_NhanVien);
        }

        public bool SuaNV(DTO_NhanVien dto_NhanVien)
        {
            return dal_NhanVien.SuaNV(dto_NhanVien);
        }

        public bool XoaNV(string maNV)
        {
            return dal_NhanVien.XoaNV(maNV);
        }

        public bool KiemTraNhanVienTonTai(string maNV)
        {
            return dal_NhanVien.KiemTraNhanVienTonTai(maNV);
        }

        public bool KiemTraTaiKhoanTonTai(string tkhoan)
        {
            return dal_NhanVien.KiemTraTaiKhoanTonTai(tkhoan);
        }
    }
}
