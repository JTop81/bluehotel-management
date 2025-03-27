using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QUANLYKHACHSAN
{
    public class DTO_DichVu
    {
        private int maDV;
        public int MaDV { get => maDV; set => maDV = value; }

        private string tenDV;
        public string TenDV { get => tenDV; set => tenDV = value; }

        private string moTa;
        public string MoTa { get => moTa; set => moTa = value; }

        private decimal giaTien;
        public decimal GiaTien { get => giaTien; set => giaTien = value; }

        public DTO_DichVu()
        {

        }

        public DTO_DichVu(string tenDV, string moTa, decimal giaTien)
        {
            this.tenDV = tenDV;
            this.moTa = moTa;
            this.giaTien = giaTien;
        }

        public DTO_DichVu(int maDV, string tenDV, string moTa, decimal giaTien)
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.moTa = moTa;
            this.giaTien = giaTien;
        }
    }
}
