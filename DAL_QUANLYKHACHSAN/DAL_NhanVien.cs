using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO_QUANLYKHACHSAN;

namespace DAL_QUANLYKHACHSAN
{
    public class DAL_NhanVien
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM NhanVien ");
            return dt;
        }

        public bool KiemTraNhanVienTonTai(string maNV)
        {
            try
            {
                string query = "SELECT * FROM NhanVien WHERE maNV = '" + maNV + "'";

                DataTable dt = DataProvider.Instance.ExecuteQuery(query);

                return dt.Rows.Count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool KiemTraTaiKhoanTonTai(string tkhoan)
        {
            try
            {
                string query = "SELECT * FROM NhanVien WHERE tkhoan = '" + tkhoan + "'";

                DataTable dt = DataProvider.Instance.ExecuteQuery(query);

                return dt.Rows.Count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool ThemNV(DTO_NhanVien nhanVien)
        {
            try
            {
                int quyen;
                if (nhanVien is DTO_Admin)
                    quyen = 1;
                else quyen = 0;
                string cmd = "INSERT INTO NhanVien(maNV, tenNV, ngaySinh, sex, sdt, tkhoan, pass, quyen) " +
                    "VALUES ('" + nhanVien.MaNV + "', N'" + nhanVien.TenNV + "', '" + nhanVien.NgaySinh.ToShortDateString() +
                    "', N'" + nhanVien.GioiTinh + "', '" + nhanVien.Sdt + "', '" + nhanVien.Tkhoan + "', '" + nhanVien.Pass + "', " +
                     quyen + ") \n";

                DataProvider.Instance.ExecuteNonQuery(cmd);

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool SuaNV(DTO_NhanVien nhanVien)
        {
            try
            {
                int quyen;
                if (nhanVien is DTO_Admin)
                    quyen = 1;
                else quyen = 0;
                string cmd = "UPDATE NhanVien SET hotenNV = '" + nhanVien.TenNV + "', ngaySinh = '" + nhanVien.NgaySinh.ToShortDateString() +
                    "', gioiTinh = '" + nhanVien.GioiTinh + "', sdt = '" + nhanVien.Sdt + "', tkhoan = '" + nhanVien.Tkhoan + "', pass = '" + nhanVien.Pass +
                    "', quyen = " + quyen + " WHERE maNV = '" + nhanVien.MaNV + "'";

                DataProvider.Instance.ExecuteNonQuery(cmd);

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool XoaNV(string maNV)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery("DELETE FROM NhanVien WHERE maNV = @id ", new object[] { maNV });
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public DataTable SearchNV(string maNV)
        {
            try
            {
                string query = "SELECT * FROM NhanVien WHERE maNV LIKE '" + maNV + "%'";
                DataTable td = DataProvider.Instance.ExecuteQuery(query);
                return td;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return null;
        }

        public DTO_NhanVien GetNV(string maNV)
        {
            try
            {
                DataTable td = DataProvider.Instance.ExecuteQuery("SELECT * FROM NhanVien WHERE maNV = @maNV",
                    new object[] { maNV });
                bool quyen = false;
                if (td.Rows[0][7].ToString() == "True")
                {
                    quyen = true;
                }
                else
                {
                    quyen = false;
                }
                DTO_NhanVien dto_NhanVien = new DTO_NhanVien(td.Rows[0][0].ToString(), td.Rows[0][1].ToString(),
                    Convert.ToDateTime(td.Rows[0][2].ToString()), td.Rows[0][3].ToString(), td.Rows[0][4].ToString(), td.Rows[0][5].ToString(),
                    td.Rows[0][6].ToString(), quyen);

                return dto_NhanVien;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return null;
        }
    }
}
