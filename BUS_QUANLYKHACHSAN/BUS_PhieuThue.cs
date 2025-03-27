using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_QUANLYKHACHSAN;
using DAL_QUANLYKHACHSAN;

namespace BUS_QUANLYKHACHSAN
{
    public class BUS_PhieuThue
    {
        DAL_PhieuThue dal_PhieuThue = new DAL_PhieuThue();

        public DataTable GetAllPhieuThue()
        {
            return dal_PhieuThue.GetAll();
        }

        public string ThemPhieuThue(int maKH, DateTime ngayThue, string maNV)
        {
            return dal_PhieuThue.ThemPhieuThue(maKH, ngayThue, maNV);
        }

        public bool KiemTraTinhTrangPhieu(int soPThue)
        {
            return dal_PhieuThue.KiemTraTinhTrangPhieu(soPThue);
        }

        public bool KiemTraPhieu(int soPThue)
        {
            return dal_PhieuThue.KiemTraPhieu(soPThue);
        }

        public DTO_PhieuThue TimKiemPhieuThue(int soPThue)
        {
            return dal_PhieuThue.TimKiemPhieuThue(soPThue);
        }

        public bool XoaPhieuThue(int soPhieuThue)
        {
            return dal_PhieuThue.XoaPhieuThue(soPhieuThue);
        }

        public bool ThanhToan(int soPThue, DateTime ngayThanhToan)
        {
            return dal_PhieuThue.ThanhToan(soPThue, ngayThanhToan);
        }

        public bool CheckIfNotReg(int soPThue)
        {
            return dal_PhieuThue.CheckIfNotReg(soPThue);
        }

        public DataTable ThongKeTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return dal_PhieuThue.ThongKeTheoNgay(ngayBatDau, ngayKetThuc);
        }

        public DataTable ThongKeTheoQuy(int quy, int nam)
        {
            return dal_PhieuThue.ThongKeTheoQuy(quy, nam);
        }
    }
}
