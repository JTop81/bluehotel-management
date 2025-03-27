using System;
using System.Windows.Forms;
using BUS_QUANLYKHACHSAN;
using DTO_QUANLYKHACHSAN;

namespace GUI_QUANLYKHACHSAN
{
    public partial class fDichvu : Form
    {
        BUS_DichVu bus_DichVu = new BUS_DichVu();


        public fDichvu()
        {
            InitializeComponent();
            bus_DichVu = new BUS_DichVu();
        }

        private void fDichvu_Load(object sender, EventArgs e)
        {
            dtgdichvu.DataSource = bus_DichVu.getAllDV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txttendv.Text == "" || txtgiatiendv.Text == "" || txtmotadv.Text == "")
            {
                MessageBox.Show("Thông tin về dịch vụ mới đang để trống.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Xác nhận thêm thông tin dịch vụ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DTO_DichVu dichvu = new DTO_DichVu(txttendv.Text, txtmotadv.Text, int.Parse(txtgiatiendv.Text));
                    if (bus_DichVu.themDV(dichvu))
                    {
                        MessageBox.Show("Thêm thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thất bại.");
                    }
                    dtgdichvu.DataSource = bus_DichVu.getAllDV();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgdichvu.SelectedRows.Count < 1)
            {
                MessageBox.Show("Cập nhật thất bại. Mời chọn nội dung trong bảng.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Sửa thông tin dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DTO_DichVu dichvu = new DTO_DichVu(int.Parse(dtgdichvu.SelectedRows[0].Cells[0].Value.ToString()), txttendv.Text, txtmotadv.Text, int.Parse(txtgiatiendv.Text));
                    if (bus_DichVu.suaDV(dichvu))
                    {
                        MessageBox.Show("Cập nhật thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thất bại.");
                    }
                    dtgdichvu.DataSource = bus_DichVu.getAllDV();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dtgdichvu.SelectedRows.Count < 1)
            {
                MessageBox.Show("Không thể xoá. Mời chọn nội dung trong bảng.");
            }
            else
            {
                DialogResult result = MessageBox.Show("Xác nhận xoá thông tin dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bus_DichVu.xoaDV(int.Parse(dtgdichvu.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        MessageBox.Show("Xoá thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá.");
                    }
                    dtgdichvu.DataSource = bus_DichVu.getAllDV();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                BUS_DichVu load = new BUS_DichVu();
                dtgdichvu.DataSource = load.getAllDV();
            }
            else
            {
                BUS_DichVu timkiem = new BUS_DichVu();
                string tendv = txtsearch.Text;
                timkiem.timkiemDV(tendv);
                BUS_DichVu load = new BUS_DichVu();
                dtgdichvu.DataSource = load.timkiemDV(tendv);
            }

        }

        private void dtgdichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmadv.Text = dtgdichvu.SelectedRows[0].Cells[0].Value.ToString();
            txttendv.Text = dtgdichvu.SelectedRows[0].Cells[1].Value.ToString();
            txtgiatiendv.Text = dtgdichvu.SelectedRows[0].Cells[2].Value.ToString();
            txtmotadv.Text = dtgdichvu.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dtgdichvu.DataSource = bus_DichVu.getAllDV();
            txtgiatiendv.Text = "";
            txtmadv.Text = "";
            txtmotadv.Text = "";
            txtsearch.Text = "";
            txttendv.Text = "";
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dtgdichvu.DataSource = bus_DichVu.timkiemDV(txtsearch.Text);
        }
    }
}
