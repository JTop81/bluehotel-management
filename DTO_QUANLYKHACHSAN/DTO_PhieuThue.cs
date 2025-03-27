using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QUANLYKHACHSAN
{
    public class DTO_PhieuThue
    {
        private int soPThue;
        public int SoPThue { get => soPThue; set => soPThue = value; }

        private int maKH;
        public int MaKH { get => maKH; set => maKH = value; }

        private string maNV;
        public string MaNV { get => maNV; set => maNV = value; }

        private DateTime ngayThue;
        public DateTime NgayThue { get => ngayThue; set => ngayThue = value; }

        private DateTime? ngayThanhToan;
        public DateTime? NgayThanhToan { get => ngayThanhToan; set => ngayThanhToan = value; }

        private decimal tienPhong;
        public decimal TienPhong { get => tienPhong; set => tienPhong = value; }

        private decimal tienDV;
        public decimal TienDV { get => tienDV; set => tienDV = value; }

        private decimal tongTienThue;
        public decimal TongTienThue { get => tongTienThue; set => tongTienThue = value; }

        private string xacNhan;
        public string XacNhan { get => xacNhan; set => xacNhan = value; }


        public DTO_PhieuThue()
        {

        }

        public DTO_PhieuThue(int maKH, string maNV, DateTime ngayThue, DateTime? ngayThanhToan,
            decimal tienPhong, decimal tienDV, string xacNhan)
        {
            this.maKH = maKH;
            this.maNV = maNV;
            this.ngayThue = ngayThue;
            this.ngayThanhToan = ngayThanhToan;
            this.tienPhong = tienPhong;
            this.tienDV = tienDV;
            tongTienThue = tienPhong + tienDV;
            this.xacNhan = xacNhan;
        }

        public DTO_PhieuThue(DataRow row)
        {
            soPThue = (int)row["soPThue"];
            maKH = (int)row["maKH"];
            maNV = row["maNV"].ToString();
            ngayThue = (DateTime)row["ngayThue"];
            var dateTemp = row["ngayThanhToan"];
            if (dateTemp.ToString() != "")
                ngayThanhToan = (DateTime?)row["ngayThanhToan"];
            tienPhong = (decimal)Convert.ToDouble(row["tongtien"].ToString());
            tienDV = (decimal)Convert.ToDouble(row["tienDV"].ToString());
            tongTienThue = tienPhong + tienDV;
            xacNhan = row["xacNhan"].ToString();
        }
    }
}
