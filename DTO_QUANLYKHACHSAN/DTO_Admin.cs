using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QUANLYKHACHSAN
{
    public class DTO_Admin : DTO_NhanVien
    {
        public DTO_Admin()
        {

        }

        public DTO_Admin(string maNV, string tenNV, DateTime ngaySinh, string gioiTinh, string sdt, string tkhoan, string pass)
            : base(maNV, tenNV, ngaySinh, gioiTinh, sdt, tkhoan, pass, true)
        {

        }
    }
}
