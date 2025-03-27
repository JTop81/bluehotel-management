namespace GUI_QUANLYKHACHSAN
{
    partial class fDoiPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txbMaPhieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listPhongTrong = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.listPhongThue = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.txbMaNV = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txbTrangThai = new System.Windows.Forms.TextBox();
            this.txbMaPhongMoi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txbTongTien = new System.Windows.Forms.TextBox();
            this.dtpNgayChuyen = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnThemPhongThue = new System.Windows.Forms.Button();
            this.txbMaPhongCu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbMaKhach = new System.Windows.Forms.TextBox();
            this.dtpNgayThue = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txbThoiHan = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(9, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(500, 30);
            this.label14.TabIndex = 13;
            this.label14.Text = "Phiếu Đổi Phòng";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.txbMaPhieu);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(101, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 38);
            this.panel3.TabIndex = 14;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(207, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 26);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txbMaPhieu
            // 
            this.txbMaPhieu.Location = new System.Drawing.Point(91, 9);
            this.txbMaPhieu.Name = "txbMaPhieu";
            this.txbMaPhieu.Size = new System.Drawing.Size(100, 20);
            this.txbMaPhieu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu thuê:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Danh sách phòng trống:";
            // 
            // listPhongTrong
            // 
            this.listPhongTrong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listPhongTrong.FullRowSelect = true;
            this.listPhongTrong.GridLines = true;
            this.listPhongTrong.HideSelection = false;
            this.listPhongTrong.Location = new System.Drawing.Point(3, 23);
            this.listPhongTrong.Name = "listPhongTrong";
            this.listPhongTrong.Size = new System.Drawing.Size(499, 104);
            this.listPhongTrong.TabIndex = 0;
            this.listPhongTrong.UseCompatibleStateImageBehavior = false;
            this.listPhongTrong.View = System.Windows.Forms.View.Details;
            this.listPhongTrong.SelectedIndexChanged += new System.EventHandler(this.listPhongTrong_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Số phòng";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Loại Phòng";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá thuê";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mô tả";
            this.columnHeader4.Width = 200;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.listPhongTrong);
            this.panel4.Location = new System.Drawing.Point(25, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(506, 131);
            this.panel4.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.listPhongThue);
            this.panel5.Location = new System.Drawing.Point(25, 221);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(506, 132);
            this.panel5.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Danh sách phòng khách thuê:";
            // 
            // listPhongThue
            // 
            this.listPhongThue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listPhongThue.FullRowSelect = true;
            this.listPhongThue.GridLines = true;
            this.listPhongThue.HideSelection = false;
            this.listPhongThue.Location = new System.Drawing.Point(4, 24);
            this.listPhongThue.Name = "listPhongThue";
            this.listPhongThue.Size = new System.Drawing.Size(499, 104);
            this.listPhongThue.TabIndex = 1;
            this.listPhongThue.UseCompatibleStateImageBehavior = false;
            this.listPhongThue.View = System.Windows.Forms.View.Details;
            this.listPhongThue.SelectedIndexChanged += new System.EventHandler(this.listPhongThue_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số phiếu thuê";
            this.columnHeader5.Width = 98;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số phòng";
            this.columnHeader6.Width = 95;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Thời hạn";
            this.columnHeader7.Width = 92;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Giá phòng";
            this.columnHeader8.Width = 102;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(586, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mã nhân viên:";
            // 
            // txbMaNV
            // 
            this.txbMaNV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbMaNV.Location = new System.Drawing.Point(667, 6);
            this.txbMaNV.Name = "txbMaNV";
            this.txbMaNV.ReadOnly = true;
            this.txbMaNV.Size = new System.Drawing.Size(100, 13);
            this.txbMaNV.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Trạng thái:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Ngày đổi phòng:";
            // 
            // txbTrangThai
            // 
            this.txbTrangThai.Location = new System.Drawing.Point(113, 177);
            this.txbTrangThai.Name = "txbTrangThai";
            this.txbTrangThai.ReadOnly = true;
            this.txbTrangThai.Size = new System.Drawing.Size(100, 20);
            this.txbTrangThai.TabIndex = 3;
            // 
            // txbMaPhongMoi
            // 
            this.txbMaPhongMoi.Location = new System.Drawing.Point(113, 98);
            this.txbMaPhongMoi.Name = "txbMaPhongMoi";
            this.txbMaPhongMoi.ReadOnly = true;
            this.txbMaPhongMoi.Size = new System.Drawing.Size(100, 20);
            this.txbMaPhongMoi.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Tổng tiền:";
            // 
            // txbTongTien
            // 
            this.txbTongTien.Location = new System.Drawing.Point(113, 151);
            this.txbTongTien.Name = "txbTongTien";
            this.txbTongTien.ReadOnly = true;
            this.txbTongTien.Size = new System.Drawing.Size(100, 20);
            this.txbTongTien.TabIndex = 2;
            // 
            // dtpNgayChuyen
            // 
            this.dtpNgayChuyen.Location = new System.Drawing.Point(113, 125);
            this.dtpNgayChuyen.Name = "dtpNgayChuyen";
            this.dtpNgayChuyen.Size = new System.Drawing.Size(100, 20);
            this.dtpNgayChuyen.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mã phòng mới:";
            // 
            // btnThemPhongThue
            // 
            this.btnThemPhongThue.Location = new System.Drawing.Point(113, 203);
            this.btnThemPhongThue.Name = "btnThemPhongThue";
            this.btnThemPhongThue.Size = new System.Drawing.Size(100, 23);
            this.btnThemPhongThue.TabIndex = 15;
            this.btnThemPhongThue.Text = "Đổi phòng";
            this.btnThemPhongThue.UseVisualStyleBackColor = true;
            this.btnThemPhongThue.Click += new System.EventHandler(this.btnThemPhongThue_Click);
            // 
            // txbMaPhongCu
            // 
            this.txbMaPhongCu.Location = new System.Drawing.Point(113, 72);
            this.txbMaPhongCu.Name = "txbMaPhongCu";
            this.txbMaPhongCu.ReadOnly = true;
            this.txbMaPhongCu.Size = new System.Drawing.Size(100, 20);
            this.txbMaPhongCu.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mã phòng cũ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày thuê:";
            // 
            // txbMaKhach
            // 
            this.txbMaKhach.Location = new System.Drawing.Point(113, 20);
            this.txbMaKhach.Name = "txbMaKhach";
            this.txbMaKhach.ReadOnly = true;
            this.txbMaKhach.Size = new System.Drawing.Size(100, 20);
            this.txbMaKhach.TabIndex = 5;
            // 
            // dtpNgayThue
            // 
            this.dtpNgayThue.Location = new System.Drawing.Point(113, 46);
            this.dtpNgayThue.Name = "dtpNgayThue";
            this.dtpNgayThue.Size = new System.Drawing.Size(100, 20);
            this.dtpNgayThue.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã khách:";
            // 
            // txbThoiHan
            // 
            this.txbThoiHan.Location = new System.Drawing.Point(718, 25);
            this.txbThoiHan.Name = "txbThoiHan";
            this.txbThoiHan.Size = new System.Drawing.Size(49, 20);
            this.txbThoiHan.TabIndex = 19;
            this.txbThoiHan.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txbMaKhach);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.dtpNgayThue);
            this.groupBox1.Controls.Add(this.txbTrangThai);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txbMaPhongCu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnThemPhongThue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txbMaPhongMoi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbTongTien);
            this.groupBox1.Controls.Add(this.dtpNgayChuyen);
            this.groupBox1.Location = new System.Drawing.Point(537, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 242);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chuyển phòng:";
            // 
            // fDoiPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 364);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txbThoiHan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbMaNV);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label14);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fDoiPhong";
            this.Text = "Đổi Phòng";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txbMaPhieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView listPhongTrong;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView listPhongThue;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbMaNV;
        private System.Windows.Forms.TextBox txbMaPhongMoi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnThemPhongThue;
        private System.Windows.Forms.TextBox txbMaPhongCu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbMaKhach;
        private System.Windows.Forms.DateTimePicker dtpNgayThue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpNgayChuyen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbTrangThai;
        private System.Windows.Forms.TextBox txbTongTien;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbThoiHan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}