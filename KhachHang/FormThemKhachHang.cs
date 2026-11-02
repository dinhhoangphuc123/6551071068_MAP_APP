using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.KhachHang
{
    public partial class FormThemKhachHang : Form
    {
        public FormThemKhachHang()
        {
            InitializeComponent();
            btnThoat.DialogResult = DialogResult.Cancel;
        }

        private string GenerateMaKH()
        {
            using var db = new HotelManagementContext();
            var danhSachMa = db.KhachHangs
                .AsNoTracking()
                .Select(k => k.MaKh)
                .ToList();

            int max = 0;
            foreach (string ma in danhSachMa)
            {
                if (ma != null && ma.Length > 2 && int.TryParse(ma.Substring(2), out int so) && so > max)
                {
                    max = so;
                }
            }
            return "KH" + (max + 1).ToString("D3");
        }

        private void FormThemKhachHang_Load(object sender, EventArgs e)
        {
            txtHoVaTen.MaxLength = 50;
            txtCCCD.MaxLength = 12;
            txtSoDienThoai.MaxLength = 10;
            txtQuocTich.MaxLength = 30;
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSoDienThoai.KeyPress += OnlyAllowDigits;

            try
            {
                txtMaKH.Text = GenerateMaKH();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã khách hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cbGioiTinh.SelectedIndex = 0;
        }

        private void OnlyAllowDigits(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string tenKH = txtHoVaTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string quocTich = txtQuocTich.Text.Trim();
            string gioiTinh = cbGioiTinh.Text.Trim();

            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Chưa có mã khách hàng, vui lòng mở lại form!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(tenKH))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập số CCCD/Passport!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            // Kiểm tra định dạng CCCD (10 hoặc 12 số) (T5)
            if ((cccd.Length != 10 && cccd.Length != 12) || !cccd.All(char.IsDigit))
            {
                MessageBox.Show("Số CCCD/Passport phải gồm đúng 10 hoặc 12 chữ số!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            // Kiểm tra định dạng SĐT (10 số) (T5)
            if (!string.IsNullOrEmpty(sdt) && (sdt.Length != 10 || !sdt.All(char.IsDigit)))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (string.IsNullOrEmpty(quocTich))
            {
                MessageBox.Show("Vui lòng nhập quốc tịch!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuocTich.Focus();
                return;
            }

            if (string.IsNullOrEmpty(gioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbGioiTinh.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();
                var khTonTai = db.KhachHangs.FirstOrDefault(k => k.CccdPassport == cccd);
                if (khTonTai != null)
                {
                    // Cơ chế khôi phục nếu khách hàng đã xóa mềm trước đó (C9)
                    if (khTonTai.DaXoa == true)
                    {
                        var hoiKhoiPhuc = MessageBox.Show(
                            $"Khách hàng {khTonTai.TenKh} (CCCD: {cccd}) đã từng tồn tại và bị xóa trước đó.\nBạn có muốn KHÔI PHỤC lại khách hàng này không?",
                            "Khôi phục khách hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (hoiKhoiPhuc == DialogResult.Yes)
                        {
                            khTonTai.DaXoa = false;
                            khTonTai.TenKh = tenKH;
                            khTonTai.Sdt = string.IsNullOrEmpty(sdt) ? null : sdt;
                            khTonTai.QuocTich = quocTich;
                            khTonTai.GioiTinh = gioiTinh;
                            db.SaveChanges();
                            MessageBox.Show("Khôi phục khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            Close();
                            return;
                        }
                    }

                    MessageBox.Show("Số CCCD/Passport này đang tồn tại trong hệ thống!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }

                if (db.KhachHangs.Any(k => k.MaKh == maKH))
                {
                    maKH = GenerateMaKH();
                    txtMaKH.Text = maKH;
                }

                var khachHang = new Models.KhachHang
                {
                    MaKh = maKH,
                    TenKh = tenKH,
                    Sdt = string.IsNullOrEmpty(sdt) ? null : sdt,
                    CccdPassport = cccd,
                    QuocTich = quocTich,
                    GioiTinh = gioiTinh,
                    DaXoa = false
                };

                db.KhachHangs.Add(khachHang);
                int kq = db.SaveChanges();

                if (kq > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

