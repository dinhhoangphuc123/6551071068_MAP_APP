using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _6551071068_MAP_APP.Data;
using Microsoft.EntityFrameworkCore;

namespace _6551071068_MAP_APP.Forms;

public sealed partial class AddServiceDialog : Form
{
    private readonly string _maCtdp;
    private readonly string _maPhong;

    private ComboBox cbDichVu = null!;
    private NumericUpDown numSoLuong = null!;
    private Label lblDonGia = null!;
    private Label lblConLai = null!;
    private Label lblThanhTien = null!;
    private Button btnXacNhan = null!;
    private Button btnHuy = null!;

    public AddServiceDialog(string maCtdp, string maPhong)
    {
        _maCtdp = maCtdp;
        _maPhong = maPhong;
        InitializeComponent();
        LoadDichVu();
    }

    private void InitializeComponent()
    {
        Text = $"Gọi dịch vụ cho phòng {_maPhong}";
        Size = new Size(480, 360);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        BackColor = Color.White;

        var lblTitle = new Label
        {
            Text = $"THÊM DỊCH VỤ - PHÒNG {_maPhong}",
            Font = new Font("Segoe UI", 13F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 128, 128),
            Dock = DockStyle.Top,
            Height = 45,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var pnlForm = new Panel { Dock = DockStyle.Fill, Padding = new Padding(30, 10, 30, 10) };

        var lblDv = new Label { Text = "Chọn dịch vụ:", Location = new Point(30, 20), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Regular) };
        cbDichVu = new ComboBox
        {
            Location = new Point(30, 45),
            Width = 400,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = new Font("Segoe UI", 10F)
        };
        cbDichVu.SelectedIndexChanged += CbDichVu_SelectedIndexChanged;

        lblDonGia = new Label { Text = "Đơn giá: 0 VNĐ", Location = new Point(30, 90), AutoSize = true, Font = new Font("Segoe UI", 10F) };
        lblConLai = new Label { Text = "Còn lại trong kho: 0", Location = new Point(240, 90), AutoSize = true, Font = new Font("Segoe UI", 10F) };

        var lblSl = new Label { Text = "Số lượng:", Location = new Point(30, 130), AutoSize = true, Font = new Font("Segoe UI", 10F) };
        numSoLuong = new NumericUpDown
        {
            Location = new Point(30, 155),
            Width = 140,
            Minimum = 1,
            Maximum = 1000,
            Value = 1,
            Font = new Font("Segoe UI", 10F)
        };
        numSoLuong.ValueChanged += (_, _) => CapNhatThanhTien();

        lblThanhTien = new Label
        {
            Text = "Thành tiền: 0 VNĐ",
            Location = new Point(200, 157),
            AutoSize = true,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold),
            ForeColor = Color.DarkRed
        };

        btnXacNhan = new Button
        {
            Text = "Thêm vào phòng",
            DialogResult = DialogResult.None,
            Location = new Point(130, 230),
            Size = new Size(160, 38),
            BackColor = Color.FromArgb(0, 139, 139),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnXacNhan.FlatAppearance.BorderSize = 0;
        btnXacNhan.Click += BtnXacNhan_Click;

        btnHuy = new Button
        {
            Text = "Đóng",
            DialogResult = DialogResult.Cancel,
            Location = new Point(305, 230),
            Size = new Size(100, 38),
            BackColor = Color.LightGray,
            ForeColor = Color.Black,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F),
            Cursor = Cursors.Hand
        };
        btnHuy.FlatAppearance.BorderSize = 0;

        pnlForm.Controls.AddRange(new Control[]
        {
            lblDv, cbDichVu, lblDonGia, lblConLai, lblSl, numSoLuong, lblThanhTien, btnXacNhan, btnHuy
        });

        Controls.Add(pnlForm);
        Controls.Add(lblTitle);
    }

    private void LoadDichVu()
    {
        try
        {
            using var db = new HotelManagementContext();
            var ds = db.DichVus
                .AsNoTracking()
                .Where(d => d.DaXoa != true && (d.SlconLai == null || d.SlconLai > 0))
                .OrderBy(d => d.TenDv)
                .Select(d => new
                {
                    d.MaDv,
                    d.TenDv,
                    d.DonGia,
                    SlTon = d.SlconLai ?? 999
                })
                .ToList();

            if (ds.Count == 0)
            {
                MessageBox.Show("Hiện không có dịch vụ nào còn hàng trong kho.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            cbDichVu.DisplayMember = "HienThi";
            cbDichVu.ValueMember = "MaDv";
            cbDichVu.DataSource = ds.Select(d => new
            {
                d.MaDv,
                d.DonGia,
                d.SlTon,
                HienThi = $"{d.TenDv} - {d.DonGia:N0} VNĐ (Còn: {d.SlTon})"
            }).ToList();

            if (cbDichVu.Items.Count > 0)
                cbDichVu.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải danh mục dịch vụ: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CbDichVu_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cbDichVu.SelectedItem == null) return;
        dynamic item = cbDichVu.SelectedItem;
        decimal donGia = item.DonGia;
        int slTon = item.SlTon;

        lblDonGia.Text = $"Đơn giá: {donGia:N0} VNĐ";
        lblConLai.Text = $"Còn lại: {slTon}";
        numSoLuong.Maximum = Math.Max(1, slTon);
        if (numSoLuong.Value > numSoLuong.Maximum)
            numSoLuong.Value = numSoLuong.Maximum;

        CapNhatThanhTien();
    }

    private void CapNhatThanhTien()
    {
        if (cbDichVu.SelectedItem == null) return;
        dynamic item = cbDichVu.SelectedItem;
        decimal donGia = item.DonGia;
        int sl = (int)numSoLuong.Value;
        lblThanhTien.Text = $"Thành tiền: {(donGia * sl):N0} VNĐ";
    }

    private void BtnXacNhan_Click(object? sender, EventArgs e)
    {
        if (cbDichVu.SelectedItem == null) return;
        dynamic item = cbDichVu.SelectedItem;
        string maDv = item.MaDv;
        decimal donGia = item.DonGia;
        int sl = (int)numSoLuong.Value;

        try
        {
            using var db = new HotelManagementContext();
            var dichVu = db.DichVus.FirstOrDefault(d => d.MaDv == maDv && d.DaXoa != true);
            if (dichVu == null)
            {
                MessageBox.Show("Không tìm thấy thông tin dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dichVu.SlconLai.HasValue && dichVu.SlconLai.Value < sl)
            {
                MessageBox.Show($"Dịch vụ chỉ còn {dichVu.SlconLai.Value} trong kho.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ctdv = db.Ctdvs.FirstOrDefault(c => c.MaCtdp == _maCtdp && c.MaDv == maDv && c.DaXoa != true);
            if (ctdv != null)
            {
                ctdv.Sl += sl;
                ctdv.DonGia = donGia;
                ctdv.ThanhTien = ctdv.Sl * donGia;
            }
            else
            {
                db.Ctdvs.Add(new HotelManagement.Models.CTDV
                {
                    MaCtdp = _maCtdp,
                    MaDv = maDv,
                    Sl = sl,
                    DonGia = donGia,
                    ThanhTien = sl * donGia,
                    DaXoa = false
                });
            }

            // Trừ tồn kho dịch vụ (N4)
            if (dichVu.SlconLai.HasValue)
            {
                dichVu.SlconLai -= sl;
            }

            db.SaveChanges();
            MessageBox.Show($"Đã thêm {sl} {dichVu.TenDv} vào phòng {_maPhong} thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
