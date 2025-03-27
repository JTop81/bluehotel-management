using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUS_QUANLYKHACHSAN;
using DTO_QUANLYKHACHSAN;

namespace GUI_QUANLYKHACHSAN
{
    public partial class QLPhong : Form
    {
        BUS_Phong bus_Phong;
        BUS_DSPhongThue bus_DSPhongThue;

        public QLPhong()
        {
            InitializeComponent();
            bus_Phong = new BUS_Phong();
            bus_DSPhongThue = new BUS_DSPhongThue();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmaphong.Text == "" || txtloaiphong.Text == "" || txtloaiphong.Text == "" || txttinhtrang.Text == "" || txtgiathue.Text == "")
            {
                MessageBox.Show("Mời nhập đầy đủ thông tin.");
                return;
            }
            if (bus_DSPhongThue.KiemTraMaPhongTonTai(txtmaphong.Text))
            {
                MessageBox.Show("Mã phòng này đã tồn tại.");
                return;
            }
            DialogResult result = MessageBox.Show("Xác nhận thêm phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DTO_Phong dto_Phong = new DTO_Phong(txtmaphong.Text, txtloaiphong.Text, txtdieukienphong.Text, txttinhtrang.Text, decimal.Parse(txtgiathue.Text));
                if (bus_Phong.ThemPhong(dto_Phong))
                {
                    MessageBox.Show("Thêm thành công.");
                }
                else
                {
                    MessageBox.Show("Thất bại.");
                }
            }
            dtgphong.DataSource = bus_Phong.getAllPhong();
            //string query1 = "INSERT INTO dbo.Phong VALUES (N'" + txtmaphong.Text + "', N'" + txtloaiphong.Text + "', N'" + txtdieukienphong.Text + "', N'" + txttinhtrang.Text + "', N'" + txtgiathue.Text + "')";
            //string query2 = "Thêm thành công.";
            //ImportantStuff add = new ImportantStuff();
            //add.basicbutton(query1, query2);
            //String query = "SELECT * FROM dbo.Phong";
            //ImportantStuff load = new ImportantStuff();
            //dtgphong.DataSource = load.ExecuteQuery(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgphong.SelectedRows.Count < 1)
            {
                MessageBox.Show("Mời chọn dòng trong bảng.");
                return;
            }
            if (txtmaphong.Text == "" || txtloaiphong.Text == "" || txtloaiphong.Text == "" || txttinhtrang.Text == "" || txtgiathue.Text == "")
            {
                MessageBox.Show("Mời nhập đầy đủ thông tin.");
                return;
            }
            if (bus_DSPhongThue.KiemTraMaPhongTonTai(txtmaphong.Text))
            {
                MessageBox.Show("Mã phòng này đã tồn tại.");
                return;
            }
            DialogResult result = MessageBox.Show("Xác nhận sửa thông tin phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DTO_Phong dto_Phong = new DTO_Phong(txtmaphong.Text, txtloaiphong.Text, txtdieukienphong.Text, txttinhtrang.Text, decimal.Parse(txtgiathue.Text));
                if (bus_Phong.SuaPhong(dto_Phong, dtgphong.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Cập nhật thành công.");
                }
                else
                {
                    MessageBox.Show("Thất bại.");
                }
            }
            dtgphong.DataSource = bus_Phong.getAllPhong();
            //string query1 = "UPDATE dbo.Phong SET maPhong = N'" + txtmaphong.Text + "', loaiPhong = N'" + txtloaiphong.Text + "', dkPhong = N'" + txtdieukienphong.Text + "', tinhTrang = N'" + txttinhtrang.Text + "', giaThue = N'" + txtgiathue.Text + "' WHERE maPhong = '" + txtmaphong.Text + "'";
            //string query2 = "Cập nhập thành công.";
            //ImportantStuff add = new ImportantStuff();
            //add.basicbutton(query1, query2);
            //String query = "SELECT * FROM dbo.Phong";
            //ImportantStuff load = new ImportantStuff();
            //dtgphong.DataSource = load.ExecuteQuery(query);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtgphong.SelectedRows.Count < 1)
            {
                MessageBox.Show("Mời chọn dòng trong bảng.");
                return;
            }
            DialogResult result = MessageBox.Show("Xác nhận xoá thông tin phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {               
                if (bus_Phong.XoaPhong(dtgphong.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Xoá phòng thành công.");
                }
                else
                {
                    MessageBox.Show("Thất bại.");
                }
            }
            dtgphong.DataSource = bus_Phong.getAllPhong();
            //string query1 = "DELETE FROM dbo.Phong WHERE maPhong = N'" + txtmaphong.Text + "'";
            //string query2 = "Xoá thành công.";
            //ImportantStuff add = new ImportantStuff();
            //add.basicbutton(query1, query2);
            //String query = "SELECT * FROM dbo.Phong";
            //ImportantStuff load = new ImportantStuff();
            //dtgphong.DataSource = load.ExecuteQuery(query);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtgphong.DataSource = bus_Phong.getAllPhong();
            txtdieukienphong.Text = "";
            txtgiathue.Text = "";
            txtloaiphong.Text = "";
            txtmaphong.Text = "";
            txtsearch.Text = "";
            txttinhtrang.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //String query = "SELECT * FROM dbo.Phong WHERE maPhong LIKE N'%" + txtsearch.Text + "%'";
            //ImportantStuff load = new ImportantStuff();
            //dtgphong.DataSource = load.ExecuteQuery(query);
        }

        private void dtgphong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaphong.Text = dtgphong.SelectedRows[0].Cells[0].Value.ToString();
            txtloaiphong.Text = dtgphong.SelectedRows[0].Cells[1].Value.ToString();
            txtdieukienphong.Text = dtgphong.SelectedRows[0].Cells[2].Value.ToString();
            txttinhtrang.Text = dtgphong.SelectedRows[0].Cells[3].Value.ToString();
            txtgiathue.Text = dtgphong.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void QLPhong_Load(object sender, EventArgs e)
        {
            dtgphong.DataSource = bus_Phong.getAllPhong();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dtgphong.DataSource = bus_Phong.SearchMaPhong(txtsearch.Text);
        }
    }
}
