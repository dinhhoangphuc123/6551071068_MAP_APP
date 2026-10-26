using _6551071068_MAP_APP.Data;
using _6551071068_MAP_APP.UI;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

/// <summary>Room filters and the room status table shown in the lab manual.</summary>
public sealed class FloorPlanControl : UserControl
{
    private readonly TextBox _search = new();
    private readonly DateTimePicker _date = new() { Format = DateTimePickerFormat.Short };
    private readonly DateTimePicker _time = new()
    {
        Format = DateTimePickerFormat.Time,
        ShowUpDown = true
    };
    private readonly DataGridView _grid = ClassicUi.Grid();
    private readonly RadioButton _allStatus = Radio("Tất cả phòng");
    private readonly RadioButton _normal = Radio("Phòng trống");
    private readonly RadioButton _booked = Radio("Phòng đã đặt");
    private readonly RadioButton _occupied = Radio("Phòng đang thuê");
    private readonly RadioButton _repair = Radio("Phòng đang sửa chữa");
    private readonly RadioButton _allTypes = Radio("Tất cả phòng");
    private readonly RadioButton _standardSingle = Radio("Phòng thường đơn");
    private readonly RadioButton _standardDouble = Radio("Phòng thường đôi");
    private readonly RadioButton _vipSingle = Radio("Phòng VIP đơn");
    private readonly RadioButton _vipDouble = Radio("Phòng VIP đôi");
    private readonly RadioButton _allCleaning = Radio("Tất cả");
    private readonly RadioButton _clean = Radio("Đã dọn dẹp");
    private readonly RadioButton _notClean = Radio("Chưa dọn dẹp");
    private readonly System.Windows.Forms.Timer _searchTimer = new() { Interval = 300 };
    private bool _loading;
    private bool _dateFilterEnabled;

    public FloorPlanControl()
    {
        Dock = DockStyle.Fill;
        BackColor = ClassicUi.Honeydew;
        Size = new Size(1276, 851);
        MinimumSize = new Size(1276, 851);

        Controls.Add(BuildFilters());
        Controls.Add(BuildToolbar());

        _grid.Location = new Point(274, 74);
        _grid.Size = new Size(990, 713);
        _grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _grid.RowTemplate.Height = 24;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        ConfigureGrid();
        Controls.Add(_grid);

        _search.TextChanged += (_, _) => ScheduleReload();
        _date.ValueChanged += (_, _) =>
        {
            _dateFilterEnabled = true;
            if (!_loading) ScheduleReload();
        };
        foreach (RadioButton radio in FilterRadios())
        {
            radio.CheckedChanged += (_, _) =>
            {
                if (!_loading && radio.Checked) ScheduleReload();
            };
        }

        _searchTimer.Tick += async (_, _) =>
        {
            _searchTimer.Stop();
            await LoadRoomsAsync();
        };
        _searchTimer.Stop();
        Disposed += (_, _) => _searchTimer.Dispose();
        Load += async (_, _) => await LoadRoomsAsync();
    }

    private Control BuildFilters()
    {
        var filters = new Panel
        {
            Location = new Point(0, 0),
            Size = new Size(267, 788),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left,
            BackColor = ClassicUi.GreenYellow
        };
        AddFilterGroup(filters, "Trạng thái phòng", new Point(3, 0), new Size(255, 279),
            new (RadioButton Radio, int Y)[]
            {
                (_normal, 61), (_booked, 105), (_occupied, 149), (_repair, 192), (_allStatus, 236)
            });
        AddFilterGroup(filters, "Loại phòng", new Point(6, 298), new Size(255, 279),
            new (RadioButton Radio, int Y)[]
            {
                (_standardSingle, 61), (_standardDouble, 105), (_vipSingle, 149), (_vipDouble, 192), (_allTypes, 236)
            });
        AddFilterGroup(filters, "Tình trạng dọn dẹp", new Point(12, 595), new Size(246, 188),
            new (RadioButton Radio, int Y)[]
            {
                (_clean, 61), (_notClean, 105), (_allCleaning, 149)
            });

        _allStatus.Checked = true;
        _allTypes.Checked = true;
        _allCleaning.Checked = true;
        return filters;
    }

    private static void AddFilterGroup(Panel parent, string title, Point location, Size size,
        IEnumerable<(RadioButton Radio, int Y)> radios)
    {
        var panel = new Panel
        {
            Location = location,
            Size = size,
            BackColor = ClassicUi.GreenYellow,
            BorderStyle = BorderStyle.FixedSingle
        };
        panel.Controls.Add(new Label
        {
            Text = title,
            Location = new Point(18, 9),
            Size = new Size(size.Width - 30, 31),
            Font = new Font("Segoe UI", 14.25f, FontStyle.Bold),
            ForeColor = Color.Black
        });
        foreach (var (radio, y) in radios)
        {
            radio.Location = new Point(15, y);
            panel.Controls.Add(radio);
        }

        parent.Controls.Add(panel);
    }

    private Control BuildToolbar()
    {
        var toolbar = new Panel
        {
            Location = new Point(274, 0),
            Size = new Size(990, 74),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            BackColor = ClassicUi.Honeydew
        };
        toolbar.Controls.Add(new Label
        {
            Text = "Chọn ngày",
            Location = new Point(27, 1),
            Size = new Size(200, 20),
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Microsoft Sans Serif", 9f)
        });
        _date.Location = new Point(27, 28);
        _date.Size = new Size(200, 27);
        toolbar.Controls.Add(_date);
        toolbar.Controls.Add(new Label
        {
            Text = "Chọn giờ",
            Location = new Point(265, 1),
            Size = new Size(200, 20),
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Microsoft Sans Serif", 9f)
        });
        _time.Location = new Point(265, 28);
        _time.Size = new Size(200, 27);
        toolbar.Controls.Add(_time);

        toolbar.Controls.Add(new PictureBox
        {
            Image = ClassicUi.Image("search.png"),
            Location = new Point(514, 16),
            Size = new Size(30, 40),
            SizeMode = PictureBoxSizeMode.Zoom
        });
        _search.Location = new Point(554, 21);
        _search.Size = new Size(149, 27);
        _search.Font = new Font("Microsoft Sans Serif", 10f);
        toolbar.Controls.Add(_search);

        var booking = new Button
        {
            Text = "Đặt phòng",
            Location = new Point(757, 10),
            Size = new Size(166, 54),
            BackColor = Color.FromArgb(192, 192, 255),
            ForeColor = Color.Blue,
            Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold),
            UseVisualStyleBackColor = false
        };
        booking.Click += (_, _) =>
        {
            string room = _grid.CurrentRow?.Cells["MaPH"].Value?.ToString() ?? "";
            MessageBox.Show(room.Length == 0
                    ? "Chức năng đặt phòng đang được xây dựng."
                    : $"Chức năng đặt phòng đang được xây dựng.\nPhòng đang chọn: {room}",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        };
        toolbar.Controls.Add(booking);
        return toolbar;
    }

    private static RadioButton Radio(string text)
        => new()
        {
            Text = text,
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 12f),
            ForeColor = Color.Black
        };

    private IEnumerable<RadioButton> FilterRadios()
    {
        yield return _allStatus;
        yield return _normal;
        yield return _booked;
        yield return _occupied;
        yield return _repair;
        yield return _allTypes;
        yield return _standardSingle;
        yield return _standardDouble;
        yield return _vipSingle;
        yield return _vipDouble;
        yield return _allCleaning;
        yield return _clean;
        yield return _notClean;
    }

    private void ConfigureGrid()
    {
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPH", HeaderText = "Mã phòng", FillWeight = 90 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tang", HeaderText = "Tầng", FillWeight = 70 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLPH", HeaderText = "Loại phòng", FillWeight = 120 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TTPH", HeaderText = "Trạng thái phòng", FillWeight = 130 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "TTDD", HeaderText = "Tình trạng dọn dẹp", FillWeight = 145 });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "GhiChu", HeaderText = "Ghi chú", FillWeight = 110 });
    }

    private void ScheduleReload()
    {
        _searchTimer.Stop();
        _searchTimer.Start();
    }

    private async Task LoadRoomsAsync()
    {
        if (_loading || IsDisposed) return;

        _loading = true;
        try
        {
            await using var db = new HotelManagementContext();
            IQueryable<Phong> query = db.Phongs.AsNoTracking().Where(p => p.DaXoa != true);

            string? status = _allStatus.Checked ? null
                : _normal.Checked ? "Bình thường"
                : _booked.Checked ? "Đã đặt"
                : _occupied.Checked ? "Đang thuê"
                : _repair.Checked ? "Đang sửa chữa"
                : null;
            if (status is not null) query = query.Where(p => p.Ttph == status);

            string? typeCode = _allTypes.Checked ? null
                : _standardSingle.Checked ? "NOR01"
                : _standardDouble.Checked ? "NOR02"
                : _vipSingle.Checked ? "VIP01"
                : _vipDouble.Checked ? "VIP02"
                : null;
            if (typeCode is not null) query = query.Where(p => p.MaLph == typeCode);

            string? cleaning = _allCleaning.Checked ? null
                : _clean.Checked ? "Đã dọn dẹp"
                : _notClean.Checked ? "Chưa dọn dẹp" : null;
            if (cleaning is not null) query = query.Where(p => p.Ttdd == cleaning);

            string keyword = _search.Text.Trim();
            if (keyword.Length > 0) query = query.Where(p => p.MaPh.Contains(keyword));

            if (_dateFilterEnabled)
            {
                DateTime start = _date.Value.Date;
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

            _grid.Rows.Clear();
            foreach (var room in rooms)
            {
                _grid.Rows.Add(room.MaPh, room.Tang, room.TenLph ?? "Chưa phân loại",
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
