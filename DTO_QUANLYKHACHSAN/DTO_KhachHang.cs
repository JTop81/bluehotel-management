using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QUANLYKHACHSAN
{
    public class DTO_KhachHang
    {
        private int maKH;
        public int MaKH { get => maKH; set => maKH = value; }

        private string tenKH;
        public string TenKH { get => tenKH; set => tenKH = value; }

        private DateTime ngaySinh;
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        private string diaChi;
        public string DiaChi { get => diaChi; set => diaChi = value; }

        private string cmnd;
        public string Cmnd { get => cmnd; set => cmnd = value; }

        private string sdt;
        public string Sdt { get => sdt; set => sdt = value; }

        private string sex;
        public string Sex { get => sex; set => sex = value; }

        public DTO_KhachHang()
        {

        }

        public DTO_KhachHang(string tenKH, DateTime ngaySinh, string diaChi, string cmnd, string sdt, string sex)
        {
            this.tenKH = tenKH;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.cmnd = cmnd;
            this.sdt = sdt;
            this.sex = sex;
        }

        public DTO_KhachHang(int maKH, string tenKH, DateTime ngaySinh, string diaChi, string cmnd, string sdt, string sex)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.cmnd = cmnd;
            this.sdt = sdt;
            this.sex = sex;
        }
    }
}
