using System;
using System.Data;
using DTO_QUANLYKHACHSAN;
using System.Data.SqlClient;

namespace DAL_QUANLYKHACHSAN
{
    public class DAL_PhieuDichVu
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM PhieuDichVu ");
            return dt; 
        }

        public DataTable ShowPDV(int soPThue)
        {
            try
            {
                string query = "SELECT PhieuDichVu.maDV, maPhong, ngayThueDV, giaTien " +
                "FROM PhieuDichVu JOIN DichVu ON PhieuDichVu.maDV = DichVu.maDV " +
                "WHERE PhieuDichVu.soPThue = " + soPThue;
                DataTable dt = new DataTable();
                dt = DataProvider.Instance.ExecuteQuery(query);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return null;
        }

        public DTO_PhieuDichVu GetPDV(int soPDV)
        {
            try
            {
                DataTable td = DataProvider.Instance.ExecuteQuery("SELECT * FROM PhieuDichVu WHERE soPDV = " + soPDV);
                DTO_PhieuDichVu pDV = new DTO_PhieuDichVu(td.Rows[0]);

                return pDV;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return null;
        }

        public DataTable TimTheoPThue(string soPThue)
        {
            try
            {
                string cmd = "SELECT soPDV, maDV, PhieuDichVu.soPThue, maPhong, PhieuDichVu.maNV, ngayThueDV FROM PhieuDichVu, PhieuThue " +
                    "WHERE PhieuThue.soPThue = PhieuDichVu.soPThue AND PhieuThue.xacNhan = N'Chưa thanh toán' AND PhieuDichVu.soPThue LIKE '%" + soPThue + "%'";
                //string cmd = "SELECT * FROM PhieuDichVu WHERE soPThue LIKE '%" + soPThue + "%'";
                DataTable td = DataProvider.Instance.ExecuteQuery(cmd);
                return td;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return null;
        }

        public DataTable GetPDVchuaThanhToan()
        {
            try
            {
                string cmd = "SELECT soPDV, maDV, PhieuDichVu.soPThue, maPhong, PhieuDichVu.maNV, ngayThueDV FROM PhieuDichVu, PhieuThue " +
                    "WHERE PhieuThue.soPThue = PhieuDichVu.soPThue AND PhieuThue.xacNhan = N'Chưa thanh toán'";
                DataTable dt = new DataTable();
                dt = DataProvider.Instance.ExecuteQuery(cmd);
                return dt;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        public bool ThemPDV(DTO_PhieuDichVu pDV)
        {
            //string cmd = "SELECT COUNT(*) FROM PhieuDichVu WHERE soPThue = " + pDV.SoPhieuThue + " AND maPhong = '" + pDV.MaPhong +
            //        "' AND maDV = '" + pDV.DichVu.MaDV + "' AND ngayThueDV = '" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
            try
            {               
                string cmd = "INSERT INTO PhieuDichVu(soPThue, maPhong, maDV, maNV, ngayThueDV) " +
                    "VALUES (" + pDV.SoPhieuThue + ", '" + pDV.MaPhong + "', '" + pDV.MaDV +
                    "', '" + pDV.MaNV + "', '" + DateTime.Now.ToString("MM/dd/yyyy") + "') \n";
                DataProvider.Instance.ExecuteNonQuery(cmd);
                return true;
                //int dataCount = (int)DataProvider.Instance.ExecuteScalar(cmd);
                //if (dataCount > 0)
                //{
                //    cmd = "SELECT soPDV FROM PhieuDichVu WHERE soPThue = " + pDV.SoPhieuThue + " AND maPhong = '" + pDV.MaPhong +
                //    "' AND maDV = '" + pDV.DichVu.MaDV + "' AND ngayThueDV = '" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
                //    int id = (int)DataProvider.Instance.ExecuteScalar(cmd);
                //    Console.WriteLine(id);
                //    pDV = GetObject.Instance.GetPDV(id);
                //    //pDV.SoLan++;
                //    DataProvider.Instance.ExecuteNonQuery("UPDATE PhieuDichVu SET soLan = " + pDV.SoLan + " WHERE soPDV = " + id);
                //    cmd = "SELECT soPDV FROM PhieuDichVu WHERE soPThue = " + pDV.SoPhieuThue + " ";
                //    DataTable pDVID = DataProvider.Instance.ExecuteQuery(cmd);
                //    decimal tongTienDV = 0;
                //    for (int i = 0; i < pDVID.Rows.Count; i++)
                //    {
                //        DTO_PhieuDichVu phieu = GetObject.Instance.GetPDV(int.Parse(pDVID.Rows[i][0].ToString()));
                //        tongTienDV += phieu.TienDV;
                //    }

                //    cmd = "UPDATE PhieuThue SET tienDV = " + tongTienDV + " WHERE soPThue = " + pDV.SoPhieuThue;
                //    DataProvider.Instance.ExecuteNonQuery(cmd);
                //    return true;
                //}
                //else
                //{
                //    Console.WriteLine(pDV.SoPhieuThue + " " + pDV.MaPhong + " " + pDV.DichVu.MaDV + " " + pDV.MaNV);
                //    cmd = "INSERT INTO PhieuDichVu(soPThue, maPhong, maDV, maNV, ngayThueDV) " +
                //        "VALUES (" + pDV.SoPhieuThue + ", '" + pDV.MaPhong + "', '" + pDV.DichVu.MaDV + 
                //        "', '" + pDV.MaNV + "', '" + DateTime.Now.ToString("MM/dd/yyyy") + "') \n";
                //    DataProvider.Instance.ExecuteNonQuery(cmd);
                //    cmd = "SELECT soPDV FROM PhieuDichVu WHERE soPThue = " + pDV.SoPhieuThue + " ";
                //    DataTable pDVID = DataProvider.Instance.ExecuteQuery(cmd);
                //    decimal tongTienDV = 0;
                //    for (int i = 0; i < pDVID.Rows.Count; i++)
                //    {
                //        DTO_PhieuDichVu phieu = GetObject.Instance.GetPDV(int.Parse(pDVID.Rows[i][0].ToString()));
                //        tongTienDV += phieu.TienDV;
                //    }

                //    cmd = "UPDATE PhieuThue SET tienDV = " + tongTienDV + " WHERE soPThue = " + pDV.SoPhieuThue;
                //    DataProvider.Instance.ExecuteNonQuery(cmd);
                //    return true;
                //}
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;

        }

        public bool XoaPDV(int id)
        {
            try
            {
                DataProvider.Instance.ExecuteNonQuery("DELETE FROM PhieuDichVu WHERE soPDV = @id ", new object[] { id });
                //string cmd = "SELECT soPDV FROM PhieuDichVu WHERE soPThue = " + phieuDV.SoPhieuThue + " ";
                //DataTable pDVID = DataProvider.Instance.ExecuteQuery(cmd);
                //decimal tongTienDV = 0;
                //for (int i = 0; i < pDVID.Rows.Count; i++)
                //{
                //    DTO_PhieuDichVu phieu = GetObject.Instance.GetPDV(int.Parse(pDVID.Rows[i][0].ToString()));
                //    tongTienDV += phieu.TienDV;
                //}

                //cmd = "UPDATE PhieuThue SET tienDV = " + tongTienDV + " WHERE soPThue = " + phieuDV.SoPhieuThue;
                //DataProvider.Instance.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return false;
        }

        
    }
}
