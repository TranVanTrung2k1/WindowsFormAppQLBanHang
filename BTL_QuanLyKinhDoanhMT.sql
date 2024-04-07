CREATE DATABASE QuanLyKinhDoanhMayTinh
ON(
	NAME =BTLN09QuanLyKinhDoanhMayTinh,
	FILENAME = 'D:\THSQL\QuanLyKinhDanhMayTinh.mdf'
)

USE QuanLyKinhDoanhMayTinh;

--1. TẠO CÁC BẢNG--

-- tblLoaiHang
 CREATE TABLE tblLoaiHang
 (
	sMaLoaiHang VARCHAR(20) PRIMARY KEY,
	sTenLoaiHang NVARCHAR(30)
 )

 --tblNhaCungCap
 CREATE TABLE tblNhaCungCap
 (
	iMaNCC INT PRIMARY KEY,
	sTenNhaCC NVARCHAR(30),
	sTenGiaoDich NVARCHAR(50),
	sDiaChi NVARCHAR(50),
	sDienThoai CHAR(10)
 )

 --tblMatHang
 CREATE TABLE tblMatHang
 (
	sMaHang VARCHAR(20) PRIMARY KEY,
	sTenHang NVARCHAR(30),
	iMaNCC INT REFERENCES dbo.tblNhaCungCap(iMaNCC),
	sMaLoaiHang VARCHAR(20) REFERENCES dbo.tblLoaiHang(sMaLoaiHang),
	fSoLuong FLOAT,
	fGiaHang FLOAT,
 )

 --tblKhachHang
 CREATE TABLE tblKhachHang
 (
	iMaKH INT PRIMARY KEY,
	sTenKH NVARCHAR(30),
	sDiaChi NVARCHAR(50),
	sDienThoai CHAR(10)
 )

 --tblNhanVien
 CREATE TABLE tblNhanVien
 (
	iMaNV INT PRIMARY KEY,
	sTenNV NVARCHAR(30),
	sDiaChi NVARCHAR(50),
	sDienThoai CHAR(10),
	dNgaySinh DATETIME CHECK(DATEDIFF(YEAR,dNgaySinh,GETDATE()) >=18),
	sGioiTinh NVARCHAR(5),
	dNgayVaoLam DATETIME,
	fLuongCoBan FLOAT,
	fPhuCap FLOAT
 )
 Alter table tblNhanVien ADD Constraint CK__tblNhanVi__sGioi__2F10007B CHECK(sGioiTinh LIKE N'%Nam%' OR sGioiTinh LIKE N'%Nữ%')
 --tblDonDatHang
 CREATE TABLE tblDonDatHang
 (
	iSoHD INT PRIMARY KEY,
	iMaNV INT REFERENCES dbo.tblNhanVien(iMaNV),
	iMaKH INT REFERENCES dbo.tblKhachHang(iMaKH),
	dNgayDatHang DATETIME,
	dNgayGiaoHang DATETIME,
	fTongTienHD FLOAT CHECK (fTongTienHD >0),
	CONSTRAINT ck_ngaydathang CHECK(DATEDIFF(DAY,dNgayDatHang,dNgayGiaoHang)>=0)
 )

 --tblChiTietDatHang
 CREATE TABLE tblChiTietDatHang
 (
	iSoHD INT REFERENCES dbo.tblDonDatHang(iSoHD),
	sMaHang VARCHAR(20) REFERENCES dbo.tblMatHang(sMaHang),
	fGiaBan FLOAT,
	iSoLuongMua INT,
	fMucGiamGia FLOAT,
	CONSTRAINT pk_chitietdathang PRIMARY KEY (iSoHD,sMaHang)
 )

 --tblDonNhapKho
CREATE TABLE tblDonNhapKho
(
	iSoNK INT PRIMARY KEY,
	iMaNV INT REFERENCES dbo.tblNhanVien(iMaNV),
	dNgayNhapHang DATETIME,
	fTongSoLuong FLOAT CHECK(fTongSoLuong >0)
)

-- tblChiTietNhapKho
CREATE TABLE tblChiTietNhapKho
(
	iSoNK INT REFERENCES dbo.tblDonNhapKho(iSoNK),
	sMaHang VARCHAR(20) REFERENCES dbo.tblMatHang(sMaHang),
	fGiaNhap FLOAT,
	fSoLuongNhap FLOAT CHECK (fSoLuongNhap >0),
	CONSTRAINT pk_chitietnhapkho PRIMARY KEY(iSoNK,sMaHang)
)

--2. THEM DU LIEU--
-- tblLoaiHang
INSERT INTO dbo.tblLoaiHang VALUES
	('LH01', N'LapTop'),
	('LH02', N'PC'),
	('LH03', N'Phụ Kiện')

--tblNhaCungCap
INSERT INTO dbo.tblNhaCungCap VALUES
	(101, N'ASUS', N'Nhập Hàng Asus', N'Hà Nội', '0334455667'), 
	(102, N'DELL', N'Nhập Hàng Dell', N'Đà Nẵng', '0334455668'),
	(103, N'APPLE', N'Nhập Hàng Apple', N'Hải Phòng', '0334455669'),
	(104, N'LENOVO', N'Nhập Hàng Lenovo', N'TP. Hồ Chí Minh', '0334455670'	)

--tblKhachHang
INSERT INTO dbo.tblKhachHang VALUES
	(111, N'Trần Anh Vũ', N'Giáp Nhị, Hà Nội', '0112233445'),
	(112, N'Trần Thanh Tâm', N'Hoàng Mai, Hà Nội', '0112233446'),
	(113, N'Nguyễn Minh Tú', N'Minh Khai, Hà Nội', '0112233447'),
	(114, N'Đỗ Thu Phương', N'Giáp Bát, Hà Nội', '0112233448'),
	(115, N'Lê Văn Tráng', N'Định Công, Hà Nội', '0112233449')
	
-- tblNhanVien
INSERT INTO dbo.tblNhanVien VALUES
	(1010, N'Đỗ Thị Bích', N'Giáp Bát, Hà Nội', '0123456781',	'1997/01/01', N'Nữ', '2019/02/26', 7050000, 1000000),
	(1011, N'Nguyễn Công Chính',	N'Pháp Vân, Hà Nội', '0123456782', '1989/12/21', N'Nam', '2016/11/22',	12100000, 2000000),
	(1012, N'Vương Quang Huy', N'Giải Phóng, Hà Nội', '0123456783',	'1999/03/12', N'Nam', '2020/04/02',	5500000, 450000),
	(1013, N'Phạm Tiến Đạt', N'Cầu Giấy, Hà Nội', '0123456784',	'2000/07/15', N'Nam', '2020/07/03',	5000000, 250000)

--tblMatHang
INSERT INTO dbo.tblMatHang VALUES
	('MH01', N'ASUS VivoBook 15 A512DA', 101, 'LH01', 400, 12290000),
	('MH02', N'ASUS Laptop 15 X509UA', 101, 'LH01', 350, 10700000),
	('MH03', N'Laptop Dell XPS 13', 102, 'LH01', 100, 40400000),
	('MH04', N'Laptop Dell Gaming G3', 102, 'LH01', 200, 21000000),
	('MH05', N'Laptop Lenovo Thinkpad X13', 104, 'LH01', 150, 34500000),
	('MH06', N'Apple MacBook Pro', 103, 'LH01', 250, 35500000),
	('MH07', N'PC Dell Vostro', 102, 'LH02', 300, 7050000),
	('MH08', N'PC Lenovo V50t', 104, 'LH02', 200, 9190000),
	('MH09', N'PC Lenovo Ideacentre AIO', 104, 'LH02', 500, 12000000),
	('MH10', N'PC Asus Pro D340MC', 101, 'LH02', 650, 7000000),
	('MH11', N'PC Apple iMac 2019', 103, 'LH02', 250, 47800000),
	('MH12', N'Tai nghe AirPods 2', 103, 'LH03', 200, 3990000),
	('MH13', N'Apple Magic Mouse 2', 103, 'LH03', 200, 2490000),
	('MH14', N'CPU AMD Ryzen 9', 101, 'LH03', 150, 19299000),
	('MH15', N'Card đồ họa RTX3060TI', 101, 'LH03', 200, 13149000)

--tblDonNhapKho
INSERT INTO dbo.tblDonNhapKho VALUES
	(511, 1010, '2019/01/23', 2110),
	(512, 1011, '2017/11/12', 1800),
	(513, 1012, '2020/04/25', 1660),
	(514, 1013, '2020/07/07', 800)

--tblChiTietNhapKho
INSERT INTO dbo.tblChiTietNhapKho VALUES
	(511, 'MH01', 10790000, 450),
	(511, 'MH12', 2490000, 400),
	(511, 'MH03', 38900000, 250),
	(511, 'MH11', 46300000, 560),
	(511, 'MH05', 33000000, 450),
	(512, 'MH06', 34000000, 350),
	(512, 'MH07', 5550000, 600),
	(512, 'MH15', 11649000, 500),
	(512, 'MH09', 10500000, 350),
	(513, 'MH10', 5500000, 450),
	(513, 'MH04', 19500000, 400),
	(513, 'MH02', 9200000, 250),
	(513, 'MH13', 990000, 560),
	(514, 'MH14', 17799000, 450),
	(514, 'MH08', 7690000, 350)

--tblDonDatHang
INSERT INTO dbo.tblDonDatHang VALUES
	(510, 1010, 111, '2020/01/14', '2020/01/17', 59690000),
	(520, 1011, 112, '2020/03/15', '2020/03/18', 74900000),
	(530, 1012, 113, '2019/05/16', '2019/05/19', 47800000),
	(540, 1013, 114, '2020/06/17', '2020/06/20', 48688000),
	(550, 1011, 115, '2017/11/18', '2017/11/21', 35500000)

--tblChiTietDatHang
INSERT INTO dbo.tblChiTietDatHang VALUES
	(510, 'MH01', 12290000, 1, 0),
	(510, 'MH03', 40400000, 1, 0),
	(510, 'MH10', 7000000, 1, 0),
	(520, 'MH05', 34500000, 2, 0),
	(520, 'MH03', 40400000, 1, 0),
	(530, 'MH11', 47800000, 1, 0),
	(540, 'MH15', 13149000, 3, 0),
	(540, 'MH07', 7050000, 2, 0),
	(540, 'MH08', 9190000, 4, 0),
	(540, 'MH14', 19299000, 3, 0),
	(550, 'MH06', 35500000, 2, 0)

--3. XÂY DỰNG CÁC VIEW--
--3.1 Tạo‌ ‌view‌ ‌chứa‌ ‌danh‌ ‌sách‌ ‌nhân‌ ‌viên‌ ‌với‌ ‌các‌ ‌thông‌ ‌tin:‌ ‌Mã Nhân Viên,‌ ‌Tên Nhân Viên,‌ Lương Cơ Bản, Phụ Cấp--
CREATE VIEW vv_dsnhanvien
AS
SELECT iMaNV AS [Mã Nhân Viên],sTenNV AS [Họ & Tên], fLuongCoBan AS [Lương Cơ Bản], fPhuCap AS [Phụ Cấp]
FROM dbo.tblNhanVien

SELECT * FROM vv_dsnhanvien

--3.2 Tạo view cho biết danh sách tên hàng đã bán trong tháng 6 năm 2020--
CREATE VIEW vv_dshangban2020
AS
SELECT dbo.tblMatHang.sMaHang,sTenHang,dNgayDatHang,dNgayGiaoHang
FROM dbo.tblMatHang,dbo.tblDonDatHang,dbo.tblChiTietDatHang
WHERE dbo.tblMatHang.sMaHang = dbo.tblChiTietDatHang.sMaHang
AND dbo.tblDonDatHang.iSoHD = dbo.tblChiTietDatHang.iSoHD
AND YEAR(dbo.tblDonDatHang.dNgayDatHang) = 2020
AND MONTH(dbo.tblDonDatHang.dNgayDatHang) =06

SELECT * FROM vv_dshangban2020

--3.3 Tạo view cho biết mặt hàng có số lượng lớn hơn 200--
CREATE VIEW vv_dshangbansoluong200
AS
SELECT sMaHang,sTenHang,fSoLuong
FROM dbo.tblMatHang
WHERE fSoLuong > 200 
	
SELECT * FROM vv_dshangbansoluong200

--3.4 Tạo view chứa danh sách nhân viên nam--
CREATE VIEW vv_dsnhanviennam
AS
SELECT *
FROM dbo.tblNhanVien
WHERE sGioiTinh = N'Nam'

SELECT * FROM vv_dsnhanviennam

--3.5 Tạo view chứa danh sách mặt hàng với các thông tin: Mã Hàng, Tên Hàng, Số Lượng, Giá Hàng--
CREATE VIEW vv_dsmathang
AS
SELECT  sMaHang AS [Mã Hàng],sTenHang AS [Tên Hàng], fSoLuong AS [Số Lượng], fGiaHang AS [Giá Hàng]
FROM dbo.tblMatHang

SELECT * FROM vv_dsmathang

--3.6 Tạo view cho biết thông tin mặt hàng có mã hàng là MH11--
CREATE VIEW vv_dsmathangmahangmh11
AS
SELECT  *
FROM dbo.tblMatHang
WHERE sMaHang = 'MH11'

SELECT * FROM vv_dsmathangmahangmh11

--3.7 Tạo view cho biết thông tin sản phẩm đã mua của khách hàng có số hóa đơn là 510--
CREATE VIEW vv_dsthongtinsphd510
AS
SELECT dbo.tblDonDatHang.iSoHD,dbo.tblKhachHang.sTenKH,dbo.tblMatHang.sTenHang,dbo.tblChiTietDatHang.iSoLuongMua
FROM dbo.tblMatHang,dbo.tblDonDatHang,dbo.tblChiTietDatHang,dbo.tblKhachHang
WHERE dbo.tblDonDatHang.iSoHD = 510
AND dbo.tblDonDatHang.iSoHD = dbo.tblChiTietDatHang.iSoHD
AND dbo.tblDonDatHang.iMaKH = dbo.tblKhachHang.iMaKH
AND dbo.tblChiTietDatHang.sMaHang = dbo.tblMatHang.sMaHang

SELECT * FROM vv_dsthongtinsphd510

--3.8 Tạo view cho biết thông tin của nhân viên có tên là Đỗ Thị Bích--
CREATE VIEW vv_dsnhanviendothibich
AS
SELECT *
FROM dbo.tblNhanVien
WHERE sTenNV = N'Đỗ Thị Bích'

SELECT * FROM vv_dsnhanviendothibich

--3.9 Tạo view cho biết số mặt hàng của từng loại hàng--
CREATE VIEW vv_dssomathang
AS
SELECT tblLoaiHang.sMaLoaiHang,sTenLoaiHang, COUNT(dbo.tblMatHang.sMaLoaiHang) AS [Số lượng sản phẩm], SUM(fSoLuong) AS [Tổng số lượng]
FROM dbo.tblLoaiHang,dbo.tblMatHang
WHERE tblLoaiHang.sMaLoaiHang = dbo.tblMatHang.sMaLoaiHang
GROUP BY tblLoaiHang.sMaLoaiHang, sTenLoaiHang

SELECT * FROM vv_dssomathang

--3.10 Tạo view cho xem khách hàng mua hàng tổng tiền nhiều nhất--
CREATE VIEW vv_khachhangmuanhieunhat
AS
SELECT tblKhachHang.iMaKH,sTenKH
FROM dbo.tblKhachHang
WHERE iMaKH =(
	SELECT TOP 1 iMaKH
	FROM dbo.tblDonDatHang
	GROUP BY iMaKH
	ORDER BY SUM(fTongTienHD) DESC)

SELECT * FROM vv_khachhangmuanhieunhat

--3.11 Tạo view cho biết tổng số tiền hàng thu được trong mỗi tháng của năm 2020--
CREATE VIEW vv_tongtienhangthang2020
AS
SELECT tblDonDatHang.iSoHD,MONTH(dNgayGiaoHang) AS [Tháng],SUM(iSoLuongMua*fGiaBan - iSoLuongMua*fGiaBan*fMucGiamGia ) AS [Tổng tiền]
FROM dbo.tblChiTietDatHang,dbo.tblDonDatHang
WHERE dbo.tblDonDatHang.iSoHD = tblChiTietDatHang.iSoHD
AND YEAR(dNgayGiaoHang)=2020
GROUP BY tblDonDatHang.iSoHD,MONTH(dNgayGiaoHang)

SELECT * FROM vv_tongtienhangthang2020

--3.12 Tạo view thống kê tên các sản phẩm không bán được trong năm 2019--
CREATE VIEW vv_sanphamkhongbanduoc2019
AS
SELECT dbo.tblMatHang.sMaHang, dbo.tblMatHang.sTenHang
FROM dbo.tblMatHang, dbo.tblDonDatHang, dbo.tblChiTietDatHang
WHERE NOT YEAR(dNgayGiaoHang)=2019
	  AND dbo.tblDonDatHang.iSoHD= dbo.tblChiTietDatHang.iSoHD
      AND tblChiTietDatHang.sMaHang=tblMatHang.sMaHang
GROUP BY  dbo.tblMatHang.sMaHang, dbo.tblMatHang.sTenHang

SELECT * FROM vv_sanphamkhongbanduoc2019

--3.13 Tạo view cho biết tổng số mặt hàng của từng nhà cung cấp--
CREATE VIEW vv_tongmathangcuatungnhacungcap
AS
SELECT  dbo.tblNhaCungCap.iMaNCC, dbo.tblNhaCungCap.sTenNhaCC, COUNT(dbo.tblMatHang.fSoLuong) AS [Tổng Số Mặt Hàng]
FROM dbo.tblMatHang, dbo.tblNhaCungCap
WHERE dbo.tblMatHang.iMaNCC=dbo.tblNhaCungCap.iMaNCC
GROUP BY dbo.tblNhaCungCap.iMaNCC, dbo.tblNhaCungCap.sTenNhaCC

SELECT * FROM vv_tongmathangcuatungnhacungcap

--3.14 Tạo view cho biết tổng tiền hàng đã nhập trong mỗi tháng của năm 2020--
CREATE VIEW vv_tongtienhangdanhap2020
AS
SELECT tblDonNhapKho.iSoNK,MONTH(dNgayNhapHang) AS [Tháng],SUM(fSoLuongNhap*fGiaNhap) AS [Tổng tiền]
FROM dbo.tblChiTietNhapKho,dbo.tblDonNhapKho
WHERE dbo.tblDonNhapKho.iSoNK = dbo.tblChiTietNhapKho.iSoNK
AND YEAR(dNgayNhapHang)=2020
GROUP BY dbo.tblDonNhapKho.iSoNK,MONTH(dNgayNhapHang)

SELECT * FROM vv_tongtienhangdanhap2020

--3.15 Tạo view cho biết tổng số lượng nhập hàng trong năm 2019--
CREATE VIEW vv_tongSLnhaphang2019
AS
SELECT dbo.tblMatHang.sTenHang,SUM(dbo.tblChiTietNhapKho.fSoLuongNhap) 	AS [Tổng số lượng]
FROM dbo.tblDonNhapKho, dbo.tblChiTietNhapKho, dbo.tblMatHang
WHERE dbo.tblDonNhapKho.iSoNK=dbo.tblChiTietNhapKho.iSoNK
	AND dbo.tblChiTietNhapKho.sMaHang=dbo.tblMatHang.sMaHang
	AND YEAR(dNgayNhapHang)=2019
GROUP BY  dbo.tblMatHang.sTenHang

SELECT * FROM vv_tongSLnhaphang2019

--3.16 Tạo view tính lương của từng nhân viên--
CREATE VIEW vv_luongtungNV
AS
SELECT sTenNV, (fLuongCoBan+fPhuCap) AS [Tổng Lương]
FROM dbo.tblNhanVien

SELECT * FROM vv_luongtungNV

--3.17 Tạo view đưa ra top 5 sản phẩm doanh thu cao nhất--
CREATE VIEW vv_top5sanphamcaonhat
AS
SELECT *
FROM dbo.tblMatHang 
WHERE sMaHang IN ( SELECT TOP 5 dbo.tblMatHang.sMaHang
	FROM dbo.tblDonDatHang,dbo.tblChiTietDatHang,dbo.tblMatHang
	WHERE dbo.tblDonDatHang.iSoHD = dbo.tblChiTietDatHang.iSoHD 
	AND dbo.tblChiTietDatHang.sMaHang = tblMatHang.sMaHang
	GROUP BY tblMatHang.sMaHang
	ORDER BY SUM(iSoLuongMua*fGiaBan - iSoLuongMua*fGiaBan*fMucGiamGia) DESC)

SELECT * FROM vv_top5sanphamcaonhat

--3.18 Tạo view hóa đơn có tổng tiền cao nhất--
CREATE VIEW vv_hoadonMAX
AS
SELECT TOP 1 tblDonDatHang.iSoHD,SUM(iSoLuongMua*fGiaBan - iSoLuongMua*fGiaBan*fMucGiamGia) AS [Tổng tiền Max]
FROM dbo.tblDonDatHang,dbo.tblChiTietDatHang
WHERE dbo.tblDonDatHang.iSoHD = dbo.tblChiTietDatHang.iSoHD
GROUP BY tblDonDatHang.iSoHD
ORDER BY SUM(iSoLuongMua*fGiaBan-iSoLuongMua*fGiaBan*fMucGiamGia) DESC

SELECT * FROM vv_hoadonMAX

--3.19 Tạo view cho biết số lượng và tổng tiền đã bán của từng sản phẩm trong năm 2020--
CREATE VIEW vv_soluongvatongtiensp2020
AS
SELECT tblMatHang.sMaHang,SUM(iSoLuongMua) AS [Tổng số lượng],SUM(iSoLuongMua*fGiaBan - iSoLuongMua*fGiaBan*fMucGiamGia) AS [Tổng tiền Max]
FROM dbo.tblDonDatHang,dbo.tblChiTietDatHang,dbo.tblMatHang
WHERE dbo.tblDonDatHang.iSoHD = dbo.tblChiTietDatHang.iSoHD
AND tblMatHang.sMaHang = tblChiTietDatHang.sMaHang
GROUP BY tblMatHang.sMaHang

SELECT * FROM vv_soluongvatongtiensp2020

--3.20 Tạo view nhân viên làm việc trên 2 năm--
CREATE VIEW vv_nhanvienlamtren2nam
AS
SELECT *
FROM dbo.tblNhanVien
WHERE DATEDIFF(YEAR,dNgayVaoLam,GETDATE()) >=2

SELECT * FROM vv_nhanvienlamtren2nam

--4. XÂY DỰNG PROCEDURE CHO CSDL

--4.1 Tìm nhân viên theo tên nhân viên--
CREATE PROC sptimnhanvien_tennhanvien (@tennhanvien nvarchar(30))
	AS
          BEGIN
		SELECT *
		FROM dbo.tblNhanVien
		WHERE sTenNV = @tennhanvien
         END
	EXEC sptimnhanvien_tennhanvien N'Vương Quang Huy'

--4.2 Tổng tiền hàng bán ra trong một tháng trong 1 năm--
CREATE PROC sptongtienhangban_thang (@thang int, @nam int)
	AS
          BEGIN
		SELECT @thang AS[Thang], SUM (fGiaBan*iSoLuongMua - fGiaBan*iSoLuongMua*fMucGiamGia) AS [Tong tien]
		FROM dbo.tblDonDatHang,dbo.tblChiTietDatHang
		WHERE tblDonDatHang.iSoHD = tblDonDatHang.iSoHD
			AND MONTH(dNgayGiaoHang) = @thang
			AND YEAR(dNgayGiaoHang) = @nam
		GROUP BY MONTH(dNgayGiaoHang),YEAR(dNgayGiaoHang)
          END
	EXEC sptongtienhangban_thang 3,2020

--4.3 Tiền lương của nhân viên bất kì (theo mã NV)--
CREATE PROC spluongnhanvien_maNV (@maNV nvarchar(20))
	AS
          BEGIN
		SELECT iMaNV,(fLuongCoBan+fPhuCap) as [Lương]
		FROM dbo.tblNhanVien
		WHERE imanv = @maNV
         END
	EXEC spluongnhanvien_maNV @maNV=N'1010'

--4.4 Mặt hàng không bán được trong năm--
CREATE PROC dskhongduocban2020 (@nam INT)
	AS
	BEGIN
		SELECT tblmathang.smahang, tblmathang.stenhang
		FROM tblmathang where tblmathang.smahang
		NOT IN (SELECT tblmathang.smahang 
		FROM tbldondathang,tblchitietdathang,tblmathang
		WHERE tbldondathang.isohd=tblchitietdathang.isohd 
		AND tblchitietdathang.smahang=tblmathang.smahang 
		AND YEAR(dngaydathang)=@nam )
	END
EXEC dskhongduocban2020 @nam='2020'

--4.5 Tạo thủ tục bổ sung thêm 1 bản ghi mới cho tblChiTietDatHang--
CREATE PROC spthemHD (@mahd nvarchar(10),@mahang nvarchar(10), @giaban float, @SLmua int, @mucgiamgia float)
	AS
	BEGIN
		INSERT INTO tblChiTietDatHang
		VALUES (@mahd, @mahang, @giaban, @SLmua, @mucgiamgia)
	END
	EXEC spthemHD '550', 'MH02', '10700000', '1', '0'
	SELECT*FROM tblChiTietDatHang

--4.6 Tăng lương cơ bản cho nhân viên (x %)  có lượng bán ra lớn hơn chỉ tiêu của một năm--
CREATE PROC sptangluongcoban_nhanvien (@chitieu int, @nam int, @phantram float)
	AS 
		BEGIN 
		UPDATE dbo.tblNhanVien
		SET fLuongCoBan = fLuongCoBan + fLuongCoBan * @phantram
		WHERE iMaNV IN ( SELECT dbo.tblNhanVien.iMaNV
						 FROM dbo.tblNhanVien, dbo.tblDonDatHang, dbo.tblChiTietDatHang
						 WHERE tblDonDatHang.iMaNV = tblNhanVien.iMaNV
			                   AND tblDonDatHang.iSoHD = tblChiTietDatHang.iSoHD
			                   AND YEAR(dNgayDatHang) = @nam 
						GROUP BY tblNhanVien.iMaNV
						HAVING SUM (iSoLuongMua) > @chitieu )	
		END

		EXEC sptangluongcoban_nhanvien 11,2020,0.1

--4.7 Doanh số bán ra của một mặt hàng trong năm--
CREATE PROC spdoanhso1mathang1nam (@mahang nvarchar(10), @nam int)
	AS
	BEGIN	
		SELECT tblChiTietDatHang.sMaHang as[Mã Hàng],
			(iSoLuongMua*fGiaBan - iSoLuongMua*fGiaBan*fMucGiamGia) as[Tổng số tiền]
		FROM tblMatHang,tblChiTietDatHang,tblDonDatHang
		WHERE tblMatHang.sMaHang=tblChiTietDatHang.sMaHang
			AND tblChiTietDatHang.iSoHD=tblDonDatHang.iSoHD
			AND tblChiTietDatHang.sMaHang= @mahang
			AND YEAR(tblDonDatHang.dNgayDatHang)= @nam
		
	END 
EXEC spdoanhso1mathang1nam @mahang='MH11', @nam='2019'

--4.8 Tổng số tiền hàng thu được của một năm--
CREATE PROC sptienhang1nam (@nam int)
	AS
	BEGIN	
		SELECT SUM(tblChiTietDatHang.iSoLuongMua*tblChiTietDatHang.fGiaBan -
			tblChiTietDatHang.iSoLuongMua*tblChiTietDatHang.fGiaBan*tblChiTietDatHang.fMucGiamGia) as[Tổng số tiền]
		FROM tblMatHang,tblChiTietDatHang,tblDonDatHang
		WHERE tblMatHang.sMaHang=tblChiTietDatHang.sMaHang
			AND tblChiTietDatHang.iSoHD=tblDonDatHang.iSoHD
			AND YEAR(tblDonDatHang.dNgayDatHang)=@nam
		GROUP BY tblMatHang.sTenHang
	END 
	EXEC sptienhang1nam @nam='2019'

--4.9 Tổng tiền hàng nhập vào của một năm--
CREATE PROC sp_tongtiennhaphang1nam (@Nam int)
AS
BEGIN	
	SELECT @Nam as [Nam], 
		SUM(tblChiTietNhapKho.fSoLuongNhap*tblChiTietNhapKho.fGiaNhap) as[Tổng số tiền]
	FROM tblMatHang,tblChiTietNhapKho,tblDonNhapKho
	WHERE
		tblMatHang.sMaHang=tblChiTietNhapKho.sMaHang
	AND tblChiTietNhapKho.iSoNK=tblDonNhapKho.iSoNK
	AND YEAR(tblDonNhapKho.dNgayNhapHang)=@Nam
END 
EXEC sp_tongtiennhaphang1nam  @Nam='2019'

--4.10 Giỏ hàng của khách hàng (sản phẩm đã mua + đã giao)--
CREATE PROC spgiohang_khachhang (@makh int)
	AS
    BEGIN 
		SELECT tblKhachHang.iMaKH,tblDonDatHang.iSoHD,SUM(iSoLuongMua) AS [Tong so luong]
		FROM dbo.tblDonDatHang,dbo.tblChiTietDatHang,dbo.tblKhachHang
		WHERE tblDonDatHang.iSoHD = tblChiTietDatHang.iSoHD
			AND tblDonDatHang.iMaKH = tblKhachHang.iMaKH
			AND tblKhachHang.iMaKH = @makh
		GROUP BY tblKhachHang.iMaKH,tblDonDatHang.iSoHD
	END 

	EXEC spgiohang_khachhang 114

--4.11 Thống kê hàng nhập từ một nhà cung cấp trong một năm--
CREATE PROC spthongkesanpham_nhacungcap (@mancc int,@year int)
	AS
    BEGIN
		SELECT tblNhaCungCap.iMaNCC,@year AS [Nam],sTenHang,SUM(fSoLuongNhap) AS [So luong]
		FROM dbo.tblNhaCungCap,dbo.tblChiTietNhapKho,dbo.tblDonNhapKho,dbo.tblMatHang
		WHERE dbo.tblDonNhapKho.iSoNK = tblChiTietNhapKho.iSoNK
			AND dbo.tblChiTietNhapKho.sMaHang = dbo.tblMatHang.sMaHang
			AND tblNhaCungCap.iMaNCC = tblMatHang.iMaNCC
			AND tblNhaCungCap.iMaNCC = @mancc
			AND YEAR(dbo.tblDonNhapKho.dNgayNhapHang) = @year
		GROUP BY tblNhaCungCap.iMaNCC,sTenHang
	END 

	EXEC spthongkesanpham_nhacungcap 101,2020

--4.12 Truy xuất nguồn gốc của một mặt hàng--
CREATE PROC spchitiet_mathang (@mamathang nvarchar(20))
	AS
    BEGIN
		SELECT sMaHang,sTenHang,tblLoaiHang.sTenLoaiHang,sTenNhaCC,sDiaChi
		FROM dbo.tblNhaCungCap,dbo.tblMatHang,dbo.tblLoaiHang
		WHERE sMaHang = @mamathang
			AND tblMatHang.iMaNCC = tblNhaCungCap.iMaNCC
			AND tblMatHang.sMaLoaiHang = tblLoaiHang.sMaLoaiHang
	END 

	EXEC spchitiet_mathang N'MH06'

--4.13 Giảm giá với đơn đặt hàng chưa áp dụng giảm giá và được đặt hàng trong ngày hôm nay ( mức giảm giá x%)--
CREATE PROC spmucgiamgia_dondathang (@sohd int, @ngaydat datetime, @mucgiamgia float )
	AS
    BEGIN
		UPDATE dbo.tblChiTietDatHang
		SET fMucGiamGia = fMucGiamGia+ @mucgiamgia
		WHERE iSoHD IN ( SELECT tblDonDatHang.iSoHD
						 FROM dbo.tblDonDatHang,dbo.tblChiTietDatHang,dbo.tblMatHang
						 WHERE tblDonDatHang.iSoHD = tblChiTietDatHang.iSoHD
								AND tblChiTietDatHang.sMaHang = dbo.tblMatHang.sMaHang
								AND tblDonDatHang.iSoHD = @sohd
								AND dNgayDatHang = @ngaydat
								AND fMucGiamGia = 0
						)
	END 

	EXEC spmucgiamgia_dondathang 510,'2020/01/14',0.1

--4.14 Số tiền mà nhân viên sử dụng để nhập kho và số hóa đơn đã xử lí--
CREATE PROC spthongkenhapkho_nhanvien ( @manv int )
	AS
    BEGIN
		SELECT tblNhanVien.iMaNV,sTenNV,COUNT(tblDonNhapKho.iSoNK) AS [So Hoa Don NK],SUM(fSoLuongNhap*fGiaNhap) AS [Tong tien]
		FROM dbo.tblNhanVien,dbo.tblDonNhapKho,dbo.tblChiTietNhapKho
		WHERE dbo.tblNhanVien.iMaNV = dbo.tblDonNhapKho.iMaNV
			AND tblDonNhapKho.iSoNK = tblChiTietNhapKho.iSoNK
			AND tblNhanVien.iMaNV = @manv
		GROUP BY tblNhanVien.iMaNV,sTenNV
	END 

	EXEC spthongkenhapkho_nhanvien 1012

--4.15 Số tiền mà nhân viên bán được và số hóa đơn đã xử lý--
CREATE PROC spthongkebanhang_nhanvien ( @manv int )
	AS
    BEGIN
		SELECT tblNhanVien.iMaNV,sTenNV,COUNT(tblDonDatHang.iSoHD) AS [So Hoa Don],
		SUM(iSoLuongMua*fGiaBan-iSoLuongMua*fGiaBan*fMucGiamGia) AS [Tong tien]
		FROM dbo.tblNhanVien,dbo.tblDonDatHang,dbo.tblChiTietDatHang
		WHERE dbo.tblNhanVien.iMaNV = dbo.tblDonDatHang.iMaNV
			AND tblDonDatHang.iSoHD = tblChiTietDatHang.iSoHD
			AND tblNhanVien.iMaNV = @manv
		GROUP BY tblNhanVien.iMaNV,tblNhanVien.sTenNV
	END 

	EXEC spthongkebanhang_nhanvien 1011

--5. XÂY DỰNG CÁC TRIGGER CHO CSDL

--5.1 Giá bán phải lớn hơn hoặc bằng giá hàng--
CREATE TRIGGER tg_kiemTraGiaBan
ON dbo.tblChiTietDatHang
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @giaBan FLOAT, @giaHang FLOAT, @maHang VARCHAR(20)

		SELECT @giaBan = fGiaBan, @maHang = sMaHang FROM Inserted
		SELECT @giaHang = fGiaHang FROM dbo.tblMatHang WHERE @maHang = sMaHang

		IF(@giaBan < @giaHang)
		BEGIN
		    PRINT N'Giá bán phải lớn hơn hoặc bằng giá hàng'
				ROLLBACK TRAN
		END
END

--5.2 Kiểm tra giới tính xem đúng không--
CREATE TRIGGER tg_kiemtragioitinh
	ON dbo.tblNhanVien
	AFTER INSERT, UPDATE 
	AS 
		BEGIN 
			DECLARE @gioitinh NVARCHAR(5)
			SELECT @gioitinh = sGioiTinh FROM inserted
			IF(@gioitinh != N'Nam' AND @gioitinh != N'Nữ')
				BEGIN
					RAISERROR('Giới Tính Không Hợp Lệ!',16,10)
					ROLLBACK TRAN
				END
		END

--5.3 Kiểm tra ngày nhập hàng đúng không--
CREATE TRIGGER tg_kiemTraNgayNhapHang
ON tblDonNhapKho
AFTER INSERT, UPDATE 
AS 
BEGIN
    DECLARE @ngayNhapHang DATETIME
		SELECT @ngayNhapHang = dNgayNhapHang FROM Inserted

		IF(@ngayNhapHang > GETDATE())
		BEGIN
		    PRINT N'Ngày nhập hàng không đc lớn hơn ngày hiện tại'
				ROLLBACK TRAN
		END
END

--5.4 Kiểm tra ngày vào làm xem hợp lý không--
CREATE TRIGGER tg_kiemTraNgayVaoLam
ON tblNhanVien
AFTER INSERT, UPDATE 
AS 
BEGIN
    DECLARE @ngayVaoLam DATETIME
		SELECT @ngayVaoLam = dNgayVaoLam FROM Inserted

		IF(@ngayVaoLam > GETDATE())
		BEGIN
		    PRINT N'Ngày vào làm không đc lớn hơn ngày hiện tại'
				ROLLBACK TRAN
		END
END

--5.5 Đảm bảo số lượng hàng bán không vượt số hiện có và nếu bán thì số lượng hàng trong kho sẽ giảm--
CREATE TRIGGER tg_kiemtrahangban
	ON dbo.tblChiTietDatHang
	INSTEAD OF INSERT,UPDATE 
	AS 
		BEGIN 
			DECLARE @soluongmua FLOAT 
			DECLARE @smahang VARCHAR(20)
			DECLARE @soluongkho FLOAT
			SELECT @soluongmua = iSoLuongMua,@smahang = sMaHang FROM inserted
			SELECT @soluongkho = (SELECT fSoLuong
							   FROM dbo.tblMatHang
							   WHERE @smahang = sMaHang
								 )
			IF(@soluongmua > @soluongkho)
				BEGIN
					PRINT('So Luong Mua Vuot Qua So Luong Trong Kho')
					ROLLBACK TRAN
				END
			ELSE
				BEGIN
					UPDATE dbo.tblMatHang
					SET fSoLuong = fSoLuong-@soluongmua
					WHERE sMaHang = @smahang
				END
			END

--5.6 Cập nhật lại số lượng hàng tồn kho khi khách hàng hủy đặt một mặt hàng--
CREATE TRIGGER tg_xoachitietdathang
	ON dbo.tblChiTietDatHang
	AFTER DELETE
	AS 
		BEGIN 
			DECLARE @soluongmua FLOAT 
			DECLARE @smahang VARCHAR(20)
			DECLARE @soluongkho FLOAT
			SELECT @soluongmua = iSoLuongMua,@smahang = sMaHang FROM Deleted
			SELECT @soluongkho = (SELECT fSoLuong
									FROM dbo.tblMatHang
									WHERE @smahang = sMaHang
								 )
				BEGIN
					UPDATE dbo.tblMatHang
					SET fSoLuong = fSoLuong+@soluongmua
					WHERE sMaHang = @smahang
				END
			END

--5.7 Cập nhật số lượng hàng tồn kho khi nhập thêm mặt hàng--
CREATE TRIGGER tg_themChiTietDatHang
ON dbo.tblChiTietDatHang
AFTER INSERT 
AS 
BEGIN 
	DECLARE @soLuongMua FLOAT, @maHang VARCHAR(20), @soLuongKho FLOAT
	SELECT @soLuongMua = iSoLuongMua, @maHang = sMaHang FROM Inserted
	SELECT @soLuongKho = fSoLuong FROM dbo.tblMatHang WHERE @maHang = sMaHang
							
	BEGIN
		UPDATE dbo.tblMatHang
		SET fSoLuong = fSoLuong - @soLuongMua
		WHERE sMaHang = @maHang
	END
END

--5.8 Cập nhật tổng tiền của hóa đơn khi đặt thêm hàng--
CREATE TRIGGER tg_tongTienHoaDon_insert
ON tblChiTietDatHang
AFTER INSERT 
AS 
BEGIN
    DECLARE @soHD INT, @giaMuaHang FLOAT
		SELECT 
			@giaMuaHang = (fGiaBan * iSoLuongMua * (1 - fMucGiamGia)), 
			@soHD = iSoHD FROM Inserted

		BEGIN
		    UPDATE dbo.tblDonDatHang
				SET fTongTienHD = fTongTienHD + @giaMuaHang
				WHERE @soHD = iSoHD
		END
END

--5.9 Cập nhật tổng tiền của hóa đơn khi khách hàng hủy đặt mặt hàng--
CREATE TRIGGER tg_tongtienhoadon_delete
	ON dbo.tblChiTietDatHang
	AFTER DELETE
	AS
		BEGIN
			DECLARE @iSohd INT
			DECLARE @giahangmua FLOAT
			SELECT @giahangmua = (fGiaBan * iSoLuongMua - fGiaBan * iSoLuongMua*fMucGiamGia),@iSohd = iSoHD FROM Deleted
			BEGIN
				UPDATE dbo.tblDonDatHang
				SET fTongTienHD = fTongTienHD-@giahangmua
				WHERE iSoHD = @iSohd
			END 
		END

--5.10 Cập nhật số lượng hàng nhập của một hóa đơn nhập kho khi nhập mới--
CREATE TRIGGER tg_capnhatdonnhapkho_soluong
		ON dbo.tblChiTietNhapKho
		INSTEAD OF INSERT
		AS
			BEGIN
				DECLARE @slnhap FLOAT, @sonk INT 
				SELECT @slnhap = fSoLuongNhap,@sonk = iSoNK FROM Inserted
				BEGIN
					UPDATE dbo.tblDonNhapKho
					SET fTongSoLuong = fTongSoLuong + @slnhap
					WHERE @sonk = iSoNK
				END
			END

--6. PHÂN QUYỀN VÀ BẢO MẬT 

--6.1 Tài khoản quản lý
CREATE LOGIN Quanli WITH PASSWORD = '123456'
	CREATE USER quanli01 FOR LOGIN Quanli

	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblNhanVien TO quanli01
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblMatHang TO quanli01
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblNhaCungCap TO quanli01
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblKhachHang TO quanli01

	GRANT EXECUTE ON dbo.sptimnhanvien_tennhanvien TO quanli01
	GRANT EXECUTE ON dbo.spluongnhanvien_maNV TO quanli01
	GRANT EXECUTE ON dbo.sptangluongcoban_nhanvien TO quanli01
	GRANT EXECUTE ON dbo.spthongkesanpham_nhacungcap TO quanli01
	GRANT EXECUTE ON dbo.spgiohang_khachhang TO quanli01
	GRANT EXECUTE ON dbo.sp_tongtiennhaphang1nam TO quanli01
	GRANT EXECUTE ON dbo.sptienhang1nam TO quanli01
	GRANT EXECUTE ON dbo.spdoanhso1mathang1nam TO quanli01
	GRANT EXECUTE ON dbo.dskhongduocban2020 TO quanli01
	GRANT EXECUTE ON dbo.sptongtienhangban_thang TO quanli01

--6.2 Tài khoản nhân viên nhập kho
CREATE LOGIN NhanvienNK WITH PASSWORD = '123456'
	CREATE USER nhanvienNK FOR LOGIN NhanvienNK

	DENY UPDATE,SELECT,INSERT,DELETE ON dbo.tblNhanVien TO nhanvienNK
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblMatHang TO nhanvienNK
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblDonNhapKho TO nhanvienNK
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblChiTietNhapKho TO nhanvienNK

	GRANT EXECUTE ON dbo.spthemHD TO nhanvienNK
	GRANT EXECUTE ON dbo.spthongkenhapkho_nhanvien TO nhanvienNK

--6.3 Tài khoản nhân viên bán hàng 
CREATE LOGIN NhanvienBH WITH PASSWORD = '123456'
	CREATE USER nhanvienBH FOR LOGIN NhanvienBH

	DENY UPDATE,SELECT,INSERT,DELETE ON dbo.tblNhanVien TO nhanvienBH
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblMatHang TO nhanvienBH
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblDonDatHang TO nhanvienBH
	GRANT UPDATE,SELECT,INSERT,DELETE ON dbo.tblChiTietDatHang TO nhanvienBH

	GRANT EXECUTE ON dbo.spmucgiamgia_dondathang TO nhanvienBH
	GRANT EXECUTE ON dbo.spthongkebanhang_nhanvien TO nhanvienBH
	GRANT EXECUTE ON dbo.sptongtienhangban_thang TO nhanvienBH

--6.4 Tài khoản khách hàng
CREATE LOGIN KhachHang WITH PASSWORD = '123456'
	CREATE USER khachhang FOR LOGIN KhachHang
	GRANT UPDATE,SELECT,INSERT ON dbo.tblKhachHang TO khachhang
	GRANT EXECUTE ON dbo.spgiohang_khachhang TO khachhang



	---------
---create table Thi
--(
--Mon nvarchar(30),
--MaSV nvarchar(10),
--NgThi datetime, 
--Kqua float,
--constraint PK_Thi primary key(Mon, MaSV, NgThi)
--)

--insert into Thi
--values
--(N'Hệ quản trị CSDL','19A193','16-12-2022', 7),
--(N'Lập trình Web','19A192','15-12-2022', 9),
--(N'Triết học Mác- Lê-nin','19A193','16-12-2022', 6),
--(N'Giải tích','20A193','20-5-2022', 5),
--(N'Tiếng anh chuyên ngành','22A192','8-11-2022', 4),
--(N'Nguyên lý hệ điều hành','18A195','18-7-2022', 7),
--(N'Cấu trúc dữ liệu và giải thuật','19A191','5-8-2022', 10);
--select *from Thi
-------------
create trigger tg_soSvThi
On Thi
INSTEAD OF INSERT 
AS
BEGIN
	declare @mon nvarchar(30)
	declare @masv nvarchar(10)
	declare @ngthi datetime
	select @mon = Mon, @masv = MaSV,@ngthi = NgThi from inserted 
		if(


create proc HienThi(@month int, @year int)
as
begin
	select count(MaSV) as [Số lượng sinh viên], Mon as [Môn], @month as [Tháng], @year as [Năm]
	from Thi
	where @month = month(NgThi) and @year = year(NgThi)
	group by Mon
end
exec HienThi 12,2022

select* from tblNhaCungCap
select* from tblMatHang
select* from tblNhanVien
select* from tblKhachHang
select* from tblLoaiHang
select* from tblDonDatHang
select* from tblDonNhapKho
select* from tblChiTietDatHang
select* from tblChiTietNhapKho


-------------------------C#############--------------
alter proc Check_MaLoaiHang 
@maloaihang nvarchar(30)
AS
Select sMaLoaiHang From tblLoaiHang 
Where sMaLoaiHang = @maloaihang;

Exec Check_MaLoaiHang ''


Create proc Insert_tblLoaiHang
@maLoaiHang varchar(30), 
@tenLoaiHang nvarchar(50)
as
Insert into tblLoaiHang(sMaLoaiHang, sTenLoaiHang)
values(@maLoaiHang, @tenLoaiHang);

Exec Insert_tblLoaiHang '', '';

Create proc Update_tblLoaiHang
@maLoaiHang varchar(30), 
@tenLoaiHang nvarchar(50)
as
Update tblLoaiHang 
Set sTenLoaiHang = @tenLoaiHang
Where sMaLoaiHang = @maLoaiHang

Create proc Delete_tblLoaiHang
@maLoaiHang varchar(30)
as
Delete From tblLoaiHang Where sMaLoaiHang = @maLoaiHang

Create proc Select_tblLoaiHang
As
Select sMaLoaiHang, sTenLoaiHang
From tblLoaiHang

--------------------


Create proc Check_iSoNK_tblNhapKho
@maNhap varchar(30)
as
Select iSoNK FROM tblDonNhapKho
WHERE iSoNK = @maNhap

Create proc Select_tblDonNhapKho
as
Select iSoNK, iMaNV, dNgayNhapHang, fTongSoLuong FRom tblDonNhapKho

Create proc INSERT_tblDonNhapKho
@soNK int,
@maNV int,
@ngaynhap datetime,
@soluong float
as
Insert into tblDonNhapKho(iSoNK,iMaNV,dNgayNhapHang,fTongSoLuong)
values(@soNK, @maNV, @ngaynhap, @soluong);

Create proc Update_tblDonNhapKho 
@soNK int,
@maNV int,
@ngaynhap datetime,
@soluong float
as
Update tblDonNhapKho
Set iMaNV = @maNV, dNgayNhapHang = @ngaynhap, fTongSoLuong = @soluong
where iSoNK = @soNK;

Create proc Kiemtrarangbuoc_SoNK
@soNK int
as
Select iSoNK From tblChiTietNhapKho
Where iSoNK = @soNK;

Create Proc Delete_tblDonNhapKho
@soNK int
as
Delete From tblDonNhapKho WHere iSoNK = @soNK

create proc HoaDonBanHang
as
Select sTenKH, tblKhachHang.sDiaChi, tblKhachHang.sDienThoai, sTenNV, fGiaBan, iSoLuongMua, tblDonDatHang.iSoHD, fTongTienHD, sTenHang, dNgayGiaoHang, fMucGiamGia
From tblDonDatHang, tblNhanVien, tblKhachHang, tblMatHang, tblChiTietDatHang
WHERE tblDonDatHang.iSoHD = tblChiTietDatHang.iSoHD
and tblChiTietDatHang.sMaHang = tblMatHang.sMaHang
and tblDonDatHang.iMaKH = tblKhachHang.iMaKH
and tblDonDatHang.iMaNV = tblNhanVien.iMaNV


Create Proc Check_MaHang
@mahang nvarchar(30)
AS
Select sMaHang From tblMatHang 
Where sMaHang = @mahang;

Create Proc Check_MaNCC
@maNCC int
AS
Select iMaNCC From  tblNhaCungCap
Where iMaNCC = @maNCC;


Create proc Select_tblMatHang
As
Select sMaHang, sTenHang, fGiaHang, iMaNCC, fSoLuong, sMaLoaiHang
From tblMatHang

Create proc Insert_tblMatHang
@maHang varchar(30), 
@tenHang nvarchar(50),
@maNCC int,
@maLoaiHang varchar(30),
@giaHang float,
@soLuong float
as
Insert into tblMatHang(sMaHang, sTenHang, iMaNCC, sMaLoaiHang, fGiaHang, fSoLuong)
values(@maHang, @tenHang, @maNCC, @maLoaiHang, @giaHang, @soLuong);

Create proc Select_tblNhaCungCap
as
Select iMaNCC, sTenNhaCC, sTenGiaoDich, sDiaChi, sDienThoai
From tblNhaCungCap


Create proc Select_sTenLoaiHang
@maloaihang varchar(30)
as
Select sTenLoaiHang 
From tblLoaiHang
Where sMaLoaiHang = @maloaihang;

create proc CheckRangBuocLoaiHang
@maloaihang varchar(30)
as
Select sMaLoaiHang from tblMatHang
Where sMaLoaiHang = @maloaihang;

Create proc CheckRangBuocMatHang_Nhap
@mahang varchar(30)
as
Select sMaHang from tblChiTietNhapKho
where sMaHang = @mahang;

Create proc CheckRangBuocMatHang_Xuat
@mahang varchar(30)
as
Select sMaHang from tblChiTietDatHang
where sMaHang = @mahang;

Create proc Delete_tblMatHang
@mahang varchar(30)
as
Delete From tblMatHang Where sMaHang = @mahang;

Create proc Update_tblMatHang
@maHang varchar(30),
@tenHang varchar(50),
@maNCC int,
@maLoaiHang varchar(30),
@giaHang float,
@soLuong float
as
Update tblMatHang 
Set sTenHang = @tenHang, iMaNCC = @maNCC, sMaLoaiHang = @maLoaiHang, fGiaHang = @giaHang, fSoLuong = @soLuong
Where sMaHang = @maHang;


Create proc Check_MaNCC_tblNhaCungCap 
@maNCC int 
as
Select iMaNCC from tblNhaCungCap
Where iMaNCC = @maNCC;

create proc Insert_tblNhaCungCap
@maNCC int,
@tenNCC varchar(50),
@tenGiaoDich varchar(50),
@diaChi varchar(50),
@sdt varchar(50)
as
Insert into tblNhaCungCap(iMaNCC, sTenNhaCC, sTenGiaoDich, sDiaChi, sDienThoai)
values(@maNCC, @tenNCC, @tenGiaoDich, @diaChi, @sdt);

Create proc CheckRangBuocNCC
@maNCC int
as 
Select iMaNCC From tblMatHang
Where iMaNCC = @maNCC;

create proc Update_tblNhaCungCap
@maNCC int,
@tenNCC varchar(50),
@tenGiaoDich varchar(50),
@diaChi varchar(50),
@sdt varchar(50)
as
Update tblNhaCungCap
Set sTenNhaCC = @tenNCC, sTenGiaoDich = @tenGiaoDich, sDiaChi = @diaChi, sDienThoai = @sdt
Where iMaNCC = @maNCC;

Create proc Delete_tblNhaCungCap
@maNCC int 
As
Delete From tblNhaCungCap where iMaNCC = @maNCC;

Create proc Select_tblKhachHang
as
Select iMaKH, sTenKH, sDiaChi, sDienThoai From tblKhachHang;

Create proc Insert_tblKhachHang
@maKH int,
@tenKH nvarchar(50),
@diaChi nvarchar(50),
@sdt nvarchar(50)
as
Insert into tblKhachHang(iMaKH, sTenKH, sDiaChi, sDienThoai)
values(@maKH, @tenKH, @diaChi, @sdt);

Create proc Update_tblKhachHang
@maKH int,
@tenKH nvarchar(50),
@diaChi nvarchar(50),
@sdt nvarchar(50)
as 
Update tblKhachHang 
Set sTenKH = @tenKH, sDiaChi = @diaChi, sDienThoai = @sdt
Where iMaKH = @maKH;

Create proc Check_MaKH_tblKhachHang
@maKH int
as
Select iMaKH from tblKhachHang
Where iMaKH = @maKH;

Create proc CheckRangBuocKhachHang
@maKH int
as
Select iMaKH from tblDonDatHang
Where iMaKH = @maKH;

Create proc Delete_tblKhachHang
@maKH int
as
Delete From tblKhachHang Where iMaKH = @maKH;

-----Check Khoá chính
-----Thêm mới
-----Update
-----Select
-----CheckRangBuocKhoaNgoai
-----Delete

create proc Check_MaNV_tblNhanVien
@maNV int 
as
Select iMaNV from tblNhanVien 
Where iMaNV = @maNV;

Create proc Select_tblNhanVien
as
Select iMaNV, sTenNV, sDiaChi, sDienThoai, dNgaySinh, sGioiTinh, dNgayVaoLam , fLuongCoBan, fPhuCap From tblNhanVien

Create proc Insert_tblNhanVien
@maNV int, 
@tenNV varchar(30),
@diaChi varchar(50),
@sdt varchar(25),
@ngaySinh date,
@gioiTinh varchar(10),
@ngayVaoLam date,
@luongCB float,
@phuCap float
as
Insert into tblNhanVien(iMaNV, sTenNV, sDiaChi, sDienThoai, dNgaySinh, sGioiTinh, dNgayVaoLam, fLuongCoBan, fPhuCap)
values(@maNV, @tenNV, @diaChi, @sdt, @ngaySinh, @gioiTinh, @ngayVaoLam, @luongCB, @phuCap);

Create proc Update_tblNhanVien
@maNV int, 
@tenNV varchar(30),
@diaChi varchar(50),
@sdt varchar(25),
@ngaySinh date,
@gioiTinh varchar(10),
@ngayVaoLam date,
@luongCB float,
@phuCap float
as
Update tblNhanVien 
Set sTenNV = @tenNV, sDiaChi = @diaChi, sDienThoai = @sdt, dNgaySinh = @ngaySinh, sGioiTinh = @gioiTinh, dNgayVaoLam = @ngayVaoLam,
fLuongCoBan = @luongCB, fPhuCap = @phuCap
Where iMaNV = @maNV;

Create proc CheckRangBuocNhanVien_NhapKho
@maNV int
as
Select iMaNV From tblDonNhapKho
Where iMaNV = @maNV;

Create proc CheckRangBuocNhanVien_XuatHang
@maNV int
as
Select iMaNV from tblDonDatHang
Where iMaNV = @maNV;

Create proc Delete_tblNhanVien
@maNV int 
as
Delete From tblNhanVien Where iMaNV = @maNV;

---------------------------------------
create proc Check_MaHD_DonDatHang
@maHD int
as
Select iSoHD From tblDonDatHang Where iSoHD = @maHD

create proc Select_tblDonDatHang_tblChiTietDatHang
as 
Select tblDonDatHang.iSoHD, iMaNV, iMaKH, dNgayDatHang, dNgayGiaoHang, fTongTienHD, sMaHang, fGiaBan, iSoLuongMua, fMucGiamGia
From tblChiTietDatHang FULL JOIN tblDonDatHang ON tblChiTietDatHang.iSoHD = tblDonDatHang.iSoHD


create proc Select_tblDonDatHang_tblChiTietDatHang1
@maHD int
as 
Select tblDonDatHang.iSoHD, iMaNV, iMaKH, dNgayDatHang, dNgayGiaoHang, fTongTienHD, sMaHang, fGiaBan, iSoLuongMua, fMucGiamGia
From tblChiTietDatHang JOIN tblDonDatHang ON tblChiTietDatHang.iSoHD = tblDonDatHang.iSoHD
WHere tblDonDatHang.iSoHD = @maHD;

Create proc Select_tblDonDatHang 
@maHD int 
as
Select iSoHD, iMaNV, iMaKH, dNgayDatHang, dNgayGiaoHang, fTongTienHD From tblDonDatHang
Where iSoHD = @maHD;

Create proc Select_tblDonDatHang_NoPara
as
Select iSoHD, iMaNV, iMaKH, dNgayDatHang, dNgayGiaoHang, fTongTienHD From tblDonDatHang


create proc Select_tblChiTietDatHang 
@maHD int
as
Select iSoHD, sMaHang, fGiaBan, iSoLuongMua, fMucGiamGia From tblChiTietDatHang
Where iSoHD = @maHD;

Create proc Select_tblChiTietDatHang_getdata
@maHD int,
@maHang varchar(30)
as
Select iSoHD, sMaHang, fGiaBan, iSoLuongMua, fMucGiamGia From tblChiTietDatHang
Where iSoHD = @maHD
and sMaHang = @maHang;


create proc Select_tblChiTietDatHang_NoPara

as
Select iSoHD, sMaHang, fGiaBan, iSoLuongMua, fMucGiamGia From tblChiTietDatHang


Create proc Insert_tblDonDatHang
@maHD int,
@maNV int,
@maKH int,
@ngayDat date,
@ngayGiao date,
@tongTien float
as
Insert into tblDonDatHang(iSoHD, iMaNV, iMaKH, dNgayDatHang, dNgayGiaoHang, fTongTienHD)
values(@maHD, @maNV, @maKH, @ngayDat, @ngayGiao, @tongTien);

Create proc Insert_tblChiTietDatHang
@maHD int, 
@maHang varchar(30),
@giaBan float,
@soLuong int ,
@giamGia float
as
Insert into tblChiTietDatHang(iSoHD, sMaHang, fGiaBan, iSoLuongMua, fMucGiamGia)
values(@maHD, @maHang, @giaBan, @soLuong, @giamGia);

Create proc Update_tblDonDatHang
@maHD int,
@maNV int,
@maKH int,
@ngayDat date,
@ngayGiao date,
@tongTien float
as
Update tblDonDatHang 
Set iMaNV = @maNV, iMaKH = @maKH, dNgayDatHang = @ngayDat, dNgayGiaoHang = @ngayGiao, fTongTienHD = @tongTien
Where iSoHD = @maHD;

create proc Update_tblChiTietDatHang
@maHD int, 
@maHang varchar(30),
@giaBan float,
@soLuong int ,
@giamGia float
as
Update tblChiTietDatHang 
Set fGiaBan = @giaBan, iSoLuongMua = @soLuong, fMucGiamGia = @giamGia
Where iSoHD = @maHD and sMaHang = @maHang;

Create proc CheckRangBuocDonDatHang
@maHD int
as
Select iSoHD From tblChiTietDatHang Where iSoHD = @maHD;


Create proc Check_MaHD_MaHang_tblChiTietDatHang
@maHD int,
@maHang varchar(50)
as
Select iSoHD, sMaHang From tblChiTietDatHang Where iSoHD = @maHD and sMaHang = @maHang;

Create proc Delete_tblDonDatHang
@maHD int 
as
Delete From tblDonDatHang Where iSoHD = @maHD;

create proc Delete_tblChiTietDatHang
@maHD int,
@maHang varchar(50)
as 
Delete From tblChiTietDatHang Where iSoHD = @maHD and sMaHang = @maHang;

create proc Select_DSDonDatHang
@fromDate date,
@toDate date
as
Select iSoHD, dNgayGiaoHang, fTongTienHD From tblDonDatHang
Where dNgayGiaoHang BETWEEN @fromDate AND @toDate


Create proc Check_SoNK_tblDonNhapKho
@maNK int 
as
Select iSoNK From tblDonNhapKho Where iSoNK = @maNk;

Create proc Check_PrimaryKey_tblChiTietNhapKho
@maNK int,
@maHang varchar(50)
as
Select iSoNK From tblChiTietNhapKho Where iSoNK = @maNK and sMaHang = @maHang;

Create proc Select_tblDonNhapKho_tblChiTietNhapKho
as
Select tblDonNhapKho.iSoNK, iMaNV, dNgayNhapHang, fTongSoLuong, sMaHang, fGiaNhap, fSoLuongNhap
From tblDonNhapKho FULL Join tblChiTietNhapKho ON tblDonNhapKho.iSoNK = tblChiTietNhapKho.iSoNK;

Create proc Select_tblDonNhapKho_tblChiTietNhapKho1
@maNK int
as
Select tblDonNhapKho.iSoNK, iMaNV, dNgayNhapHang, fTongSoLuong, sMaHang, fGiaNhap, fSoLuongNhap
From tblDonNhapKho FULL Join tblChiTietNhapKho ON tblDonNhapKho.iSoNK = tblChiTietNhapKho.iSoNK 
where tblDonNhapKho.iSoNK = @maNK;

Create proc Select_tblDonNhapKho
as
Select iSoNK, iMaNV, dNgayNhapHang, fTongSoLuong from tblDonNhapKho 

Create proc Select_tblDonNhapKho_Para
@maNK int 
as
Select iSoNK, iMaNV, dNgayNhapHang, fTongSoLuong from tblDonNhapKho Where iSoNK = @maNK;

create proc Select_tblChiTietNhapKho
@maNK int
as
Select iSoNK, sMaHang, fGiaNhap, fSoLuongNhap From tblChiTietNhapKho Where iSoNK = @maNK;

Create proc Select_tblChiTietNhapKho_NoPara
as
Select iSoNK, sMaHang, fGiaNhap, fSoLuongNhap From tblChiTietNhapKho;

Create proc Select_tblChiTietNhapKho_Para
@maNK int,
@maHang varchar(50)
as
Select iSoNK, sMaHang, fGiaNhap, fSoLuongNhap From tblChiTietNhapKho Where iSoNK = @maNK and sMaHang = @maHang;

alter proc Insert_tblDonNhapKho
@maNK int,
@maNV int,
@ngayNhap date,
@tongSoLuong float
as
Insert into tblDonNhapKho(iSoNK, iMaNV, dNgayNhapHang, fTongSoLuong)
values(@maNK, @maNV, @ngayNhap, @tongSoLuong);

alter proc Insert_tblChiTietNhapKho
@maNK int,
@maHang varchar(50),
@giaNhap float,
@soLuongNhap float
as
Insert into tblChiTietNhapKho(iSoNK, sMaHang, fGiaNhap, fSoLuongNhap)
values(@maNK, @maHang, @giaNhap, @soLuongNhap);

Alter proc Update_tblDonNhapKho
@maNK int,
@maNV int,
@ngayNhap date,
@tongSoLuong float
as
Update tblDonNhapKho Set iMaNV = @maNV, dNgayNhapHang = @ngayNhap, fTongSoLuong = @tongSoLuong
Where  iSoNK = @maNK;

alter proc Update_tblChiTietNhapKho
@maNK int,
@maHang varchar(50),
@giaNhap float,
@soLuongNhap float
as
Update tblChiTietNhapKho Set fGiaNhap = @giaNhap, fSoLuongNhap = @soLuongNhap
Where  iSoNK = @maNK and sMaHang = @maHang;

create proc CheckRangBuocDonNhapKho
@maNK int 
as
Select iSoNK From tblChiTietNhapKho Where iSoNK = @maNK;

Alter proc Delete_tblDonNhapKho
@maNK int
as
Delete From tblDonNhapKho Where iSoNK = @maNk;

Create proc Delete_tblChiTietNhapKho
@maNK int,
@maHang varchar(50)
as
Delete From tblChiTietNhapKho Where iSoNK = @maNK and sMaHang = @maHang;

Create proc Select_DSDonNhapKho
@fromDate date,
@toDate date
as
Select iSoNk, dNgayNhapHang, fTongSoLuong From tblDonNhapKho
Where dNgayNhapHang BETWEEN @fromDate AND @toDate

-----Check Khoá chính
-----Thêm mới
-----Update
-----Select
-----CheckRangBuocKhoaNgoai
-----Delete

create proc Reports_DonDatHang 
as
Select tblDonDatHang.iSoHD, tblDonDatHang.iMaKH, tblDonDatHang.iMaNV, sTenNV, sTenKH, dNgayDatHang, dNgayGiaoHang, tblKhachHang.sDiaChi, tblKhachHang.sDienThoai as[SDT],
fTongTienHD, fGiaBan, iSoLuongMua,fMucGiamGia, sTenHang From tblDonDatHang, tblChiTietDatHang, tblNhanVien, tblKhachHang, tblMatHang
Where tblDonDatHang.iSoHD = tblChiTietDatHang.iSoHD 
and tblDonDatHang.iMaKH = tblKhachHang.iMaKH
and tblDonDatHang.iMaNV = tblNhanVien.iMaNV
and tblChiTietDatHang.sMaHang = tblMatHang.sMaHang

create proc Reports_DonNhapKho
as
Select tblChiTietNhapKho.iSoNK, tblDonNhapKho.iMaNV, sTenHang, sTenNV, dNgayNhapHang, fTongSoLuong, fGiaNhap, fSoLuongNhap,
sTenNhaCC, tblNhaCungCap.sDiaChi as [DiaChiNCC], tblNhaCungCap.sDienThoai as[SDTNCC]
From tblDonNhapKho, tblChiTietNhapKho, tblNhanVien, tblMatHang, tblNhaCungCap
Where tblDonNhapKho.iSoNK = tblChiTietNhapKho.iSoNK
and tblDonNhapKho.iMaNV = tblNhanVien.iMaNV
and tblChiTietNhapKho.sMaHang = tblMatHang.sMaHang
and tblNhaCungCap.iMaNCC = tblMatHang.iMaNCC

Create proc Reports_MatHang
as 
Select tblMatHang.sMaHang, tblMatHang.sMaLoaiHang, sTenHang, sTenLoaiHang, sTenNhaCC, fGiaHang, fSoLuong From tblMatHang, tblLoaiHang, tblNhaCungCap
Where tblMatHang.sMaLoaiHang = tblLoaiHang.sMaLoaiHang
and tblMatHang.iMaNCC = tblNhaCungCap.iMaNCC

Create proc Reports_NhanVien
as
Select tblNhanVien.iMaNV, iSoHD, iSoNK, sDiaChi, sDienThoai, sTenNV, dNgaySinh, dNgayVaoLam, sGioiTinh, fLuongCoBan, fPhuCap, dNgayDatHang, dNgayNhapHang, dNgayNhapHang
From tblNhanVien, tblDonDatHang, tblDonNhapKho
Where tblNhanVien.iMaNV = tblDonDatHang.iMaNV
and tblNhanVien.iMaNV = tblDonNhapKho.iMaNV

create proc Reports_KhachHang
as
Select tblKhachHang.iMaKH, sTenKH, sDiaChi, sDienThoai, sTenHang, dNgayDatHang, dNgayGiaoHang,
fTongTienHD, fGiaBan, iSoLuongMua, fMucGiamGia , tblChiTietDatHang.iSoHD
From tblKhachHang, tblDonDatHang, tblChiTietDatHang, tblMatHang
Where tblKhachHang.iMaKH = tblDonDatHang.iMaKH
and tblDonDatHang.iSoHD = tblChiTietDatHang.iSoHD
and tblChiTietDatHang.sMaHang = tblMatHang.sMaHang



----------------------------------
create proc Select_HoTenNV
@tenNV Nvarchar(30)
as
Select * from tblNhanVien
Where sTenNV LIKE '%'+@tenNV+'%';

EXec Select_HoTenNV N'Đỗ Thị';

Create proc Select_LuongCB 
@fromLuongCb float,
@toLuongCb  float
as
Select * from tblNhanVien
Where (@fromLuongCb < fLuongCoBan and  @toLuongCb > fLuongCoBan)

create proc Select_NV_Tuoi
@tuoi int
as
Select iMaNV, sTenNV, sDiaChi, sDienThoai, dNgaySinh, sGioiTinh, dNgayVaoLam, fLuongCoBan, fPhuCap From tblNhanVien 
Where DATEDIFF(d,dNgaySinh,getDate())/365 >= @tuoi

