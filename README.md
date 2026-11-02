<div align="center">

# HOTEL MANAGEMENT

### Ứng dụng quản lý khách sạn trên nền tảng WinForms

C# &nbsp;|&nbsp; .NET 10 &nbsp;|&nbsp; Entity Framework Core &nbsp;|&nbsp; SQL Server

<br>

`6551071068_MAP_APP`

</div>

---

## 1. Giới thiệu

Hotel Management là ứng dụng desktop hỗ trợ lễ tân và quản lý khách sạn vận hành công việc hằng ngày: theo dõi tình trạng phòng, lập phiếu đặt phòng, quản lý khách hàng, nhân viên, dịch vụ và tiện nghi. Ứng dụng được xây dựng trong khuôn khổ học phần thực hành, kết nối trực tiếp tới cơ sở dữ liệu SQL Server có sẵn thông qua Entity Framework Core. Ứng dụng không tạo cơ sở dữ liệu và không chạy migration, toàn bộ cấu trúc bảng nằm trong một tệp script duy nhất.

Giao diện được thiết kế hoàn toàn bằng Windows Forms Designer, vì vậy mọi màn hình đều có thể mở và chỉnh sửa trực quan trong Visual Studio.

---

## 2. Chức năng

### 2.1 Đã hoàn thiện

| Nhóm chức năng | Nội dung |
| :--- | :--- |
| **Xác thực** | Đăng nhập theo tài khoản nhân viên. Mật khẩu được băm bằng PBKDF2-SHA256 (310.000 vòng lặp, salt ngẫu nhiên); mật khẩu cũ dạng văn bản thường tự động được nâng cấp ở lần đăng nhập đầu tiên. |
| **Quên mật khẩu** | Gửi mã xác nhận sáu chữ số qua Gmail SMTP đến email nhân viên. Mã có hiệu lực 5 phút, tối đa 5 lần nhập sai, giãn cách 60 giây giữa các lần gửi lại. |
| **Sơ đồ phòng** | Bảng trạng thái phòng với bộ lọc theo tình trạng phòng, loại phòng, tình trạng dọn dẹp, tìm theo mã phòng và lọc phòng trống theo ngày. |
| **Quản lý phòng** | Tìm kiếm, thêm mới, cập nhật, xóa mềm, khôi phục phòng đã xóa và xuất Excel. |
| **Quản lý loại phòng** | Tìm kiếm, thêm mới, cập nhật, xuất Excel và xem chi tiết tiện nghi theo từng loại. |
| **Đặt phòng** | Chọn nhiều phòng trống theo khoảng thời gian, tự điền thông tin khách cũ theo CCCD/Passport, lưu phiếu thuê trong một giao dịch có kiểm tra trùng lịch. |
| **Khách hàng, Nhân viên, Dịch vụ, Tiện nghi** | Tìm kiếm, thêm mới, cập nhật, xóa mềm và xuất Excel. |
| **Chi tiết tiện nghi** | Gán tiện nghi và số lượng cho từng loại phòng. |

### 2.2 Đang phát triển

Ba mục trên thanh điều hướng hiện hiển thị trang chờ: **Danh sách hóa đơn**, **Danh sách tài khoản** và **Thống kê**.

---

## 3. Công nghệ sử dụng

| Thành phần | Chi tiết |
| :--- | :--- |
| Ngôn ngữ và nền tảng | C#, .NET 10 (`net10.0-windows`), Windows Forms |
| Truy cập dữ liệu | Entity Framework Core 10 với SQL Server provider |
| Cơ sở dữ liệu | SQL Server Express, cơ sở dữ liệu `HotelManagement` |
| Xuất báo cáo | ClosedXML (tệp `.xlsx`) |
| Gửi thư | `System.Net.Mail` qua Gmail SMTP |
| Solution | Định dạng `.slnx` |

---

## 4. Cấu trúc thư mục

Toàn bộ mã nguồn được tổ chức theo từng nhóm nghiệp vụ, mỗi nhóm nằm trong một thư mục riêng.

```
6551071068_MAP_APP/
│
├── Data/                       Tầng dữ liệu
│                               Entity, DbContext, băm mật khẩu, cấu hình, gửi thư
│
├── Database/                   Cơ sở dữ liệu
│                               Script tạo bảng, trigger và dữ liệu mẫu
│
├── Forms/                      Khung giao diện chính
│                               Đăng nhập, quên mật khẩu, màn hình chính,
│                               sơ đồ phòng, phòng, loại phòng và hộp thoại
│
├── SoDoPhong/                  Đặt phòng
├── KhachHang/                  Quản lý khách hàng
├── NhanVien/                   Quản lý nhân viên
├── DichVu/                     Quản lý dịch vụ
├── TienNghi/                   Quản lý tiện nghi
├── ChiTietTienNghi/            Tiện nghi theo từng loại phòng
├── LoaiPhong/                  Lớp tương thích cho biểu mẫu loại phòng
│
├── UI/                         Thành phần giao diện dùng chung, bộ nạp hình ảnh
├── Resources/                  Biểu tượng và hình ảnh của ứng dụng
├── Properties/                 Tài nguyên dự án
│
├── appsettings.json            Chuỗi kết nối và cấu hình Gmail SMTP
├── Program.cs                  Điểm khởi chạy: đăng nhập, sau đó mở khung chính
└── 6551071068_MAP_APP.slnx     Tệp solution
```

Ba thư mục `Data`, `Database` và `Forms` là phần lõi của ứng dụng. Mỗi thư mục nghiệp vụ như `KhachHang`, `NhanVien`, `DichVu`, `TienNghi` gồm ba biểu mẫu: danh sách, thêm mới và cập nhật.

---

## 5. Cơ sở dữ liệu

Hệ thống gồm 12 bảng: `NhanVien`, `TaiKhoan`, `KhachHang`, `LoaiPhong`, `Phong`, `PhieuThue`, `CTDP`, `HoaDon`, `TienNghi`, `CTTN`, `DichVu` và `CTDV`.

Chuỗi nghiệp vụ chính đi theo hướng: khách hàng lập **phiếu thuê**, mỗi phiếu gồm nhiều **chi tiết đặt phòng** (`CTDP`), mỗi chi tiết có thể phát sinh **chi tiết dịch vụ** (`CTDV`) và được thanh toán bằng **hóa đơn**. Ba trigger (`CapNhatGiaCTDP`, `CapNhatGiaDV`, `CapNhatGiaTriHoaDon`) tự động tính tiền phòng, tiền dịch vụ và giá trị hóa đơn. Dữ liệu được xóa mềm thông qua cột `DaXoa`.

---

## 6. Hướng dẫn cài đặt

### 6.1 Yêu cầu

Visual Studio có hỗ trợ .NET 10 cùng workload *.NET Desktop Development*, và SQL Server Express đang chạy trên máy.

### 6.2 Các bước thực hiện

**Bước 1. Tạo cơ sở dữ liệu.**
Mở `Database/Database.sql` trong SQL Server Management Studio và thực thi toàn bộ tệp. Script sẽ tạo cơ sở dữ liệu `HotelManagement`, các bảng, trigger và dữ liệu mẫu.

**Bước 2. Cấu hình chuỗi kết nối.**
Mở `appsettings.json` và kiểm tra giá trị `ConnectionStrings:DefaultConnection`. Giá trị mặc định:

```
Server=.\SQLEXPRESS;Database=HotelManagement;Trusted_Connection=True;TrustServerCertificate=True;
```

Nếu máy của bạn dùng tên instance khác, hãy thay phần `Server` cho phù hợp.

**Bước 3. Mở và chạy dự án.**
Mở `6551071068_MAP_APP.slnx` bằng Visual Studio, đặt `6551071068_MAP_APP` làm startup project và nhấn **F5**.

### 6.3 Cấu hình chức năng quên mật khẩu

Chức năng này cần một tài khoản Gmail và *App Password* của tài khoản đó. Địa chỉ gửi được khai báo trong mục `GmailSMTP` của `appsettings.json`. Riêng App Password không nên ghi vào tệp cấu hình; hãy đặt qua biến môi trường người dùng rồi khởi động lại Visual Studio:

```
GmailSMTP__AppPassword = <mật khẩu ứng dụng gồm 16 ký tự>
```

Các khóa còn lại (`GmailSMTP__Host`, `GmailSMTP__Port`, `GmailSMTP__From`) cũng có thể ghi đè theo cách tương tự.

---

## 7. Tài khoản dùng thử

Các tài khoản dưới đây có sẵn trong dữ liệu mẫu. Mật khẩu mẫu sẽ được tự động băm ở lần đăng nhập đầu tiên.

| Tên đăng nhập | Mật khẩu | Cấp quyền | Nhân viên |
| :--- | :---: | :---: | :--- |
| `admin` | `1234` | 3 | AD001 |
| `admin1` | `1234` | 3 | AD002 |
| `admin2` | `1234` | 3 | AD003 |
| `Quanly` | `1234` | 2 | QL001 |
| `NhanVien` | `1234` | 1 | NV001 |

Đây là dữ liệu phục vụ học tập và kiểm thử. Không sử dụng các mật khẩu này trong môi trường thực tế.

---

## 8. Hạn chế đã biết và hướng phát triển

Phần này ghi lại trung thực những nội dung còn thiếu hoặc cần cải thiện, nhằm làm rõ phạm vi hiện tại của dự án.

**Chức năng chưa có.** Quản lý hóa đơn và thanh toán, quản lý tài khoản (kèm việc tự tạo tài khoản khi thêm nhân viên mới), và màn hình thống kê doanh thu vẫn chưa được xây dựng.

**Phân quyền.** Cấp quyền (`CapDoQuyen`) đã được đọc khi đăng nhập nhưng chưa được áp dụng để giới hạn chức năng, nên mọi nhân viên hiện đều thấy cùng một bộ menu.

**Lọc phòng trống.** Việc đặt phòng chuyển trạng thái cả phòng sang "Đã đặt", trong khi danh sách phòng trống chỉ lấy phòng ở trạng thái "Bình thường". Hệ quả là phòng đã có lịch đặt trong tương lai sẽ không xuất hiện ở các ngày còn trống. Hướng xử lý là dựa hoàn toàn vào khoảng thời gian của chi tiết đặt phòng thay vì trạng thái tổng của phòng.

**Đặt phòng theo giờ.** Cơ sở dữ liệu và trigger đã hỗ trợ thuê dưới bốn giờ, nhưng giao diện đặt phòng hiện yêu cầu ngày trả phải sau ngày nhận.

**Trigger.** Các trigger được viết cho thao tác một dòng; việc thêm hoặc cập nhật nhiều dòng trong một câu lệnh có thể cho kết quả không chính xác.

**Bộ lọc loại phòng.** Màn hình sơ đồ phòng đang gắn cứng bốn mã loại phòng mẫu, nên các loại phòng thêm mới chưa xuất hiện trong bộ lọc.

**Chất lượng mã nguồn.** Các module Lab 2 còn gọi cơ sở dữ liệu đồng bộ trên luồng giao diện và lặp lại đoạn xuất Excel; hai namespace `_6551071068_MAP_APP` và `HotelManagement` cùng tồn tại; một số lớp cũ trong `LoaiPhong/` và `SoDoPhong/` không còn được sử dụng. Dự án chưa có bộ kiểm thử tự động.

---

## 9. Ghi chú bảo mật

Không đưa mật khẩu ứng dụng Gmail, chuỗi kết nối chứa thông tin đăng nhập, hoặc bất kỳ thông tin bí mật nào vào kho mã nguồn. Hãy dùng biến môi trường cho các giá trị nhạy cảm.

---

<div align="center">

**Hotel Management**

Phát triển bởi dinhhoangphuc123

</div>