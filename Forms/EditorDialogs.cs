using System.Globalization;
using _6551071068_MAP_APP.Data;
using _6551071068_MAP_APP.UI;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed class RoomEditorDialog : Form
{
    private readonly string? _roomCode;
    private readonly TextBox _code = new();
    private readonly ComboBox _status = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox _cleaning = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ComboBox _roomType = new() { DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly TextBox _note = new() { Multiline = true, ScrollBars = ScrollBars.Vertical };
    private readonly Button _save = new();

    public RoomEditorDialog(string? maPhong = null)
    {
        _roomCode = maPhong;
        Text = maPhong is null ? "Thêm mới phòng" : $"Cập nhật phòng {maPhong}";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = new Size(595, 588);
        BackColor = SystemColors.Control;

        _code.MaxLength = 5;
        _code.CharacterCasing = CharacterCasing.Upper;
        _code.ReadOnly = maPhong is not null;
        _note.MaxLength = 100;
        _status.Items.AddRange(["Bình thường", "Đã đặt", "Đang thuê", "Đang sửa chữa"]);
        _cleaning.Items.AddRange(["Đã dọn dẹp", "Chưa dọn dẹp"]);
        _status.SelectedIndex = 0;
        _cleaning.SelectedIndex = 0;

        var fieldsPanel = new Panel
        {
            Location = new Point(43, 45),
            Size = new Size(509, 433),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.Control
        };

        AddRoomField(fieldsPanel, "Mã số phòng", _code, 23);
        AddRoomField(fieldsPanel, "Trạng thái phòng", _status, 81);
        AddRoomField(fieldsPanel, "Loại phòng", _roomType, 139);
        AddRoomField(fieldsPanel, "Tình trạng dọn dẹp", _cleaning, 197);
        var noteCaption = RoomCaption("Ghi chú", new Point(22, 324), new Size(155, 30));
        _note.Location = new Point(168, 313);
        _note.Size = new Size(296, 91);
        _note.Font = new Font("Microsoft Sans Serif", 11f);
        fieldsPanel.Controls.Add(noteCaption);
        fieldsPanel.Controls.Add(_note);
        Controls.Add(fieldsPanel);

        var cancel = new Button
        {
            Text = "Thoát",
            Location = new Point(300, 500),
            Size = new Size(137, 59),
            BackColor = SystemColors.GradientActiveCaption,
            UseVisualStyleBackColor = false,
            Font = new Font("Microsoft Sans Serif", 12f)
        };
        cancel.DialogResult = DialogResult.Cancel;
        _save.Text = maPhong is null ? "Thêm mới" : "Cập nhật";
        _save.Location = new Point(97, 500);
        _save.Size = new Size(137, 59);
        _save.BackColor = Color.Moccasin;
        _save.UseVisualStyleBackColor = false;
        _save.Font = new Font("Microsoft Sans Serif", 12f);
        _save.Click += async (_, _) => await SaveAsync();
        Controls.Add(cancel);
        Controls.Add(_save);
        AcceptButton = _save;
        CancelButton = cancel;
        Load += async (_, _) => await LoadFormAsync();
    }

    private static void AddRoomField(Panel panel, string label, Control input, int y)
    {
        panel.Controls.Add(RoomCaption(label, new Point(20, y), new Size(152, 31)));
        input.Location = new Point(168, y);
        input.Size = new Size(296, 31);
        input.Font = new Font("Microsoft Sans Serif", 11f);
        panel.Controls.Add(input);
    }

    private static Label RoomCaption(string text, Point location, Size size)
        => new()
        {
            Text = text,
            Location = location,
            Size = size,
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("Microsoft Sans Serif", 11f)
        };

    private async Task LoadFormAsync()
    {
        try
        {
            await using var db = new HotelManagementContext();
            var types = await db.LoaiPhongs.AsNoTracking()
                .OrderBy(x => x.MaLph)
                .Select(x => new { x.MaLph, x.TenLph })
                .ToListAsync();
            _roomType.DataSource = types;
            _roomType.DisplayMember = "TenLph";
            _roomType.ValueMember = "MaLph";

            if (_roomCode is null)
            {
                _code.Focus();
                return;
            }

            var room = await db.Phongs.AsNoTracking()
                .Where(x => x.MaPh == _roomCode && x.DaXoa != true)
                .Select(x => new { x.MaPh, x.Ttph, x.Ttdd, x.GhiChu, x.MaLph })
                .FirstOrDefaultAsync();
            if (room is null)
            {
                MessageBox.Show("Không tìm thấy phòng cần cập nhật.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _save.Enabled = false;
                return;
            }

            _code.Text = room.MaPh;
            _status.SelectedItem = room.Ttph;
            _cleaning.SelectedItem = room.Ttdd;
            _roomType.SelectedValue = room.MaLph ?? string.Empty;
            _note.Text = room.GhiChu ?? string.Empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải dữ liệu phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _save.Enabled = false;
        }
    }

    private async Task SaveAsync()
    {
        string maPhong = _code.Text.Trim().ToUpperInvariant();
        string? maLoaiPhong = _roomType.SelectedValue?.ToString();
        if (maPhong.Length == 0)
        {
            Warn("Vui lòng nhập mã phòng.", _code);
            return;
        }

        if (maPhong.Length > 5)
        {
            Warn("Mã phòng tối đa 5 ký tự.", _code);
            return;
        }

        if (string.IsNullOrWhiteSpace(maLoaiPhong))
        {
            Warn("Vui lòng chọn loại phòng.", _roomType);
            return;
        }

        if (_status.SelectedItem is not string status || _cleaning.SelectedItem is not string cleaning)
        {
            Warn("Vui lòng chọn trạng thái phòng và tình trạng dọn dẹp.", _status);
            return;
        }

        _save.Enabled = false;
        try
        {
            await using var db = new HotelManagementContext();
            Phong? room;
            if (_roomCode is null)
            {
                room = await db.Phongs.FirstOrDefaultAsync(x => x.MaPh == maPhong);
                if (room is not null && room.DaXoa != true)
                {
                    Warn("Mã phòng đã tồn tại. Vui lòng nhập mã khác.", _code);
                    return;
                }

                if (room is not null)
                {
                    if (MessageBox.Show($"Phòng {maPhong} đã được xóa trước đây. Khôi phục phòng với thông tin vừa nhập?",
                            "Xác nhận khôi phục", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    room.Ttph = status;
                    room.Ttdd = cleaning;
                    room.MaLph = maLoaiPhong;
                    room.GhiChu = EmptyToNull(_note.Text);
                    room.DaXoa = false;
                }
                else
                {
                    room = new Phong
                    {
                        MaPh = maPhong,
                        Ttph = status,
                        Ttdd = cleaning,
                        MaLph = maLoaiPhong,
                        GhiChu = EmptyToNull(_note.Text),
                        DaXoa = false
                    };
                    db.Phongs.Add(room);
                }
            }
            else
            {
                room = await db.Phongs.FirstOrDefaultAsync(x => x.MaPh == _roomCode && x.DaXoa != true);
                if (room is null)
                {
                    MessageBox.Show("Không tìm thấy phòng cần cập nhật.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                room.Ttph = status;
                room.Ttdd = cleaning;
                room.MaLph = maLoaiPhong;
                room.GhiChu = EmptyToNull(_note.Text);
            }

            await db.SaveChangesAsync();
            MessageBox.Show(_roomCode is null ? "Thêm phòng thành công." : "Cập nhật phòng thành công.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show("Lỗi khi lưu phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi lưu phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (!IsDisposed)
            {
                _save.Enabled = true;
            }
        }
    }

    private static string? EmptyToNull(string value)
        => string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    private void Warn(string message, Control control)
    {
        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        control.Focus();
    }
}

public sealed class RoomTypeEditorDialog : Form
{
    private readonly string? _roomTypeCode;
    private readonly TextBox _code = new();
    private readonly TextBox _name = new();
    private readonly TextBox _beds = new();
    private readonly TextBox _maximumGuests = new();
    private readonly TextBox _dailyPrice = new();
    private readonly TextBox _hourlyPrice = new();
    private readonly Button _save = new();

    public RoomTypeEditorDialog(string? maLoaiPhong = null)
    {
        _roomTypeCode = maLoaiPhong;
        Text = maLoaiPhong is null ? "Thêm mới loại phòng" : $"Cập nhật loại phòng {maLoaiPhong}";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        ClientSize = maLoaiPhong is null ? new Size(548, 639) : new Size(604, 626);
        BackColor = SystemColors.Control;

        var title = new Label
        {
            Text = maLoaiPhong is null ? "Thêm mới thông tin loại phòng" : "Cập nhật thông tin loại phòng",
            Location = maLoaiPhong is null ? new Point(72, 31) : new Point(113, 49),
            Size = maLoaiPhong is null ? new Size(420, 34) : new Size(400, 34),
            Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold),
            ForeColor = Color.Orange,
            TextAlign = ContentAlignment.MiddleCenter
        };
        Controls.Add(title);

        _code.MaxLength = 5;
        _code.CharacterCasing = CharacterCasing.Upper;
        _code.ReadOnly = maLoaiPhong is not null;
        _name.MaxLength = 20;
        _beds.MaxLength = 5;
        _maximumGuests.MaxLength = 5;
        _dailyPrice.MaxLength = 18;
        _hourlyPrice.MaxLength = 18;
        _beds.KeyPress += DigitsOnly;
        _maximumGuests.KeyPress += DigitsOnly;
        _dailyPrice.KeyPress += DecimalInput;
        _hourlyPrice.KeyPress += DecimalInput;

        var fieldsPanel = new Panel
        {
            Location = maLoaiPhong is null ? new Point(21, 101) : new Point(48, 121),
            Size = maLoaiPhong is null ? new Size(506, 439) : new Size(507, 375),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.Control
        };
        Controls.Add(fieldsPanel);
        int inputX = maLoaiPhong is null ? 177 : 160;
        int[] rows = maLoaiPhong is null ? [29, 95, 160, 229, 294, 358] : [45, 100, 155, 210, 265, 320];
        string[] captions = ["Mã loại phòng", "Tên loại phòng", "Số giường", "Số người tối đa", "Giá ngày", "Giá giờ"];
        Control[] inputs = [_code, _name, _beds, _maximumGuests, _dailyPrice, _hourlyPrice];
        for (int index = 0; index < inputs.Length; index++)
        {
            AddRoomTypeField(fieldsPanel, captions[index], inputs[index], rows[index], inputX);
        }

        int saveX = maLoaiPhong is null ? 97 : 136;
        int cancelX = maLoaiPhong is null ? 297 : 336;
        int buttonY = maLoaiPhong is null ? 548 : 519;
        var cancel = new Button
        {
            Text = "Thoát",
            Location = new Point(cancelX, buttonY),
            Size = new Size(137, 59),
            BackColor = SystemColors.GradientActiveCaption,
            UseVisualStyleBackColor = false,
            Font = new Font("Microsoft Sans Serif", 12f)
        };
        cancel.DialogResult = DialogResult.Cancel;
        _save.Text = maLoaiPhong is null ? "Thêm mới" : "Cập nhật";
        _save.Location = new Point(saveX, buttonY);
        _save.Size = new Size(137, 59);
        _save.BackColor = Color.Moccasin;
        _save.UseVisualStyleBackColor = false;
        _save.Font = new Font("Microsoft Sans Serif", 12f);
        _save.Click += async (_, _) => await SaveAsync();
        Controls.Add(cancel);
        Controls.Add(_save);
        AcceptButton = _save;
        CancelButton = cancel;
        if (_roomTypeCode is not null)
        {
            Load += async (_, _) => await LoadRoomTypeAsync();
        }
    }

    private static void AddRoomTypeField(Panel panel, string label, Control input, int y, int inputX)
    {
        panel.Controls.Add(new Label
        {
            Text = label,
            Location = new Point(10, y),
            Size = new Size(inputX - 18, 30),
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("Microsoft Sans Serif", 11f)
        });
        input.Location = new Point(inputX, y);
        input.Size = new Size(275, 30);
        input.Font = new Font("Microsoft Sans Serif", 11f);
        panel.Controls.Add(input);
    }

    private async Task LoadRoomTypeAsync()
    {
        try
        {
            await using var db = new HotelManagementContext();
            var type = await db.LoaiPhongs.AsNoTracking()
                .Where(x => x.MaLph == _roomTypeCode)
                .Select(x => new { x.MaLph, x.TenLph, x.SoGiuong, x.SoNguoiToiDa, x.GiaNgay, x.GiaGio })
                .FirstOrDefaultAsync();
            if (type is null)
            {
                MessageBox.Show("Không tìm thấy loại phòng cần cập nhật.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _save.Enabled = false;
                return;
            }

            _code.Text = type.MaLph;
            _name.Text = type.TenLph ?? string.Empty;
            _beds.Text = type.SoGiuong.ToString(CultureInfo.InvariantCulture);
            _maximumGuests.Text = type.SoNguoiToiDa.ToString(CultureInfo.InvariantCulture);
            _dailyPrice.Text = type.GiaNgay.ToString("0.##", CultureInfo.CurrentCulture);
            _hourlyPrice.Text = type.GiaGio.ToString("0.##", CultureInfo.CurrentCulture);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải thông tin loại phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _save.Enabled = false;
        }
    }

    private async Task SaveAsync()
    {
        string code = _code.Text.Trim().ToUpperInvariant();
        string name = _name.Text.Trim();
        if (code.Length == 0)
        {
            Warn("Vui lòng nhập mã loại phòng.", _code);
            return;
        }

        if (name.Length == 0)
        {
            Warn("Vui lòng nhập tên loại phòng.", _name);
            return;
        }

        if (!int.TryParse(_beds.Text.Trim(), out int beds) || beds <= 0)
        {
            Warn("Số giường không hợp lệ.", _beds);
            return;
        }

        if (!int.TryParse(_maximumGuests.Text.Trim(), out int maximumGuests) || maximumGuests <= 0)
        {
            Warn("Số người tối đa không hợp lệ.", _maximumGuests);
            return;
        }

        if (!TryParseMoney(_dailyPrice.Text, out decimal dailyPrice) || dailyPrice < 0)
        {
            Warn("Giá ngày không hợp lệ.", _dailyPrice);
            return;
        }

        if (!TryParseMoney(_hourlyPrice.Text, out decimal hourlyPrice) || hourlyPrice < 0)
        {
            Warn("Giá giờ không hợp lệ.", _hourlyPrice);
            return;
        }

        _save.Enabled = false;
        try
        {
            await using var db = new HotelManagementContext();
            LoaiPhong? type;
            if (_roomTypeCode is null)
            {
                if (await db.LoaiPhongs.AnyAsync(x => x.MaLph == code))
                {
                    Warn("Mã loại phòng đã tồn tại. Vui lòng nhập mã khác.", _code);
                    return;
                }

                type = new LoaiPhong { MaLph = code };
                db.LoaiPhongs.Add(type);
            }
            else
            {
                type = await db.LoaiPhongs.FirstOrDefaultAsync(x => x.MaLph == _roomTypeCode);
                if (type is null)
                {
                    MessageBox.Show("Không tìm thấy loại phòng cần cập nhật.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            type.TenLph = name;
            type.SoGiuong = beds;
            type.SoNguoiToiDa = maximumGuests;
            type.GiaNgay = dailyPrice;
            type.GiaGio = hourlyPrice;
            await db.SaveChangesAsync();
            MessageBox.Show(_roomTypeCode is null ? "Thêm loại phòng thành công." : "Cập nhật loại phòng thành công.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show("Lỗi khi lưu loại phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi lưu loại phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            if (!IsDisposed)
            {
                _save.Enabled = true;
            }
        }
    }

    private static bool TryParseMoney(string value, out decimal amount)
    {
        const NumberStyles styles = NumberStyles.Number;
        return decimal.TryParse(value.Trim(), styles, CultureInfo.CurrentCulture, out amount) ||
               decimal.TryParse(value.Trim(), styles, CultureInfo.InvariantCulture, out amount);
    }

    private static void DigitsOnly(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private static void DecimalInput(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar is not '.' and not ',')
        {
            e.Handled = true;
        }
    }

    private void Warn(string message, Control control)
    {
        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        control.Focus();
    }
}
