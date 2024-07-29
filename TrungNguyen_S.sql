create database QLCOFFEE_TRUNGNGUYEN
GO

USE QLCOFFEE_TRUNGNGUYEN
GO


-- LÝU THÔNG TIN ÐÃNG KÍ 
create table TaiKhoan
(
	TenTaiKhoan nvarchar(255) primary key,
	MatKhau varchar(100),
	Email varchar(100)
)
GO

CREATE TABLE NguyenLieu (
    MaNL VARCHAR(10) PRIMARY KEY NOT NULL,
    TenNL NVARCHAR(255),
    DVT NVARCHAR(50),
    SltonKho INT
);
go

CREATE TABLE SanPham (
    MaSP VARCHAR(10) PRIMARY KEY NOT NULL,
    TenSP NVARCHAR(255),
    DVT NVARCHAR(50),
    SltonKho INT,
	MaNL VARCHAR(10),
	CLSP NVARCHAR(50),
	FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
);
go

CREATE TABLE QuanLyKho (
    MaSP VARCHAR(10) PRIMARY KEY NOT NULL,
    TenSP NVARCHAR(255),
    DVT NVARCHAR(50),
    SltonKho INT,
	CLSP NVARCHAR(50),
);
go

CREATE TABLE HopDong (
    MaHD VARCHAR(10) PRIMARY KEY NOT NULL,
    NgayKi DATE,
    ThoiHan INT,
    GiaTri DECIMAL(10, 2),
    MaNL VARCHAR(10),
    MaSP VARCHAR(10),
    LoaiHD NVARCHAR(50),
    FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

CREATE TABLE NhapNguyenLieu (
    MaNL VARCHAR(10),
    MaHD VARCHAR(10),
    NgayKi DATE,
    SoLuong INT,
    CONSTRAINT PK_NhapNguyenLieu PRIMARY KEY (MaNL, MaHD),
    CONSTRAINT FK_NhapNguyenLieu_HopDong FOREIGN KEY (MaHD) REFERENCES HopDong(MaHD),
    CONSTRAINT FK_NhapNguyenLieu_NguyenLieu FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
);
ALTER TABLE NhapNguyenLieu
ADD TenNL NVARCHAR(50)

UPDATE NhapNguyenLieu
SET NhapNguyenLieu.TenNL = NguyenLieu.TenNL
FROM NhapNguyenLieu
JOIN NguyenLieu ON NhapNguyenLieu.MaNL = NguyenLieu.MaNL


CREATE TABLE XuatSanPham (
    MaSP VARCHAR(10),
    MaHD VARCHAR(10),
    NgayKi DATE,
    SoLuong INT,
    CONSTRAINT PK_XuatSanPham PRIMARY KEY (MaSP, MaHD),
    CONSTRAINT FK_XuatSanPham_HopDong FOREIGN KEY (MaHD) REFERENCES HopDong(MaHD),
    CONSTRAINT FK_XuatSanPham_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
ALTER TABLE XuatSanPham
ADD TenSP NVARCHAR(50)

UPDATE XuatSanPham
SET XuatSanPham.TenSP = SanPham.TenSP
FROM XuatSanPham
JOIN SanPham ON XuatSanPham.MaSP = SanPham.MaSP

select * from NhapNguyenLieu
select * from XuatSanPham
select * from TaiKhoan
select * from NguyenLieu
select * from SanPham
select * from HopDong












insert into TaiKhoan values
 (N'AA','123456','sang@gmail.com'),
 (N'BB','111111','tuyen@gmail.com'),
 (N'CC','222222','quynh@gmail.com')


 select * from TaiKhoan
 select * from SanPham


CREATE TABLE Kho (
    MaSP VARCHAR(10) PRIMARY KEY NOT NULL,
    TenSP NVARCHAR(255),
    DVT NVARCHAR(50),
    SltonKho INT,
    Quality NVARCHAR(10) 
);
go

