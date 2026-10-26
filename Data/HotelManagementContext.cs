using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Data;

/// <summary>
/// EF Core mapping for the HotelManagement database described in the lab manual.
/// The application uses the existing database and does not run migrations.
/// </summary>
public sealed class HotelManagementContext : DbContext
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
                .WithMany()
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

        modelBuilder.Entity<CTDP>(entity =>
        {
            entity.ToTable("CTDP");
            entity.HasKey(x => x.MaCtdp);
            entity.Property(x => x.MaCtdp).HasColumnName("MaCTDP").HasMaxLength(7).IsUnicode().IsRequired();
            entity.Property(x => x.MaPh).HasColumnName("MaPH").HasMaxLength(5).IsUnicode().IsRequired();
            entity.Property(x => x.Checkin).HasColumnName("CheckIn").HasColumnType("smalldatetime").IsRequired();
            entity.Property(x => x.CheckOut).HasColumnName("CheckOut").HasColumnType("smalldatetime").IsRequired();
            entity.Property(x => x.DaXoa).HasColumnName("DaXoa");
            entity.HasOne(x => x.MaPhNavigation)
                .WithMany(x => x.Ctdps)
                .HasForeignKey(x => x.MaPh)
                .HasPrincipalKey(x => x.MaPh);
        });
    }
}

public sealed class NhanVien
{
    public string MaNv { get; set; } = string.Empty;
    public string TenNv { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
}

public sealed class TaiKhoan
{
    public string TenTk { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int CapDoQuyen { get; set; }
    public string MaNv { get; set; } = string.Empty;
    public bool? DaXoa { get; set; }
    public NhanVien? MaNvNavigation { get; set; }
}

public sealed class LoaiPhong
{
    public string MaLph { get; set; } = string.Empty;
    public string TenLph { get; set; } = string.Empty;
    public int SoGiuong { get; set; }
    public int SoNguoiToiDa { get; set; }
    public decimal GiaNgay { get; set; }
    public decimal GiaGio { get; set; }
    public ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}

public sealed class Phong
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

public sealed class CTDP
{
    public string MaCtdp { get; set; } = string.Empty;
    public string MaPh { get; set; } = string.Empty;
    public DateTime Checkin { get; set; }
    public DateTime CheckOut { get; set; }
    public bool? DaXoa { get; set; }
    public Phong? MaPhNavigation { get; set; }
}
