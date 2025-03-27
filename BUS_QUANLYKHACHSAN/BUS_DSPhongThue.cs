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
    public class BUS_DSPhongThue
    {
        DAL_DSPhongThue dal_DSPhongThue = new DAL_DSPhongThue();

        public DataTable getAllDS()
        {
            return dal_DSPhongThue.GetAll();
        }

        public bool ThemPhongThue(DTO_DSPhongThue dsPhongThue)
        {
            return dal_DSPhongThue.ThemPhongThue(dsPhongThue);
        }

        public bool HuyPhongThue(string maPhong, int soPThue)
        {
            return dal_DSPhongThue.HuyPhongThue(maPhong, soPThue);
        }

        public bool KiemTraMaPhong(string maPhong)
        {
            return dal_DSPhongThue.KiemTraMaPhong(maPhong);
        }

        public bool KiemTraMaPhongTonTai(string maPhong)
        {
            return dal_DSPhongThue.KiemTraMaPhongTonTai(maPhong);
        }

        public DataTable ShowPhongThue(int soPThue)
        {
            return dal_DSPhongThue.ShowPhongThue(soPThue);
        }

        public DataTable GetSPTbyMaPhong(string maPhong)
        {
            return dal_DSPhongThue.GetSPTbyMaPhong(maPhong);
        }
    }
}
