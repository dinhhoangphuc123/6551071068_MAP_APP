using _6551071068_MAP_APP.Data;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class RoomTypeControl : UserControl
{
    private int _loadVersion;

    public RoomTypeControl()
    {
        InitializeComponent();
        Dock = DockStyle.Fill;
        dgvRoomTypes.AutoGenerateColumns = false;
    }

    private async void RoomTypeControl_Load(object? sender, EventArgs e) => await LoadRoomTypesAsync();

    private void TxtSearch_TextChanged(object? sender, EventArgs e)
    {
        searchTimer.Stop();
        searchTimer.Start();
    }

    private async void SearchTimer_Tick(object? sender, EventArgs e)
    {
        searchTimer.Stop();
        await LoadRoomTypesAsync();
    }

    private async void BtnAdd_Click(object? sender, EventArgs e) => await AddRoomTypeAsync();

    private void DgvRoomTypes_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) => SetRowIcons();

    private void SetRowIcons()
    {
        foreach (DataGridViewRow row in dgvRoomTypes.Rows)
        {
            row.Cells["IconLoaiPhong"].Value = ((DataGridViewImageColumn)dgvRoomTypes.Columns["IconLoaiPhong"]!).Image;
            row.Cells["colTienNghi"].Value = ((DataGridViewImageColumn)dgvRoomTypes.Columns["colTienNghi"]!).Image;
            row.Cells["colSua"].Value = ((DataGridViewImageColumn)dgvRoomTypes.Columns["colSua"]!).Image;
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
            string keyword = txtSearch.Text.Trim();
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

            dgvRoomTypes.DataSource = rows;
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

        var row = dgvRoomTypes.Rows[e.RowIndex];
        string maLoaiPhong = row.Cells["MaLPH"].Value?.ToString() ?? string.Empty;
        string tenLoaiPhong = row.Cells["TenLPH"].Value?.ToString() ?? string.Empty;
        if (maLoaiPhong.Length == 0)
        {
            return;
        }

        switch (dgvRoomTypes.Columns[e.ColumnIndex].Name)
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
        var rows = dgvRoomTypes.Rows.Cast<DataGridViewRow>().Where(r => r.Visible && !r.IsNewRow).ToList();
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
