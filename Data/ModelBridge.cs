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
