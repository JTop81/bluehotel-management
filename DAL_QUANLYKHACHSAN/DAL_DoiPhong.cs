using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QUANLYKHACHSAN
{
    public class DAL_DoiPhong
    {
        //private static DAL_DoiPhong instance;

        //public static DAL_DoiPhong Instance
        //{
        //    get { if (instance == null) instance = new DAL_DoiPhong(); return DAL_DoiPhong.instance; }
        //    private set { DAL_DoiPhong.instance = value; }
        //}

        //private DAL_DoiPhong() { }
        public bool DoiPhong(int soPThue, string maPhongCu, string maPhongMoi, DateTime ngayChuyen, DateTime ngayThue, string manv)
        {
            string query = "EXEC sp_DoiPhong " + soPThue + ", " + maPhongCu + ", " + maPhongMoi + ", '" + ngayChuyen.ToString("MM/dd/yyyy")
                           + "', '" + ngayThue.ToString("MM/dd/yyyy") + "', '" + manv + "'";
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt >= 0;
        }
    }
}
