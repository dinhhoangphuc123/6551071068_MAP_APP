using System.Drawing;
using _6551071068_MAP_APP.UI;

namespace HotelManagement
{
    public class HotelManagementContext : _6551071068_MAP_APP.Data.HotelManagementContext
    {
    }

    namespace Properties
    {
        internal static class Resources
        {
            public static Image search => AppImages.Load("search.png")!;
            public static Image DichVu => AppImages.Load("DichVu.png")!;
            public static Image TienNghi => AppImages.Load("TienNghi.png")!;
            public static Image KhachHang => AppImages.Load("KhachHang.png")!;
            public static Image NhanVien => AppImages.Load("NhanVien.png")!;
            public static Image Giuong => AppImages.Load("Giuong.png")!;
            public static Image details => AppImages.Load("details.png")!;
            public static Image edit => AppImages.Load("edit.png")!;
            public static Image delete => AppImages.Load("delete.png")!;
            public static Image Add => AppImages.Load("Add.png")!;
            public static Image PhieuThue => AppImages.Load("PhieuThue.png")!;
            public static Image Phong => AppImages.Load("Phong.png")!;
            public static Image DichVu1 => AppImages.Load("DichVu1.png")!;
            public static Image money => AppImages.Load("money.png")!;
            public static Image CalendarPick => AppImages.Load("CalendarPick.png")!;
            public static Image Name => AppImages.Load("Name.png")!;
            public static Image NhanVien1 => AppImages.Load("NhanVien1.png")!;
            public static Image printer => AppImages.Load("printer.png")!;
            public static Image pictureIconNoneBackGroundResize55 => AppImages.Load("pictureIconNoneBackGroundResize55.png")!;
            public static Image heart => AppImages.Load("heart.png") ?? AppImages.Load("tick.png")!;
            public static Image TaiKhoan => AppImages.Load("TaiKhoan.png")!;
            public static Image DoanhThu => AppImages.Load("DoanhThu.png")!;
            public static Image DoanhThuThue => AppImages.Load("DoanhThuThue.png")!;
            public static Image SoPhongDat => AppImages.Load("SoPhongDat.png")!;
            public static Image DatPhongChart => AppImages.Load("DatPhongChart.png")!;
            public static Image DichVuChart => AppImages.Load("DichVuChart.png")!;
            public static Image ThuePhongChart => AppImages.Load("ThuePhongChart.png")!;
            public static Image top1 => AppImages.Load("top1.png")!;
            public static Image top2 => AppImages.Load("top2.png")!;
            public static Image top3 => AppImages.Load("top3.png")!;
        }
    }
}

namespace HotelManagement.DangNhap
{
    public static class FormDangNhap
    {
        public static string MaNV_DangNhap =>
            !string.IsNullOrWhiteSpace(_6551071068_MAP_APP.Forms.LoginForm.MaNvDangNhap)
                ? _6551071068_MAP_APP.Forms.LoginForm.MaNvDangNhap
                : "NV001";
    }
}
