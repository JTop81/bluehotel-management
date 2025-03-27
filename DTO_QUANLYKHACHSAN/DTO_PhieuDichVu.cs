using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DTO_QUANLYKHACHSAN
{
    public class DTO_PhieuDichVu
    {
        private int id;
        public int ID { get => id; set => id = value; }

        private int soPhieuThue;
        public int SoPhieuThue { get => soPhieuThue; set => soPhieuThue = value; }

        private int maDV;
        public int MaDV { get => maDV; set => maDV = value; }

        //private int soLan;
        //public int SoLan { get => soLan; set => soLan = value; }

        private string maPhong;
        public string MaPhong { get => maPhong; set => maPhong = value; }

        private string maNV;
        public string MaNV { get => maNV; set => maNV = value; }

        private DateTime ngayThueDV;
        public DateTime NgayThueDV { get => ngayThueDV; set => ngayThueDV = value; }

        private decimal tienDV;
        public decimal TienDV { get => tienDV; set => tienDV = value; }

        public DTO_PhieuDichVu()
        {

        }

        public DTO_PhieuDichVu(int soPhieuThue, string maPhong, int maDV, string maNV)
        {
            this.soPhieuThue = soPhieuThue;
            this.maPhong = maPhong;
            this.maDV = maDV;
            this.maNV = maNV;
            //this.soLan = soLan;
            //tienDV = dichVu.GiaTien * soLan;
        }

        public DTO_PhieuDichVu(DataRow row)
        {
            id = (int)row["soPDV"];
            maDV = (int)row["maDV"];
            soPhieuThue = (int)row["soPThue"];
            maPhong = row["maPhong"].ToString();
            maNV = row["maNV"].ToString();
            ngayThueDV = (DateTime)row["ngayThueDV"];
        }
    }
}
