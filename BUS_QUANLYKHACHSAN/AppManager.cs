using System;
using System.Data;
using System.Data.SqlClient;
using DTO_QUANLYKHACHSAN;
using DAL_QUANLYKHACHSAN;

namespace BUS_QUANLYKHACHSAN
{
    public static class AppManager
    {
        public static DTO_NhanVien currentNhanVien;

        public static void SetUser(string username)
        {
            try
            {
                BUS_Admin bus_Admin = new BUS_Admin();
                DataTable td = DataProvider.Instance.ExecuteQuery
                    //("SELECT maNV, quyen FROM NhanVien WHERE tkhoan = '" + username + "'");
                    ("SELECT maNV, quyen FROM NhanVien WHERE tkhoan = @username ", new object[] { username });

                if (Convert.ToInt16(td.Rows[0][1]) == 0)
                {
                    currentNhanVien = bus_Admin.GetNV(td.Rows[0][0].ToString());
                }
                else
                {
                    currentNhanVien = bus_Admin.GetAdmin(td.Rows[0][0].ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
    }
}
