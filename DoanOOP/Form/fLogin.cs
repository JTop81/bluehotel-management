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

namespace GUI_QUANLYKHACHSAN
{
    public partial class fLogin : Form
    {
        Thread th;
        int failTime = 0;

        public fLogin()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel)!= System.Windows.Forms.DialogResult.OK )
            {
                e.Cancel = true;
            }    
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Mời nhập đủ thông tin đăng nhập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (TaskDangNhap.Login(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Dang nhap thanh cong. Bạn là: " + AppManager.currentNhanVien.GetType());
                this.FormClosing -= fLogin_FormClosing;
                this.Close();
                th = new Thread(OpenMainForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                failTime++;
                if (failTime < 6)
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai. Xin hãy nhập lại.");
                if (failTime == 6)
                {
                    this.FormClosing -= fLogin_FormClosing;
                    Application.Exit();
                }
            }
        }

        private void OpenMainForm(object o)
        {
            Application.Run(new fMain());
        }
    }
}
