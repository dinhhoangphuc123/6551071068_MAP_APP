using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _6551071068_MAP_APP.Data;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class CheckoutDialog : Form
{
    private readonly string _maCtdp;
    private decimal _tienPhong;
    private decimal _tienDichVu;
    private decimal _tongTien;
    private string _maPhong = string.Empty;

    private Label lblKhachHang = null!;
    private Label lblPhong = null!;
    private Label lblThoiGian = null!;
    private Label lblTienPhong = null!;
    private Label lblTienDichVu = null!;
    private Label lblTongTien = null!;
    private DataGridView dgvDichVu = null!;
    private Button btnThanhToan = null!;
    private Button btnDong = null!;

    public CheckoutDialog(string maCtdp)
    {
        _maCtdp = maCtdp;
        InitializeComponent();
        LoadThongTinThanhToan();
    }

    private void InitializeComponent()
    {
        Text = "Thanh toán & Trả phòng (Check-out)";
        Size = new Size(650, 620);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        BackColor = Color.White;

        var lblHeader = new Label
        {
            Text = "HÓA ĐƠN THANH TOÁN & TRẢ PHÒNG",
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 128, 128),
            Dock = DockStyle.Top,
            Height = 45,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var pnlContent = new Panel { Dock = DockStyle.Fill, Padding = new Padding(25, 10, 25, 10) };

        var grpThongTin = new GroupBox
        {
            Text = "Thông tin thuê phòng",
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
            Location = new Point(25, 10),
            Size = new Size(580, 115)
        };

        lblKhachHang = new Label { Location = new Point(15, 25), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        lblPhong = new Label { Location = new Point(15, 52), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        lblThoiGian = new Label { Location = new Point(15, 79), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        grpThongTin.Controls.AddRange(new Control[] { lblKhachHang, lblPhong, lblThoiGian });

        var lblTitleDv = new Label
        {
            Text = "Dịch vụ đã sử dụng trong kỳ nghỉ:",
            Location = new Point(25, 135),
            AutoSize = true,
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold)
        };

        dgvDichVu = new DataGridView
        {
            Location = new Point(25, 160),
            Size = new Size(580, 160),
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            RowHeadersVisible = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.Fixed3D
        };
        dgvDichVu.Columns.Add("TenDV", "Tên dịch vụ");
        dgvDichVu.Columns.Add("DonGia", "Đơn giá");
        dgvDichVu.Columns.Add("SL", "Số lượng");
        dgvDichVu.Columns.Add("ThanhTien", "Thành tiền");
        dgvDichVu.Columns["DonGia"]!.DefaultCellStyle.Format = "N0";
        dgvDichVu.Columns["ThanhTien"]!.DefaultCellStyle.Format = "N0";
        dgvDichVu.Columns["DonGia"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvDichVu.Columns["ThanhTien"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvDichVu.Columns["SL"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        var grpTongKet = new GroupBox
        {
            Text = "Tổng kết chi phí",
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
            Location = new Point(25, 330),
            Size = new Size(580, 130)
        };

        lblTienPhong = new Label { Location = new Point(20, 25), AutoSize = true, Font = new Font("Segoe UI", 10F) };
        lblTienDichVu = new Label { Location = new Point(20, 52), AutoSize = true, Font = new Font("Segoe UI", 10F) };
        lblTongTien = new Label
        {
            Location = new Point(20, 85),
            AutoSize = true,
            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
            ForeColor = Color.DarkRed
        };
        grpTongKet.Controls.AddRange(new Control[] { lblTienPhong, lblTienDichVu, lblTongTien });

        btnThanhToan = new Button
        {
            Text = "Xác nhận Thanh toán & Trả phòng",
            Location = new Point(140, 480),
            Size = new Size(290, 42),
            BackColor = Color.FromArgb(0, 139, 139),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnThanhToan.FlatAppearance.BorderSize = 0;
        btnThanhToan.Click += BtnThanhToan_Click;

        btnDong = new Button
        {
            Text = "Đóng",
            Location = new Point(445, 480),
            Size = new Size(100, 42),
            BackColor = Color.LightGray,
            ForeColor = Color.Black,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F),
            Cursor = Cursors.Hand
        };
        btnDong.FlatAppearance.BorderSize = 0;
        btnDong.Click += (_, _) => Close();

        pnlContent.Controls.AddRange(new Control[]
        {
            grpThongTin, lblTitleDv, dgvDichVu, grpTongKet, btnThanhToan, btnDong
        });

        Controls.Add(pnlContent);
        Controls.Add(lblHeader);
    }

    private void LoadThongTinThanhToan()
    {
        try
        {
            using var db = new HotelManagementContext();
            var ctdp = db.Ctdps
                .Include(c => c.MaPhNavigation)
                    .ThenInclude(p => p!.MaLphNavigation)
                .Include(c => c.MaPtNavigation)
                    .ThenInclude(pt => pt!.MaKhNavigation)
                .FirstOrDefault(c => c.MaCtdp == _maCtdp);

            if (ctdp == null)
            {
                MessageBox.Show("Không tìm thấy thông tin lượt thuê phòng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            _maPhong = ctdp.MaPh;
            var kh = ctdp.MaPtNavigation?.MaKhNavigation;
            var phong = ctdp.MaPhNavigation;
            var loaiPhong = phong?.MaLphNavigation;

            lblKhachHang.Text = $"Khách hàng: {kh?.TenKh ?? "Chưa rõ"} | SĐT: {kh?.Sdt ?? "-"} | CCCD: {kh?.CccdPassport ?? "-"}";
            lblPhong.Text = $"Phòng: {_maPhong} ({loaiPhong?.TenLph ?? "Tiêu chuẩn"}) | Giá: {loaiPhong?.GiaNgay:N0} VNĐ/ngày";

            DateTime gioVao = ctdp.CheckIn;
            DateTime gioRa = DateTime.Now;
            if (gioRa < gioVao) gioRa = gioVao.AddHours(2);

            int soNgayThue = Math.Max(1, (int)Math.Ceiling((gioRa - gioVao).TotalDays));
            decimal giaNgay = loaiPhong?.GiaNgay ?? 0;
            _tienPhong = giaNgay * soNgayThue;

            lblThoiGian.Text = $"Nhận phòng: {gioVao:dd/MM/yyyy HH:mm} | Trả phòng: {gioRa:dd/MM/yyyy HH:mm} ({soNgayThue} ngày)";
            lblTienPhong.Text = $"Tiền phòng ({soNgayThue} ngày x {giaNgay:N0} VNĐ): {_tienPhong:N0} VNĐ";

            // Load Dịch vụ đã dùng (CTDV)
            var dsDv = db.Ctdvs
                .AsNoTracking()
                .Where(c => c.MaCtdp == _maCtdp && c.DaXoa != true)
                .Include(c => c.MaDvNavigation)
                .ToList();

            dgvDichVu.Rows.Clear();
            _tienDichVu = 0;
            foreach (var d in dsDv)
            {
                decimal tt = d.ThanhTien ?? ((d.DonGia ?? 0) * d.Sl);
                _tienDichVu += tt;
                dgvDichVu.Rows.Add(d.MaDvNavigation?.TenDv ?? d.MaDv, d.DonGia ?? 0, d.Sl, tt);
            }

            lblTienDichVu.Text = $"Tiền dịch vụ ({dsDv.Count} món): {_tienDichVu:N0} VNĐ";
            _tongTien = _tienPhong + _tienDichVu;
            lblTongTien.Text = $"TỔNG THANH TOÁN: {_tongTien:N0} VNĐ";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tính tiền phòng: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnThanhToan_Click(object? sender, EventArgs e)
    {
        var xacNhan = MessageBox.Show(
            $"Xác nhận khách hàng đã thanh toán đủ {_tongTien:N0} VNĐ và hoàn tất trả phòng {_maPhong}?",
            "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (xacNhan != DialogResult.Yes) return;

        try
        {
            using var db = new HotelManagementContext();
            var ctdp = db.Ctdps.FirstOrDefault(c => c.MaCtdp == _maCtdp);
            if (ctdp == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu lượt đặt phòng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var phong = db.Phongs.FirstOrDefault(p => p.MaPh == _maPhong);

            // Sinh mã hóa đơn HDxxx
            var cacMaHd = db.HoaDons.Select(h => h.MaHd).ToList();
            int lonNhat = 0;
            foreach (var ma in cacMaHd)
            {
                string digits = new string(ma.Where(char.IsDigit).ToArray());
                if (int.TryParse(digits, out int val) && val > lonNhat)
                    lonNhat = val;
            }
            int tiep = lonNhat + 1;
            string maHD = "HD" + tiep.ToString("D3");
            if (maHD.Length > 5)
            {
                maHD = "H" + tiep.ToString("D4");
                if (maHD.Length > 5) maHD = maHD.Substring(maHD.Length - 5);
            }

            string maNV = LoginForm.MaNvDangNhap;
            if (string.IsNullOrWhiteSpace(maNV)) maNV = "AD001";

            // Tạo hóa đơn ghi nhận doanh thu (N4)
            db.HoaDons.Add(new HotelManagement.Models.HoaDon
            {
                MaHd = maHD,
                NgHd = DateTime.Now,
                TriGia = _tongTien,
                MaNv = maNV,
                TrangThai = "Đã thanh toán",
                MaCtdp = _maCtdp,
                DaXoa = false
            });

            // Cập nhật trạng thái lượt thuê và giải phóng phòng (N1, N3)
            ctdp.TrangThai = "Đã trả phòng";
            ctdp.CheckOut = DateTime.Now;
            ctdp.ThanhTien = _tienPhong;

            if (phong != null)
            {
                phong.Ttph = "Bình thường";
            }

            db.SaveChanges();

            MessageBox.Show(
                $"Thanh toán thành công!\nMã hóa đơn: {maHD}\nSố tiền: {_tongTien:N0} VNĐ\nPhòng {_maPhong} đã sẵn sàng đón khách tiếp theo.",
                "Thanh toán hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi lưu hóa đơn: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
