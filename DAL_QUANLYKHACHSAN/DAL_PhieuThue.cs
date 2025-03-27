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
    public class DAL_PhieuThue
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM PhieuThue ");
            return dt;
        }

        public string ThemPhieuThue(int maKH, DateTime ngayThue, string maNV)
        {
            try
            {
                string query = "INSERT INTO dbo.PhieuThue(maKH,maNV,ngayThue) OUTPUT INSERTED.soPThue VALUES ( " + maKH + ",'" + maNV + "','" + ngayThue.ToString("MM/dd/yyyy") + "')";
                string kiem = DataProvider.Instance.ExecuteScalar(query).ToString();
                return kiem;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        public bool KiemTraTinhTrangPhieu(int soPThue)
        {
            try
            {
                string query = "EXEC sp_CheckedPhieuThue @soPThue";
                DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { soPThue });
                return result.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public bool KiemTraPhieu(int soPThue)
        {
            try
            {
                string query = "SELECT * FROM dbo.PhieuThue WHERE soPThue = @soPThue";
                DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { soPThue });
                return result.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public DTO_PhieuThue TimKiemPhieuThue(int soPThue)
        {
            try
            {
                string query = "SELECT * FROM PhieuThue WHERE soPThue = @soPThue";
                DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] { soPThue });
                DTO_PhieuThue dto_PhieuThue = new DTO_PhieuThue(table.Rows[0]);
                return dto_PhieuThue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        public bool XoaPhieuThue(int soPhieuThue)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery("DELETE FROM PhieuThue WHERE soPhieuThue = @id ", new object[] { soPhieuThue });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public bool ThanhToan(int soPThue, DateTime ngayThanhToan)
        {
            string query = "EXEC USP_ThanhToan '" + ngayThanhToan.ToString("MM/dd/yyyy") + "'," + soPThue;
            int kiem = DataProvider.Instance.ExecuteNonQuery(query);
            return kiem > 0;
        }

        public bool CheckIfNotReg(int soPThue)
        {
            string query = "SELECT COUNT(*) FROM PhieuThue WHERE soPThue = " + soPThue + " AND xacNhan = N'Chưa thanh toán' ";
            int dataCount = (int)DataProvider.Instance.ExecuteScalar(query);
            return dataCount > 0;
        }

        public DataTable ThongKeTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            try
            {
                string query = "EXEC sp_ThongKeNgay '" + ngayBatDau.ToString("MM/dd/yyyy") + "', '" + ngayKetThuc.ToString("MM/dd/yyyy") + "'";
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        public DataTable ThongKeTheoQuy(int quy, int nam)
        {
            try
            {
                string query = "EXEC sp_ThongKeQuy " + quy + ", " + nam;
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
