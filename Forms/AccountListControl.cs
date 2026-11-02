using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _6551071068_MAP_APP.Data;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class AccountListControl : UserControl
{
    private Panel pnlHeader = null!;
    private Panel pnlActions = null!;
    private DataGridView dgvAccounts = null!;
    private TextBox txtSearch = null!;
    private ComboBox cbCapQuyen = null!;
    private Button btnDoiMatKhau = null!;
    private Button btnPhanQuyen = null!;
    private Button btnKhoaMoKhoa = null!;
    private Button btnLamMoi = null!;
    private Button btnXuatExcel = null!;
    private Label lblSummary = null!;

    public AccountListControl()
    {
        InitializeComponent();
        _ = LoadDanhSachTaiKhoanAsync();
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
            Text = "QUẢN LÝ TÀI KHOẢN & PHÂN QUYỀN",
            Font = new Font("Segoe UI", 15F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 128, 128),
            Location = new Point(15, 8),
            AutoSize = true
        };

        lblSummary = new Label
        {
            Text = "Đang tải danh sách tài khoản...",
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
            Width = 190,
            Font = new Font("Segoe UI", 10F),
            PlaceholderText = "Tên TK, Tên NV, Mã NV..."
        };
        txtSearch.TextChanged += async (_, _) => await LoadDanhSachTaiKhoanAsync();

        var lblLoc = new Label { Text = "Quyền:", Location = new Point(285, 16), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        cbCapQuyen = new ComboBox
        {
            Location = new Point(340, 13),
            Width = 140,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = new Font("Segoe UI", 9.5F)
        };
        cbCapQuyen.Items.AddRange(new object[] { "Tất cả", "Cấp 1 - Nhân viên", "Cấp 2 - Quản lý", "Cấp 3 - Quản trị" });
        cbCapQuyen.SelectedIndex = 0;
        cbCapQuyen.SelectedIndexChanged += async (_, _) => await LoadDanhSachTaiKhoanAsync();

        btnDoiMatKhau = TaoNut("Đổi mật khẩu", Color.FromArgb(70, 130, 180), Color.White, 115, 500);
        btnDoiMatKhau.Click += BtnDoiMatKhau_Click;

        btnPhanQuyen = TaoNut("Phân quyền", Color.FromArgb(0, 139, 139), Color.White, 105, 625);
        btnPhanQuyen.Click += BtnPhanQuyen_Click;

        btnKhoaMoKhoa = TaoNut("Khóa / Mở khóa", Color.FromArgb(205, 92, 92), Color.White, 125, 740);
        btnKhoaMoKhoa.Click += BtnKhoaMoKhoa_Click;

        btnLamMoi = TaoNut("Làm mới", Color.LightGray, Color.Black, 85, 875);
        btnLamMoi.Click += async (_, _) => await LoadDanhSachTaiKhoanAsync();

        btnXuatExcel = TaoNut("Xuất Excel", Color.FromArgb(34, 139, 34), Color.White, 100, 970);
        btnXuatExcel.Click += BtnXuatExcel_Click;

        pnlActions.Controls.AddRange(new Control[]
        {
            lblTim, txtSearch, lblLoc, cbCapQuyen,
            btnDoiMatKhau, btnPhanQuyen, btnKhoaMoKhoa, btnLamMoi, btnXuatExcel
        });

        // Grid
        dgvAccounts = new DataGridView
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
        dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 128, 128);
        dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvAccounts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        dgvAccounts.ColumnHeadersHeight = 38;
        dgvAccounts.EnableHeadersVisualStyles = false;

        dgvAccounts.Columns.Add("TenTK", "Tên đăng nhập");
        dgvAccounts.Columns.Add("MaNV", "Mã NV");
        dgvAccounts.Columns.Add("TenNV", "Họ và tên nhân viên");
        dgvAccounts.Columns.Add("ChucVu", "Chức vụ");
        dgvAccounts.Columns.Add("Email", "Email");
        dgvAccounts.Columns.Add("CapDoQuyen", "Cấp quyền");
        dgvAccounts.Columns.Add("TrangThai", "Trạng thái");

        dgvAccounts.Columns["TenTK"]!.FillWeight = 20;
        dgvAccounts.Columns["MaNV"]!.FillWeight = 10;
        dgvAccounts.Columns["TenNV"]!.FillWeight = 22;
        dgvAccounts.Columns["ChucVu"]!.FillWeight = 15;
        dgvAccounts.Columns["Email"]!.FillWeight = 20;
        dgvAccounts.Columns["CapDoQuyen"]!.FillWeight = 15;
        dgvAccounts.Columns["TrangThai"]!.FillWeight = 12;

        dgvAccounts.Columns["MaNV"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvAccounts.Columns["CapDoQuyen"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgvAccounts.Columns["TrangThai"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        dgvAccounts.CellFormatting += DgvAccounts_CellFormatting;

        Controls.Add(dgvAccounts);
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

    private async Task LoadDanhSachTaiKhoanAsync()
    {
        try
        {
            string keyword = txtSearch?.Text.Trim() ?? "";
            string quyenFilter = cbCapQuyen?.SelectedItem?.ToString() ?? "Tất cả";

            await using var db = new HotelManagementContext();
            var query = db.TaiKhoans.AsNoTracking();

            if (quyenFilter.StartsWith("Cấp 1")) query = query.Where(t => t.CapDoQuyen == 1);
            else if (quyenFilter.StartsWith("Cấp 2")) query = query.Where(t => t.CapDoQuyen == 2);
            else if (quyenFilter.StartsWith("Cấp 3")) query = query.Where(t => t.CapDoQuyen == 3);

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(t =>
                    t.TenTk.Contains(keyword) ||
                    t.MaNv.Contains(keyword) ||
                    (t.MaNvNavigation != null &&
                        (t.MaNvNavigation.TenNv.Contains(keyword) ||
                         (t.MaNvNavigation.Email != null && t.MaNvNavigation.Email.Contains(keyword)))));
            }

            var ds = await query
                .OrderBy(t => t.MaNv)
                .Select(t => new
                {
                    t.TenTk,
                    t.MaNv,
                    TenNv = t.MaNvNavigation != null ? t.MaNvNavigation.TenNv : "(Chưa gán)",
                    ChucVu = t.MaNvNavigation != null ? t.MaNvNavigation.ChucVu : "-",
                    Email = t.MaNvNavigation != null && t.MaNvNavigation.Email != null ? t.MaNvNavigation.Email : "-",
                    t.CapDoQuyen,
                    DaKhoa = t.DaXoa == true || (t.MaNvNavigation != null && t.MaNvNavigation.DaXoa == true)
                })
                .ToListAsync();

            dgvAccounts.Rows.Clear();
            int hoatDong = 0, biKhoa = 0;

            foreach (var a in ds)
            {
                string tenQuyen = a.CapDoQuyen switch
                {
                    3 => "Cấp 3 - Quản trị",
                    2 => "Cấp 2 - Quản lý",
                    _ => "Cấp 1 - Nhân viên"
                };

                string trangThai = a.DaKhoa ? "Đã khóa" : "Hoạt động";
                if (a.DaKhoa) biKhoa++; else hoatDong++;

                dgvAccounts.Rows.Add(
                    a.TenTk,
                    a.MaNv,
                    a.TenNv,
                    a.ChucVu,
                    a.Email,
                    tenQuyen,
                    trangThai
                );
            }

            lblSummary.Text = $"Tổng số: {ds.Count} tài khoản | Đang hoạt động: {hoatDong} | Đã khóa: {biKhoa}";
        }
        catch (Exception ex)
        {
            lblSummary.Text = "Lỗi tải tài khoản: " + ex.Message;
        }
    }

    private void DgvAccounts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvAccounts.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
        {
            if (e.Value.ToString() == "Hoạt động")
            {
                e.CellStyle!.BackColor = Color.FromArgb(235, 250, 238);
                e.CellStyle.ForeColor = Color.DarkGreen;
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
            else
            {
                e.CellStyle!.BackColor = Color.FromArgb(255, 235, 235);
                e.CellStyle.ForeColor = Color.Red;
            }
        }
        else if (dgvAccounts.Columns[e.ColumnIndex].Name == "CapDoQuyen" && e.Value != null)
        {
            string q = e.Value.ToString() ?? "";
            if (q.Contains("Quản trị"))
            {
                e.CellStyle!.ForeColor = Color.DarkRed;
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
        }
    }

    private async void BtnDoiMatKhau_Click(object? sender, EventArgs e)
    {
        if (dgvAccounts.CurrentRow == null) return;
        string tenTk = dgvAccounts.CurrentRow.Cells["TenTK"].Value?.ToString() ?? "";
        string tenNv = dgvAccounts.CurrentRow.Cells["TenNV"].Value?.ToString() ?? "";

        using var prompt = new Form
        {
            Text = $"Đổi mật khẩu tài khoản: {tenTk}",
            Size = new Size(380, 200),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent,
            MaximizeBox = false,
            MinimizeBox = false,
            BackColor = Color.White
        };

        var lbl = new Label { Text = $"Nhập mật khẩu mới cho {tenNv} ({tenTk}):", Location = new Point(25, 20), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        var txtNew = new TextBox { Location = new Point(25, 50), Width = 310, Font = new Font("Segoe UI", 10F), UseSystemPasswordChar = true };
        var btnLuu = new Button { Text = "Xác nhận đổi", Location = new Point(135, 100), Size = new Size(110, 35), BackColor = Color.FromArgb(0, 139, 139), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Hủy", Location = new Point(255, 100), Size = new Size(80, 35), BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat, DialogResult = DialogResult.Cancel };

        prompt.Controls.AddRange(new Control[] { lbl, txtNew, btnLuu, btnCancel });

        if (prompt.ShowDialog(FindForm()) != DialogResult.OK) return;

        string passMoi = txtNew.Text.Trim();
        if (passMoi.Length < 4)
        {
            MessageBox.Show("Mật khẩu mới phải có ít nhất 4 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await using var db = new HotelManagementContext();
            var acc = await db.TaiKhoans.FirstOrDefaultAsync(t => t.TenTk == tenTk);
            if (acc == null) return;

            acc.Password = PasswordHasher.Hash(passMoi);
            await db.SaveChangesAsync();

            MessageBox.Show($"Đã đổi mật khẩu cho tài khoản {tenTk} thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnPhanQuyen_Click(object? sender, EventArgs e)
    {
        if (dgvAccounts.CurrentRow == null) return;
        string tenTk = dgvAccounts.CurrentRow.Cells["TenTK"].Value?.ToString() ?? "";
        string maNv = dgvAccounts.CurrentRow.Cells["MaNV"].Value?.ToString() ?? "";

        using var prompt = new Form
        {
            Text = $"Phân quyền tài khoản: {tenTk}",
            Size = new Size(360, 200),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent,
            MaximizeBox = false,
            MinimizeBox = false,
            BackColor = Color.White
        };

        var lbl = new Label { Text = "Chọn cấp độ quyền:", Location = new Point(25, 20), AutoSize = true, Font = new Font("Segoe UI", 9.5F) };
        var cbQuyen = new ComboBox { Location = new Point(25, 50), Width = 290, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
        cbQuyen.Items.AddRange(new object[] { "Cấp 1 - Nhân viên thường", "Cấp 2 - Quản lý khách sạn", "Cấp 3 - Quản trị viên hệ thống" });
        cbQuyen.SelectedIndex = 0;

        var btnLuu = new Button { Text = "Lưu quyền", Location = new Point(135, 100), Size = new Size(100, 35), BackColor = Color.FromArgb(0, 139, 139), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, DialogResult = DialogResult.OK };
        var btnCancel = new Button { Text = "Hủy", Location = new Point(245, 100), Size = new Size(70, 35), BackColor = Color.LightGray, FlatStyle = FlatStyle.Flat, DialogResult = DialogResult.Cancel };

        prompt.Controls.AddRange(new Control[] { lbl, cbQuyen, btnLuu, btnCancel });

        if (prompt.ShowDialog(FindForm()) != DialogResult.OK) return;

        int quyenMoi = cbQuyen.SelectedIndex + 1;

        try
        {
            await using var db = new HotelManagementContext();
            var acc = await db.TaiKhoans.FirstOrDefaultAsync(t => t.TenTk == tenTk);
            if (acc == null) return;

            // Kiểm tra không hạ quyền Admin cuối cùng (C2)
            if (acc.CapDoQuyen == 3 && quyenMoi < 3)
            {
                int soAdmin = await db.TaiKhoans.CountAsync(t => t.CapDoQuyen == 3 && t.DaXoa != true);
                if (soAdmin <= 1)
                {
                    MessageBox.Show("Không thể hạ quyền Quản trị viên cuối cùng của hệ thống!", "Từ chối",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            acc.CapDoQuyen = quyenMoi;
            await db.SaveChangesAsync();

            MessageBox.Show($"Đã cập nhật cấp quyền cho tài khoản {tenTk} thành Cấp {quyenMoi}!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDanhSachTaiKhoanAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi phân quyền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnKhoaMoKhoa_Click(object? sender, EventArgs e)
    {
        if (dgvAccounts.CurrentRow == null) return;
        string tenTk = dgvAccounts.CurrentRow.Cells["TenTK"].Value?.ToString() ?? "";
        string maNv = dgvAccounts.CurrentRow.Cells["MaNV"].Value?.ToString() ?? "";
        string trangThai = dgvAccounts.CurrentRow.Cells["TrangThai"].Value?.ToString() ?? "";

        // Chặn xóa/khóa chính mình (C2)
        if (string.Equals(maNv, LoginForm.MaNvDangNhap, StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Bạn không thể khóa tài khoản của chính mình đang đăng nhập!", "Từ chối thao tác",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        bool seKhoa = (trangThai == "Hoạt động");
        string hanhDong = seKhoa ? "KHÓA" : "MỞ KHÓA";

        var confirm = MessageBox.Show(
            $"Bạn có chắc chắn muốn {hanhDong} tài khoản {tenTk}?",
            $"Xác nhận {hanhDong.ToLower()}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes) return;

        try
        {
            await using var db = new HotelManagementContext();
            var acc = await db.TaiKhoans.FirstOrDefaultAsync(t => t.TenTk == tenTk);
            if (acc == null) return;

            // Chặn khóa admin cuối cùng (C2)
            if (seKhoa && acc.CapDoQuyen == 3)
            {
                int soAdmin = await db.TaiKhoans.CountAsync(t => t.CapDoQuyen == 3 && t.DaXoa != true);
                if (soAdmin <= 1)
                {
                    MessageBox.Show("Không thể khóa tài khoản Quản trị viên cuối cùng của hệ thống!", "Từ chối",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            acc.DaXoa = seKhoa;
            await db.SaveChangesAsync();

            MessageBox.Show($"Đã {hanhDong.ToLower()} tài khoản {tenTk} thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDanhSachTaiKhoanAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi {hanhDong.ToLower()}: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnXuatExcel_Click(object? sender, EventArgs e)
    {
        if (dgvAccounts.Rows.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = $"DanhSachTaiKhoan_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
        };

        if (dialog.ShowDialog(FindForm()) != DialogResult.OK) return;

        try
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("TaiKhoan");

            for (int col = 0; col < dgvAccounts.Columns.Count; col++)
            {
                ws.Cell(1, col + 1).Value = dgvAccounts.Columns[col].HeaderText;
                ws.Cell(1, col + 1).Style.Font.Bold = true;
                ws.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#008080");
                ws.Cell(1, col + 1).Style.Font.FontColor = XLColor.White;
            }

            for (int row = 0; row < dgvAccounts.Rows.Count; row++)
            {
                for (int col = 0; col < dgvAccounts.Columns.Count; col++)
                {
                    ws.Cell(row + 2, col + 1).Value = dgvAccounts.Rows[row].Cells[col].Value?.ToString() ?? "";
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

