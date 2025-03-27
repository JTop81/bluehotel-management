using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO_QUANLYKHACHSAN;

namespace DAL_QUANLYKHACHSAN
{
    public class DAL_DSPhongThue
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM DanhSachPhongThue ");
            return dt;
        }

        public bool ThemPhongThue(DTO_DSPhongThue dsPhongThue)
        {
            try
            {
                string cmd = "INSERT INTO DanhSachPhongThue(maPhong, soPThue, thoiHan) VALUES ('" + dsPhongThue.MaPhong 
                    + "', " + dsPhongThue.SoPThue + ", " + dsPhongThue.ThoiHan + ")";
                DataProvider.Instance.ExecuteNonQuery(cmd/*, new object[] { dsPhongThue.MaPhong, dsPhongThue.SoPThue, dsPhongThue.ThoiHan}*/);
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool HuyPhongThue(string maPhong, int soPThue)
        {
            try
            {
                string cmd = "DELETE FROM dbo.DanhSachPhongThue WHERE maPhong = @maPhong AND soPThue = @soPThue";
                DataProvider.Instance.ExecuteNonQuery(cmd, new object[] { maPhong, soPThue });
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool KiemTraMaPhong(string maPhong)
        {
            try
            {
                string cmd = "EXEC sp_KiemTraMaPhong @maPhong";
                DataTable result = DataProvider.Instance.ExecuteQuery(cmd, new object[] { maPhong });
                return result.Rows.Count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool KiemTraMaPhongTonTai(string maPhong)
        {
            try
            {
                string cmd = "EXEC sp_KiemTraMaPhongTonTai @maPhong";
                DataTable result = DataProvider.Instance.ExecuteQuery(cmd, new object[] { maPhong });
                return result.Rows.Count > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public DataTable ShowPhongThue(int soPThue)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT ds.soPThue, ds.maPhong, ds.thoiHan, p.giaThue "
                +"FROM DanhSachPhongThue AS ds JOIN Phong AS p ON ds.maPhong = p.maPhong WHERE ds.soPThue = @soPThue ",
                new object[] { soPThue });
            return dt;
        }

        public DataTable GetSPTbyMaPhong(string maPhong)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT soPThue FROM DanhSachPhongThue WHERE maPhong = @maPhong ", new object[] { maPhong });
            return dt;
        }
    }
}
