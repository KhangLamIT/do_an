﻿Create database QL_NhaSach

Create table NHANVIEN(
MANV nvarchar(10) Primary key,
TENNV nvarchar(255),
DC nvarchar(255),
EMAIL nvarchar(255),
SDT nvarchar(255),
NGAYSINH date,
disabled int DEFAULT '0',
MATKHAU nvarchar(255)
) 

Create table MATHANG (
MAMH nchar(10) primary key,
TENMATHANG NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_MH_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_MH_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)

Create table LOAIMATHANG (
MALOAI nchar(10) primary key,
TENLOAI NVARCHAR(500),
HINHMINHHOA NVARCHAR(255),
MAMH nchar (10),
disabled int DEFAULT '0',
CONSTRAINT fk_MH_LMH
  FOREIGN KEY (MAMH)
  REFERENCES MATHANG(MAMH ),
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_LOAIMATHANG_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_LOAIMATHANG_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)
Create table CHUDE (
MACD nchar(10) primary key,
TENCD NVARCHAR(500),
HINHMINHHOA NVARCHAR(255),
MALOAI nchar (10),
disabled int DEFAULT '0',
CONSTRAINT fk_CD_LMH
  FOREIGN KEY (MALOAI )
  REFERENCES LOAIMATHANG (MALOAI ),
  NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_CD_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_CD_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)

Create table LOAICHUDE (
MALOAICD nchar(10) primary key,
TENLOAICD NVARCHAR(500),
HINHMINHHOA NVARCHAR(255),
MACD nchar (10),
disabled int DEFAULT '0',
CONSTRAINT fk_LOAICD_CD
  FOREIGN KEY (MACD )
  REFERENCES CHUDE (MACD ),
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_LOAICD_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_LOAICD_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)

Create table TACGIA (
MATG nchar(10) primary key,
TENTG NVARCHAR(500),
NGAYSINH DATE,
DC NVARCHAR(500),
SDT NVARCHAR(10),
EMAIL NVARCHAR(50),
GT NVARCHAR(3),
MOTA NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_TG_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_TG_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)

Create table NHACC(
MANCC nchar(10) primary key,
TENCC NVARCHAR(500),
DC NVARCHAR(500),
STK NVARCHAR(20),
SDT NVARCHAR(10),
MOTA NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_NCC_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_NCC_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)
Create table NHAXB(
MANXB nchar(10) primary key,
TENNXB NVARCHAR(500),
DC NVARCHAR(500),
STK NVARCHAR(20),
SDT NVARCHAR(10),
MOTA NVARCHAR(500),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_NHAXB_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_NXB_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)
Create table SANPHAM(
MASP NCHAR(10) PRIMARY KEY,
TENSP NVARCHAR(500),
NGAYDANG DATE,
GIABAN INT,
GIANHAP INT,
MANCC NCHAR(10),
MANXB NCHAR(10),
XUATXU NVARCHAR(500),
THUONGHIEU NVARCHAR(500),
NGONNGU NVARCHAR(500),
KICHTHUOC NVARCHAR(500),
SOTRANG NVARCHAR(500),
MOTA NVARCHAR(500),
DOTUOI NVARCHAR(500),
HSD DATE,
SLTON INT,
TRONGLUONG INT,
disabled int DEFAULT '0'
CONSTRAINT fk_MANCC_SP FOREIGN KEY (MANCC ) REFERENCES NHACC (MANCC),
CONSTRAINT fk_MANXB_SP FOREIGN KEY (MANXB) REFERENCES NHAXB (MANXB),
  NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_SP_KHNGT FOREIGN KEY (NGUOITAO) REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_SP_KHNGS FOREIGN KEY (NGUOISUA) REFERENCES NHANVIEN(MANV)
  )
    
CREATE table SACHTG(
MASP NCHAR(10),
MATG NCHAR(10),
CONSTRAINT pk_SACHTG
  PRIMARY KEY(MASP,MATG),
  CONSTRAINT fk_SACHTG_SP
  FOREIGN KEY (MASP)
  REFERENCES SANPHAM (MASP),
  CONSTRAINT fk_SACHTG_TG
  FOREIGN KEY (MATG)
  REFERENCES TACGIA (MATG),
  disabled int DEFAULT '0',
  NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_SCAHTG_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_SACHTG_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)

CREATE table SANPHAMHINHANH(
MAHINH int IDENTITY Primary key,
MASP nchar(10),
HINH nvarchar(255),
  CONSTRAINT fk_SANPHAMHINHANH_SP
  FOREIGN KEY (MASP)
  REFERENCES SANPHAM (MASP),
  disabled int DEFAULT '0',
  NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_SPHINH_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_SPHINH_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)
Create table SANPHAMLOAICHUDE(
MASP nchar(10),
MALOAICD nchar(10),
disabled int DEFAULT '0',
CONSTRAINT pk_SANPHAMLOAICHUDE
  PRIMARY KEY(MASP,MALOAICD),
  CONSTRAINT fk_SANPHAMLOAICHUDE_SP
  FOREIGN KEY (MASP)
  REFERENCES SANPHAM (MASP),
  CONSTRAINT fk_SANPHAMLOAICHUDE_LOAICD
  FOREIGN KEY (MALOAICD)
  REFERENCES LOAICHUDE (MALOAICD),
  NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_SPCD_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_SPCD_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)
Create table KHACHHANG(
MAKH int IDENTITY Primary key,
HOKH nvarchar(255),
TENKH nvarchar(255),
DC nvarchar(255),
EMAIL nvarchar(255),
SDT nvarchar(10),
disabled int DEFAULT '0',
MATKHAU nvarchar(255),
)

Create table DANHGIA(
MADG int IDENTITY Primary key,
MASP nchar(10),
MAKH int,
NGAYDANHGIA date,
DIEMDANHGIA int,
  CONSTRAINT fk_DANHGIA_SP
  FOREIGN KEY (MASP) REFERENCES SANPHAM (MASP),
  CONSTRAINT fk_DANHGIA_KH
  FOREIGN KEY (MAKH) REFERENCES KHACHHANG (MAKH),
)
Create table KHUYENMAI(
MAKHM Nchar(10) primary key,
GIATIEN int,
NGAYBD Date,
NGAYKET Date,
DIEUKIEN int,
HINHTHUCKM int,
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_KM_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_KM_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)
Create table DONHANG(
MADH int IDENTITY Primary key,
NGAYLAP date DEFAULT getdate(),
TONGTIEN int,
DCGIAO nvarchar(255),
SDT nvarchar(255),
QUOCGIA nvarchar(255),
THANHPHO nvarchar(255),
QUANHUYEN nvarchar(255),
PHUONGXA nvarchar(255),
EMAIL nvarchar(255),
HINHTHUC int,
TRANGTHAI int DEFAULT 0,
MAKH int DEFAULT NULL,
MAKHM nchar(10) NULL,
HOTEN nvarchar(255),
DIACHI nvarchar(255),
  CONSTRAINT fk_DONHANG_KH
  FOREIGN KEY (MAKH) REFERENCES KHACHHANG (MAKH),
  CONSTRAINT fk_DONHANG_KM
  FOREIGN KEY (MAKHM) REFERENCES KHUYENMAI (MAKHM),
)
alter table donhang
add TIENGIAM INT 
Create table DONHANGCT(
MADH int,
MASP nchar(10),
SL int,
THANHTIEN int,
CONSTRAINT pk_DONHANGCT
  PRIMARY KEY(MADH,MASP),
 CONSTRAINT fk_DONGHANGCT_DONHANG
  FOREIGN KEY (MADH) REFERENCES DONHANG (MADH),
  CONSTRAINT fk_DONHANGCT_SP
  FOREIGN KEY (MASP) REFERENCES SANPHAM (MASP),
)
Create table QUANGCAO(
MA int IDENTITY Primary key,
Hinh nvarchar(255),
disabled int DEFAULT '0',
NGUOITAO nvarchar(10),
NGAYTAO Date DEFAULT getdate(),
NGUOISUA nvarchar(10),
NGAYSUA Date,
CONSTRAINT fk_QUANGCAO_KHNGT
  FOREIGN KEY (NGUOITAO)
  REFERENCES NHANVIEN(MANV),
  CONSTRAINT fk_QUANGCAO_KHNGS
  FOREIGN KEY (NGUOISUA)
  REFERENCES NHANVIEN(MANV)
)
--ADD admin
INSERT INTO NHANVIEN(MANV,TENNV,MATKHAU) VALUES ('admin','Admin','123')
--Add mặt hàng
INSERT INTO MATHANG(MAMH,TENMATHANG,NGUOITAO) VALUES ('MH001',N'SACH','admin')
INSERT INTO MATHANG(MAMH,TENMATHANG,NGUOITAO) VALUES ('MH002','ĐỒ CHƠI','admin')
INSERT INTO MATHANG(MAMH,TENMATHANG,NGUOITAO) VALUES ('MH003','DỤNG CỤ','admin')
--
INSERT INTO LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) VALUES ('LMH001',N'SÁCH TRONG NƯỚC','MH001','admin')
INSERT INTO LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) VALUES ('LMH002',N'Foreign books','MH001','admin')
INSERT INTO LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) VALUES ('LMH003',N'Đồ chơi','MH002','admin')
INSERT INTO LOAIMATHANG(MALOAI,TENLOAI,MAMH,NGUOITAO) VALUES ('LMH004',N'VPP-Dụng cụ học sinh','MH003','admin')

--
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH001',N'VĂN HỌC','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH002',N'KINH TẾ','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH003',N'TÂM LÝ - KỸ NĂNG SỐNG','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH004',N'NUÔI DẬY CON','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH005',N'SÁCH THIẾU NHI','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH006',N'TIỂU SỬ - HỒI KÝ','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH007',N'GIÁO KHOA - KHAM KHẢO','LMH001','admin')
INSERT INTO CHUDE(MACD,TENCD,MALOAI,NGUOITAO) VALUES ('CDH008',N'SÁCH HỌC NGOẠI NGỮ','LMH001','admin')
--
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH001',N'Tiểu Thuyết','CDH001','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH002',N'Truyên ngắn -  Tàn Văn','CDH001','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH003',N'Ngôn tình','CDH001','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH004',N'Sách giáo khoa','CDH007','admin')
INSERT INTO LOAICHUDE(MALOAICD,TENLOAICD,MACD,NGUOITAO) VALUES ('LCDH005',N'Sách tham khảo','CDH007','admin')
--
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('d-day2_840x320_edit_moi.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('HoiSachOnline_T322_mainbanner__840x320_moi.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('840x320_-_DISNEY-100.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('840x320_-_Alphabooks_.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('840x320_Dong_A_edit_moi.jpg','admin')
INSERT INTO QUANGCAO(Hinh,NGUOITAO) VALUES ('840x320_-_Shopeepay_T3-100.jpg','admin')
--
INSERT INTO NHACC(MANCC,TENCC) VALUES ('NC001','Cty Phương Nam')
--
INSERT INTO NHAXB(MANXB,TENNXB) VALUES ('NXB01','NXB Giáo Dục Việt Nam')
--
insert into TACGIA (MATG,TENTG,NGUOITAO) values ('TG001','Bộ Giáo Dục Và Đào Tạo','admin')
--
INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP001',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP001','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP001','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP001','LCDH004')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP001','LCDH005')

--
INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP002',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP002','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP002','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP002','LCDH004')

INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP003',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP003','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP003','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP003','LCDH004')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP003','LCDH005')

INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP004',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP004','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP004','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP004','LCDH004')

INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP005',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP005','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP005','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP005','LCDH004')


INSERT INTO SANPHAM(MASP,TENSP,GIABAN,GIANHAP,MANCC,MANXB,KICHTHUOC,SOTRANG,NGUOITAO) values ('SP006',N'Tiếng Anh 3 - Tập 2 - Sách Học Sinh (2021)',35000,34000,'NC001','NXB01','26.5 x 19 x 0.4 cm','79','admin')
INSERT INTO SACHTG(MASP,MATG,NGUOITAO) Values ('SP006','TG001','admin')
INSERT INTO SANPHAMHINHANH(MASP,HINH) values ('SP006','image_241202.jpg')
INSERT INTO SANPHAMLOAICHUDE(MASP,MALOAICD) values ('SP006','LCDH004')
select * from CHUDE where disabled=0 and MALOAI='LMH001'

select * from LOAICHUDE where disabled=0 and macd='CDH001'

select * from QUANGCAO where disabled=0

select * from KHACHHANG

select * from DONHANG