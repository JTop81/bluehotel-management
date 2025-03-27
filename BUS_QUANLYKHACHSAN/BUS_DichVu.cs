using System.Data;
using DAL_QUANLYKHACHSAN;
using DTO_QUANLYKHACHSAN;

namespace BUS_QUANLYKHACHSAN
{
    public class BUS_DichVu
    {
        DAL_DichVu dal_DichVu = new DAL_DichVu();

        public DataTable getAllDV()
        {
            return dal_DichVu.GetAll();
        }

        public DTO_DichVu getDV(int maDV)
        {
            return dal_DichVu.GetDV(maDV);
        }

        public bool themDV(DTO_DichVu dichvu)
        {
            return dal_DichVu.ThemDV(dichvu);
        }

        public bool suaDV(DTO_DichVu dichvu)
        {
            return dal_DichVu.SuaDV(dichvu);
        }

        public bool xoaDV(int maDV)
        {
            return dal_DichVu.XoaDV(maDV);
        }

        public DataTable timkiemDV(string tenDV)
        {
            return dal_DichVu.MyGetDV(tenDV);
        }
    }
}
