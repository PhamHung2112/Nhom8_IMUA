Use master
go
IF(EXISTS(SELECT * FROM SYSDATABASES WHERE NAME='Nhom8'))
	DROP DATABASE Nhom8
go
Create database [Nhom8]
go
use [Nhom8]
go
--------------------------------------------------------------------------------------------------------------------------
Create table [KhachHang]
(
	[MaKH] Integer Identity NOT NULL,
	[TenDangNhap] Varchar(50) NOT NULL,
	[MatKhau] Varchar(50) NOT NULL,
	[HoTen] Nvarchar(100) NOT NULL,
	[SoDT] Varchar(50) NOT NULL,
	[DiaChi] Nvarchar(100) NOT NULL,
	[Email] Varchar(50) NOT NULL,
	[TrangThai] Bit NOT NULL,
Primary Key ([MaKH])
) 
go

Create table [QuanTri]
(
	[MaQT] Integer Identity NOT NULL,
	[TenDangNhap] Varchar(50) NOT NULL,
	[MatKhau] Varchar(50) NOT NULL,
	[AnhDaiDien] Text NOT NULL,
	[HoTen] Nvarchar(100) NOT NULL,
	[LoaiTK] Bit NOT NULL,
Primary Key ([MaQT])
) 
go

Create table [DanhMuc]
(
	[MaDM] Integer Identity NOT NULL,
	[TenDM] Nvarchar(100) NOT NULL,
	[AnhDM] Text NOT NULL,
	[BieuTuong] Text NOT NULL,
Primary Key ([MaDM])
) 
go

Create table [LoaiSP]
(
	[MaLoai] Integer Identity NOT NULL,
	[TenLoai] Nvarchar(100) NOT NULL,
	[MaDM] Integer NOT NULL,
Primary Key ([MaLoai])
) 
go

Create table [SanPham]
(
	[MaSP] Integer Identity NOT NULL,
	[TenSP] Nvarchar(100) NOT NULL,
	[AnhDaiDien] Text NOT NULL,
	[GiaMoi] Money NOT NULL,
	[GiaCu] Money NOT NULL,
	[MoTa] Nvarchar(4000) NOT NULL,
	[XuatXu] Nvarchar(100) NOT NULL,
	[TrongLuong] Text NOT NULL,
	[MaLoai] Integer NOT NULL,
Primary Key ([MaSP])
) 
go

Create table [HoaDon]
(
	[MaHD] Integer Identity NOT NULL,
	[PhiVanChuyen] Money NOT NULL,
	[ThanhTien] Money NOT NULL,
	[NgayMua] Datetime NOT NULL,
	[MaKH] Integer NULL,
Primary Key ([MaHD])
) 
go

Create table [TinTuc]
(
	[MaTinTuc] Integer Identity NOT NULL,
	[TieuDe] Nvarchar(100) NOT NULL,
	[TomTat] Nvarchar(1000) NOT NULL,
	[NoiDung] Nvarchar(4000) NOT NULL,
	[AnhTinTuc] Text NOT NULL,
Primary Key ([MaTinTuc])
) 
go

Create table [ChiTietHoaDon]
(
	[MaHD] Integer NOT NULL,
	[MaSP] Integer NOT NULL,
	[SoLuong] Integer NOT NULL,
Primary Key ([MaHD],[MaSP])
) 
go

Alter table [HoaDon] add  foreign key([MaKH]) references [KhachHang] ([MaKH])  on update cascade on delete cascade
go
Alter table [LoaiSP] add  foreign key([MaDM]) references [DanhMuc] ([MaDM])  on update cascade on delete cascade 
go
Alter table [SanPham] add  foreign key([MaLoai]) references [LoaiSP] ([MaLoai])  on update cascade on delete cascade 
go
Alter table [ChiTietHoaDon] add  foreign key([MaSP]) references [SanPham] ([MaSP])  on update cascade on delete cascade 
go
Alter table [ChiTietHoaDon] add  foreign key([MaHD]) references [HoaDon] ([MaHD])  on update cascade on delete cascade
go
--------------------------------------------------------------------------------------------------------------------------
Insert into [DanhMuc] values (N'Mỹ Phẩm Trang Điểm', 'dm1.png', 'icon-dm1.png')
Insert into [DanhMuc] values (N'Hỗ Trợ Điều Trị', 'dm2.png', 'icon-dm2.png')
Insert into [DanhMuc] values (N'Chăm Sóc Da Mặt', 'dm3.png', 'icon-dm3.png')
Insert into [DanhMuc] values (N'Chăm Sóc Toàn Thân', 'dm4.png', 'icon-dm4.png')
Insert into [DanhMuc] values (N'Chăm Sóc Tóc', 'dm5.png', 'icon-dm5.png')
Insert into [DanhMuc] values (N'Thương Hiệu Ưa Chuộng', 'dm6.png', 'icon-dm6.png')
Insert into [DanhMuc] values (N'Sức Khỏe Dinh Dưỡng', 'dm7.png', 'icon-dm7.png')
Insert into [DanhMuc] values (N'Các Sản Phẩm Khác', 'dm8.png', 'icon-dm8.png')

Insert into [LoaiSP] values (N'Son môi', 1)
Insert into [LoaiSP] values (N'Kem nền', 1)
Insert into [LoaiSP] values (N'Phấn nước', 1)
Insert into [LoaiSP] values (N'Che khuyết điểm', 1)
Insert into [LoaiSP] values (N'Điều trị mụn', 2)
Insert into [LoaiSP] values (N'Điều trị rụng tóc', 2)
Insert into [LoaiSP] values (N'Giảm cân tan mỡ bụng', 2)
Insert into [LoaiSP] values (N'Sữa rửa mặt', 3)
Insert into [LoaiSP] values (N'Nước tẩy trang', 3)
Insert into [LoaiSP] values (N'Kem tẩy lông', 4)
Insert into [LoaiSP] values (N'Kem chống nắng', 4)
Insert into [LoaiSP] values (N'Sữa tắm trắng da', 4)
Insert into [LoaiSP] values (N'Xịt dưỡng tóc', 5)
Insert into [LoaiSP] values (N'Kem ủ tóc', 5)
Insert into [LoaiSP] values (N'Thương hiệu Pháp', 6)
Insert into [LoaiSP] values (N'Thương hiệu Hàn Quốc', 6)
Insert into [LoaiSP] values (N'Dầu dừa nguyên chất', 7)
Insert into [LoaiSP] values (N'Mật ong thiên nhiên', 7)
Insert into [LoaiSP] values (N'Phụ kiện làm đẹp', 8)
Insert into [LoaiSP] values (N'Nước hoa chính hãng', 8)

--Loại sản phẩm: Son môi
Insert into [SanPham] values (N'Son Dior 999', 'sp-sonmoi1.png', '600000', '715000', N'Đây là một trong những màu son bán chạy nhất của thương hiệu Dior trên toàn thế giới.', N'Pháp', '3.5gr', 1)
Insert into [SanPham] values (N'Son Dưỡng Môi The Collagen', 'sp-sonmoi2.png', '200000', '270000', N'Son Môi The Collagen được nhập khẩu chính hãng trực tiếp từ Hàn Quốc.', N'Hàn Quốc', '3gr', 1)
Insert into [SanPham] values (N'Son Dưỡng Dior Addict', 'sp-sonmoi3.png', '745000', '920000', N'Thỏi son với thành phần chiết xuất 100% thiên nhiên nên an toàn khi sử dụng.', N'Pháp', '20gr', 1)
Insert into [SanPham] values (N'Son Lì 3CE Stylenanda', 'sp-sonmoi4.png', '450000', '520000', N'Son lì 3CE – dòng son cực hot và được lựa chọn nhiều trên thị trường.', N'Hàn Quốc', '3.5gr', 1)
Insert into [SanPham] values (N'Son Dưỡng Môi Bioderma', 'sp-sonmoi5.png', '300000', '350000', N'Son dưỡng môi Bioderma là dòng sản phẩm chăm sóc môi tốt nhất đến từ Pháp.', N'Pháp', '10gr', 1)
Insert into [SanPham] values (N'Son Dưỡng Môi DHC Nhật Bản', 'sp-sonmoi6.png', '195000', '250000', N'Son dưỡng môi DHC được nhập khẩu chính hãng Nhật Bản.', N'Nhật Bản', '15gr', 1)
Insert into [SanPham] values (N'Son Dưỡng Môi Vaseline', 'sp-sonmoi7.png', '65000', '85000', N'Son dưỡng môi vaseline lip therapy được sản xuất bởi mỹ phẩm Vaseline.', N'Trung Quốc', '21gr', 1)
Insert into [SanPham] values (N'Son Collagen The Face Shop', 'sp-sonmoi8.png', '270000', '320000', N'Son Hàn Quốc Collagen là dòng son đang cực HOT trong năm nay.', N'Hàn Quốc', '5gr', 1)
Insert into [SanPham] values (N'Son lì dạng thỏi Pencil & Smudger', 'sp-sonmoi9.png', '240000', '280000', N'Son thỏi lì dạng thỏi Pencil Smudger được sản xuất bởi mỹ phẩm Maybelline.', N'Trung Quốc', '20gr', 1)
Insert into [SanPham] values (N'Son Môi AmOk Mint Best Color', 'sp-sonmoi10.jpg', '160000', '180000', N'Son Môi AmOk Mint Best Color được nhập khẩu chính hãng từ Hàn Quốc.', N'Hàn Quốc', '20gr', 1)
--Loại sản phẩm: Kem nền
Insert into [SanPham] values (N'Kem Che Khuyết Điểm Dermacol', 'sp-kemnen1.png', '250000', '310000', N'Kem che khuyết điểm Dermacol là dòng sản phẩm trang điểm được tin dùng hàng đầu hiện nay.', N'Cộng Hòa Séc', '30gr', 2)
Insert into [SanPham] values (N'Kem Nền NEUTROGENA', 'sp-kemnen2.png', '200000', '250000', N'Kem nền Neutrogena Skin Clearing Oil được nhập khẩu chính hãng tại Mỹ.', N'Mỹ', '35gr', 2)
Insert into [SanPham] values (N'Kem Nền Maybelline Rewind', 'sp-kemnen3.png', '170000', '210000', N'Kem Nền Maybelline Rewind được nhập khẩu chính hãng từ Mỹ.', N'Mỹ', '30gr', 2)
Insert into [SanPham] values (N'Kem Che Khuyết Điểm Instant Age', 'sp-kemnen4.png', '180000', '220000', N'Che khuyết điểm bằng kem Instant Age, giúp che phủ hoàn toàn các vết nám.', N'Mỹ', '20gr', 2)
Insert into [SanPham] values (N'Kem Nền Revlon Colorstay 24h', 'sp-kemnen5.png', '210000', '245000', N'Kem nền Revlon Colostay che khuyết điểm hoàn hảo, được giới makeup đánh giá rất cao.', N'Mỹ', '35gr', 2)
Insert into [SanPham] values (N'Kem Nền The Face Shop Gold Collagen', 'sp-kemnen6.png', '350000', '380000', N'Kem lót The Face Shop chứa hàng triệu tinh thể vàng nguyên chất và Collagen.', N'Hàn Quốc', '40gr', 2)
Insert into [SanPham] values (N'Kem Nền The Face Shop Power Perfection', 'sp-kemnen7.png', '320000', '420000', N'Kem nền The Face Shop Power Perfection sở hữu 3 công dụng trong 1 sản phẩm.', N'Hàn Quốc', '30gr', 2)
--Loại sản phẩm: Phấn nước
Insert into [SanPham] values (N'Phấn Nước Sulwhasoo Perfecting', 'sp-phannuoc1.png', '900000', '950000', N'Phấn nước dưỡng da Sulwhasoo là loại phấn nền cao cấp đa chức năng.', N'Hàn Quốc', '40gr', 3)
Insert into [SanPham] values (N'Phấn Nước Laneige Cushion', 'sp-phannuoc2.png', '740000', '780000', N'Phấn nước Laneige Cushion được nhập khẩu chính hãng từ Laneige Hàn Quốc.', N'Hàn Quốc', '30gr', 3)
--Loại sản phẩm: Che khuyết điểm
Insert into [SanPham] values (N'Bảng Phấn Tạo Khối Color Effects', 'sp-chekhuyetdiem1.png', '170000', '210000', N'Phấn tạo khối Color 3 màu tạo cho khuôn mặt thanh thoát, hoàn hảo hơn khi makeup.', N'Hàn Quốc', '50gr', 4)
Insert into [SanPham] values (N'Phấn Nén IOPE-Perfect Skin Twin Pact', 'sp-chekhuyetdiem2.png', '650000', '700000', N'Phấn nền trang điểm IOPE che phủ hoàn hảo, dưỡng ẩm cho da mịn màng, tươi tắn.', N'Hàn Quốc', '30gr', 4)
--Loại sản phẩm: Điều trị mụn
Insert into [SanPham] values (N'Serum Trị Mụn Peel Acnes Blanc', 'sp-dieutrimun1.png', '355000', '395000', N'Tăng cường sản sinh collagen giúp da săn chắc, hồng hào và sáng mịn hơn.', N'Pháp', '35gr', 5)
Insert into [SanPham] values (N'Bộ Trị Mụn Yanhee', 'sp-dieutrimun2.png', '250000', '300000', N'Tăng cường sản sinh collagen giúp da săn chắc, hồng hào và sáng mịn hơn.', N'Pháp', '35gr', 5)
--Loại sản phẩm: Điều trị rụng tóc
Insert into [SanPham] values (N'Bộ Dầu Gội Weilaiya', 'sp-dieutrirungtoc1.png', '585000', '650000', N'Bộ Dầu Gội mang đến giải pháp ngăn rụng và kích thích mọc tóc.', N'Việt Nam', '80gr', 6)
Insert into [SanPham] values (N'Kẹo Gấu Mọc Tóc Hair Vitamins', 'sp-dieutrirungtoc2.png', '790000', '950000', N'Kẹo gấu là một trong những dòng thực phẩm chăm sóc tóc được tin dùng hàng đầu tại Mỹ.', N'Mỹ', '50gr', 6)
--Loại sản phẩm: Giảm cân tan mỡ bụng
Insert into [SanPham] values (N'Thuốc Giảm Cân Đông Y Mộc Linh', 'sp-giamcan1.png', '435000', '540000', N'Đây là sản phẩm hỗ trợ giảm cân dành cho người bị lờn với thuốc lâu năm, khó giảm cân.', N'Việt Nam', '100gr', 7)
Insert into [SanPham] values (N'Kem Tan Mỡ Eveline Slim', 'sp-giamcan2.png', '220000', '290000', N'Kích thích quá trình tuần hoàn tái tạo da và ngăn ngừa lão hóa hiệu quả.', N'Nga', '30gr', 7)
--Loại sản phẩm: Sữa rửa mặt
Insert into [SanPham] values (N'Sữa Rửa Mặt Body Vitamin E', 'sp-suaruamat1.png', '300000', '425000', N'Sữa rửa mặt Body chính là bí quyết giúp bạn sở hữu làn da rạng rỡ và khỏe đẹp.', N'Hàn Quốc', '120gr', 8)
Insert into [SanPham] values (N'Sữa Rửa Mặt Foam Cleansing', 'sp-suaruamat2.png', '150000', '185000', N'Giữ ẩm hiệu quả, duy trì sự đàn hồi cho làn da mịn màng tươi sáng và trắng hồng tự nhiên.', N'Hàn Quốc', '120gr', 8)
--Loại sản phẩm: Nước tẩy trang
Insert into [SanPham] values (N'Nước Tẩy Trang Byphasse Solution', 'sp-nuoctaytrang1.png', '200000', '250000', N'Nước Tẩy Trang Byphasse Solution Micellaire có xuất xứ từ đất nước Tây Ban Nha xinh đẹp.', N'Tây Ban Nha', '300gr', 9)
Insert into [SanPham] values (N'Nước Tẩy Trang Mắt Môi Lip Eye Remover', 'sp-nuoctaytrang2.png', '120000', '140000', N'Nước Tẩy Trang Mắt Môi Lip Eye Remover được nhập khẩu chính hãng từ Hàn Quốc.', N'Hàn Quốc', '350gr', 9)
--Loại sản phẩm: Kem tẩy lông
Insert into [SanPham] values (N'Gel Dịu Da Và Làm Chậm Mọc Lông CLEO', 'sp-kemtaylong1.png', '155000', '185000', N'Sản phẩm dành riêng cho làn da sau tẩy lông, nhất là da nhạy cảm dễ bị kích ứng nhẹ như nóng rát, khô da.', N'Mỹ', '300ml', 10)
Insert into [SanPham] values (N'Kem Tẩy Lông Missha In Shower Comfort', 'sp-kemtaylong2.png', '220000', '250000', N'Kem tẩy lông Missha In Shower Comfor được nhập khẩu chính hãng từ mỹ phẩm Hàn Quốc.', N'Hàn Quốc', '100ml', 10)
--Loại sản phẩm: Kem chống nắng
Insert into [SanPham] values (N'Kem Chống Nắng Neutrogena Ultra Sheer', 'sp-kemchongnang1.png', '290000', '310000', N'Tích hợp Butylene Glycol dưỡng ẩm và làm đẹp da, Vitamin A, C, E nuôi dưỡng làn da.', N'Mỹ', '300ml', 11)
Insert into [SanPham] values (N'Xịt Chống Nắng JM Solution Marine', 'sp-kemchongnang2.png', '225000', '300000', N'Sản phẩm giúp bảo vệ da khỏi các tác hại của tia cực tím, tia UVB, UVA, tia sáng xanh.', N'Hàn Quốc', '310ml', 11)
--Loại sản phẩm: Sữa tắm trắng da
Insert into [SanPham] values (N'Sữa Tắm Trắng Da Cathy Choo', 'sp-suatrangda1.png', '200000', '260000', N'Sữa tắm trắng da Cathy Choo Vàng 24k được nhập khẩu chính hãng từ mỹ phẩm Thái Lan.', N'Thái Lan', '500ml', 12)
Insert into [SanPham] values (N'Sữa Tắm Nước Hoa COCO Perfume', 'sp-suatrangda2.png', '180000', '220000', N'Sữa tắm Coco Perfume nước hoa giúp dưỡng ẩm cho da mềm mại, trắng sáng và hương thơm quyến rũ.', N'Hàn Quốc', '800ml', 12)
--Loại sản phẩm: Xịt dưỡng tóc
Insert into [SanPham] values (N'Tinh Chất Hà Thủ Ô', 'sp-xitduongtoc1.png', '295000', '400000', N'Tinh chất Hà Thủ Ô kích thích mọc móc giúp tóc mọc lại nhanh an toàn và hiệu quả.', N'Việt Nam', '200ml', 13)
Insert into [SanPham] values (N'Serum Tinh Dầu Bưởi', 'sp-xitduongtoc2.png', '150000', '180000', N'Tinh dầu bưởi được sản xuất ở dạng serum giúp da đầu hấp thu nhanh, ngăn rụng tóc dứt điểm.', N'Việt Nam', '180ml', 13)
--Loại sản phẩm: Kem ủ tóc
Insert into [SanPham] values (N'Kem Ủ Tóc Phục Hồi Hư Tổn Bed Head Tigi', 'sp-kemutoc1.png', '295000', '395000', N'Cung cấp độ ẩm giúp tóc mềm mượt, giảm xơ rối và gãy rụng, giúp tóc bóng hơn với độ bồng bềnh tự nhiên.', N'Mỹ', '200gr', 14)
Insert into [SanPham] values (N'Kem Ủ Tóc NutriCare Fanola', 'sp-kemutoc2.png', '300000', '450000', N'Kem ủ tóc NutriCare Fanola, với thành phần chứa nhiều dưỡng chất giàu protein chính là giải pháp hoàn hảo cho mái tóc.', N'Ý', '1500ml', 14)
--Loại sản phẩm: Thương hiệu Pháp
Insert into [SanPham] values (N'Dầu Gội Khô Evoluderm', 'sp-thPhap1.png', '180000', '200000', N'Dầu gội khô Evoluderm được nhập khẩu chính hãng từ Evoluderm Pháp.', N'Pháp', '160gr', 15)
Insert into [SanPham] values (N'Lăn Khử Mùi Etiaxil', 'sp-thPhap2.png', '275000', '320000', N'Lăn Etiaxil chính là giải pháp hoàn hảo cho bạn luôn tự tin và thêm cuốn hút.', N'Pháp', '15ml', 15)
--Loại sản phẩm: Thương hiệu Hàn Quốc
Insert into [SanPham] values (N'Kem Dưỡng Trắng Laneige Tone Up Cream', 'sp-thHQ1.png', '570000', '630000', N'Kem dưỡng trắng Laneige – bí quyết giúp bạn sở hữu làn da tươi tắn, sáng mịn chỉ sau vài tuần.', N'Hàn Quốc', '50ml', 16)
Insert into [SanPham] values (N'Kem Trị Sẹo Rỗ Đông Y Genie Non Fix Skin', 'sp-thHQ2.png', '900000', '990000', N'Kem trị sẹo rỗ Đông Y Hàn Quốc được mệnh danh là siêu phẩm loại bỏ sẹo nhanh chóng trên thị trường.', N'Hàn Quốc', '30gr', 16)
--Loại sản phẩm: Dầu dừa nguyên chất
Insert into [SanPham] values (N'Dầu Dừa COCO Secret', 'sp-daudua1.png', '150000', '190000', N'Dầu dừa Coco Secret được sản xuất bởi Công ty cổ phần Dầu Dừa Coco Secret Việt Nam.', N'Việt Nam', '500ml', 17)
--Loại sản phẩm: Mật ong thiên nhiên
Insert into [SanPham] values (N'Mật Ong Nguyên Chất QUEEN BEE', 'sp-matong1.png', '500000', '600000', N'Mật Ong thiên nhiên Queen Bee không chỉ bổ dưỡng mà còn được xem như 1 vị thuốc cần thiết cho cơ thể.', N'Việt Nam', '2000ml', 18)
--Loại sản phẩm: Phụ kiện làm đẹp
Insert into [SanPham] values (N'Bộ Khuôn Tạo Dáng Chân Mày Mini Brow Class', 'sp-phukien1.png', '60000', '70000', N'Bộ Khuôn Tạo Dáng Chân Mày Mini Brow Class giúp định hình chân mày nhanh chóng, không gây lem.', N'Hàn Quốc', '10gr', 19)
Insert into [SanPham] values (N'Cọ Đánh Phấn Phủ Daily Beauty Tools Powder Brush', 'sp-phukien2.png', '140000', '160000', N'Cọ Đánh Phấn Phủ Daily Beauty Tools được nhập khẩu chính hãng từ Hàn Quốc.', N'Hàn Quốc', '100gr', 19)
--Loại sản phẩm: Nước hoa chính hãng
Insert into [SanPham] values (N'Nước Hoa COCO Mademoiselle Chanel', 'sp-nuochoa1.png', '950000', '980000', N'Nước hoa Coco Mademoiselle Chanel cho phái nữ thêm quyến rũ, tự tin.', N'Pháp', '100ml', 20)
Insert into [SanPham] values (N'Nước Hoa Versace Eros EDT', 'sp-nuochoa2.png', '900000', '970000', N'Versace Eros thể hiện sự mạnh mẽ nam tính thông qua sự kết hợp tinh tế của hương lá bạc hà tươi, vỏ chanh và táo xanh.', N'Ý', '100ml', 20)

Insert into [TinTuc] values (N'Những cách trị sẹo rỗ từ thiên nhiên an toàn', N'Sẹo rỗ luôn là nỗi ám ảnh của hầu hết chúng ta, chúng không chỉ khiến da tổn thương đau đớn mà còn khiến mất tự tin, khó sử dụng mỹ phẩm. Vậy làm sao để tìm được cách trị sẹo rỗ an toàn, hiệu quả bạn hãy cùng theo dõi qua bài viết sau.', N'Một trong những cách trị sẹo rỗ hiệu quả nhất được nhiều người tin dùng nhất đó là sử dụng nha đam. Nha đam với thành phần chứa nhiều axit amin, vitamin, khoáng tố vi lượng nhất là axít gama linolenic có công dụng làm lành vết thương, kích thích tái tạo tế bào da nhanh chóng. Bạn chỉ cần dùng gel nha đam thoa  đều lên vùng sẹo sau khi rửa sạch trong khoảng 15 phút để dưỡng chất thẩm thấu tốt hơn. Rau má là một trong những cách trị sẹo rỗ lâu năm được lưu truyền trong dân gian và nhiều người tin dùng. Chúng có tác dụng chữa lành sẹo nhanh chóng, dễ kiếm nguyên liệu và dễ thực hiện. Với chiết xuất có chất triterpenoids kết hợp cùng các hợp chất khác sẽ ức chế sự sản sinh quá mức collagen trong các mô sẹo, ngăn sẹo phát triển.', 'tintuc1.png')
Insert into [TinTuc] values (N'Cách trị sẹo lõm trên mặt với vitamin E đơn giản', N'Cách trị sẹo lõm trên mặt từ vitamin E luôn là một trong những phương pháp trị sẹo được rất nhiều người tin dùng. Vậy dùng sao cho hiệu quả và an toàn, bạn hãy cùng theo dõi qua bài viết sau.', N'Hầu hết chúng ta đều biết rằng, vitamin E được xem như là một trong những nguyên liệu làm đẹp được rất nhiều chị em tin dùng. Bởi chúng có tác dụng trẻ hóa làn da, ngăn ngừa các triệu chứng lão hóa hiện hữu trên da một kẻ thù của sắc đẹp. Đặc biệt, nhờ cơ chế hoạt động bổ sung dưỡng chất và kích thích collagen nên vitamin E chính là cách trị sẹo lõm trên mặt tại nhà được nhiều người tin dùng. Dễ dàng nhận thấy vitamin E dạng viên nang dễ kiếm, giá rẻ và khá đơn giản và đem lại hiệu quả khá tốt trong việc loại bỏ sẹo lõm. Mật ong với thành phần chứa chất kháng viêm cùng các nguồn vitamin, dưỡng chất nên nó không chỉ trị thâm, dưỡng da, chống khô da mà còn là cách trị sẹo lõm trên mặt từ thiên nhiên đang để bạn dùng thử.', 'tintuc2.png')
Insert into [TinTuc] values (N'Cách trị sẹo lõm thủy đậu từ thiên nhiên an toàn, hiệu quả', N'Chúng ta đều biết thủy đậu nếu như không điều trị kịp thời đúng cách thì sẽ gây viêm nhiễm và dễ để lại sẹo lõm. Vậy đâu mới là cách trị sẹo lõm an toàn và hiệu quả, bạn hãy cùng theo dõi qua bài viết sau.', N'Sử dụng phương pháp tự nhiên để điều trị sẹo lõm rất tốt cho da, cung cấp các chất dinh dưỡng giúp tái tạo hồi phục da và lấp đầy sẹo lõm nhanh chóng. Trong rau má có chứa lượng lớn collagen đồng thời an toàn, lành tính nên không gây kích ứng da nên đây được xem là cách trị sẹo lõm do thủy đậu được rất nhiều người tin dùng. Cách làm đơn giản, bạn dùng rau má đã rửa sạch và xay nhuyễn, lọc lấy nước và thoa đều lên vùng da mụn đợi khô và rửa lại. Ngoài ra, bạn cũng có thể dùng bã rau má để đắp lên vùng bị sẹo để tăng hiệu quả hơn. Thành phần trong dầu dừa chứa axit béo chống oxy hóa và bảo vệ da, chúng sẽ kích thích quá trình sản xuất collagen giúp mềm da, làm bề mặt sẹo mềm mịn hơn.', 'tintuc3.png')
Insert into [TinTuc] values (N'Cách trị sẹo lõm và những sai lầm bạn chưa biết', N'Những vết sẹo lõm khiến chúng ta mất tự tin trong cuộc sống và luôn tìm phương pháp loại bỏ chúng. Vậy đâu mới là cách trị sẹo lõm an toàn, hiệu quả và nhanh chóng, bạn hãy cùng theo dõi qua bài viết sau.', N'Sẹo lõm hình thành từ những tổn thương do kết cấu các mô da và collagen bị đứt gãy, tế bào không hấp thu được dưỡng chất làm đầy vùng da bị lõm. Cách trị sẹo lõm lâu nămtại nhà từ các nguyên liệu dân gian được rất nhiều người tin dùng, bạn có thể sử dụng các nguyên liệu như: chanh, nghệ, mật ong, nha đam… Ưu điểm của các phương pháp tự nhiên sẽ có giá thành rẻ, dễ tìm kiếm, dễ áp dụng tại nhà. Tuy nhiên, dùng nguyên liệu tự nhiên sẽ khiến tốn thời gian để nhận thấy hiệu quả. ', 'tintuc4.png')
Insert into [TinTuc] values (N'Đi tìm cách trị sẹo lồi hiệu quả, nhanh chóng', N'Cách trị sẹo lồi nhanh chóng hiệu quả luôn là ước muốn của hầu hết người bị sẹo. Bởi sẹo lồi không chỉ khiến bạn đau đớn, gây tổn thương da mà còn khiến bạn mất tự tin trong cuộc sống. Vậy để loại bỏ sẹo lồi tốt nhất bạn hãy cùng theo dõi qua bài viết sau.', N'Trị sẹo bằng cách tiêm thuốc: Bằng cách tiêm trực tiếp chất Corticosteroid vào mô sẹo sẽ giúp phá hủy cấu trúc tổ chức của sẹo, giảm kích thích và giúp sẹo xẹp dần. Thế nhưng việc điều trị thường kéo dài từ 6 – 12 tháng, gây tốn kém và dễ khiến bị teo da tại vùng tiêm, rối loạn kinh nguyệt, mất sắc tố không hồi phục. Phẩu thuật cắt bỏ: Dành cho những vùng sẹo lớn, bác sĩ sẽ giúp bạn cắt bỏ vùng sẹo và ghép da nhằm giảm lực căng trên toàn bộ da được khâu. Nhược điểm của cách trị sẹo lồi công nghệ này là không làm dứt điểm sẹo, gây đau đớn, dễ bị tái phát. Phẩu thuật lạnh: Sử dụng ni tơ lỏng để phá hủy tổ chức của sẹo làm cho sẹo xẹp xuống, giúp bạn loại bỏ sẹo nhanh hơn.', 'tintuc5.png')

select * from [DanhMuc]
select * from [LoaiSP]
select * from [SanPham]
select * from [TinTuc]