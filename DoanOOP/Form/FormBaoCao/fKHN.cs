using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QUANLYKHACHSAN;

namespace GUI_QUANLYKHACHSAN
{
    public partial class fKHN : Form
    {
        DateTime ngayBatDau, ngayKetThuc;
        BUS_KhachHang bus_KhachHang;

        private void fKHN_Load(object sender, EventArgs e)
        {
            textBox1.Text = ngayBatDau.ToShortDateString();
            textBox2.Text = ngayKetThuc.ToShortDateString();
            textBox3.Text = 0.ToString();
            DataTable td = new DataTable();
            td = bus_KhachHang.KhachHangTheoNgay(ngayBatDau, ngayKetThuc);
            if (td.Rows.Count > 0)
            {
                for (int i = 0; i < td.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                    item.SubItems.Add(td.Rows[i][1].ToString());
                    item.SubItems.Add(td.Rows[i][2].ToString());
                    item.SubItems.Add(td.Rows[i][3].ToString());
                    listView1.Items.Add(item);
                }
                textBox3.Text = td.Rows.Count.ToString();
            }
        }

        public fKHN(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            InitializeComponent();
            bus_KhachHang = new BUS_KhachHang();
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
    }
}
