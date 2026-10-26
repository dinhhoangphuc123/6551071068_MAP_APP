using System.Globalization;
using _6551071068_MAP_APP.Data;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class RoomTypeEditorDialog : Form
{
    private readonly string? _roomTypeCode;

    public RoomTypeEditorDialog() : this(null)
    {
    }

    public RoomTypeEditorDialog(string? maLoaiPhong)
    {
        InitializeComponent();
        _roomTypeCode = maLoaiPhong;
        Text = maLoaiPhong is null ? "Thêm mới loại phòng" : $"Cập nhật loại phòng {maLoaiPhong}";

        txtCode.ReadOnly = maLoaiPhong is not null;
        btnSave.Text = maLoaiPhong is null ? "Thêm mới" : "Cập nhật";
        if (_roomTypeCode is not null)
        {
            ApplyEditLayout();
            Load += async (_, _) => await LoadRoomTypeAsync();
        }
    }

    // Designer hiển thị bố cục "Thêm mới"; chế độ "Cập nhật" dùng kích thước/vị trí khác nên chỉnh lại ở đây
    private void ApplyEditLayout()
    {
        ClientSize = new Size(604, 626);
        lblTitle.Text = "Cập nhật thông tin loại phòng";
        lblTitle.Location = new Point(113, 49);
        lblTitle.Size = new Size(400, 34);
        pnlFields.Location = new Point(48, 121);
        pnlFields.Size = new Size(507, 375);

        (Label Caption, Control Input)[] fields =
        [
            (lblCode, txtCode), (lblName, txtName), (lblBeds, txtBeds),
            (lblMaximumGuests, txtMaximumGuests), (lblDailyPrice, txtDailyPrice), (lblHourlyPrice, txtHourlyPrice)
        ];
        int[] rows = [45, 100, 155, 210, 265, 320];
        const int inputX = 160;
        for (int index = 0; index < fields.Length; index++)
        {
            fields[index].Caption.Location = new Point(10, rows[index]);
            fields[index].Caption.Size = new Size(inputX - 18, 30);
            fields[index].Input.Location = new Point(inputX, rows[index]);
        }

        btnSave.Location = new Point(136, 519);
        btnCancel.Location = new Point(336, 519);
    }

    private async void BtnSave_Click(object? sender, EventArgs e) => await SaveAsync();

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
                btnSave.Enabled = false;
                return;
            }

            txtCode.Text = type.MaLph;
            txtName.Text = type.TenLph ?? string.Empty;
            txtBeds.Text = type.SoGiuong.ToString(CultureInfo.InvariantCulture);
            txtMaximumGuests.Text = type.SoNguoiToiDa.ToString(CultureInfo.InvariantCulture);
            txtDailyPrice.Text = type.GiaNgay.ToString("0.##", CultureInfo.CurrentCulture);
            txtHourlyPrice.Text = type.GiaGio.ToString("0.##", CultureInfo.CurrentCulture);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải thông tin loại phòng: " + ex.GetBaseException().Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnSave.Enabled = false;
        }
    }

    private async Task SaveAsync()
    {
        string code = txtCode.Text.Trim().ToUpperInvariant();
        string name = txtName.Text.Trim();
        if (code.Length == 0)
        {
            Warn("Vui lòng nhập mã loại phòng.", txtCode);
            return;
        }

        if (name.Length == 0)
        {
            Warn("Vui lòng nhập tên loại phòng.", txtName);
            return;
        }

        if (!int.TryParse(txtBeds.Text.Trim(), out int beds) || beds <= 0)
        {
            Warn("Số giường không hợp lệ.", txtBeds);
            return;
        }

        if (!int.TryParse(txtMaximumGuests.Text.Trim(), out int maximumGuests) || maximumGuests <= 0)
        {
            Warn("Số người tối đa không hợp lệ.", txtMaximumGuests);
            return;
        }

        if (!TryParseMoney(txtDailyPrice.Text, out decimal dailyPrice) || dailyPrice <= 0)
        {
            Warn("Giá ngày không hợp lệ.", txtDailyPrice);
            return;
        }

        if (!TryParseMoney(txtHourlyPrice.Text, out decimal hourlyPrice) || hourlyPrice <= 0)
        {
            Warn("Giá giờ không hợp lệ.", txtHourlyPrice);
            return;
        }

        btnSave.Enabled = false;
        try
        {
            await using var db = new HotelManagementContext();
            LoaiPhong? type;
            if (_roomTypeCode is null)
            {
                if (await db.LoaiPhongs.AnyAsync(x => x.MaLph == code))
                {
                    Warn("Mã loại phòng đã tồn tại. Vui lòng nhập mã khác.", txtCode);
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
                btnSave.Enabled = true;
            }
        }
    }

    private static bool TryParseMoney(string value, out decimal amount)
    {
        const NumberStyles styles = NumberStyles.Number;
        return decimal.TryParse(value.Trim(), styles, CultureInfo.CurrentCulture, out amount) ||
               decimal.TryParse(value.Trim(), styles, CultureInfo.InvariantCulture, out amount);
    }

    private void DigitsOnly(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void DecimalInput(object? sender, KeyPressEventArgs e)
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
