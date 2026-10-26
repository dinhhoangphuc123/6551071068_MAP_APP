using _6551071068_MAP_APP.Data;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class RoomEditorDialog : Form
{
    private readonly string? _roomCode;

    public RoomEditorDialog() : this(null)
    {
    }

    public RoomEditorDialog(string? maPhong)
    {
        InitializeComponent();
        _roomCode = maPhong;
        Text = maPhong is null ? "Thêm mới phòng" : $"Cập nhật phòng {maPhong}";

        txtCode.ReadOnly = maPhong is not null;
        // Thêm mới chỉ cho "Bình thường"/"Đang sửa chữa"; "Đã đặt"/"Đang thuê" chỉ có khi sửa phòng đã có phiếu
        object[] statuses = maPhong is null
            ? new object[] { "Bình thường", "Đang sửa chữa" }
            : new object[] { "Bình thường", "Đã đặt", "Đang thuê", "Đang sửa chữa" };
        cboStatus.Items.AddRange(statuses);
        cboStatus.SelectedIndex = 0;
        cboCleaning.SelectedIndex = 0;
        btnSave.Text = maPhong is null ? "Thêm mới" : "Cập nhật";
    }

    private async void RoomEditorDialog_Load(object? sender, EventArgs e) => await LoadFormAsync();

    private async void BtnSave_Click(object? sender, EventArgs e) => await SaveAsync();

    private async Task LoadFormAsync()
    {
        try
        {
            await using var db = new HotelManagementContext();
            var types = await db.LoaiPhongs.AsNoTracking()
                .OrderBy(x => x.MaLph)
                .Select(x => new { x.MaLph, x.TenLph })
                .ToListAsync();
            cboRoomType.DataSource = types;
            cboRoomType.DisplayMember = "TenLph";
            cboRoomType.ValueMember = "MaLph";

            if (_roomCode is null)
            {
                txtCode.Focus();
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
                btnSave.Enabled = false;
                return;
            }

            txtCode.Text = room.MaPh;
            cboStatus.SelectedItem = room.Ttph;
            cboCleaning.SelectedItem = room.Ttdd;
            cboRoomType.SelectedValue = room.MaLph ?? string.Empty;
            txtNote.Text = room.GhiChu ?? string.Empty;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải dữ liệu phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnSave.Enabled = false;
        }
    }

    private async Task SaveAsync()
    {
        string maPhong = txtCode.Text.Trim().ToUpperInvariant();
        string? maLoaiPhong = cboRoomType.SelectedValue?.ToString();
        if (maPhong.Length == 0)
        {
            Warn("Vui lòng nhập mã phòng.", txtCode);
            return;
        }

        if (maPhong.Length > 5)
        {
            Warn("Mã phòng tối đa 5 ký tự.", txtCode);
            return;
        }

        if (string.IsNullOrWhiteSpace(maLoaiPhong))
        {
            Warn("Vui lòng chọn loại phòng.", cboRoomType);
            return;
        }

        if (cboStatus.SelectedItem is not string status || cboCleaning.SelectedItem is not string cleaning)
        {
            Warn("Vui lòng chọn trạng thái phòng và tình trạng dọn dẹp.", cboStatus);
            return;
        }

        btnSave.Enabled = false;
        try
        {
            await using var db = new HotelManagementContext();
            Phong? room;
            if (_roomCode is null)
            {
                room = await db.Phongs.FirstOrDefaultAsync(x => x.MaPh == maPhong);
                if (room is not null && room.DaXoa != true)
                {
                    Warn("Mã phòng đã tồn tại. Vui lòng nhập mã khác.", txtCode);
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
                    room.GhiChu = EmptyToNull(txtNote.Text);
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
                        GhiChu = EmptyToNull(txtNote.Text),
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
                room.GhiChu = EmptyToNull(txtNote.Text);
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
                btnSave.Enabled = true;
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
