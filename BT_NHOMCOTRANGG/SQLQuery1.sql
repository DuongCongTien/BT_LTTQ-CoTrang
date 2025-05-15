
USE master;
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyMayBay')
BEGIN
    ALTER DATABASE QuanLyMayBay SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyMayBay;
END
GO
CREATE DATABASE QuanLyMayBay;
GO

USE QuanLyMayBay;
GO
CREATE TABLE sanBay (
    maSanBay INT PRIMARY KEY,
    tenSanBay VARCHAR(100) NOT NULL,
    diaChi VARCHAR(255) NOT NULL
);

CREATE TABLE hangHangKhong (
    maHangHangKhong INT PRIMARY KEY,
    tenHangHangKhong VARCHAR(100) NOT NULL,
    quocGia VARCHAR(100) NOT NULL
);

CREATE TABLE chuyenBay (
    maChuyenBay INT PRIMARY KEY,
    maSanBayDi INT NOT NULL,
    maSanBayDen INT NOT NULL,
    maHangHangKhong INT NOT NULL,
    gioKhoiHanh DATETIME NOT NULL,
    gioDen DATETIME NOT NULL,
    trangThaiChuyenBay VARCHAR(50) NOT NULL CHECK (trangThaiChuyenBay IN ('Chưa khởi hành', 'Đang bay', 'Hoãn', 'Hủy', 'Đã đến')),
    soGheTrong INT NOT NULL CHECK (soGheTrong >= 0),
    FOREIGN KEY (maSanBayDi) REFERENCES sanBay(maSanBay),
    FOREIGN KEY (maSanBayDen) REFERENCES sanBay(maSanBay),
    FOREIGN KEY (maHangHangKhong) REFERENCES hangHangKhong(maHangHangKhong),
    CHECK (maSanBayDi <> maSanBayDen),
    CHECK (gioKhoiHanh < gioDen)
);
CREATE TABLE khachHang (
    maKH INT PRIMARY KEY,
    tenKH VARCHAR(100) NOT NULL,
    cccd CHAR(12) NOT NULL UNIQUE CHECK (cccd LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    email VARCHAR(100) NOT NULL CHECK (email LIKE '_%@_%._%'),
    soDienThoai CHAR(10) NOT NULL CHECK (soDienThoai LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    ngaySinh DATE NOT NULL CHECK (ngaySinh < GETDATE()),
    gioiTinh CHAR(1) NOT NULL CHECK (gioiTinh IN ('M', 'F')),
    loaiKH VARCHAR(50) NOT NULL CHECK (loaiKH IN ('Thường', 'VIP', 'Thành viên'))
);

CREATE TABLE veMayBay (
    maVe INT PRIMARY KEY,
    maChuyenBay INT NOT NULL,
    maKH INT NOT NULL,
    ngayDat DATE NOT NULL CHECK (ngayDat <= GETDATE()),
    giaVe MONEY NOT NULL CHECK (giaVe >= 0),
    trangThai VARCHAR(50) NOT NULL CHECK (trangThai IN ('Đã thanh toán', 'Chưa thanh toán', 'Đã hủy')),
    soGhe CHAR(5) NOT NULL,
    loaiVe VARCHAR(50) NOT NULL CHECK (loaiVe IN ('Phổ thông', 'Thương gia', 'Hạng nhất')),
    hanHanhLy INT NOT NULL CHECK (hanHanhLy >= 0),
    loaiVeDi INT NOT NULL CHECK (loaiVeDi IN (1, 2)), -- 1: Một chiều, 2: Khứ hồi
    FOREIGN KEY (maChuyenBay) REFERENCES chuyenBay(maChuyenBay),
    FOREIGN KEY (maKH) REFERENCES khachHang(maKH)
);

CREATE TABLE veKhuHoi (
    maVeDi INT PRIMARY KEY,
    maVeVe INT NOT NULL UNIQUE,
    FOREIGN KEY (maVeDi) REFERENCES veMayBay(maVe),
    FOREIGN KEY (maVeVe) REFERENCES veMayBay(maVe)
);

CREATE TABLE hoaDon (	
    maHoaDon INT PRIMARY KEY,
    maVe INT NOT NULL,
    phuongThucThanhToan VARCHAR(50) NOT NULL CHECK (phuongThucThanhToan IN ('Tiền mặt', 'Thẻ tín dụng', 'Chuyển khoản', 'Ví điện tử')),
    tongTien MONEY NOT NULL CHECK (tongTien >= 0),
    ngayLap DATETIME NOT NULL CHECK (ngayLap <= GETDATE()),
    tinhTrangThanhToan VARCHAR(50) NOT NULL CHECK (tinhTrangThanhToan IN ('Đã thanh toán', 'Chưa thanh toán')),
    FOREIGN KEY (maVe) REFERENCES veMayBay(maVe)
);

-- Bảng sanBay
INSERT INTO sanBay (maSanBay, tenSanBay, diaChi) VALUES
(1, N'Tân Sơn Nhất', N'TP. Hồ Chí Minh'),
(2, N'Nội Bài', N'Hà Nội'),
(3, N'Đà Nẵng', N'Đà Nẵng');

-- Bảng hangHangKhong
INSERT INTO hangHangKhong (maHangHangKhong, tenHangHangKhong, quocGia) VALUES
(1, 'Vietnam Airlines', 'Việt Nam'),
(2, 'VietJet Air', 'Việt Nam'),
(3, 'Bamboo Airways', 'Việt Nam');

-- Bảng chuyenBay
INSERT INTO chuyenBay (maChuyenBay, maSanBayDi, maSanBayDen, maHangHangKhong, gioKhoiHanh, gioDen, trangThaiChuyenBay, soGheTrong) VALUES
(101, 1, 2, 1, '2025-05-15 08:00:00', '2025-05-15 10:00:00', 'Chưa khởi hành', 100),
(102, 2, 3, 2, '2025-05-16 14:30:00', '2025-05-16 16:00:00', 'Chưa khởi hành', 85),
(103, 3, 1, 3, '2025-05-17 18:00:00', '2025-05-17 19:30:00', 'Chưa khởi hành', 90);

-- Bảng khachHang
INSERT INTO khachHang (maKH, tenKH, cccd, email, soDienThoai, ngaySinh, gioiTinh, loaiKH) VALUES
(1, 'Nguyễn Văn A', '012345678901', 'a@example.com', '0912345678', '1995-01-01', 'M', 'Thường'),
(2, 'Trần Thị B', '123456789012', 'b@example.com', '0987654321', '1990-12-12', 'F', 'VIP'),
(3, 'Lê Văn C', '234567890123', 'c@example.com', '0909090909', '2000-05-10', 'M', 'Thành viên');

-- Bảng veMayBay
INSERT INTO veMayBay (maVe, maChuyenBay, maKH, ngayDat, giaVe, trangThai, soGhe, loaiVe, hanHanhLy, loaiVeDi) VALUES
(201, 101, 1, '2025-05-10', 1500000, 'Đã thanh toán', 'A01', 'Phổ thông', 20, 1),
(202, 102, 2, '2025-05-11', 2500000, 'Chưa thanh toán', 'B02', 'Thương gia', 30, 2),
(203, 103, 3, '2025-05-09', 1800000, 'Đã thanh toán', 'C03', 'Phổ thông', 25, 1),
(204, 102, 2, '2025-05-11', 2500000, 'Đã thanh toán', 'B03', 'Thương gia', 30, 1); -- Vé khứ hồi

-- Bảng veKhuHoi
INSERT INTO veKhuHoi (maVeDi, maVeVe) VALUES
(202, 204); -- vé đi: 202, vé về: 204

-- Bảng hoaDon
INSERT INTO hoaDon (maHoaDon, maVe, phuongThucThanhToan, tongTien, ngayLap, tinhTrangThanhToan) VALUES
(301, 201, 'Thẻ tín dụng', 1500000, '2025-05-10 10:00:00', 'Đã thanh toán'),
(302, 203, 'Tiền mặt', 1800000, '2025-05-09 09:00:00', 'Đã thanh toán'),
(303, 204, 'Chuyển khoản', 2500000, '2025-05-11 12:00:00', 'Đã thanh toán');

