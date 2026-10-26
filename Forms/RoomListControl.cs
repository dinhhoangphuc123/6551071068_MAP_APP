using _6551071068_MAP_APP.Data;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class RoomListControl : UserControl
{
    private int _loadVersion;

    public RoomListControl()
    {
        InitializeComponent();
        Dock = DockStyle.Fill;
        dgvRooms.AutoGenerateColumns = false;
        Resize += (_, _) => LayoutSearchField();
        LayoutSearchField();
    }

    private void LayoutSearchField()
    {
        // Keep the search box clear of the right-aligned toolbar buttons on narrower windows.
        txtSearch.Width = Math.Clamp(ClientSize.Width - 636, 80, 187);
    }

    private async void RoomListControl_Load(object? sender, EventArgs e) => await LoadRoomsAsync();

    private void TxtSearch_TextChanged(object? sender, EventArgs e)
    {
        searchTimer.Stop();
        searchTimer.Start();
    }

    private async void SearchTimer_Tick(object? sender, EventArgs e)
    {
        searchTimer.Stop();
        await LoadRoomsAsync();
    }

    private async void BtnAdd_Click(object? sender, EventArgs e) => await AddRoomAsync();

    private void DgvRooms_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) => SetRowIcons();

    private void SetRowIcons()
    {
        foreach (DataGridViewRow row in dgvRooms.Rows)
        {
            row.Cells["IconPhong"].Value = ((DataGridViewImageColumn)dgvRooms.Columns["IconPhong"]!).Image;
            row.Cells["colSua"].Value = ((DataGridViewImageColumn)dgvRooms.Columns["colSua"]!).Image;
            row.Cells["colXoa"].Value = ((DataGridViewImageColumn)dgvRooms.Columns["colXoa"]!).Image;
        }
    }

    private async Task LoadRoomsAsync()
    {
        if (IsDisposed)
        {
            return;
        }

        int version = ++_loadVersion;
        try
        {
            string keyword = txtSearch.Text.Trim();
            await using var db = new HotelManagementContext();
            var query = db.Phongs.AsNoTracking().Where(p => p.DaXoa != true);
            if (keyword.Length > 0)
            {
                query = query.Where(p => p.MaPh.Contains(keyword));
            }

            var rooms = await query
                .OrderBy(p => p.MaPh)
                .Select(p => new RoomRow
                {
                    MaPH = p.MaPh,
                    TTPH = p.Ttph ?? string.Empty,
                    TTDD = p.Ttdd ?? string.Empty,
                    TenLPH = p.MaLphNavigation == null ? "Chưa phân loại" : p.MaLphNavigation.TenLph ?? "Chưa phân loại",
                    GhiChu = p.GhiChu ?? string.Empty
                })
                .ToListAsync();
            // Bỏ kết quả cũ nếu đã có lần tải mới hơn hoặc control đã bị đóng
            if (IsDisposed || version != _loadVersion)
            {
                return;
            }

            dgvRooms.DataSource = rooms;
        }
        catch (Exception ex)
        {
            if (IsDisposed || version != _loadVersion)
            {
                return;
            }

            MessageBox.Show("Lỗi tải danh sách phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task AddRoomAsync()
    {
        using var dialog = new RoomEditorDialog();
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
        {
            await LoadRoomsAsync();
        }
    }

    private async void Grid_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }

        string maPhong = dgvRooms.Rows[e.RowIndex].Cells["MaPH"].Value?.ToString() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(maPhong))
        {
            return;
        }

        string column = dgvRooms.Columns[e.ColumnIndex].Name;
        if (column == "colSua")
        {
            using var dialog = new RoomEditorDialog(maPhong);
            if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
            {
                await LoadRoomsAsync();
            }
        }
        else if (column == "colXoa")
        {
            if (MessageBox.Show($"Bạn có chắc muốn xóa phòng {maPhong}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await DeleteRoomAsync(maPhong);
                await LoadRoomsAsync();
            }
        }
    }

    private async Task DeleteRoomAsync(string maPhong)
    {
        try
        {
            await using var db = new HotelManagementContext();
            var room = await db.Phongs.FirstOrDefaultAsync(p => p.MaPh == maPhong && p.DaXoa != true);
            if (room is null)
            {
                MessageBox.Show("Không tìm thấy phòng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (room.Ttph is "Đang thuê" or "Đã đặt")
            {
                MessageBox.Show($"Phòng {maPhong} đang ở trạng thái {room.Ttph} nên không thể xóa.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            room.DaXoa = true;
            await db.SaveChangesAsync();
            MessageBox.Show("Đã xóa phòng thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi xóa phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ExportExcel_Click(object? sender, EventArgs e)
    {
        var rows = dgvRooms.Rows.Cast<DataGridViewRow>().Where(r => r.Visible && !r.IsNewRow).ToList();
        if (rows.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Title = "Xuất danh sách phòng",
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = $"DanhSachPhong_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
        };
        if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
        {
            return;
        }

        try
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.Worksheets.Add("Danh sách phòng");
            string[] columns = ["MaPH", "TTPH", "TTDD", "TenLPH", "GhiChu"];
            string[] headers = ["Mã phòng", "Trạng thái phòng", "Dọn dẹp", "Loại phòng", "Ghi chú"];
            for (int c = 0; c < columns.Length; c++)
            {
                sheet.Cell(1, c + 1).Value = headers[c];
                sheet.Cell(1, c + 1).Style.Font.Bold = true;
            }

            for (int r = 0; r < rows.Count; r++)
            {
                for (int c = 0; c < columns.Length; c++)
                {
                    sheet.Cell(r + 2, c + 1).Value = rows[r].Cells[columns[c]].Value?.ToString() ?? string.Empty;
                }
            }

            sheet.Columns().AdjustToContents();
            workbook.SaveAs(dialog.FileName);
            if (MessageBox.Show("Xuất dữ liệu thành công. Bạn có muốn mở file ngay không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(dialog.FileName)
                {
                    UseShellExecute = true
                });
            }
        }
        catch (IOException)
        {
            MessageBox.Show("Không ghi được file. Hãy đóng file Excel nếu file đang được mở rồi thử lại.",
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi xuất Excel: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private sealed class RoomRow
    {
        public string MaPH { get; init; } = string.Empty;
        public string TTPH { get; init; } = string.Empty;
        public string TTDD { get; init; } = string.Empty;
        public string TenLPH { get; init; } = string.Empty;
        public string GhiChu { get; init; } = string.Empty;
    }
}
