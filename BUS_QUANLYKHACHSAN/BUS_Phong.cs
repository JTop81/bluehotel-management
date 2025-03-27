using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QUANLYKHACHSAN;
using DTO_QUANLYKHACHSAN;

namespace BUS_QUANLYKHACHSAN
{
    public class BUS_Phong
    {
        DAL_Phong dal_Phong = new DAL_Phong();

        public DataTable getAllPhong()
        {
            return dal_Phong.GetAll();
        }

        public DataTable DanhSachPhongTrong()
        {
            return dal_Phong.DanhSachPhongTrong();
        }

        public bool ThemPhong(DTO_Phong dto_Phong)
        {
            return dal_Phong.ThemPhong(dto_Phong);
        }

        public bool SuaPhong(DTO_Phong dto_Phong, string maPhongCu)
        {
            return dal_Phong.SuaPhong(dto_Phong, maPhongCu);
        }

        public bool XoaPhong(string maPhong)
        {
            return dal_Phong.XoaPhong(maPhong);
        }

        public DataTable SearchMaPhong(string maPhong)
        {
            return dal_Phong.SearchMaPhong(maPhong);
        }
    }
}
