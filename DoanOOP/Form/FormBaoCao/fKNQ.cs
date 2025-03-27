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
    public partial class fKNQ : Form
    {
        int quy, nam;
        BUS_KhachHang bus_KhachHang;

        private void fKNQ_Load(object sender, EventArgs e)
        {
            textBox1.Text = quy.ToString();
            textBox2.Text = nam.ToString();
            textBox3.Text = 0.ToString();
            DataTable td = new DataTable();
            td = bus_KhachHang.KhachHangTheoQuy(quy, nam);
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

        public fKNQ(int quy, int nam)
        {
            InitializeComponent();
            bus_KhachHang = new BUS_KhachHang();
            this.quy = quy;
            this.nam = nam;
        }
    }
}
