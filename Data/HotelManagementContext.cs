global using HotelManagementContext = _6551071068_MAP_APP.Data.HotelManagementContext;
global using Cttn = HotelManagement.Models.Cttn;
global using Ctdp = HotelManagement.Models.Ctdp;
global using CTTN = HotelManagement.Models.Cttn;
global using CTDP = HotelManagement.Models.Ctdp;
global using DichVu = HotelManagement.Models.DichVu;
global using KhachHang = HotelManagement.Models.KhachHang;
global using NhanVien = HotelManagement.Models.NhanVien;
global using TienNghi = HotelManagement.Models.TienNghi;
global using Phong = HotelManagement.Models.Phong;
global using LoaiPhong = HotelManagement.Models.LoaiPhong;
global using PhieuThue = HotelManagement.Models.PhieuThue;
global using HoaDon = HotelManagement.Models.HoaDon;
global using TaiKhoan = HotelManagement.Models.TaiKhoan;
global using CTDV = HotelManagement.Models.CTDV;
global using Ctdv = HotelManagement.Models.CTDV;

using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Data;

/// <summary>
/// EF Core mapping for the HotelManagement database described in the lab manual.
/// The application uses the existing database and does not run migrations.
/// </summary>
public class HotelManagementContext : DbContext
{
    public HotelManagementContext()
    {
    }

    public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
        : base(options)
    {
    }

    public DbSet<NhanVien> NhanViens => Set<NhanVien>();
    public DbSet<TaiKhoan> TaiKhoans => Set<TaiKhoan>();
    public DbSet<Phong> Phongs => Set<Phong>();
    public DbSet<LoaiPhong> LoaiPhongs => Set<LoaiPhong>();
    public DbSet<CTDP> Ctdps => Set<CTDP>();
    public DbSet<KhachHang> KhachHangs => Set<KhachHang>();
    public DbSet<PhieuThue> PhieuThues => Set<PhieuThue>();
    public DbSet<HoaDon> HoaDons => Set<HoaDon>();
    public DbSet<TienNghi> TienNghis => Set<TienNghi>();
    public DbSet<CTTN> Cttns => Set<CTTN>();
    public DbSet<DichVu> DichVus => Set<DichVu>();
    public DbSet<CTDV> Ctdvs => Set<CTDV>();
    public DbSet<CTDV> CTDVs => Ctdvs;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(AppConfiguration.GetDefaultConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.ToTable("NhanVien");
            entity.HasKey(x => x.MaNv);
            entity.Property(x => x.MaNv).HasColumnName("MaNV").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.TenNv).HasColumnName("TenNV").HasMaxLength(50).IsUnicode().IsRequired();
            entity.Property(x => x.ChucVu).HasColumnName("ChucVu").HasMaxLength(50).IsUnicode().IsRequired();
            entity.Property(x => x.Luong).HasColumnName("Luong").HasColumnType("money").IsRequired();
            entity.Property(x => x.Sdt).HasColumnName("SDT").HasMaxLength(10).IsUnicode().IsRequired();
            entity.Property(x => x.Cccd).HasColumnName("CCCD").HasMaxLength(12).IsUnicode().IsRequired();
            entity.Property(x => x.NgaySinh).HasColumnName("NgaySinh").HasColumnType("date").IsRequired();
            entity.Property(x => x.GioiTinh).HasColumnName("GioiTinh").HasMaxLength(3).IsUnicode().IsRequired();
            entity.Property(x => x.DiaChi).HasColumnName("DiaChi").HasMaxLength(100).IsUnicode().IsRequired();
            entity.Property(x => x.Email).HasColumnName("Email").HasMaxLength(100).IsUnicode();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.ToTable("TaiKhoan");
            entity.HasKey(x => x.TenTk);
            entity.Property(x => x.TenTk).HasColumnName("TenTK").HasMaxLength(50).IsUnicode().IsRequired();
            entity.Property(x => x.Password).HasColumnName("Password").HasMaxLength(1000).IsRequired();
            entity.Property(x => x.CapDoQuyen).HasColumnName("CapDoQuyen").IsRequired();
            entity.Property(x => x.MaNv).HasColumnName("MaNV").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
            entity.HasOne(x => x.MaNvNavigation)
                .WithMany(x => x.TaiKhoans)
                .HasForeignKey(x => x.MaNv)
                .HasPrincipalKey(x => x.MaNv);
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.ToTable("LoaiPhong");
            entity.HasKey(x => x.MaLph);
            entity.Property(x => x.MaLph).HasColumnName("MaLPH").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.TenLph).HasColumnName("TenLPH").HasMaxLength(20).IsUnicode().IsRequired();
            entity.Property(x => x.SoGiuong).HasColumnName("SoGiuong").IsRequired();
            entity.Property(x => x.SoNguoiToiDa).HasColumnName("SoNguoiToiDa").IsRequired();
            entity.Property(x => x.GiaNgay).HasColumnName("GiaNgay").HasColumnType("money").IsRequired();
            entity.Property(x => x.GiaGio).HasColumnName("GiaGio").HasColumnType("money").IsRequired();
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.ToTable("Phong");
            entity.HasKey(x => x.MaPh);
            entity.Property(x => x.MaPh).HasColumnName("MaPH").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.Ttph).HasColumnName("TTPH").HasMaxLength(20).IsUnicode().IsRequired();
            entity.Property(x => x.Ttdd).HasColumnName("TTDD").HasMaxLength(20).IsUnicode().IsRequired();
            entity.Property(x => x.GhiChu).HasColumnName("GhiChu").HasMaxLength(100).IsUnicode();
            entity.Property(x => x.MaLph).HasColumnName("MaLPH").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
            entity.HasOne(x => x.MaLphNavigation)
                .WithMany(x => x.Phongs)
                .HasForeignKey(x => x.MaLph)
                .HasPrincipalKey(x => x.MaLph);
        });

        // Các bảng có trigger phải khai báo để EF Core không dùng mệnh đề OUTPUT khi SaveChanges
        modelBuilder.Entity<CTDP>(entity =>
        {
            entity.ToTable("CTDP", t => t.HasTrigger("CapNhatGiaCTDP"));
            entity.HasKey(x => x.MaCtdp);
            entity.Property(x => x.MaCtdp).HasColumnName("MaCTDP").HasMaxLength(7).IsUnicode().IsRequired();
            entity.Property(x => x.SoNguoi).HasColumnName("SoNguoi");
            entity.Property(x => x.MaPt).HasColumnName("MaPT").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.MaPh).HasColumnName("MaPH").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.CheckIn).HasColumnName("CheckIn").HasColumnType("smalldatetime").IsRequired();
            entity.Property(x => x.CheckOut).HasColumnName("CheckOut").HasColumnType("smalldatetime").IsRequired();
            entity.Property(x => x.TrangThai).HasColumnName("TrangThai").HasMaxLength(20).IsUnicode().IsRequired();
            entity.Property(x => x.DonGia).HasColumnName("DonGia").HasColumnType("money");
            entity.Property(x => x.ThanhTien).HasColumnName("ThanhTien").HasColumnType("money");
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
            entity.Property(x => x.TheoGio).HasColumnName("TheoGio");
            entity.HasOne(x => x.MaPhNavigation)
                .WithMany(x => x.Ctdps)
                .HasForeignKey(x => x.MaPh)
                .HasPrincipalKey(x => x.MaPh);
            entity.HasOne(x => x.MaPtNavigation)
                .WithMany(x => x.Ctdps)
                .HasForeignKey(x => x.MaPt)
                .HasPrincipalKey(x => x.MaPt);
            entity.HasMany(x => x.Ctdvs)
                .WithOne(x => x.MaCtdpNavigation)
                .HasForeignKey(x => x.MaCtdp)
                .HasPrincipalKey(x => x.MaCtdp);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.ToTable("KhachHang");
            entity.HasKey(x => x.MaKh);
            entity.Property(x => x.MaKh).HasColumnName("MaKH").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.TenKh).HasColumnName("TenKH").HasMaxLength(50).IsUnicode().IsRequired();
            entity.Property(x => x.Sdt).HasColumnName("SDT").HasMaxLength(10).IsUnicode();
            entity.Property(x => x.CccdPassport).HasColumnName("CCCD/Passport").HasMaxLength(12).IsUnicode().IsRequired();
            entity.Property(x => x.QuocTich).HasColumnName("QuocTich").HasMaxLength(30).IsUnicode().IsRequired();
            entity.Property(x => x.GioiTinh).HasColumnName("GioiTinh").HasMaxLength(3).IsUnicode().IsRequired();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
        });

        modelBuilder.Entity<PhieuThue>(entity =>
        {
            entity.ToTable("PhieuThue");
            entity.HasKey(x => x.MaPt);
            entity.Property(x => x.MaPt).HasColumnName("MaPT").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.NgPt).HasColumnName("NgPT").HasColumnType("smalldatetime").IsRequired();
            entity.Property(x => x.MaKh).HasColumnName("MaKH").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.MaNv).HasColumnName("MaNV").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
            entity.HasOne(x => x.MaKhNavigation).WithMany().HasForeignKey(x => x.MaKh).HasPrincipalKey(x => x.MaKh);
            entity.HasOne(x => x.MaNvNavigation).WithMany().HasForeignKey(x => x.MaNv).HasPrincipalKey(x => x.MaNv);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.ToTable("HoaDon", t => t.HasTrigger("CapNhatGiaTriHoaDon"));
            entity.HasKey(x => x.MaHd);
            entity.Property(x => x.MaHd).HasColumnName("MaHD").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.NgHd).HasColumnName("NgHD").HasColumnType("smalldatetime");
            entity.Property(x => x.TriGia).HasColumnName("TriGia").HasColumnType("money");
            entity.Property(x => x.MaNv).HasColumnName("MaNV").HasMaxLength(5).IsUnicode();
            entity.Property(x => x.TrangThai).HasColumnName("TrangThai").HasMaxLength(20).IsUnicode().IsRequired();
            entity.Property(x => x.MaCtdp).HasColumnName("MaCTDP").HasMaxLength(7).IsUnicode().IsRequired();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
            entity.HasOne(x => x.MaNvNavigation).WithMany().HasForeignKey(x => x.MaNv).HasPrincipalKey(x => x.MaNv);
            entity.HasOne(x => x.MaCtdpNavigation)
                .WithMany(x => x.HoaDons)
                .HasForeignKey(x => x.MaCtdp)
                .HasPrincipalKey(x => x.MaCtdp);
        });

        modelBuilder.Entity<TienNghi>(entity =>
        {
            entity.ToTable("TienNghi");
            entity.HasKey(x => x.MaTn);
            entity.Property(x => x.MaTn).HasColumnName("MaTN").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.TenTn).HasColumnName("TenTN").HasMaxLength(50).IsUnicode().IsRequired();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
        });

        modelBuilder.Entity<CTTN>(entity =>
        {
            entity.ToTable("CTTN");
            entity.HasKey(x => new { x.MaLph, x.MaTn });
            entity.Property(x => x.MaLph).HasColumnName("MaLPH").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.MaTn).HasColumnName("MaTN").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.Sl).HasColumnName("SL");
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
            entity.HasOne(x => x.MaLphNavigation).WithMany().HasForeignKey(x => x.MaLph).HasPrincipalKey(x => x.MaLph);
            entity.HasOne(x => x.MaTnNavigation).WithMany().HasForeignKey(x => x.MaTn).HasPrincipalKey(x => x.MaTn);
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.ToTable("DichVu");
            entity.HasKey(x => x.MaDv);
            entity.Property(x => x.MaDv).HasColumnName("MaDV").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.TenDv).HasColumnName("TenDV").HasMaxLength(20).IsUnicode().IsRequired();
            entity.Property(x => x.DonGia).HasColumnName("DonGia").HasColumnType("money").IsRequired();
            entity.Property(x => x.SlconLai).HasColumnName("SLConLai");
            entity.Property(x => x.LoaiDv).HasColumnName("LoaiDV").HasMaxLength(20).IsUnicode().IsRequired();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
        });

        modelBuilder.Entity<CTDV>(entity =>
        {
            entity.ToTable("CTDV", t => t.HasTrigger("CapNhatGiaDV"));
            entity.HasKey(x => new { x.MaCtdp, x.MaDv });
            entity.Property(x => x.MaCtdp).HasColumnName("MaCTDP").HasMaxLength(7).IsUnicode().IsRequired();
            entity.Property(x => x.MaDv).HasColumnName("MaDV").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.Sl).HasColumnName("SL").IsRequired();
            entity.Property(x => x.DonGia).HasColumnName("DonGia").HasColumnType("money");
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
            entity.Property(x => x.ThanhTien).HasColumnName("ThanhTien").HasColumnType("money");
            entity.HasOne(x => x.MaCtdpNavigation).WithMany(x => x.Ctdvs).HasForeignKey(x => x.MaCtdp).HasPrincipalKey(x => x.MaCtdp);
            entity.HasOne(x => x.MaDvNavigation).WithMany().HasForeignKey(x => x.MaDv).HasPrincipalKey(x => x.MaDv);
        });
    }
}

