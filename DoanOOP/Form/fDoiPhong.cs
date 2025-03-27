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
    public partial class fDoiPhong : Form
    {
        BUS_PhieuThue bus_PhieuThue = new BUS_PhieuThue();
        BUS_DSPhongThue bus_DSPhongThue = new BUS_DSPhongThue();
        BUS_Phong bus_Phong = new BUS_Phong();
        BUS_DoiPhong bus_DoiPhong = new BUS_DoiPhong();
        public fDoiPhong()
        {
            InitializeComponent();
            dtpNgayThue.Format = DateTimePickerFormat.Custom;
            dtpNgayThue.CustomFormat = "dd/MM/yyyy";
            dtpNgayChuyen.Format = DateTimePickerFormat.Custom;
            dtpNgayChuyen.CustomFormat = "dd/MM/yyyy";
            txbMaNV.Text = AppManager.currentNhanVien.MaNV;
            ShowPhongTrong();
        }
        #region
        void ShowPhongTrong()
        {
            listPhongTrong.Items.Clear();
            DataTable td = new DataTable();
            td = bus_Phong.DanhSachPhongTrong();
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem lstItem = new ListViewItem(td.Rows[i][0].ToString());
                lstItem.SubItems.Add(td.Rows[i][1].ToString());
                lstItem.SubItems.Add(td.Rows[i][4].ToString());
                lstItem.SubItems.Add(td.Rows[i][2].ToString());
                listPhongTrong.Items.Add(lstItem);
            }
        }

        void ShowPhongThue(int soPThue)
        {
            listPhongThue.Items.Clear();
            DataTable td = new DataTable();
            td = bus_DSPhongThue.ShowPhongThue(soPThue);
            //List<DanhSachPhongThue> ds = DanSachPhongThueDAO.Instance.ShowPhongThue(soPThue);
            //foreach (DanhSachPhongThue item in ds)
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem lstItem = new ListViewItem(td.Rows[i][0].ToString());
                lstItem.SubItems.Add(td.Rows[i][1].ToString());
                lstItem.SubItems.Add(td.Rows[i][2].ToString());
                lstItem.SubItems.Add(td.Rows[i][3].ToString());
                listPhongThue.Items.Add(lstItem);
            }
        }

        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txbMaPhieu.Text == "")
                return;
            int soPThue = int.Parse(txbMaPhieu.Text);
            if (bus_PhieuThue.KiemTraPhieu(soPThue))
            {
                ShowPhongThue(soPThue);
                DTO_PhieuThue phieu = bus_PhieuThue.TimKiemPhieuThue(soPThue);
                txbMaKhach.Text = phieu.MaKH.ToString();
                txbTongTien.Text = phieu.TienPhong.ToString();
                dtpNgayThue.Value = phieu.NgayThue;
                txbTrangThai.Text = phieu.XacNhan;
            }
            else
            {
                Reset();
                MessageBox.Show("Không tìm thấy phiếu thuê");
            }
        }

        public void Reset()
        {
            txbMaKhach.Text = "";
            txbTongTien.Text = "";
            dtpNgayThue.Value = DateTime.Now;
            txbTrangThai.Text = "";
            txbMaPhongCu.Text = "";
            txbMaPhongMoi.Text = "";
            listPhongThue.Items.Clear();
        }

        private void listPhongTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPhongTrong.SelectedItems.Count == 0)
                return;
            else
            {
                txbMaPhongMoi.Text = listPhongTrong.SelectedItems[0].Text;
            }
        }

        private void listPhongThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPhongThue.SelectedItems.Count == 0)
                return;
            else
            {
                txbMaPhongCu.Text = listPhongThue.SelectedItems[0].SubItems[1].Text;
                txbThoiHan.Text = listPhongThue.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btnThemPhongThue_Click(object sender, EventArgs e)
        {
            if (txbMaPhieu.Text == "" || txbMaPhongCu.Text == "" || txbMaPhongMoi.Text == "")
            {
                MessageBox.Show("Trống thông tin");
                return;
            }
            int soPThue = int.Parse(txbMaPhieu.Text);
            string maPhongCu = txbMaPhongCu.Text;
            string maPhongmoi = txbMaPhongMoi.Text;

            if (!bus_PhieuThue.KiemTraTinhTrangPhieu(soPThue))
            {
                MessageBox.Show("Phiếu thuê đã thanh toán");
                return;
            }
            if (!bus_DSPhongThue.KiemTraMaPhongTonTai(maPhongCu) || !bus_DSPhongThue.KiemTraMaPhong(maPhongmoi))
            {
                MessageBox.Show("Sai số phòng");
                return;
            }
            DateTime ngayChuyen = dtpNgayChuyen.Value;
            DateTime ngayThue = dtpNgayThue.Value;
            string manv = txbMaNV.Text;
            int thoihan = int.Parse(txbThoiHan.Text);
            if ((int)(ngayChuyen.Date - ngayThue.Date).Days > thoihan)
            {
                MessageBox.Show("Ngày chuyển vượt quá thời hạn thuê");
                return;
            }
            if (bus_DoiPhong.DoiPhong(soPThue, maPhongCu, maPhongmoi, ngayChuyen, ngayThue, manv))
            {
                ShowPhongTrong();
                ShowPhongThue(soPThue);
                DTO_PhieuThue phieu = bus_PhieuThue.TimKiemPhieuThue(soPThue);
                txbTongTien.Text = phieu.TienPhong.ToString();
                MessageBox.Show("Đổi phòng thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }

        }
    }
}
