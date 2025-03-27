using System.Data;
using DAL_QUANLYKHACHSAN;

namespace BUS_QUANLYKHACHSAN
{
    public static class TaskDangNhap
    {
        public static bool Login(string username, string password)
        {
            //int userCount = (int)DatabaseHelper.Instance.ExecuteScalar
            //    ("SELECT COUNT(*) FROM NhanVien WHERE tkhoan ='" + username + "' AND pass ='" + password + "' ");
            //if (userCount > 0)

            string sql = "EXEC USP_Login @userName , @password ";
            DataTable td = DataProvider.Instance.ExecuteQuery(sql, new object[] { username, password });
            if (td.Rows.Count > 0)
            {
                AppManager.SetUser(username);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
