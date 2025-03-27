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
    public partial class fThanhToan : Form
    {
        BUS_PhieuThue bus_PhieuThue;
        BUS_DSPhongThue bus_DSPhongThue;
        BUS_PhieuDichVu bus_PhieuDichVu;
        public fThanhToan()
        {
            InitializeComponent();
            bus_PhieuThue = new BUS_PhieuThue();
            bus_DSPhongThue = new BUS_DSPhongThue();
            bus_PhieuDichVu = new BUS_PhieuDichVu();
            dtpNgayThue.Format = DateTimePickerFormat.Custom;
            dtpNgayThue.CustomFormat = "dd/MM/yyyy";
            dtpNgayThanhToan.Format = DateTimePickerFormat.Custom;
            dtpNgayThanhToan.CustomFormat = "dd/MM/yyyy";
        }

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            if (txtTimPhieu.Text == "")
                return;
            int soPThue = int.Parse(txtTimPhieu.Text);
            if (bus_PhieuThue.KiemTraPhieu(soPThue))
            {
                DTO_PhieuThue phieu = bus_PhieuThue.TimKiemPhieuThue(soPThue);
                txtMaKhach.Text = phieu.MaKH.ToString();
                txtTienPhong.Text = phieu.TienPhong.ToString();
                txtTienDichVu.Text = phieu.TienDV.ToString();
                txtTongTien.Text = (phieu.TienDV + phieu.TienPhong).ToString();
                dtpNgayThue.Value = phieu.NgayThue;
                txtTrangThai.Text = phieu.XacNhan;
                if (phieu.NgayThanhToan.ToString() != "")
                    dtpNgayThanhToan.Value = phieu.NgayThanhToan.Value;
                ShowPhongThue(soPThue);
                ShowDichVu(soPThue);
            }
            else
            {
                Reset();
                MessageBox.Show("Không tìm thấy phiếu thuê");
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

        void ShowDichVu(int soPThue)
        {
            listDichVu.Items.Clear();
            DataTable t = new DataTable();
            t = bus_PhieuDichVu.ShowPDV(soPThue);
            for (int i = 0; i < t.Rows.Count; i++)
            {
                ListViewItem lstItem = new ListViewItem(t.Rows[i][0].ToString());
                lstItem.SubItems.Add(t.Rows[i][1].ToString());
                lstItem.SubItems.Add(t.Rows[i][2].ToString());
                lstItem.SubItems.Add(t.Rows[i][3].ToString());
                listDichVu.Items.Add(lstItem);
            }
        }

        public void Reset()
        {
            txtMaKhach.Text = "";
            txtTienPhong.Text = "";
            dtpNgayThue.Value = DateTime.Now;
            txtTrangThai.Text = "";
            txtTienDichVu.Text = "";
            txtTongTien.Text = "";
            dtpNgayThanhToan.Value = DateTime.Now;
            txtTienDichVu.Text = "";
            listPhongThue.Items.Clear();
            listDichVu.Items.Clear();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            if (txtTimPhieu.Text == "")
                return;
            int soPThue = int.Parse(txtTimPhieu.Text);
            DateTime ngayThanhToan = dtpNgayThanhToan.Value;
            if (bus_PhieuThue.KiemTraTinhTrangPhieu(soPThue))
            {
                if (bus_PhieuThue.ThanhToan(soPThue, ngayThanhToan))
                {
                    txtTrangThai.Text = "Đã thanh toán";
                    MessageBox.Show("Thanh toán thành công");

                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại");
                }
            }
            else
            {
                MessageBox.Show("Phiếu đã thanh toán từ trước. Vui lòng xác nhận lại!");
            }
        }

        private void fThanhToan_Load(object sender, EventArgs e)
        {
            txbMaNV.Text = AppManager.currentNhanVien.MaNV;
        }
    }
}
