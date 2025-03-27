using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QUANLYKHACHSAN;
using BUS_QUANLYKHACHSAN;

namespace GUI_QUANLYKHACHSAN
{
    public partial class fThuephong : Form
    {
        BUS_KhachHang bus_KhachHang = new BUS_KhachHang();
        BUS_PhieuThue bus_PhieuThue = new BUS_PhieuThue();
        BUS_DSPhongThue bus_DSPhongThue = new BUS_DSPhongThue();
        BUS_Phong bus_Phong = new BUS_Phong();

        public fThuephong()
        {
            InitializeComponent();
            dtpNgayThue.Format = DateTimePickerFormat.Custom;
            dtpNgayThue.CustomFormat = "dd/MM/yyyy";
            txbMaNV.Text = AppManager.currentNhanVien.MaNV;
            //LoadList();
            ShowPhongTrong();
        }

        //void LoadList()
        //{
        //    string query = "EXEC dbo.USP_Login 'tjtanicad' , 'vitcon95'";
        //    DataTable x = DataProvider.Instance.ExecuteQuery(query);
        //    MessageBox.Show(x.Rows.Count.ToString());
        //}

        private void btnThemPhieuPhong_Click(object sender, EventArgs e)
        {
            DateTime ngayThue = dtpNgayThue.Value;
            string maNV = AppManager.currentNhanVien.MaNV;
            if (txbMaKhach.Text == "")
            {
                MessageBox.Show("Mã khách hàng đang trống!");
            }
            else
            {
                int maKH = int.Parse(txbMaKhach.Text);
                if (!bus_KhachHang.CheckedKhachHangById(maKH))
                {
                    MessageBox.Show("Khách hàng chưa tồn tại!\nVui lòng kiểm tra lại!");
                }
                else
                {
                    string check = bus_PhieuThue.ThemPhieuThue(maKH, ngayThue, maNV);
                    if (check != null)
                    {
                        txbMaPhieu.Text = check;
                        listPhongThue.Items.Clear();
                        txbTongTien.Text = "";
                        txbTrangThai.Text = "";
                        MessageBox.Show("Tạo mới phiếu thuê thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Tạo mới thất bại!");
                    }
                }
            }

        }



        private void btnThemPhongThue_Click(object sender, EventArgs e)
        {
            int thoiHan = int.Parse(numThoiHanThue.Value.ToString());
            if (txbMaPhieu.Text == "" || txbMaPhong.Text == "" || thoiHan == 0)
            {
                MessageBox.Show("Trống thông tin!");
                return;
            }
            int soPThue = int.Parse(txbMaPhieu.Text);
            string maPhong = txbMaPhong.Text;
            if (bus_PhieuThue.KiemTraTinhTrangPhieu(soPThue))
            {
                if (bus_DSPhongThue.KiemTraMaPhong(maPhong))
                {
                    DTO_DSPhongThue dsPhongThue = new DTO_DSPhongThue(maPhong, soPThue, thoiHan);
                    if (bus_DSPhongThue.ThemPhongThue(dsPhongThue))
                    {
                        DTO_PhieuThue phieu = bus_PhieuThue.TimKiemPhieuThue(soPThue);
                        txbMaKhach.Text = phieu.MaKH.ToString();
                        txbTongTien.Text = phieu.TienPhong.ToString();
                        dtpNgayThue.Value = phieu.NgayThue;
                        txbTrangThai.Text = phieu.XacNhan;
                        MessageBox.Show("Thêm thành công");
                        ShowPhongTrong();
                        ShowPhongThue(soPThue);
                    }
                    else
                        MessageBox.Show("Lỗi khi thêm");
                }
                else
                {
                    MessageBox.Show("Số phòng không chính xác hoặc đã cho thuê!");
                }

            }
            else
            {
                MessageBox.Show("Phiếu thuê không tồn tại hoặc đã thanh toán\nKhông thể thêm phòng mới!");
            }
        }



        private void btnHuyPhong_Click(object sender, EventArgs e)
        {
            
            if (txbMaPhieu.Text == "" || txbMaPhong.Text == "")
            {
                MessageBox.Show("Trống thông tin!");
                return;
            }
            int soPThue = int.Parse(txbMaPhieu.Text);
            string maPhong = txbMaPhong.Text;
            if (bus_PhieuThue.KiemTraTinhTrangPhieu(soPThue))
            {
                if (bus_DSPhongThue.KiemTraMaPhongTonTai(maPhong))
                {
                    if (bus_DSPhongThue.HuyPhongThue(maPhong, soPThue))
                    {
                        DTO_PhieuThue phieu = bus_PhieuThue.TimKiemPhieuThue(soPThue);
                        txbMaKhach.Text = phieu.MaKH.ToString();
                        txbTongTien.Text = phieu.TienPhong.ToString();
                        dtpNgayThue.Value = phieu.NgayThue;
                        txbTrangThai.Text = phieu.XacNhan;
                        MessageBox.Show("Hủy phòng thành công");
                        ShowPhongTrong();
                        ShowPhongThue(soPThue);
                    }
                    else
                        MessageBox.Show("Hủy phòng có vẫn đề");
                }
                else
                {
                    MessageBox.Show("Số phòng không chính xác !");
                }

            }
            else
            {
                MessageBox.Show("Phiếu thuê không tồn tại hoặc đã thanh toán\nKhông thể hủy phòng!");
            }
        }

        #region Kiểm tra

        void ShowPhongTrong()
        {
            listPhongTrong.Items.Clear();
            DataTable td = new DataTable();
            td = bus_Phong.DanhSachPhongTrong();
            //List<Phong> danhsach = PhongDAO.Instance.DanhSachPhongTrong();
            //foreach (Phong item in danhsach)
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem lstItem = new ListViewItem(td.Rows[i][0].ToString());
                lstItem.SubItems.Add(td.Rows[i][1].ToString());
                lstItem.SubItems.Add(td.Rows[i][4].ToString());
                lstItem.SubItems.Add(td.Rows[i][2].ToString());
                listPhongTrong.Items.Add(lstItem);
            }
        }

        void ShowThongTinPhieuThue(string soPThue)
        {

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

        private void label9_Click(object sender, EventArgs e)
        {

        }

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
            listPhongThue.Items.Clear();
        }

        bool ThanhToanPhieu(int soPThue, DateTime ngayThanhToan)
        {
            return bus_PhieuThue.ThanhToan(soPThue, ngayThanhToan);
        }

        private void listPhongTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPhongTrong.SelectedItems.Count == 0)
                return;
            else
            {
                txbMaPhong.Text = listPhongTrong.SelectedItems[0].Text;
            }
        }

        private void listPhongThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPhongThue.SelectedItems.Count == 0)
                return;
            else
            {
                txbMaPhong.Text = listPhongThue.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txbKhachCheck.Text == "")
                return;
            string checkKhach = txbKhachCheck.Text;
            string maKH = bus_KhachHang.CheckedKhachHangByCMND(checkKhach);
            if (maKH == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng");
                fKhachhang fKhachhang = new fKhachhang();
                fKhachhang.ShowDialog();
            }
            else
            {
                txbMaKhach.Text = maKH;
            }

        }
    }
}
