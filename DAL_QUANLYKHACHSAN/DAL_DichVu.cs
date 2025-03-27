using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO_QUANLYKHACHSAN;

namespace DAL_QUANLYKHACHSAN
{
    public class DAL_DichVu
    {
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM DichVu ");
            return dt;
        }

        public DTO_DichVu GetDV(int maDV)
        {
            try
            {
                DataTable td = DataProvider.Instance.ExecuteQuery("SELECT * FROM DichVu WHERE maDV = " + maDV);
                DTO_DichVu dTO_DichVu = new DTO_DichVu(int.Parse(td.Rows[0][0].ToString()), td.Rows[0][1].ToString(),
                    td.Rows[0][3].ToString(), decimal.Parse(td.Rows[0][2].ToString()));
                return dTO_DichVu;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        public DataTable MyGetDV(string tenDV)
        {
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery("SELECT * FROM DichVu WHERE tenDV  LIKE N'%" + tenDV + "%'");
            return dt;
        }

        public bool ThemDV(DTO_DichVu dto_dichvu)
        {
            try
            {
                string query;
                query = "INSERT INTO DichVu (tenDV, giaTien, moTa) VALUES (N'" + dto_dichvu.TenDV + "'," + dto_dichvu.GiaTien + ", N'" + dto_dichvu.MoTa + "')";
                DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool SuaDV(DTO_DichVu dto_dichvu)
        {
            try
            {
                string query;
                query = "UPDATE dbo.DichVu SET tenDV = N'" + dto_dichvu.TenDV + "', giaTien = " + dto_dichvu.GiaTien + ", moTa = N'" + dto_dichvu.MoTa + "' WHERE maDV = '" + dto_dichvu.MaDV + "'";
                DataProvider.Instance.ExecuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            return false;
        }

        public bool XoaDV(int maDV)
        {
            try
            {
                string query;
                query = "DELETE FROM dbo.DichVu WHERE maDV = " + maDV;
                DataProvider.Instance.ExecuteNonQuery(query);
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
