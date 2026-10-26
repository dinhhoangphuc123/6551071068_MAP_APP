using _6551071068_MAP_APP.Data;
using _6551071068_MAP_APP.UI;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed class RoomListControl : UserControl
{
    private readonly DataGridView _grid = ClassicUi.Grid();
    private readonly TextBox _search = new();
    private readonly System.Windows.Forms.Timer _searchTimer = new() { Interval = 300 };
    private int _loadVersion;

    public RoomListControl()
    {
        Dock = DockStyle.Fill;
        BackColor = SystemColors.Control;
        Size = new Size(1039, 699);
        MinimumSize = new Size(1039, 699);

        var searchIcon = new PictureBox
        {
            Image = ClassicUi.Image("search.png"),
            Location = new Point(85, 7),
            Size = new Size(39, 37),
            SizeMode = PictureBoxSizeMode.Zoom,
            Anchor = AnchorStyles.Top | AnchorStyles.Left
        };
        _search.Location = new Point(130, 12);
        _search.Size = new Size(187, 32);
        _search.Font = new Font("Microsoft Sans Serif", 13f);
        _search.Anchor = AnchorStyles.Top | AnchorStyles.Left;

        var exportButton = ClassicUi.ToolbarButton("Xuất file Excel", Color.DarkTurquoise, 167);
        exportButton.Location = new Point(560, 12);
        exportButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        exportButton.Click += ExportExcel_Click;

        var addButton = ClassicUi.ToolbarButton("Thêm mới phòng", Color.MediumSpringGreen, 188);
        addButton.Location = new Point(803, 12);
        addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        addButton.Click += async (_, _) => await AddRoomAsync();

        _grid.Location = new Point(12, 72);
        _grid.Size = new Size(1015, 615);
        _grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _grid.RowTemplate.Height = 40;
        ConfigureGrid();
        _grid.DataBindingComplete += (_, _) => SetRowIcons();
        _search.TextChanged += (_, _) =>
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        };
        _searchTimer.Tick += async (_, _) =>
        {
            _searchTimer.Stop();
            await LoadRoomsAsync();
        };
        Disposed += (_, _) => _searchTimer.Dispose();
        _grid.CellClick += Grid_CellClick;
        Load += async (_, _) => await LoadRoomsAsync();

        Controls.Add(_grid);
        Controls.Add(searchIcon);
        Controls.Add(_search);
        Controls.Add(exportButton);
        Controls.Add(addButton);
    }

    private void ConfigureGrid()
    {
        ClassicUi.AddImageColumn(_grid, "IconPhong", "", "Phong.png", 35, "Hình phòng");
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPH", DataPropertyName = nameof(RoomRow.MaPH), HeaderText = "Mã phòng", FillWeight = 72 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TTPH", DataPropertyName = nameof(RoomRow.TTPH), HeaderText = "Tình trạng phòng", FillWeight = 120 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TTDD", DataPropertyName = nameof(RoomRow.TTDD), HeaderText = "Dọn dẹp", FillWeight = 115 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLPH", DataPropertyName = nameof(RoomRow.TenLPH), HeaderText = "Loại phòng", FillWeight = 100 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "GhiChu", DataPropertyName = nameof(RoomRow.GhiChu), HeaderText = "Ghi chú", FillWeight = 100 });
        ClassicUi.AddImageColumn(_grid, "colSua", "Sửa", "edit.png", 42, "Cập nhật phòng");
        ClassicUi.AddImageColumn(_grid, "colXoa", "Xóa", "delete.png", 42, "Xóa phòng");
        _grid.Columns["IconPhong"]!.FillWeight = 30;
        _grid.Columns["colSua"]!.FillWeight = 35;
        _grid.Columns["colXoa"]!.FillWeight = 35;
    }

    private void SetRowIcons()
    {
        foreach (DataGridViewRow row in _grid.Rows)
        {
            row.Cells["IconPhong"].Value = ((DataGridViewImageColumn)_grid.Columns["IconPhong"]!).Image;
            row.Cells["colSua"].Value = ((DataGridViewImageColumn)_grid.Columns["colSua"]!).Image;
            row.Cells["colXoa"].Value = ((DataGridViewImageColumn)_grid.Columns["colXoa"]!).Image;
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
            string keyword = _search.Text.Trim();
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

            _grid.DataSource = rooms;
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

        string maPhong = _grid.Rows[e.RowIndex].Cells["MaPH"].Value?.ToString() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(maPhong))
        {
            return;
        }

        string column = _grid.Columns[e.ColumnIndex].Name;
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
        var rows = _grid.Rows.Cast<DataGridViewRow>().Where(r => r.Visible && !r.IsNewRow).ToList();
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
