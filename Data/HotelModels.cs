using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public class NhanVien
{
    public string MaNv { get; set; } = string.Empty;
    public string TenNv { get; set; } = string.Empty;
    public string ChucVu { get; set; } = string.Empty;
    public decimal Luong { get; set; }
    public string Sdt { get; set; } = string.Empty;
    public string Cccd { get; set; } = string.Empty;
    public DateOnly NgaySinh { get; set; }
    public string GioiTinh { get; set; } = string.Empty;
    public string DiaChi { get; set; } = string.Empty;
    public string? Email { get; set; }
    public bool? DaXoa { get; set; }
    public ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}

public class TaiKhoan
{
    public string TenTk { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int CapDoQuyen { get; set; }
    public string MaNv { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
    public NhanVien? MaNvNavigation { get; set; }
}

public class LoaiPhong
{
    public string MaLph { get; set; } = string.Empty;
    public string TenLph { get; set; } = string.Empty;
    public int SoGiuong { get; set; }
    public int SoNguoiToiDa { get; set; }
    public decimal GiaNgay { get; set; }
    public decimal GiaGio { get; set; }
    public ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}

public class Phong
{
    public string MaPh { get; set; } = string.Empty;
    public string Ttph { get; set; } = string.Empty;
    public string Ttdd { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
    public string MaLph { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
    public LoaiPhong? MaLphNavigation { get; set; }
    public ICollection<CTDP> Ctdps { get; set; } = new List<CTDP>();
}

public class Ctdp
{
    public string MaCtdp { get; set; } = string.Empty;
    public int? SoNguoi { get; set; }
    public string MaPt { get; set; } = string.Empty;
    public string MaPh { get; set; } = string.Empty;
    public DateTime CheckIn { get; set; }
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public DateTime Checkin { get => CheckIn; set => CheckIn = value; }
    public DateTime CheckOut { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public decimal? DonGia { get; set; }
    public decimal? ThanhTien { get; set; }
    public bool? DaXoa { get; set; }
    public bool? TheoGio { get; set; }
    public Phong? MaPhNavigation { get; set; }
    public PhieuThue? MaPtNavigation { get; set; }
}

public class KhachHang
{
    public string MaKh { get; set; } = string.Empty;
    public string TenKh { get; set; } = string.Empty;
    public string? Sdt { get; set; }
    public string CccdPassport { get; set; } = string.Empty;
    public string QuocTich { get; set; } = string.Empty;
    public string GioiTinh { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
}

public class PhieuThue
{
    public string MaPt { get; set; } = string.Empty;
    public DateTime NgPt { get; set; }
    public string MaKh { get; set; } = string.Empty;
    public string MaNv { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
    public KhachHang? MaKhNavigation { get; set; }
    public NhanVien? MaNvNavigation { get; set; }
    public ICollection<CTDP> Ctdps { get; set; } = new List<CTDP>();
}

public class HoaDon
{
    public string MaHd { get; set; } = string.Empty;
    public DateTime? NgHd { get; set; }
    public decimal? TriGia { get; set; }
    public string? MaNv { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public string MaCtdp { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
    public NhanVien? MaNvNavigation { get; set; }
    public CTDP? MaCtdpNavigation { get; set; }
}

public class TienNghi
{
    public string MaTn { get; set; } = string.Empty;
    public string TenTn { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
}

public class Cttn
{
    public string MaLph { get; set; } = string.Empty;
    public string MaTn { get; set; } = string.Empty;
    public int? Sl { get; set; }
    public bool? DaXoa { get; set; }
    public LoaiPhong? MaLphNavigation { get; set; }
    public TienNghi? MaTnNavigation { get; set; }
}

public class DichVu
{
    public string MaDv { get; set; } = string.Empty;
    public string TenDv { get; set; } = string.Empty;
    public decimal DonGia { get; set; }
    public int? SlconLai { get; set; }
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public int? SlConLai { get => SlconLai; set => SlconLai = value; }
    public string LoaiDv { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
}

public class CTDV
{
    public string MaCtdp { get; set; } = string.Empty;
    public string MaDv { get; set; } = string.Empty;
    public int Sl { get; set; }
    public decimal? DonGia { get; set; }
    public bool? DaXoa { get; set; }
    public decimal? ThanhTien { get; set; }
    public CTDP? MaCtdpNavigation { get; set; }
    public DichVu? MaDvNavigation { get; set; }
}
