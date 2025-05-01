CREATE DATABASE QuanLyNhanVien;
GO

USE QuanLyNhanVien;
GO

CREATE TABLE tblNhanvien (
    MaNV NVARCHAR(10)PRIMARY KEY, 
    Hoten NVARCHAR(50),
    Quequan NVARCHAR(100) 
);

--THêm dữ liệu

INSERT INTO tblNhanvien (MaNV, Hoten, Quequan)
VALUES
('NV01', N'Nguyễn Văn Anh', N'Hà Nội'),
('NV02', N'Trần Thu Hà', N'Hà Tây'),
('NV03', N'Lê Chí Tuệ', N'Vĩnh Phúc'),
('NV04', N'Lê Thị Hương', N'Nghệ An'),
('NV05', N'Hoàng Văn Long', N'Thái Bình');

