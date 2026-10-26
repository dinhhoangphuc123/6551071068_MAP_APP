using _6551071068_MAP_APP.Data;
using _6551071068_MAP_APP.UI;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed class RoomTypeControl : UserControl
{
    private readonly DataGridView _grid = ClassicUi.Grid();
    private readonly TextBox _search = new();
    private readonly System.Windows.Forms.Timer _searchTimer = new() { Interval = 300 };
    private int _loadVersion;

    public RoomTypeControl()
    {
        Dock = DockStyle.Fill;
        BackColor = SystemColors.Control;
        Size = new Size(948, 683);
        MinimumSize = new Size(948, 683);

        var searchIcon = new PictureBox
        {
            Image = ClassicUi.Image("search.png"),
            Location = new Point(60, 12),
            Size = new Size(39, 37),
            SizeMode = PictureBoxSizeMode.Zoom,
            Anchor = AnchorStyles.Top | AnchorStyles.Left
        };
        _search.Location = new Point(105, 17);
        _search.Size = new Size(187, 32);
        _search.Font = new Font("Microsoft Sans Serif", 13f);
        _search.Anchor = AnchorStyles.Top | AnchorStyles.Left;

        var exportButton = ClassicUi.ToolbarButton("Xuất file Excel", Color.DarkTurquoise, 167);
        exportButton.Location = new Point(546, 12);
        exportButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        exportButton.Click += ExportExcel_Click;

        var addButton = ClassicUi.ToolbarButton("Thêm mới", Color.LightPink, 167);
        addButton.Location = new Point(747, 12);
        addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        addButton.Click += async (_, _) => await AddRoomTypeAsync();

        _grid.Location = new Point(-71, 66);
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
            await LoadRoomTypesAsync();
        };
        Disposed += (_, _) => _searchTimer.Dispose();
        _grid.CellClick += Grid_CellClick;
        Load += async (_, _) => await LoadRoomTypesAsync();

        Controls.Add(_grid);
        Controls.Add(searchIcon);
        Controls.Add(_search);
        Controls.Add(exportButton);
        Controls.Add(addButton);
    }

    private void ConfigureGrid()
    {
        ClassicUi.AddImageColumn(_grid, "IconLoaiPhong", "", "Giuong.png", 42, "Hình loại phòng");
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaLPH", DataPropertyName = nameof(RoomTypeRow.MaLPH), HeaderText = "Mã loại phòng", FillWeight = 80 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLPH", DataPropertyName = nameof(RoomTypeRow.TenLPH), HeaderText = "Tên loại phòng", FillWeight = 110 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoGiuong", DataPropertyName = nameof(RoomTypeRow.SoGiuong), HeaderText = "Số giường", FillWeight = 70 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoNguoiToiDa", DataPropertyName = nameof(RoomTypeRow.SoNguoiToiDa), HeaderText = "Số người tối đa", FillWeight = 90 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaNgay", DataPropertyName = nameof(RoomTypeRow.GiaNgay), HeaderText = "Giá ngày", FillWeight = 90 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "GiaGio", DataPropertyName = nameof(RoomTypeRow.GiaGio), HeaderText = "Giá giờ", FillWeight = 90 });
        _grid.Columns["GiaNgay"]!.DefaultCellStyle.Format = "N0";
        _grid.Columns["GiaGio"]!.DefaultCellStyle.Format = "N0";
        _grid.Columns["GiaNgay"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        _grid.Columns["GiaGio"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        ClassicUi.AddImageColumn(_grid, "colTienNghi", "Tiện nghi", "details.png", 60, "Chi tiết tiện nghi");
        ClassicUi.AddImageColumn(_grid, "colSua", "Cập nhật", "edit.png", 70, "Cập nhật loại phòng");
        _grid.Columns["IconLoaiPhong"]!.FillWeight = 35;
        _grid.Columns["colTienNghi"]!.FillWeight = 50;
        _grid.Columns["colSua"]!.FillWeight = 55;
    }

    private void SetRowIcons()
    {
        foreach (DataGridViewRow row in _grid.Rows)
        {
            row.Cells["IconLoaiPhong"].Value = ((DataGridViewImageColumn)_grid.Columns["IconLoaiPhong"]!).Image;
            row.Cells["colTienNghi"].Value = ((DataGridViewImageColumn)_grid.Columns["colTienNghi"]!).Image;
            row.Cells["colSua"].Value = ((DataGridViewImageColumn)_grid.Columns["colSua"]!).Image;
        }
    }

    private async Task LoadRoomTypesAsync()
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
            var query = db.LoaiPhongs.AsNoTracking();
            if (keyword.Length > 0)
            {
                query = query.Where(x => x.MaLph.Contains(keyword) || (x.TenLph != null && x.TenLph.Contains(keyword)));
            }

            var rows = await query
                .OrderBy(x => x.MaLph)
                .Select(x => new RoomTypeRow
                {
                    MaLPH = x.MaLph,
                    TenLPH = x.TenLph ?? string.Empty,
                    SoGiuong = x.SoGiuong,
                    SoNguoiToiDa = x.SoNguoiToiDa,
                    GiaNgay = x.GiaNgay,
                    GiaGio = x.GiaGio
                })
                .ToListAsync();
            // Bỏ kết quả cũ nếu đã có lần tải mới hơn hoặc control đã bị đóng
            if (IsDisposed || version != _loadVersion)
            {
                return;
            }

            _grid.DataSource = rows;
        }
        catch (Exception ex)
        {
            if (IsDisposed || version != _loadVersion)
            {
                return;
            }

            MessageBox.Show("Lỗi khi tải loại phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task AddRoomTypeAsync()
    {
        using var dialog = new RoomTypeEditorDialog();
        if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
        {
            await LoadRoomTypesAsync();
        }
    }

    private async void Grid_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
        {
            return;
        }

        var row = _grid.Rows[e.RowIndex];
        string maLoaiPhong = row.Cells["MaLPH"].Value?.ToString() ?? string.Empty;
        string tenLoaiPhong = row.Cells["TenLPH"].Value?.ToString() ?? string.Empty;
        if (maLoaiPhong.Length == 0)
        {
            return;
        }

        switch (_grid.Columns[e.ColumnIndex].Name)
        {
            case "colSua":
                using (var dialog = new RoomTypeEditorDialog(maLoaiPhong))
                {
                    if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                    {
                        await LoadRoomTypesAsync();
                    }
                }
                break;
            case "colTienNghi":
                MessageBox.Show($"Quản lý chi tiết tiện nghi của loại phòng {tenLoaiPhong} ({maLoaiPhong}) " +
                    "đang được xây dựng theo phần tiếp theo của tài liệu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                break;
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
            Title = "Xuất danh sách loại phòng",
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = $"DanhSachLoaiPhong_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
        };
        if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
        {
            return;
        }

        try
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.Worksheets.Add("Danh sách loại phòng");
            string[] columns = ["MaLPH", "TenLPH", "SoGiuong", "SoNguoiToiDa", "GiaNgay", "GiaGio"];
            string[] headers = ["Mã loại phòng", "Tên loại phòng", "Số giường", "Số người tối đa", "Giá ngày", "Giá giờ"];
            for (int c = 0; c < columns.Length; c++)
            {
                sheet.Cell(1, c + 1).Value = headers[c];
                sheet.Cell(1, c + 1).Style.Font.Bold = true;
            }

            for (int r = 0; r < rows.Count; r++)
            {
                for (int c = 0; c < columns.Length; c++)
                {
                    object? value = rows[r].Cells[columns[c]].Value;
                    var cell = sheet.Cell(r + 2, c + 1);
                    if (value is int integer)
                    {
                        cell.Value = integer;
                    }
                    else if (value is decimal amount)
                    {
                        cell.Value = amount;
                        cell.Style.NumberFormat.Format = "#,##0";
                    }
                    else
                    {
                        cell.Value = value?.ToString() ?? string.Empty;
                    }
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

    private sealed class RoomTypeRow
    {
        public string MaLPH { get; init; } = string.Empty;
        public string TenLPH { get; init; } = string.Empty;
        public int? SoGiuong { get; init; }
        public int? SoNguoiToiDa { get; init; }
        public decimal? GiaNgay { get; init; }
        public decimal? GiaGio { get; init; }
    }
}
