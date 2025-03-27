using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QUANLYKHACHSAN
{
    public class DTO_DSPhongThue
    {
        private int id;
        public int ID { get => id; set => id = value; }

        private string maPhong;
        public string MaPhong { get => maPhong; set => maPhong = value; }

        private int soPThue;
        public int SoPThue { get => soPThue; set => soPThue = value; }

        private int thoiHan;
        public int ThoiHan { get => thoiHan; set => thoiHan = value; }

        public DTO_DSPhongThue()
        {

        }

        public DTO_DSPhongThue(string maPhong, int soPThue, int thoiHan)
        {
            this.maPhong = maPhong;
            this.soPThue = soPThue;
            this.thoiHan = thoiHan;
        }

        public DTO_DSPhongThue(DataRow row)
        {
            this.id = int.Parse(row["id"].ToString());
            this.maPhong = row["maPhong"].ToString();
            this.soPThue = int.Parse(row["soPThue"].ToString());
            this.thoiHan = int.Parse(row["thoiHan"].ToString());
        }
    }
}
