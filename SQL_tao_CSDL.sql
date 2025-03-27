CREATE DATABASE QuanLyKhachSan
Go

USE QuanLyKhachSan
go

CREATE TABLE NhanVien
(
       maNV nvarchar(10) PRIMARY KEY,
	   tenNV nvarchar(50) NOT NULL,
	   ngaySinh date NOT NULL,
	   sex nvarchar(10) NOT NULL DEFAULT N'Nam', --nam || nữ 
	   sdt nvarchar(20) NOT NULL,
	   tkhoan nvarchar(20),
	   pass nvarchar(20) DEFAULT '1',
	   quyen bit NOT NULL DEFAULT 0 -- 0 : nhân viên || 1 : admin
)
GO

CREATE TABLE Phong
(
       maPhong nvarchar(10) PRIMARY KEY,
	   loaiPhong nvarchar(50) NOT NULL,
	   dkPhong nvarchar(50) NOT NULL DEFAULT N'Phòng thơm tho',
	   tinhTrang nvarchar(50) NOT NULL DEFAULT N'Trống', -- Trống || Đã thuê
	   giaThue   float NOT NULL DEFAULT 0
)
GO

CREATE TABLE DichVu
(
       maDV int IDENTITY(1,1) PRIMARY KEY,
	   tenDV nvarchar(100) NOT NULL,
	   giaTien float NOT NULL DEFAULT 0,
	   moTa nvarchar(100) NOT NULL DEFAULT N'Chưa mô tả'
)
GO

CREATE TABLE KhachHang
(
       maKH int IDENTITY(1,1) PRIMARY KEY,
	   tenKH nvarchar(50) NOT NULL,
	   ngaySinh date NOT NULL,
	   diaChi nvarchar(100) NOT NULL DEFAULT N'Chưa có địa chỉ',
	   cmnd nvarchar(20) NOT NULL DEFAULT N'Chưa thêm',
	   sdt nvarchar(20) NOT NULL DEFAULT N'Chưa thêm',
	   sex nvarchar(10) NOT NULL DEFAULT N'Nam'
)

CREATE TABLE PhieuThue
(
       soPThue int IDENTITY(1,1) PRIMARY KEY,
	   maKH int NOT NULL,
	   maNV nvarchar(10) NOT NULL,
	   ngayThue date NOT NULL,
	   tongtien float NOT NULL DEFAULT 0,
	   tienDV float NOT NULL DEFAULT 0,
	   ngayThanhToan date,
	   xacNhan nvarchar(20) NOT NULL DEFAULT N'Chưa thanh toán'
	   FOREIGN KEY (maKH) REFERENCES dbo.KhachHang(maKH),
	   FOREIGN KEY (maNV) REFERENCES dbo.NhanVien(maNV)
)
GO

CREATE TABLE DanhSachPhongThue
(
       id INT IDENTITY(1,1) PRIMARY KEY,
	   maPhong nvarchar(10) NOT NULL,
	   soPThue int NOT NULL,
	   thoiHan int NOT NULL,
	   xacNhan bit NOT NULL DEFAULT 0   --0: chưa trả phòng || 1: đã trả phòng
	   FOREIGN KEY (maPhong) REFERENCES dbo.Phong(maPhong),
	   FOREIGN KEY (soPThue) REFERENCES dbo.PhieuThue(soPThue)
)
GO

CREATE TABLE PhieuDichVu
(
       soPDV int IDENTITY(1,1) PRIMARY KEY,
	   maDV int NOT NULL,
	   soPThue int NOT NULL,
	   maPhong nvarchar(10) NOT NULL,
	   maNV nvarchar(10) NOT NULL,
	   ngayThueDV date NOT NULL
	   FOREIGN KEY (maDV) REFERENCES dbo.DichVu(maDV),
	   FOREIGN KEY (soPThue) REFERENCES dbo.PhieuThue(soPThue),
	   FOREIGN KEY (maPhong) REFERENCES dbo.Phong(maPhong),
	   FOREIGN KEY (maNV) REFERENCES dbo.NhanVien(maNV)
)
GO

CREATE TABLE DoiPhong
(
       id INT IDENTITY(1,1) PRIMARY KEY,
	   maPhongCu nvarchar(10) NOT NULL,
	   maPhongMoi nvarchar(10) NOT NULL,
	   ngayChuyen date NOT NULL,
	   soPThue nvarchar(10) NOT NULL,
	   maNV nvarchar(10) NOT NULL DEFAULT 0
	   FOREIGN KEY (maNV) REFERENCES dbo.NhanVien(maNV)
)
GO


CREATE PROC USP_Login
@tkhoan nvarchar(20), @pass nvarchar(20)
AS
BEGIN
     SELECT * FROM dbo.NhanVien WHERE tkhoan = @tkhoan AND pass = @pass
	 
END
GO

--Cập nhật lại trạng thái phòng khi đã cho thuê
CREATE TRIGGER tr_ThemPhong ON dbo.DanhSachPhongThue AFTER INSERT AS
BEGIN
     UPDATE dbo.PhieuThue
	 SET tongtien = tongtien + (inserted.thoiHan*(SELECT giaThue FROM dbo.Phong WHERE maPhong = inserted.maPhong))
	 FROM dbo.Phong JOIN inserted ON dbo.Phong.maPhong = inserted.maPhong
	 WHERE PhieuThue.soPThue = inserted.soPThue
     UPDATE dbo.Phong
	 SET tinhTrang = N'Đã Thuê'
	 FROM dbo.Phong JOIN inserted ON dbo.Phong.maPhong = inserted.maPhong	 
END
GO

--Cập nhật lại trạng thái phòng khi hủy cho thue
CREATE TRIGGER tr_HuyPhong ON dbo.DanhSachPhongThue FOR DELETE AS
BEGIN
     UPDATE dbo.PhieuThue
	 SET tongtien = tongtien - (deleted.thoiHan*(SELECT giaThue FROM dbo.Phong WHERE maPhong = deleted.maPhong))
	 FROM dbo.Phong JOIN deleted ON dbo.Phong.maPhong = deleted.maPhong
	 WHERE PhieuThue.soPThue = deleted.soPThue
     UPDATE dbo.Phong
	 SET tinhTrang = N'Trống'
	 FROM dbo.Phong JOIN deleted ON dbo.Phong.maPhong = deleted.maPhong
END
GO

--Cập nhật lại trạng thái phòng khi khách trả phòng
CREATE PROC USP_ThanhToan
@ngayThanhToan date, @soPThue int
AS
BEGIN
     DECLARE cursorx CURSOR FOR
	 SELECT maPhong,xacNhan FROM dbo.DanhSachPhongThue WHERE soPThue = @soPThue
	 DECLARE @maPhong nvarchar(10), @xacNhan bit
	 OPEN cursorx
	 FETCH NEXT FROM cursorx INTO @maPhong, @xacNhan
	 WHILE @@FETCH_STATUS = 0
	 BEGIN
	      UPDATE dbo.Phong SET tinhTrang = N'Trống' Where maPhong = @maPhong AND @xacNhan = 0
	      FETCH NEXT FROM cursorx INTO @maPhong, @xacNhan
    END
    CLOSE cursorx
    DEALLOCATE cursorx

     UPDATE dbo.PhieuThue 
     SET xacNhan = N'Đã thanh toán',
	     ngayThanhToan = @ngayThanhToan
     WHERE soPThue = @soPThue	 
END
GO

--Kiểm tra tình trạng thanh toán của phiếu thuê
CREATE PROC sp_CheckedPhieuThue
       @soPThue INT
AS
BEGIN    
    SELECT * FROM dbo.PhieuThue WHERE soPThue = @soPThue AND xacNhan = N'Chưa thanh toán' 	       
END
GO

--Kiểm tra phòng khi cho khách thuê đảm bảo phòng còn trống
CREATE PROC sp_KiemTraMaPhong
       @maPhong nvarchar(10)
AS
BEGIN
     SELECT maPhong FROM dbo.Phong WHERE maPhong = @maPhong AND tinhTrang = N'Trống'
END
GO

--Kiểm tra tồn tại phòng
CREATE PROC sp_KiemTraMaPhongTonTai
       @maPhong nvarchar(10)
AS
BEGIN
     SELECT maPhong FROM dbo.Phong WHERE maPhong = @maPhong
END
GO

--Cập nhật tiền dịch vụ khi khách hàng đăng ký dịch vụ
CREATE TRIGGER tr_ThueDichVu ON dbo.PhieuDichVu FOR INSERT AS
BEGIN
     UPDATE dbo.PhieuThue
	 SET tienDV = tienDV + (SELECT giaTien FROM dbo.DichVu WHERE maDV = inserted.maDV)
	 FROM dbo.DichVu JOIN inserted ON dbo.DichVu.maDV = inserted.maDV
	 WHERE PhieuThue.soPThue = inserted.soPThue	 
END
GO

--Cập nhật tiền dịch vụ khi khách hàng hủy thuê dịch vụ
CREATE TRIGGER tr_HuyThueDichVu ON dbo.PhieuDichVu FOR DELETE AS
BEGIN
     UPDATE dbo.PhieuThue
	 SET tienDV = tienDV - (SELECT giaTien FROM dbo.DichVu WHERE maDV = deleted.maDV)
	 FROM dbo.DichVu JOIN deleted ON dbo.DichVu.maDV = deleted.maDV	
	 WHERE PhieuThue.soPThue = deleted.soPThue 
END
GO

--Trigger về đổi phòng cho khách
CREATE TRIGGER tr_DoiPhong ON dbo.DanhSachPhongThue FOR UPDATE AS
BEGIN
     UPDATE dbo.PhieuThue
	 SET tongtien = tongtien + (inserted.thoiHan*(SELECT giaThue FROM dbo.Phong WHERE maPhong = inserted.maPhong))
	                         - (deleted.thoiHan*(SELECT giaThue FROM dbo.Phong WHERE maPhong = deleted.maPhong))
	 FROM dbo.Phong JOIN deleted ON dbo.Phong.maPhong = deleted.maPhong
	                JOIN inserted ON  dbo.Phong.maPhong = inserted.maPhong
					WHERE PhieuThue.soPThue = inserted.soPThue
	 UPDATE dbo.Phong
	 SET tinhTrang = N'Trống'
	 FROM dbo.Phong JOIN inserted ON dbo.Phong.maPhong = inserted.maPhong
END
GO

--Thống kê doanh thu theo ngày
CREATE PROC sp_ThongKeNgay
       @ngaybatdau date,
	   @ngayketthuc date
AS
BEGIN
     SELECT soPThue, tenKH, ngayThue, ngayThanhToan, tongtien, tienDV FROM dbo.PhieuThue, dbo.KhachHang
	 WHERE  PhieuThue.maKH = KhachHang.maKH AND ngayThanhToan IS NOT NULL AND ngayThanhToan >= convert(DATETIME,@ngaybatdau, 126)  
	                                  AND ngayThanhToan <= convert(DATETIME,@ngayketthuc, 126)
	ORDER BY soPThue ASC
END
GO

--Số lượng khách hàng theo ngày
CREATE PROC sp_KhachHangNgay
       @ngaybatdau date,
	   @ngayketthuc date
AS
BEGIN
     SELECT KhachHang.maKH, tenKH, PhieuThue.soPThue, ngayThue FROM dbo.PhieuThue, dbo.KhachHang
	 WHERE  PhieuThue.maKH = KhachHang.maKH AND  ngayThue >= convert(DATETIME,@ngaybatdau, 126)  
	                                  AND ngayThue <= convert(DATETIME,@ngayketthuc, 126)
	ORDER BY soPThue ASC
END
GO

--Thống kê doanh thu theo quý và năm
CREATE PROC sp_ThongKeQuy
       @quy int,
	   @nam int
AS
BEGIN
     SELECT soPThue, tenKH, ngayThue, ngayThanhToan, tongtien, tienDV FROM dbo.PhieuThue, dbo.KhachHang
	 WHERE  PhieuThue.maKH = KhachHang.maKH AND DATEPART(qq, ngayThanhToan) = @quy AND DATEPART(yyyy, ngayThanhToan) = @nam
	ORDER BY soPThue ASC
END
GO

--Số lượng khách hàng theo quý và năm
CREATE PROC sp_KhachHangQuy
       @quy int,
	   @nam int
AS
BEGIN
     SELECT KhachHang.maKH, tenKH, PhieuThue.soPThue, ngayThue FROM dbo.PhieuThue, dbo.KhachHang
	 WHERE  PhieuThue.maKH = KhachHang.maKH AND DATEPART(qq, ngayThue) = @quy AND DATEPART(yyyy, ngayThue) = @nam
	ORDER BY soPThue ASC
END
GO

--Thêm đổi phòng
CREATE PROC sp_DoiPhong
       @soPThue int,
	   @maPhongCu nvarchar(10),
	   @maPhongMoi nvarchar(10),
	   @ngayChuyen date,
	   @ngayThue date,
	   @manv nvarchar(10)
AS
BEGIN
     INSERT INTO dbo.DoiPhong (soPThue,maPhongCu,maPhongMoi,ngayChuyen,maNV)
	 VALUES (@soPThue,@maPhongCu,@maPhongMoi,@ngayChuyen,@manv)
	 DECLARE @thoihan int
	 SET @thoihan = (SELECT thoiHan FROM dbo.DanhSachPhongThue WHERE soPThue = @soPThue AND maPhong = @maPhongCu)
	 INSERT INTO dbo.DanhSachPhongThue(maPhong,soPThue,thoiHan)
	 VALUES (@maPhongMoi,@soPThue,(@thoihan - DATEDIFF(dd,@ngayThue,@ngayChuyen)))
	 UPDATE dbo.DanhSachPhongThue
	 SET thoiHan =DATEDIFF(dd,@ngayThue,@ngayChuyen),
	 xacNhan = 1
	 WHERE soPThue = @soPThue AND maPhong = @maPhongCu
END
GO





--Lấy danh sách phòng trống
--SELECT * FROM dbo.Phong WHERE tinhTrang = N'Trống'
--SELECT soPThue,maPhong,thoiHan FROM dbo.DanhSachPhongThue WHERE soPThue = 1
--SELECT * FROM dbo.PhieuThue WHERE soPThue = 1

 --Thêm dữ liệu 
INSERT INTO dbo.NhanVien VALUES ('1111',N'Nguyễn Văn Tèo', GETDATE(),'Nam','100000','admin','admin',1)
INSERT INTO dbo.NhanVien VALUES ('5555',N'Nguyễn Văn Tý', GETDATE(),'Nữ','111111','admin1','admin',0)
INSERT INTO dbo.KhachHang(tenKH,ngaySinh,diaChi,cmnd,sdt,sex) VALUES (N'Trần Hữu Đã','1/2/1899',N'Hà Nội','111111','0123456789',N'Nam')
INSERT INTO dbo.KhachHang(tenKH,ngaySinh,diaChi,cmnd,sdt,sex) VALUES (N'Ngô Bá Khá','1/2/2020',N'Bắc Ninh','222222','0123456789',N'Nam')
INSERT INTO dbo.Phong(maPhong,loaiPhong,dkPhong,giaThue) VALUES ('A101',N'VIP',N'2 giường',2000)
INSERT INTO dbo.Phong(maPhong,loaiPhong,dkPhong,giaThue) VALUES ('A102',N'VIP',N'3 giường',3000)
INSERT INTO dbo.Phong(maPhong,loaiPhong,dkPhong,giaThue) VALUES ('A103',N'Thường',N'2 giường',1000)
INSERT INTO dbo.Phong(maPhong,loaiPhong,dkPhong,giaThue) VALUES ('A104',N'Thường',N'3 giường',2000)

INSERT INTO dbo.DichVu(tenDV,giaTien,moTa) VALUES (N'Dịch vụ Spa',1000,N'Chuyên nghiệp')
INSERT INTO dbo.DichVu(tenDV,giaTien,moTa) VALUES (N'Phòng gym',1000,N'Chuyên nghiệp')
INSERT INTO dbo.DichVu(tenDV,giaTien,moTa) VALUES (N'Dịch vụ giặt gủi quần áo',1500,N'Chuyên nghiệp')
INSERT INTO dbo.DichVu(tenDV,giaTien,moTa) VALUES (N'Dịch vụ trông trẻ',1500,N'Chuyên nghiệp')

INSERT INTO dbo.PhieuThue(maKH,maNV,ngayThue) VALUES (1,'1111','1/1/1999')
INSERT INTO dbo.PhieuThue(maKH,maNV,ngayThue) VALUES (1,'5555','2/2/2020')
INSERT INTO dbo.DanhSachPhongThue(maPhong,soPThue,thoiHan) VALUES('A101',1,2)
INSERT INTO dbo.PhieuDichVu(maDV,soPThue,maPhong,maNV,ngayThueDV) VALUES(1,1,'A101','5555','2/2/2020')

GO
 