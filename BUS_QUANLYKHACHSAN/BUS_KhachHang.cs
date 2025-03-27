using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QUANLYKHACHSAN;
using DTO_QUANLYKHACHSAN;

namespace BUS_QUANLYKHACHSAN
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_KhachHang = new DAL_KhachHang();

        public DataTable getAllKhach()
        {
            return dal_KhachHang.GetAll();
        }


        public bool CheckedKhachHangById(int maKH)
        {
            return dal_KhachHang.CheckedKhachHangById(maKH);
        }

        public string CheckedKhachHangByCMND(string checkKhach)
        {
            return dal_KhachHang.CheckedKhachHangByCMND(checkKhach);
        }

        public bool CheckedKhachHangByCMND2(string checkKhach)
        {
            return dal_KhachHang.CheckedKhachHangByCMND2(checkKhach);
        }

        public bool themKH(DTO_KhachHang khachhang)
        {
            return dal_KhachHang.ThemKH(khachhang);
        }

        public bool suaKH(DTO_KhachHang khachhang)
        {
            return dal_KhachHang.SuaKH(khachhang);
        }

        public bool xoaKH(int maKH)
        {
            return dal_KhachHang.XoaKH(maKH);
        }

        public DataTable timkiemKH(string tenKH)
        {
            return dal_KhachHang.GetKH(tenKH);
        }

        public DataTable KhachHangTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return dal_KhachHang.KhachHangTheoNgay(ngayBatDau, ngayKetThuc);
        }

        public DataTable KhachHangTheoQuy(int quy, int nam)
        {
            return dal_KhachHang.KhachHangTheoQuy(quy, nam);
        }
    }
}
