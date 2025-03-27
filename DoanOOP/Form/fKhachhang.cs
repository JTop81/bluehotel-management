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
    public partial class fKhachhang : Form
    {
        BUS_KhachHang bus_KhachHang;

        public fKhachhang()
        {
            InitializeComponent();
            bus_KhachHang = new BUS_KhachHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txttenkh.Text == "" && dateTimePicker1.Text == "" && txtdiachi.Text == "" && txtcmnd.Text == "" && txtsodienthoai.Text == "" && txtgioitinh.Text == "")
            {
                MessageBox.Show("Thông tin về khách hàng mới đang để trống.");
            }
            else
            {
                if (bus_KhachHang.CheckedKhachHangByCMND2(txtcmnd.Text))
                {
                    MessageBox.Show("Đã tồn tại khách hàng với số cmnd này. Mời thử lại.");
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận thêm thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DTO_KhachHang khachhang = new DTO_KhachHang(txttenkh.Text, dateTimePicker1.Value, txtdiachi.Text, txtcmnd.Text, txtsodienthoai.Text, txtgioitinh.Text);
                    if (bus_KhachHang.themKH(khachhang))
                    {
                        MessageBox.Show("Thêm thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thất bại.");
                    }
                    dtgkhachhang.DataSource = bus_KhachHang.getAllKhach();
                }
            }
            //string query1 = "INSERT INTO dbo.KhachHang (tenKH, ngaySinh, diaChi, cmnd, sdt, sex) VALUES (N'" + txttenkh.Text + "', N'" + txtngaysinh.Text + "', N'" + txtdiachi.Text + "', N'" + txtcmnd.Text + "', N'" + txtsodienthoai.Text + "', N'" + txtgioitinh.Text + "')";
            //string query2 = "Thêm thành công.";
            //ImportantStuff add = new ImportantStuff();
            //add.basicbutton(query1, query2);
            //String query = "SELECT * FROM dbo.KhachHang";
            //ImportantStuff load = new ImportantStuff();
            //dtgkhachhang.DataSource = load.ExecuteQuery(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgkhachhang.SelectedRows.Count < 1)
            {
                MessageBox.Show("Cập nhập thất bại. Mời chọn nội dung trong bảng");
            }
            else
            {
                if (txttenkh.Text == "" && dateTimePicker1.Text == "" && txtdiachi.Text == "" && txtcmnd.Text == "" && txtsodienthoai.Text == "" && txtgioitinh.Text == "")
                {
                    MessageBox.Show("Thông tin cập nhật khách hàng đang để trống.");
                    return;
                }
                if (bus_KhachHang.CheckedKhachHangByCMND2(txtcmnd.Text))
                {
                    MessageBox.Show("Đã tồn tại khách hàng với số cmnd này. Mời thử lại.");
                    return;
                }
                DialogResult result = MessageBox.Show("Xác nhận cập nhật thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DTO_KhachHang khachhang = new DTO_KhachHang(int.Parse(dtgkhachhang.SelectedRows[0].Cells[0].Value.ToString()),
                        txttenkh.Text, dateTimePicker1.Value, txtdiachi.Text, txtcmnd.Text, txtsodienthoai.Text, txtgioitinh.Text);
                    if (bus_KhachHang.suaKH(khachhang))
                    {
                        MessageBox.Show("Cập nhật thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thất bại.");
                    }
                    dtgkhachhang.DataSource = bus_KhachHang.getAllKhach();
                }
            }
            //string query1 = "UPDATE dbo.KhachHang SET tenKH = N'" + txttenkh.Text + "', ngaySinh = N'" + txtngaysinh.Text + "', diaChi = N'" + txtdiachi.Text + "', cmnd = N'" + txtcmnd.Text + "', sdt = N'" + txtsodienthoai.Text + "', sex = N'" + txtgioitinh.Text + "' WHERE maKH = '" + txtmakh.Text + "'";
            //string query2 = "Cập nhập thành công.";
            //ImportantStuff update = new ImportantStuff();
            //update.basicbutton(query1, query2);
            //String query = "SELECT * FROM dbo.KhachHang";
            //ImportantStuff load = new ImportantStuff();
            //dtgkhachhang.DataSource = load.ExecuteQuery(query);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtgkhachhang.SelectedRows.Count < 1)
            {
                MessageBox.Show("Xoá thất bại. Mời chọn nội dung trong bảng");
            }
            else
            {
                DialogResult result = MessageBox.Show("Xác nhận xoá thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bus_KhachHang.xoaKH(int.Parse(dtgkhachhang.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("Xoá thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá.");
                    }
                    dtgkhachhang.DataSource = bus_KhachHang.getAllKhach();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtgkhachhang.DataSource = bus_KhachHang.getAllKhach();
            txtcmnd.Text = "";
            txtdiachi.Text = "";
            txtgioitinh.Text = "";
            txtmakh.Text = "";
            txtsearch.Text = "";
            txtsodienthoai.Text = "";
            txttenkh.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                BUS_KhachHang load = new BUS_KhachHang();
                dtgkhachhang.DataSource = load.getAllKhach();
            }
            else
            {
                BUS_KhachHang timkiem = new BUS_KhachHang();
                string tenkh = txtsearch.Text;
                timkiem.timkiemKH(tenkh);
                BUS_KhachHang load = new BUS_KhachHang();
                dtgkhachhang.DataSource = load.timkiemKH(tenkh);
            }
        }

        private void dtgkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmakh.Text = dtgkhachhang.SelectedRows[0].Cells[0].Value.ToString();
            txttenkh.Text = dtgkhachhang.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Text = dtgkhachhang.SelectedRows[0].Cells[2].Value.ToString();
            txtdiachi.Text = dtgkhachhang.SelectedRows[0].Cells[3].Value.ToString();
            txtcmnd.Text = dtgkhachhang.SelectedRows[0].Cells[4].Value.ToString();
            txtsodienthoai.Text = dtgkhachhang.SelectedRows[0].Cells[5].Value.ToString();
            txtgioitinh.Text = dtgkhachhang.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            dtgkhachhang.DataSource = bus_KhachHang.getAllKhach();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dtgkhachhang.DataSource = bus_KhachHang.timkiemKH(txtsearch.Text);
        }
    }
}
