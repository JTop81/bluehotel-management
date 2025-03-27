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
    public class BUS_Admin : BUS_NhanVien
    {
        DAL_Admin dal_Admin = new DAL_Admin();

        public DTO_Admin GetAdmin(string maNV)
        {
            return dal_Admin.GetAdmin(maNV);
        }
    }
}
