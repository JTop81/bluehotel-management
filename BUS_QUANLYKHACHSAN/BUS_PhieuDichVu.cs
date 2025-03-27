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
    public class BUS_PhieuDichVu
    {
        DAL_PhieuDichVu dal_PhieuDichVu = new DAL_PhieuDichVu();

        public DataTable getAllPDV()
        {
            DataTable td = dal_PhieuDichVu.GetAll();
            return td;
        }

        public DataTable GetPDVchuaThanhToan()
        {
            return dal_PhieuDichVu.GetPDVchuaThanhToan();
        }

        public DTO_PhieuDichVu getPDV(int ID)
        {
            return dal_PhieuDichVu.GetPDV(ID);
        }

        public DataTable TimTheoPThue(string soPThue)
        {
            return dal_PhieuDichVu.TimTheoPThue(soPThue);
        }

        public bool ThemPDV(DTO_PhieuDichVu dto_PhieuDichVu)
        {
            return dal_PhieuDichVu.ThemPDV(dto_PhieuDichVu);
        }

        public bool XoaPDV(int ID)
        {
            return dal_PhieuDichVu.XoaPDV(ID);
        }

        public int DemPDV(string soPhieuThue)
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM PhieuThue WHERE soPThue = @soPhieuThue ", new object[] { soPhieuThue });
        }

        public DataTable ShowPDV(int soPThue)
        {
            DataTable dt = dal_PhieuDichVu.ShowPDV(soPThue);
            return dt;
        }
    }
}
