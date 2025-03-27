using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QUANLYKHACHSAN;
using System.Data;

namespace DAL_QUANLYKHACHSAN
{
    public class DAL_Admin
    {
        public DTO_Admin GetAdmin(string maNV)
        {
            try
            {
                DataTable td = DataProvider.Instance.ExecuteQuery("SELECT * FROM NhanVien WHERE maNV = " + maNV);
                DTO_Admin dto_Admin = new DTO_Admin(td.Rows[0][0].ToString(), td.Rows[0][1].ToString(),
                    Convert.ToDateTime(td.Rows[0][2].ToString()), td.Rows[0][3].ToString(), td.Rows[0][4].ToString(), td.Rows[0][5].ToString(),
                    td.Rows[0][6].ToString());

                return dto_Admin;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return null;
        }
    }
}
