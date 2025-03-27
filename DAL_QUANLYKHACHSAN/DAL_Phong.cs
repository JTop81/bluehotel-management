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
    public class DAL_Phong
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM Phong ");
            return dt;
        }

        public DataTable DanhSachPhongTrong()
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM Phong WHERE tinhTrang = N'Trống'" );
            return dt;
        }

        public bool ThemPhong(DTO_Phong dTO_Phong)
        {
            try
            {
                string cmd = "INSERT INTO Phong (maPhong, loaiPhong, dkPhong, tinhTrang, giaThue) VALUES (N'" + dTO_Phong.MaPhong +
                    "', N'" + dTO_Phong.LoaiPhong + "', N'" + dTO_Phong.DKPhong + "', N'" + dTO_Phong.TinhTrang + "', " + dTO_Phong.GiaThue + ")";
                DataProvider.Instance.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public bool SuaPhong(DTO_Phong dto_Phong, string maPhongCu)
        {
            try
            {
                string cmd = "UPDATE dbo.Phong SET maPhong = N'" + dto_Phong.MaPhong + "', loaiPhong = N'" + dto_Phong.LoaiPhong + 
                    "', dkPhong = N'" + dto_Phong.DKPhong + "', tinhTrang = N'" + dto_Phong.TinhTrang + "', giaThue = N'" + dto_Phong.GiaThue + "' WHERE maPhong = '" + maPhongCu + "'";
                DataProvider.Instance.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public bool XoaPhong(string maPhong)
        {
            try
            {
                string cmd = "DELETE FROM Phong WHERE maPhong = N'" + maPhong + "'";
                DataProvider.Instance.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        public DataTable SearchMaPhong(string maPhong)
        {
            try
            {
                string cmd = "SELECT * FROM Phong WHERE maPhong LIKE '%" + maPhong + "%'";
                DataTable td = DataProvider.Instance.ExecuteQuery(cmd);
                return td;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }
    }
}
