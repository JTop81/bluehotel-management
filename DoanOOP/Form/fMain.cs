using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QUANLYKHACHSAN;
using DTO_QUANLYKHACHSAN;

namespace GUI_QUANLYKHACHSAN
{
    public partial class fMain : Form
    {
        Thread th;

        public fMain()
        {
            InitializeComponent();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormClosing -= fMain_FormClosing;
            this.Close();
            th = new Thread(OpenRegForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void phòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLPhong frm = new QLPhong();
            frm.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanvien fnv = new fNhanvien();
            fnv.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachhang fkh = new fKhachhang();
            fkh.Show();
        }

        private void đăngKíPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDichvu fdv = new fDichvu();
            fdv.Show();
        }
        
        private void OpenRegForm(object o)
        {
            Application.Run(new fLogin());
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            label1.Text = "Xin chào " + AppManager.currentNhanVien.TenNV + "!";
            if (AppManager.currentNhanVien is DTO_Admin)
            {
                this.nhânViênToolStripMenuItem.Enabled = true;
                this.phòngToolStripMenuItem.Enabled = true;
                this.đăngKíPhòngToolStripMenuItem.Enabled = true;
                this.lậpBáoCáoToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.nhânViênToolStripMenuItem.Enabled = false;
                this.phòngToolStripMenuItem.Enabled = false;
                this.đăngKíPhòngToolStripMenuItem.Enabled = false;
                this.lậpBáoCáoToolStripMenuItem.Enabled = false;
            }
        }

        private void lậpBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBaoCao fbc = new fBaoCao();
            fbc.Show();
        }

        private void thuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThuephong frm = new fThuephong();
            frm.Show();
        }

        private void đổiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoiPhong frm = new fDoiPhong();
            frm.Show();
        }

        private void thuêDịchVụToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fThuedichvu frm = new fThuedichvu();
            frm.Show();
        }

        private void trảPhòngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fThanhToan frm = new fThanhToan();
            frm.Show();
        }
    }
}
