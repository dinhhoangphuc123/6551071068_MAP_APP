using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _6551071068_MAP_APP.Data;
using _6551071068_MAP_APP.UI;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class BookingListControl : UserControl
{
    private Panel pnlHeader = null!;
    private Panel pnlActions = null!;
    private DataGridView dgvBookings = null!;
    private TextBox txtSearch = null!;
    private ComboBox cbTrangThai = null!;
    private Button btnDatPhongMoi = null!;
    private Button btnCheckIn = null!;
    private Button btnThemDichVu = null!;
    private Button btnCheckOut = null!;
    private Button btnHuyPhong = null!;
    private Button btnLamMoi = null!;
    private Button btnXuatExcel = null!;
    private Label lblSummary = null!;

    public BookingListControl()
    {
        InitializeComponent();
        _ = LoadDanhSachDatPhongAsync();
    }

    private void InitializeComponent()
    {
        Dock = DockStyle.Fill;
        BackColor = Color.FromArgb(245, 248, 250);

        // Header
        pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = Color.White,
            Padding = new Padding(20, 10, 20, 10)
        };

        var lblTitle = new Label
        {
            Text = "QUẢN LÝ ĐẶT PHÒNG & THUÊ PHÒNG",
            Font = new Font("Segoe UI", 15F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 128, 128),
            Location = new Point(15, 8),
            AutoSize = true
        };

        lblSummary = new Label
        {
            Text = "Đang tải dữ liệu...",
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
            ForeColor = Color.Gray,
            Location = new Point(18, 40),
            AutoSize = true
        };

        pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblSummary });

        // Actions & Filters Toolbar
        pnlActions = new Panel
        {
            Dock = DockStyle.Top,
            Height = 55,
            BackColor = Color.White,
            Padding = new Padding(15, 8, 15, 8)
        };

        var lblTim = new Label { Text = "Tìm kiếm:", Location = new Point(15, 16), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        txtSearch = new TextBox
        {
            Location = new Point(80, 13),
            Width = 180,
            Font = new Font("Segoe UI", 10F),
            PlaceholderText = "Phòng, Tên KH, SĐT..."
        };
        txtSearch.TextChanged += async (_, _) => await LoadDanhSachDatPhongAsync();

        var lblLoc = new Label { Text = "Trạng thái:", Location = new Point(275, 16), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        cbTrangThai = new ComboBox
        {
            Location = new Point(350, 13),
            Width = 135,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = new Font("Segoe UI", 9.5F)
        };
        cbTrangThai.Items.AddRange(new object[] { "Tất cả", "Đặt trước", "Đang thuê", "Đã trả phòng", "Đã hủy" });
        cbTrangThai.SelectedIndex = 0;
        cbTrangThai.SelectedIndexChanged += async (_, _) => await LoadDanhSachDatPhongAsync();

        btnDatPhongMoi = TaoNut("Đặt phòng mới", Color.FromArgb(0, 139, 139), Color.White, 120, 500);
        btnDatPhongMoi.Click += BtnDatPhongMoi_Click;

        btnCheckIn = TaoNut("Nhận phòng", Color.FromArgb(46, 139, 87), Color.White, 110, 628);
        btnCheckIn.Click += BtnCheckIn_Click;

        btnThemDichVu = TaoNut("Thêm dịch vụ", Color.FromArgb(70, 130, 180), Color.White, 110, 746);
        btnThemDichVu.Click += BtnThemDichVu_Click;

        btnCheckOut = TaoNut("Trả phòng", Color.FromArgb(220, 100, 50), Color.White, 105, 864);
        btnCheckOut.Click += BtnCheckOut_Click;

        btnHuyPhong = TaoNut("Hủy lịch", Color.FromArgb(178, 34, 34), Color.White, 95, 977);
        btnHuyPhong.Click += BtnHuyPhong_Click;

        btnLamMoi = TaoNut("Làm mới", Color.LightGray, Color.Black, 85, 1080);
        btnLamMoi.Click += async (_, _) => await LoadDanhSachDatPhongAsync();

        btnXuatExcel = TaoNut("Xuất Excel", Color.FromArgb(34, 139, 34), Color.White, 100, 1173);
        btnXuatExcel.Click += BtnXuatExcel_Click;

        pnlActions.Controls.AddRange(new Control[]
        {
            lblTim, txtSearch, lblLoc, cbTrangThai,
            btnDatPhongMoi, btnCheckIn, btnThemDichVu, btnCheckOut, btnHuyPhong, btnLamMoi, btnXuatExcel
        });

        // Grid
        dgvBookings = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            MultiSelect = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            RowHeadersVisible = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            RowTemplate = { Height = 36 },
            Font = new Font("Segoe UI", 9.5F)
        };
        dgvBookings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 128, 128);
        dgvBookings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvBookings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        dgvBookings.ColumnHeadersHeight = 38;
        dgvBookings.EnableHeadersVisualStyles = false;

        dgvBookings.Columns.Add("MaCTDP", "Mã CTDP");
        dgvBookings.Columns.Add("MaPH", "Phòng");
        dgvBookings.Columns.Add("LoaiPhong", "Loại phòng");
        dgvBookings.Columns.Add("KhachHang", "Khách hàng");
        dgvBookings.Columns.Add("SDT", "Số điện thoại");
        dgvBookings.Columns.Add("SoKhach", "Khách");
        dgvBookings.Columns.Add("CheckIn", "Nhận phòng");
        dgvBookings.Columns.Add("CheckOut", "Trả phòng");
        dgvBookings.Columns.Add("TrangThai", "Trạng thái");
        dgvBookings.Columns.Add("TienPhong", "Tiền phòng");
        dgvBookings.Columns.Add("TienDichVu", "Tiền dịch vụ");
        dgvBookings.Columns.Add("TongTien", "Tổng cộng");

        dgvBookings.Columns["MaCTDP"]!.FillWeight = 11;
        dgvBookings.Columns["MaPH"]!.FillWeight = 8;
        dgvBookings.Columns["LoaiPhong"]!.FillWeight = 13;
        dgvBookings.Columns["KhachHang"]!.FillWeight = 18;
        dgvBookings.Columns["SDT"]!.FillWeight = 12;
        dgvBookings.Columns["SoKhach"]!.FillWeight = 7;
        dgvBookings.Columns["CheckIn"]!.FillWeight = 16;
        dgvBookings.Columns["CheckOut"]!.FillWeight = 16;
        dgvBookings.Columns["TrangThai"]!.FillWeight = 13;
        dgvBookings.Columns["TienPhong"]!.FillWeight = 13;
        dgvBookings.Columns["TienDichVu"]!.FillWeight = 13;
        dgvBookings.Columns["TongTien"]!.FillWeight = 14;

        dgvBookings.Columns["SoKhach"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvBookings.Columns["CheckIn"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        dgvBookings.Columns["CheckOut"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        dgvBookings.Columns["TienPhong"]!.DefaultCellStyle.Format = "N0";
        dgvBookings.Columns["TienDichVu"]!.DefaultCellStyle.Format = "N0";
        dgvBookings.Columns["TongTien"]!.DefaultCellStyle.Format = "N0";
        dgvBookings.Columns["TienPhong"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvBookings.Columns["TienDichVu"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvBookings.Columns["TongTien"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvBookings.Columns["TrangThai"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        dgvBookings.CellFormatting += DgvBookings_CellFormatting;
        dgvBookings.SelectionChanged += DgvBookings_SelectionChanged;

        Controls.Add(dgvBookings);
        Controls.Add(pnlActions);
        Controls.Add(pnlHeader);
    }

    private Button TaoNut(string text, Color back, Color fore, int width, int left)
    {
        var btn = new Button
        {
            Text = text,
            Location = new Point(left, 10),
            Size = new Size(width, 35),
            BackColor = back,
            ForeColor = fore,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }

    private async Task LoadDanhSachDatPhongAsync()
    {
        try
        {
            string keyword = txtSearch?.Text.Trim() ?? "";
            string statusFilter = cbTrangThai?.SelectedItem?.ToString() ?? "Tất cả";

            await using var db = new HotelManagementContext();
            var query = db.Ctdps
                .AsNoTracking()
                .Where(c => c.DaXoa != true);

            if (statusFilter != "Tất cả")
            {
                query = query.Where(c => c.TrangThai == statusFilter);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c =>
                    c.MaPh.Contains(keyword) ||
                    c.MaCtdp.Contains(keyword) ||
                    (c.MaPtNavigation != null && c.MaPtNavigation.MaKhNavigation != null &&
                        (c.MaPtNavigation.MaKhNavigation.TenKh.Contains(keyword) ||
                         (c.MaPtNavigation.MaKhNavigation.Sdt != null && c.MaPtNavigation.MaKhNavigation.Sdt.Contains(keyword)))));
            }

            var ds = await query
                .OrderByDescending(c => c.CheckIn)
                .Select(c => new
                {
                    c.MaCtdp,
                    c.MaPh,
                    TenLoaiPhong = c.MaPhNavigation != null && c.MaPhNavigation.MaLphNavigation != null
                        ? c.MaPhNavigation.MaLphNavigation.TenLph : "",
                    TenKhachHang = c.MaPtNavigation != null && c.MaPtNavigation.MaKhNavigation != null
                        ? c.MaPtNavigation.MaKhNavigation.TenKh : "Khách lẻ",
                    Sdt = c.MaPtNavigation != null && c.MaPtNavigation.MaKhNavigation != null
                        ? c.MaPtNavigation.MaKhNavigation.Sdt : "",
                    SoKhach = c.SoNguoi ?? 1,
                    c.CheckIn,
                    c.CheckOut,
                    c.TrangThai,
                    GiaNgay = c.MaPhNavigation != null && c.MaPhNavigation.MaLphNavigation != null
                        ? c.MaPhNavigation.MaLphNavigation.GiaNgay : (c.DonGia ?? 0),
                    TienDichVu = db.Ctdvs.Where(dv => dv.MaCtdp == c.MaCtdp && dv.DaXoa != true)
                        .Sum(dv => dv.ThanhTien ?? ((dv.DonGia ?? 0) * dv.Sl))
                })
                .ToListAsync();

            dgvBookings.Rows.Clear();
            int demDatTruoc = 0, demDangThue = 0;

            foreach (var item in ds)
            {
                if (item.TrangThai == "Đặt trước") demDatTruoc++;
                if (item.TrangThai == "Đang thuê") demDangThue++;

                int soNgay = Math.Max(1, (int)Math.Ceiling((item.CheckOut - item.CheckIn).TotalDays));
                decimal tienPhong = item.GiaNgay * soNgay;
                decimal tong = tienPhong + item.TienDichVu;

                dgvBookings.Rows.Add(
                    item.MaCtdp,
                    item.MaPh,
                    item.TenLoaiPhong,
                    item.TenKhachHang,
                    item.Sdt ?? "",
                    item.SoKhach,
                    item.CheckIn,
                    item.CheckOut,
                    item.TrangThai,
                    tienPhong,
                    item.TienDichVu,
                    tong
                );
            }

            lblSummary.Text = $"Tổng cộng: {ds.Count} lượt đặt | Đang thuê: {demDangThue} phòng | Đặt trước: {demDatTruoc} lượt";
            CapNhatTrangThaiNut();
        }
        catch (Exception ex)
        {
            lblSummary.Text = "Lỗi tải dữ liệu: " + ex.Message;
        }
    }

    private void DgvBookings_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvBookings.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
        {
            string tt = e.Value.ToString() ?? "";
            switch (tt)
            {
                case "Đang thuê":
                    e.CellStyle!.BackColor = Color.FromArgb(230, 248, 235);
                    e.CellStyle.ForeColor = Color.FromArgb(0, 128, 0);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    break;
                case "Đặt trước":
                    e.CellStyle!.BackColor = Color.FromArgb(255, 245, 230);
                    e.CellStyle.ForeColor = Color.FromArgb(210, 105, 30);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    break;
                case "Đã trả phòng":
                    e.CellStyle!.BackColor = Color.FromArgb(240, 240, 240);
                    e.CellStyle.ForeColor = Color.FromArgb(100, 100, 100);
                    break;
                case "Đã hủy":
                    e.CellStyle!.BackColor = Color.FromArgb(255, 235, 235);
                    e.CellStyle.ForeColor = Color.FromArgb(180, 0, 0);
                    break;
            }
        }
    }

    private void DgvBookings_SelectionChanged(object? sender, EventArgs e)
    {
        CapNhatTrangThaiNut();
    }

    private void CapNhatTrangThaiNut()
    {
        if (dgvBookings.CurrentRow == null || dgvBookings.CurrentRow.IsNewRow)
        {
            btnCheckIn.Enabled = false;
            btnThemDichVu.Enabled = false;
            btnCheckOut.Enabled = false;
            btnHuyPhong.Enabled = false;
            return;
        }

        string tt = dgvBookings.CurrentRow.Cells["TrangThai"].Value?.ToString() ?? "";
        btnCheckIn.Enabled = (tt == "Đặt trước");
        btnThemDichVu.Enabled = (tt == "Đang thuê");
        btnCheckOut.Enabled = (tt == "Đang thuê");
        btnHuyPhong.Enabled = (tt == "Đặt trước");
    }

    private async void BtnDatPhongMoi_Click(object? sender, EventArgs e)
    {
        using var form = new HotelManagement.SoDoPhong.FormDatPhong();
        if (form.ShowDialog(FindForm()) == DialogResult.OK)
        {
            await LoadDanhSachDatPhongAsync();
        }
    }

    private async void BtnCheckIn_Click(object? sender, EventArgs e)
    {
        if (dgvBookings.CurrentRow == null) return;
        string maCtdp = dgvBookings.CurrentRow.Cells["MaCTDP"].Value?.ToString() ?? "";
        string maPh = dgvBookings.CurrentRow.Cells["MaPH"].Value?.ToString() ?? "";
        string tenKh = dgvBookings.CurrentRow.Cells["KhachHang"].Value?.ToString() ?? "";

        var confirm = MessageBox.Show(
            $"Xác nhận làm thủ tục Nhận phòng (Check-in) cho khách {tenKh} vào phòng {maPh}?",
            "Xác nhận nhận phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        try
        {
            await using var db = new HotelManagementContext();
            var ctdp = await db.Ctdps.FirstOrDefaultAsync(c => c.MaCtdp == maCtdp);
            if (ctdp == null) return;

            ctdp.TrangThai = "Đang thuê";
            ctdp.CheckIn = DateTime.Now;

            var phong = await db.Phongs.FirstOrDefaultAsync(p => p.MaPh == maPh);
            if (phong != null)
            {
                phong.Ttph = "Đang thuê";
            }

            await db.SaveChangesAsync();
            MessageBox.Show($"Nhận phòng {maPh} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDanhSachDatPhongAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi nhận phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnThemDichVu_Click(object? sender, EventArgs e)
    {
        if (dgvBookings.CurrentRow == null) return;
        string maCtdp = dgvBookings.CurrentRow.Cells["MaCTDP"].Value?.ToString() ?? "";
        string maPh = dgvBookings.CurrentRow.Cells["MaPH"].Value?.ToString() ?? "";

        using var dialog = new AddServiceDialog(maCtdp, maPh);
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
        {
            await LoadDanhSachDatPhongAsync();
        }
    }

    private async void BtnCheckOut_Click(object? sender, EventArgs e)
    {
        if (dgvBookings.CurrentRow == null) return;
        string maCtdp = dgvBookings.CurrentRow.Cells["MaCTDP"].Value?.ToString() ?? "";

        using var dialog = new CheckoutDialog(maCtdp);
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
        {
            await LoadDanhSachDatPhongAsync();
        }
    }

    private async void BtnHuyPhong_Click(object? sender, EventArgs e)
    {
        if (dgvBookings.CurrentRow == null) return;
        string maCtdp = dgvBookings.CurrentRow.Cells["MaCTDP"].Value?.ToString() ?? "";
        string maPh = dgvBookings.CurrentRow.Cells["MaPH"].Value?.ToString() ?? "";

        var confirm = MessageBox.Show(
            $"Bạn có chắc chắn muốn HỦY lịch đặt phòng {maPh} (Mã CTDP: {maCtdp})?",
            "Xác nhận hủy đặt phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (confirm != DialogResult.Yes) return;

        try
        {
            await using var db = new HotelManagementContext();
            var ctdp = await db.Ctdps.FirstOrDefaultAsync(c => c.MaCtdp == maCtdp);
            if (ctdp == null) return;

            ctdp.TrangThai = "Đã hủy";
            await db.SaveChangesAsync();

            MessageBox.Show($"Đã hủy lịch đặt phòng {maPh} thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDanhSachDatPhongAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi hủy lịch đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnXuatExcel_Click(object? sender, EventArgs e)
    {
        if (dgvBookings.Rows.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = $"DanhSachDatPhong_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
        };

        if (dialog.ShowDialog(FindForm()) != DialogResult.OK) return;

        try
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("DatPhong");

            for (int col = 0; col < dgvBookings.Columns.Count; col++)
            {
                ws.Cell(1, col + 1).Value = dgvBookings.Columns[col].HeaderText;
                ws.Cell(1, col + 1).Style.Font.Bold = true;
                ws.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#008080");
                ws.Cell(1, col + 1).Style.Font.FontColor = XLColor.White;
            }

            for (int row = 0; row < dgvBookings.Rows.Count; row++)
            {
                for (int col = 0; col < dgvBookings.Columns.Count; col++)
                {
                    ws.Cell(row + 2, col + 1).Value = dgvBookings.Rows[row].Cells[col].Value?.ToString() ?? "";
                }
            }

            ws.Columns().AdjustToContents();
            wb.SaveAs(dialog.FileName);

            MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
