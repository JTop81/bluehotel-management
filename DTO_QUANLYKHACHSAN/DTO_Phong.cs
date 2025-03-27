using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QUANLYKHACHSAN
{
    public class DTO_Phong
    {
        private string maPhong;
        public string MaPhong { get => maPhong; set => maPhong = value; }

        private string loaiPhong;
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }

        private string dkPhong;
        public string DKPhong { get => dkPhong; set => dkPhong = value; }

        private string tinhTrang;
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        private decimal giaThue;
        public decimal GiaThue { get => giaThue; set => giaThue = value; }

        public DTO_Phong()
        {
        }

        public DTO_Phong(string maPhong, string loaiPhong, string dkPhong, string tinhTrang, decimal giaThue)
        {
            this.maPhong = maPhong;
            this.loaiPhong = loaiPhong;
            this.dkPhong = dkPhong;
            this.tinhTrang = tinhTrang;
            this.giaThue = giaThue;
        }
    }
}
