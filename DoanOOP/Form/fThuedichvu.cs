using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUS_QUANLYKHACHSAN;
using DTO_QUANLYKHACHSAN;

namespace GUI_QUANLYKHACHSAN
{
    public partial class fThuedichvu : Form
    {
        BUS_DSPhongThue bus_DSPhongThue;
        BUS_PhieuDichVu bus_PhieuDichVu;
        BUS_DichVu bus_DichVu;
        BUS_Phong bus_Phong;
        BUS_PhieuThue bus_PhieuThue;

        public fThuedichvu()
        {
            InitializeComponent();
            bus_PhieuDichVu = new BUS_PhieuDichVu();
            bus_DSPhongThue = new BUS_DSPhongThue();
            bus_DichVu = new BUS_DichVu();
            bus_Phong = new BUS_Phong();
            bus_PhieuThue = new BUS_PhieuThue();
        }

        private void fThuedichvu_Load(object sender, EventArgs e)
        {
            txbMaNV.Text = AppManager.currentNhanVien.MaNV;
            DataTable td = new DataTable();
            td = bus_Phong.getAllPhong();
            for (int i = 0; i < td.Rows.Count; i++)
            {
                comboPhong.Items.Add(td.Rows[i][0]);
            }

            td = bus_DichVu.getAllDV();
            for (int i = 0; i < td.Rows.Count; i++)
            {
                comboDV.Items.Add(td.Rows[i][0]);
            }

            td = bus_PhieuDichVu.GetPDVchuaThanhToan();
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                item.SubItems.Add(td.Rows[i][2].ToString());
                item.SubItems.Add(td.Rows[i][3].ToString());
                item.SubItems.Add(td.Rows[i][1].ToString());
                item.SubItems.Add(td.Rows[i][4].ToString());
                item.SubItems.Add(td.Rows[i][5].ToString());
                listView1.Items.Add(item);
            }
        }

        private void bt_adddv_Click(object sender, EventArgs e)
        {
            try
            {
                if (textPThue.Text == "" || comboPhong.Text == "" || comboDV.Text == "")
                {
                    MessageBox.Show("Mời nhập đủ thông tin.");
                    return;
                }

                DialogResult result = MessageBox.Show("Xác nhận thêm phiếu dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DTO_PhieuDichVu phieuDichVu = new DTO_PhieuDichVu(int.Parse(textPThue.Text), comboPhong.Text, int.Parse(comboDV.Text), AppManager.currentNhanVien.MaNV);
                    bus_PhieuDichVu.ThemPDV(phieuDichVu);
                    MessageBox.Show("Done", "Thông báo");
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }

                    DataTable td = bus_PhieuDichVu.getAllPDV();
                    for (int i = 0; i < td.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                        item.SubItems.Add(td.Rows[i][2].ToString());
                        item.SubItems.Add(td.Rows[i][3].ToString());
                        item.SubItems.Add(td.Rows[i][1].ToString());
                        item.SubItems.Add(td.Rows[i][4].ToString());
                        item.SubItems.Add(td.Rows[i][5].ToString());
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Chi tiết lỗi");
            }
        }

        private void bt_deldv_Click(object sender, EventArgs e)
        {
            int id;
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Mời chọn thông tin phiếu dịch vụ trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int row = this.listView1.SelectedItems[0].Index;
            id = int.Parse(this.listView1.Items[row].SubItems[0].Text);
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận huỷ phiếu dịch vụ này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bus_PhieuDichVu.XoaPDV(id);
                    MessageBox.Show("Đã xoá phiếu dịch vụ.");
                    DataTable td = bus_PhieuDichVu.getAllPDV();
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        listView1.Items[i].Remove();
                        i--;
                    }
                    for (int i = 0; i < td.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                        item.SubItems.Add(td.Rows[i][2].ToString());
                        item.SubItems.Add(td.Rows[i][3].ToString());
                        item.SubItems.Add(td.Rows[i][1].ToString());
                        item.SubItems.Add(td.Rows[i][4].ToString());
                        item.SubItems.Add(td.Rows[i][5].ToString());
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Chi tiết lỗi");
            }
        }

        private void comboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable td = new DataTable();
            td = bus_DSPhongThue.GetSPTbyMaPhong(comboPhong.Text);
            if (td.Rows.Count > 0)
            {
                for (int i = 0; i < td.Rows.Count; i++)
                {
                    if (bus_PhieuThue.CheckIfNotReg(int.Parse(td.Rows[i][0].ToString())))
                    {
                        textPThue.Text = td.Rows[i][0].ToString();
                        return;
                    }
                }

                MessageBox.Show("Phòng này hiện tại chưa được thuê.");
            }
            else
            {
                textPThue.Text = "";
            }
        }

        private void searchPDV_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Remove();
                i--;
            }
            DataTable td = new DataTable();
            td = bus_PhieuDichVu.TimTheoPThue(searchPDV.Text);
            if (td.Rows.Count > 0)
                for (int i = 0; i < td.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                    item.SubItems.Add(td.Rows[i][2].ToString());
                    item.SubItems.Add(td.Rows[i][3].ToString());
                    item.SubItems.Add(td.Rows[i][1].ToString());
                    item.SubItems.Add(td.Rows[i][4].ToString());
                    item.SubItems.Add(td.Rows[i][5].ToString());
                    listView1.Items.Add(item);
                }
        }
    }
}
