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
    public class DAL_KhachHang
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM KhachHang ");
            return dt;
        }

        public bool CheckedKhachHangById(int maKH)
        {
            string query = "SELECT * FROM KhachHang WHERE maKH = " + maKH;
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public string CheckedKhachHangByCMND(string checkKhach)
        {
            string query = "SELECT maKH FROM KhachHang WHERE cmnd = N'" + checkKhach + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
                return result.Rows[0][0].ToString();
            else
                return null;
        }

        public bool CheckedKhachHangByCMND2(string checkKhach)
        {
            try
            {
                string query;
                query = "SELECT maKH FROM KhachHang WHERE cmnd = N'" + checkKhach + "'";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                return result.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public DataTable GetKH(string tenKH)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM KhachHang WHERE tenKH  LIKE N'%" + tenKH + "%'");
            return dt;
        }

        public bool ThemKH(DTO_KhachHang dto_kh)
        {
            try
            {
                string query;
                query = "INSERT INTO KhachHang (tenKH, ngaySinh, diaChi, cmnd, sdt, sex) VALUES (N'" + dto_kh.TenKH + "', N'" + dto_kh.NgaySinh.ToShortDateString() + "', N'" + dto_kh.DiaChi + "', N'" + dto_kh.Cmnd + "', N'" + dto_kh.Sdt + "', N'" + dto_kh.Sex + "')";
                DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public bool SuaKH(DTO_KhachHang dto_kh)
        {
            try
            {
                string query;
                query = "UPDATE KhachHang SET tenKH = N'" + dto_kh.TenKH + "', ngaySinh = '" + dto_kh.NgaySinh.ToShortDateString() + "', diaChi = N'" + dto_kh.DiaChi + "', cmnd = N'" + dto_kh.Cmnd + "', sdt = N'" + dto_kh.Sdt + "', sex = N'" + dto_kh.Sex + "' WHERE maKH = " + dto_kh.MaKH;
                DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public bool XoaKH(int maKH)
        {
            try
            {
                string query;
                query = "DELETE FROM KhachHang WHERE maKH = " + maKH;
                DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public DataTable KhachHangTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            try
            {
                string query = "EXEC sp_KhachHangNgay '" + ngayBatDau.ToString("MM/dd/yyyy") + "', '" + ngayKetThuc.ToString("MM/dd/yyyy") + "'";
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        public DataTable KhachHangTheoQuy(int quy, int nam)
        {
            try
            {
                string query = "EXEC sp_KhachHangQuy " + quy + ", " + nam;
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }
    }
}
