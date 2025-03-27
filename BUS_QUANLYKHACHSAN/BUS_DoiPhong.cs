using DAL_QUANLYKHACHSAN;
using System;

namespace BUS_QUANLYKHACHSAN
{
    public class BUS_DoiPhong
    {
        DAL_DoiPhong dal_DoiPhong = new DAL_DoiPhong();

        public bool DoiPhong(int soPThue, string maPhongCu, string maPhongMoi, DateTime ngayChuyen, DateTime ngayThue, string manv)
        {
            return dal_DoiPhong.DoiPhong(soPThue, maPhongCu, maPhongMoi, ngayChuyen, ngayThue, manv);
        }
    }
}
