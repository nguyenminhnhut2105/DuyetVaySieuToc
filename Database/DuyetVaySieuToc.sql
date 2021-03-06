USE [DuyetVaySieuToc]
GO
/****** Object:  Table [dbo].[CAPQUYEN]    Script Date: 20/08/2017 11:25:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAPQUYEN](
	[MAND] [int] NOT NULL,
	[MAQUYEN] [int] NOT NULL,
	[MOTA] [nvarchar](256) NULL,
 CONSTRAINT [PK_CAPQUYEN] PRIMARY KEY CLUSTERED 
(
	[MAND] ASC,
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAINGUOIDUNG]    Script Date: 20/08/2017 11:25:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAINGUOIDUNG](
	[MALOAIND] [int] IDENTITY(1,1) NOT NULL,
	[TENLOAIND] [nvarchar](100) NULL,
	[NGAYTAO] [datetime] NULL,
 CONSTRAINT [PK_LOAINGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[MALOAIND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGHIEPVU]    Script Date: 20/08/2017 11:25:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NGHIEPVU](
	[MANGIEPVU] [varchar](64) NOT NULL,
	[TENNGHIEPVU] [nvarchar](256) NULL,
 CONSTRAINT [PK_NGHIEPVU] PRIMARY KEY CLUSTERED 
(
	[MANGIEPVU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 20/08/2017 11:25:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[MAND] [int] IDENTITY(1,1) NOT NULL,
	[MALOAIND] [int] NOT NULL,
	[TAIKHOAN] [varchar](100) NULL,
	[MATKHAU] [varchar](100) NULL,
	[SDT] [varchar](12) NULL,
	[DIACHI] [nvarchar](255) NULL,
	[EMAIL] [varchar](100) NULL,
	[NGAYTAO] [datetime] NULL,
	[QUANTRI] [int] NULL,
	[KICHHOAT] [int] NULL,
	[HOTEN] [nvarchar](255) NULL,
	[NGAYSINH] [datetime] NULL,
	[GioiTinh] [bit] NULL,
 CONSTRAINT [PK_NGUOIDUNG] PRIMARY KEY CLUSTERED 
(
	[MAND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NGUOIDUNGVAY]    Script Date: 20/08/2017 11:25:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNGVAY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SDT] [nvarchar](50) NULL,
	[CMND] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[VAYTHEO] [nvarchar](500) NULL,
	[TRANGTHAI] [int] NULL,
	[TINH] [nvarchar](100) NULL,
	[GHICHU] [nvarchar](max) NULL,
	[TINHTRANG] [int] NULL,
	[TEAM] [nvarchar](100) NULL,
	[NGAYDANGKY] [datetime] NULL,
	[NGAYDUYET] [datetime] NULL,
	[MATINHTRANG] [int] NOT NULL,
	[MATHONGBAO] [int] NOT NULL,
	[HOTEN] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.NGUOIDUNGVAY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 20/08/2017 11:25:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QUYEN](
	[MAQUYEN] [int] IDENTITY(1,1) NOT NULL,
	[MANGIEPVU] [varchar](64) NOT NULL,
	[TENQUYEN] [varchar](100) NULL,
	[MOTA] [nvarchar](256) NULL,
 CONSTRAINT [PK_QUYEN] PRIMARY KEY CLUSTERED 
(
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THONGBAO]    Script Date: 20/08/2017 11:25:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONGBAO](
	[MATHONGBAO] [int] IDENTITY(1,1) NOT NULL,
	[NOIDUNG] [nvarchar](500) NULL,
	[NGAY] [datetime] NULL,
 CONSTRAINT [PK_THONGBAO] PRIMARY KEY CLUSTERED 
(
	[MATHONGBAO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TINHTRANG]    Script Date: 20/08/2017 11:25:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TINHTRANG](
	[MATINHTRANG] [int] IDENTITY(1,1) NOT NULL,
	[TRANGTHAI] [int] NULL,
	[NGAYTAO] [datetime] NULL,
	[GhiChu] [nvarchar](500) NULL,
	[LyDo] [int] NULL,
	[NGAYDUYET] [datetime] NULL,
 CONSTRAINT [PK_TINHTRANG] PRIMARY KEY CLUSTERED 
(
	[MATINHTRANG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[LOAINGUOIDUNG] ON 

INSERT [dbo].[LOAINGUOIDUNG] ([MALOAIND], [TENLOAIND], [NGAYTAO]) VALUES (1, N'Khách hàng', CAST(N'2017-03-01 00:00:00.000' AS DateTime))
INSERT [dbo].[LOAINGUOIDUNG] ([MALOAIND], [TENLOAIND], [NGAYTAO]) VALUES (2, N'Quản lý', CAST(N'2017-03-01 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[LOAINGUOIDUNG] OFF
INSERT [dbo].[NGHIEPVU] ([MANGIEPVU], [TENNGHIEPVU]) VALUES (N'HomeController', N'chưa có mô tả')
INSERT [dbo].[NGHIEPVU] ([MANGIEPVU], [TENNGHIEPVU]) VALUES (N'QuanLyCapQuyenController', N'chưa có mô tả')
INSERT [dbo].[NGHIEPVU] ([MANGIEPVU], [TENNGHIEPVU]) VALUES (N'QuanLyKhachHangVayController', N'chưa có mô tả')
INSERT [dbo].[NGHIEPVU] ([MANGIEPVU], [TENNGHIEPVU]) VALUES (N'QuanLyNghiepVuController', N'chưa có mô tả')
INSERT [dbo].[NGHIEPVU] ([MANGIEPVU], [TENNGHIEPVU]) VALUES (N'QuanLyNguoiDungController', N'chưa có mô tả')
INSERT [dbo].[NGHIEPVU] ([MANGIEPVU], [TENNGHIEPVU]) VALUES (N'QuanLyQuyenController', N'chưa có mô tả')
SET IDENTITY_INSERT [dbo].[NGUOIDUNG] ON 

INSERT [dbo].[NGUOIDUNG] ([MAND], [MALOAIND], [TAIKHOAN], [MATKHAU], [SDT], [DIACHI], [EMAIL], [NGAYTAO], [QUANTRI], [KICHHOAT], [HOTEN], [NGAYSINH], [GioiTinh]) VALUES (1, 2, N'minhnhut', N'1ef5561b16c08092dce5dcc156faeaaa', N'01686720589', N'Bến Tre', N'nguyenminhnhut2105@gmail.com', NULL, 1, 1, N'Nguyễn Minh Nhựt', CAST(N'2017-05-21 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[NGUOIDUNG] OFF
SET IDENTITY_INSERT [dbo].[QUYEN] ON 

INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (1, N'HomeController', N'HomeController-Index', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (2, N'HomeController', N'HomeController-Login', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (3, N'HomeController', N'HomeController-Login', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (4, N'HomeController', N'HomeController-Logout', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (5, N'HomeController', N'HomeController-Menu', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (6, N'HomeController', N'HomeController-ThongBao', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (7, N'QuanLyCapQuyenController', N'QuanLyCapQuyenController-getPermissions', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (8, N'QuanLyCapQuyenController', N'QuanLyCapQuyenController-Index', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (9, N'QuanLyCapQuyenController', N'QuanLyCapQuyenController-updatePermissions', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (10, N'QuanLyKhachHangVayController', N'QuanLyKhachHangVayController-Create', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (11, N'QuanLyKhachHangVayController', N'QuanLyKhachHangVayController-Create', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (12, N'QuanLyKhachHangVayController', N'QuanLyKhachHangVayController-Delete', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (13, N'QuanLyKhachHangVayController', N'QuanLyKhachHangVayController-DeleteConfirmed', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (14, N'QuanLyKhachHangVayController', N'QuanLyKhachHangVayController-Details', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (15, N'QuanLyKhachHangVayController', N'QuanLyKhachHangVayController-Edit', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (16, N'QuanLyKhachHangVayController', N'QuanLyKhachHangVayController-Edit', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (17, N'QuanLyKhachHangVayController', N'QuanLyKhachHangVayController-Index', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (18, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-Create', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (19, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-Create', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (20, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-Delete', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (21, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-DeleteConfirmed', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (22, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-Details', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (23, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-Edit', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (24, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-Edit', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (25, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-EditNghiepVu', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (26, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-Index', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (27, N'QuanLyNghiepVuController', N'QuanLyNghiepVuController-updateNghiepVu', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (28, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-Create', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (29, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-Create', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (30, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-Create_EditCategoryUser', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (31, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-DeleteCategoryUser', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (32, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-DeleteMember', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (33, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-Edit', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (34, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-Edit', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (35, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-Index', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (36, N'QuanLyNguoiDungController', N'QuanLyNguoiDungController-Member', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (37, N'QuanLyQuyenController', N'QuanLyQuyenController-Create', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (38, N'QuanLyQuyenController', N'QuanLyQuyenController-Create', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (39, N'QuanLyQuyenController', N'QuanLyQuyenController-Delete', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (40, N'QuanLyQuyenController', N'QuanLyQuyenController-DeleteConfirmed', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (41, N'QuanLyQuyenController', N'QuanLyQuyenController-Details', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (42, N'QuanLyQuyenController', N'QuanLyQuyenController-Edit', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (43, N'QuanLyQuyenController', N'QuanLyQuyenController-Edit', N'chưa có mô tả')
INSERT [dbo].[QUYEN] ([MAQUYEN], [MANGIEPVU], [TENQUYEN], [MOTA]) VALUES (44, N'QuanLyQuyenController', N'QuanLyQuyenController-Index', N'chưa có mô tả')
SET IDENTITY_INSERT [dbo].[QUYEN] OFF
ALTER TABLE [dbo].[CAPQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_CAPQUYEN_NGUOIDUNG] FOREIGN KEY([MAND])
REFERENCES [dbo].[NGUOIDUNG] ([MAND])
GO
ALTER TABLE [dbo].[CAPQUYEN] CHECK CONSTRAINT [FK_CAPQUYEN_NGUOIDUNG]
GO
ALTER TABLE [dbo].[CAPQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_CAPQUYEN_QUYEN] FOREIGN KEY([MAQUYEN])
REFERENCES [dbo].[QUYEN] ([MAQUYEN])
GO
ALTER TABLE [dbo].[CAPQUYEN] CHECK CONSTRAINT [FK_CAPQUYEN_QUYEN]
GO
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNG_LOAINGUOIDUNG] FOREIGN KEY([MALOAIND])
REFERENCES [dbo].[LOAINGUOIDUNG] ([MALOAIND])
GO
ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NGUOIDUNG_LOAINGUOIDUNG]
GO
ALTER TABLE [dbo].[NGUOIDUNGVAY]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNGVAY_THONGBAO] FOREIGN KEY([MATHONGBAO])
REFERENCES [dbo].[THONGBAO] ([MATHONGBAO])
GO
ALTER TABLE [dbo].[NGUOIDUNGVAY] CHECK CONSTRAINT [FK_NGUOIDUNGVAY_THONGBAO]
GO
ALTER TABLE [dbo].[NGUOIDUNGVAY]  WITH CHECK ADD  CONSTRAINT [FK_NGUOIDUNGVAY_TINHTRANG] FOREIGN KEY([MATINHTRANG])
REFERENCES [dbo].[TINHTRANG] ([MATINHTRANG])
GO
ALTER TABLE [dbo].[NGUOIDUNGVAY] CHECK CONSTRAINT [FK_NGUOIDUNGVAY_TINHTRANG]
GO
ALTER TABLE [dbo].[QUYEN]  WITH CHECK ADD  CONSTRAINT [FK_QUYEN_NGHIEPVU] FOREIGN KEY([MANGIEPVU])
REFERENCES [dbo].[NGHIEPVU] ([MANGIEPVU])
GO
ALTER TABLE [dbo].[QUYEN] CHECK CONSTRAINT [FK_QUYEN_NGHIEPVU]
GO
