using _6551071068_MAP_APP.Data;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

/// <summary>Room filters and the room status table shown in the lab manual.</summary>
public sealed partial class FloorPlanControl : UserControl
{
    private bool _loading;

    public FloorPlanControl()
    {
        InitializeComponent();
        Dock = DockStyle.Fill;
        Resize += (_, _) => LayoutForViewport();
        LayoutForViewport();
    }

    private async void FloorPlanControl_Load(object? sender, EventArgs e)
    {
        LayoutForViewport();
        await LoadRoomsAsync();
    }

    private void LayoutForViewport()
    {
        int width = ClientSize.Width;
        int height = ClientSize.Height;
        if (width <= 0 || height <= 0)
        {
            return;
        }

        const int toolbarHeight = 74;
        int filterWidth = Math.Clamp((int)(width * 0.23), 165, 267);
        int tableWidth = Math.Max(0, width - filterWidth);
        pnlFilters.SetBounds(0, 0, filterWidth, height);
        pnlToolbar.SetBounds(filterWidth, 0, tableWidth, toolbarHeight);
        dgvRooms.SetBounds(filterWidth, toolbarHeight, tableWidth, Math.Max(0, height - toolbarHeight));

        int gap = 4;
        int groupSpace = Math.Max(0, height - gap * 2);
        int statusHeight = (int)(groupSpace * 0.36);
        int typeHeight = (int)(groupSpace * 0.36);
        int cleaningHeight = groupSpace - statusHeight - typeHeight;
        grpStatus.SetBounds(3, 0, Math.Max(0, filterWidth - 6), statusHeight);
        grpType.SetBounds(3, statusHeight + gap, Math.Max(0, filterWidth - 6), typeHeight);
        grpCleaning.SetBounds(3, statusHeight + typeHeight + gap * 2, Math.Max(0, filterWidth - 6), cleaningHeight);

        float titleFont = Math.Clamp(filterWidth / 20f, 9f, 12f);
        LayoutFilterGroup(lblStatusTitle, [rdoNormal, rdoBooked, rdoOccupied, rdoRepair, rdoAllStatus], grpStatus, titleFont);
        LayoutFilterGroup(lblTypeTitle, [rdoStandardSingle, rdoStandardDouble, rdoVipSingle, rdoVipDouble, rdoAllTypes], grpType, titleFont);
        LayoutFilterGroup(lblCleaningTitle, [rdoClean, rdoNotClean, rdoAllCleaning], grpCleaning, titleFont);

        LayoutToolbar(tableWidth);
    }

    private static void LayoutFilterGroup(Label title, RadioButton[] radios, Panel panel, float titleFont)
    {
        title.SetBounds(12, 5, Math.Max(0, panel.ClientSize.Width - 24), 25);
        title.Font = new Font("Segoe UI", titleFont, FontStyle.Bold);

        int rowHeight = Math.Max(20, (panel.ClientSize.Height - 38) / radios.Length);
        float radioFont = Math.Clamp(rowHeight * 0.34f, 8f, 10.5f);
        for (int index = 0; index < radios.Length; index++)
        {
            radios[index].Location = new Point(10, 32 + index * rowHeight);
            radios[index].Font = new Font("Microsoft Sans Serif", radioFont);
        }
    }

    private void LayoutToolbar(int width)
    {
        int buttonWidth = Math.Clamp((int)(width * 0.17), 100, 150);
        int dateWidth = Math.Clamp((width - buttonWidth - 170) / 2, 95, 190);
        int x = 8;
        lblChonNgay.SetBounds(x, 1, dateWidth, 20);
        dtpDate.SetBounds(x, 28, dateWidth, 27);
        x += dateWidth + 8;
        lblChonGio.SetBounds(x, 1, dateWidth, 20);
        dtpTime.SetBounds(x, 28, dateWidth, 27);
        x += dateWidth + 12;

        int searchIconWidth = 28;
        picSearch.SetBounds(x, 18, searchIconWidth, 34);
        x += searchIconWidth + 4;
        int buttonX = Math.Max(x + 90, width - buttonWidth - 8);
        txtSearch.SetBounds(x, 22, Math.Max(80, buttonX - x - 8), 27);
        btnDatPhong.SetBounds(buttonX, 10, Math.Min(buttonWidth, Math.Max(0, width - buttonX - 6)), 54);
        float actionFont = Math.Clamp(buttonWidth / 12f, 8.5f, 12f);
        btnDatPhong.Font = new Font("Microsoft Sans Serif", actionFont, FontStyle.Bold);
    }

    private void Filter_Changed(object? sender, EventArgs e) => ScheduleReload();

    private void Radio_CheckedChanged(object? sender, EventArgs e)
    {
        if (sender is RadioButton { Checked: true }) ScheduleReload();
    }

    private async void SearchTimer_Tick(object? sender, EventArgs e)
    {
        searchTimer.Stop();
        await LoadRoomsAsync();
    }

    private void BtnDatPhong_Click(object? sender, EventArgs e)
    {
        string room = dgvRooms.CurrentRow?.Cells["MaPH"].Value?.ToString() ?? "";
        MessageBox.Show(room.Length == 0
                ? "Chức năng đặt phòng đang được xây dựng."
                : $"Chức năng đặt phòng đang được xây dựng.\nPhòng đang chọn: {room}",
            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ScheduleReload()
    {
        searchTimer.Stop();
        searchTimer.Start();
    }

    private async Task LoadRoomsAsync()
    {
        if (IsDisposed) return;
        if (_loading)
        {
            // Đang tải: hẹn tải lại sau để không bỏ mất thay đổi bộ lọc mới
            ScheduleReload();
            return;
        }

        _loading = true;
        try
        {
            await using var db = new HotelManagementContext();
            IQueryable<Phong> query = db.Phongs.AsNoTracking().Where(p => p.DaXoa != true);

            string? status = rdoAllStatus.Checked ? null
                : rdoNormal.Checked ? "Bình thường"
                : rdoBooked.Checked ? "Đã đặt"
                : rdoOccupied.Checked ? "Đang thuê"
                : rdoRepair.Checked ? "Đang sửa chữa"
                : null;
            if (status is not null) query = query.Where(p => p.Ttph == status);

            string? typeCode = rdoAllTypes.Checked ? null
                : rdoStandardSingle.Checked ? "NOR01"
                : rdoStandardDouble.Checked ? "NOR02"
                : rdoVipSingle.Checked ? "VIP01"
                : rdoVipDouble.Checked ? "VIP02"
                : null;
            if (typeCode is not null) query = query.Where(p => p.MaLph == typeCode);

            string? cleaning = rdoAllCleaning.Checked ? null
                : rdoClean.Checked ? "Đã dọn dẹp"
                : rdoNotClean.Checked ? "Chưa dọn dẹp" : null;
            if (cleaning is not null) query = query.Where(p => p.Ttdd == cleaning);

            string keyword = txtSearch.Text.Trim();
            if (keyword.Length > 0) query = query.Where(p => p.MaPh.Contains(keyword));

            // Tick checkbox mới lọc "phòng còn trống theo ngày", bỏ tick thì xem tất cả
            if (dtpDate.Checked)
            {
                DateTime start = dtpDate.Value.Date;
                DateTime end = start.AddDays(1);
                query = query.Where(p => p.Ttph == "Bình thường" &&
                    !p.Ctdps.Any(c => c.DaXoa != true && c.Checkin < end && c.CheckOut > start));
            }

            var rooms = await query
                .OrderBy(p => p.MaPh)
                .Select(p => new
                {
                    p.MaPh,
                    Tang = p.MaPh.Length > 1 ? p.MaPh.Substring(1, 1) : "-",
                    TenLph = p.MaLphNavigation == null ? "Chưa phân loại" : p.MaLphNavigation.TenLph,
                    p.Ttph,
                    p.Ttdd,
                    p.GhiChu
                })
                .ToListAsync();

            dgvRooms.Rows.Clear();
            foreach (var room in rooms)
            {
                dgvRooms.Rows.Add(room.MaPh, room.Tang, room.TenLph ?? "Chưa phân loại",
                    room.Ttph ?? string.Empty, room.Ttdd ?? string.Empty, room.GhiChu ?? string.Empty);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải danh sách phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _loading = false;
        }
    }
}
