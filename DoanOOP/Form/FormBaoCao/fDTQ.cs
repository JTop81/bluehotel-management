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
    public partial class fDTQ : Form
    {
        int quy, nam;
        BUS_PhieuThue bus_PhieuThue;

        private void fDTQ_Load(object sender, EventArgs e)
        {
            textBox1.Text = quy.ToString();
            textBox2.Text = nam.ToString();
            textBox3.Text = 0.ToString();
            DataTable td = new DataTable();
            td = bus_PhieuThue.ThongKeTheoQuy(quy, nam);
            if (td.Rows.Count > 0)
            {
                decimal tongTien = 0;
                for (int i = 0; i < td.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                    item.SubItems.Add(td.Rows[i][1].ToString());
                    item.SubItems.Add(td.Rows[i][2].ToString());
                    item.SubItems.Add(td.Rows[i][3].ToString());
                    item.SubItems.Add(td.Rows[i][4].ToString());
                    item.SubItems.Add(td.Rows[i][5].ToString());
                    decimal tongtienPhong = 0;
                    tongtienPhong += decimal.Parse(td.Rows[i][4].ToString());
                    tongtienPhong += decimal.Parse(td.Rows[i][5].ToString());
                    tongTien += tongtienPhong;
                    item.SubItems.Add(tongtienPhong.ToString());
                    listView1.Items.Add(item);
                }
                textBox3.Text = tongTien.ToString();
            }
        }

        public fDTQ(int quy, int nam)
        {
            InitializeComponent();
            bus_PhieuThue = new BUS_PhieuThue();
            this.quy = quy;
            this.nam = nam;
        }
    }
}
