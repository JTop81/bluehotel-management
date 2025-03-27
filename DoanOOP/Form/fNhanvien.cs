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
using DTO_QUANLYKHACHSAN;

namespace GUI_QUANLYKHACHSAN
{
    public partial class fNhanvien : Form
    {
        BUS_NhanVien bus_NhanVien;

        public fNhanvien()
        {
            InitializeComponent();
            bus_NhanVien = new BUS_NhanVien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtgioitinh.Text == "" || dateTimePicker1.Text == "" || txtquyen.Text == ""
                || txtsodienthoai.Text == "" || txttennv.Text == "")
            {
                MessageBox.Show("Mời nhập đủ các thông tin cần thiết.");
                return;
            }
            if ((txttaikhoan.Text != "" && txtmatkhau.Text == "") || (txttaikhoan.Text == "" && txtmatkhau.Text != ""))
            {
                MessageBox.Show("Nếu đăng kí tài khoản, vui lòng nhập đủ tài khoản và mật khẩu");
                return;
            }
            if (bus_NhanVien.KiemTraNhanVienTonTai(txtmanv.Text))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại. Mời chọn mã khác.");
                return;
            }
            if (txttaikhoan.Text != "" && bus_NhanVien.KiemTraTaiKhoanTonTai(txttaikhoan.Text))
            {
                MessageBox.Show("Tài khoản này đã tồn tại. Mời chọn tài khoản khác.");
                return;
            }
            DialogResult result = MessageBox.Show("Xác nhận thêm nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DTO_NhanVien dto_NhanVien = new DTO_NhanVien(txtmanv.Text, txttennv.Text, dateTimePicker1.Value, txtgioitinh.Text, txtsodienthoai.Text,
                txttaikhoan.Text, txtmatkhau.Text, txtquyen.Text == "Quản lý" ? true : false);
                if (bus_NhanVien.ThemNV(dto_NhanVien))
                {
                    MessageBox.Show("Thêm thành công.");
                }
                else
                {
                    MessageBox.Show("Thất bại.");
                }
            }
            dtgnhanvien.DataSource = bus_NhanVien.getAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtgnhanvien.DataSource = bus_NhanVien.getAll();
            dateTimePicker1.Value = DateTime.Now;
            txtgioitinh.Text = "";
            txtmanv.Text = "";
            txtmatkhau.Text = "";
            txtquyen.Text = "";
            txtsearch.Text = "";
            txtsodienthoai.Text = "";
            txttaikhoan.Text = "";
            txttennv.Text = "";
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            dtgnhanvien.DataSource = bus_NhanVien.getAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgnhanvien.SelectedRows.Count < 1)
            {
                MessageBox.Show("Mời chọn dòng trong bảng.");
                return;
            }
            if (txtmanv.Text == "" || txtgioitinh.Text == "" || dateTimePicker1.Text == "" || txtquyen.Text == ""
                || txtsodienthoai.Text == "" || txttennv.Text == "")
            {
                MessageBox.Show("Mời nhập đủ các thông tin cần thiết.");
                return;
            }
            if ((txttaikhoan.Text != "" && txtmatkhau.Text == "") || (txttaikhoan.Text == "" && txtmatkhau.Text != ""))
            {
                MessageBox.Show("Nếu đăng kí tài khoản, vui lòng nhập đủ tài khoản và mật khẩu");
                return;
            }
            if (txttaikhoan.Text != "" && bus_NhanVien.KiemTraTaiKhoanTonTai(txttaikhoan.Text))
            {
                MessageBox.Show("Tài khoản này đã tồn tại. Mời chọn tài khoản khác.");
                return;
            }
            DialogResult result = MessageBox.Show("Xác nhận sửa thông tin nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DTO_NhanVien dto_NhanVien = new DTO_NhanVien(dtgnhanvien.SelectedRows[0].Cells[0].Value.ToString(), txttennv.Text, dateTimePicker1.Value, txtgioitinh.Text, txtsodienthoai.Text,
                txttaikhoan.Text, txtmatkhau.Text, txtquyen.Text == "Quản lý" ? true : false);
                if (bus_NhanVien.SuaNV(dto_NhanVien))
                {
                    MessageBox.Show("Sửa nhân viên thành công.");
                }
                else
                {
                    MessageBox.Show("Thất bại.");
                }
            }
            dtgnhanvien.DataSource = bus_NhanVien.getAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtgnhanvien.SelectedRows.Count < 1)
            {
                MessageBox.Show("Mời chọn dòng trong bảng.");
                return;
            }
            DialogResult result = MessageBox.Show("Xác nhận xoá thông tin nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (bus_NhanVien.XoaNV(dtgnhanvien.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Xoá nhân viên thành công.");
                }
                else
                {
                    MessageBox.Show("Thất bại.");
                }
            }
            dtgnhanvien.DataSource = bus_NhanVien.getAll();
        }

        private void dtgnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmanv.Text = dtgnhanvien.SelectedRows[0].Cells[0].Value.ToString();
            txttennv.Text = dtgnhanvien.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Text = dtgnhanvien.SelectedRows[0].Cells[2].Value.ToString();
            txtgioitinh.Text = dtgnhanvien.SelectedRows[0].Cells[3].Value.ToString();
            txtsodienthoai.Text = dtgnhanvien.SelectedRows[0].Cells[4].Value.ToString();
            txttaikhoan.Text = dtgnhanvien.SelectedRows[0].Cells[5].Value.ToString();
            txtmatkhau.Text = dtgnhanvien.SelectedRows[0].Cells[6].Value.ToString();
            txtquyen.Text = dtgnhanvien.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dtgnhanvien.DataSource = bus_NhanVien.SearchNV(txtsearch.Text);
        }
    }
}
