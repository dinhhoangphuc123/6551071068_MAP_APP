using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.ThongKe
{
    public partial class FormThongKe : Form
    {
        private readonly CultureInfo viVN = new CultureInfo("vi-VN");

        // KPI controls
        private Label lblValDoanhThuPhong = null!;
        private Label lblValDoanhThuDichVu = null!;
        private Label lblValSoPhongDat = null!;

        // Top badges
        private Label lblTopDoanhThu = null!;
        private Label lblTopSoLuotDat = null!;
        private Label lblTopDichVu = null!;

        // Chart panels
        private Panel pnlChartDichVu = null!;
        private Panel pnlChartThuePhong = null!;
        private Panel pnlChartSoPhongDat = null!;

        // Data cache for chart redraw
        private List<(string Ten, decimal GiaTri)> _chartDataDichVu = new();
        private List<(string Ten, decimal GiaTri)> _chartDataThuePhong = new();
        private List<(string Ten, int GiaTri)> _chartDataSoPhongDat = new();

        public FormThongKe()
        {
            InitializeComponent();
            KhoiTaoGiaoDienDashboard();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today;
            LoadDuLieuThongKe();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadDuLieuThongKe();
        }

        private void KhoiTaoGiaoDienDashboard()
        {
            pnlMain.Controls.Clear();

            // 1. Top row KPI Cards (3 cards: Doanh thu thuê phòng, Doanh thu dịch vụ, Số phòng đặt)
            Panel card1 = TaoTheKpi("Doanh thu thuê phòng", "0 VND", Color.FromArgb(255, 127, 80), Properties.Resources.DoanhThu, out lblValDoanhThuPhong);
            card1.Location = new Point(20, 20);
            card1.Size = new Size(340, 110);

            Panel card2 = TaoTheKpi("Doanh thu Dịch vụ", "0 VND", Color.FromArgb(218, 165, 32), Properties.Resources.DoanhThuThue, out lblValDoanhThuDichVu);
            card2.Location = new Point(380, 20);
            card2.Size = new Size(340, 110);

            Panel card3 = TaoTheKpi("Số phòng đặt", "0", Color.FromArgb(107, 142, 35), Properties.Resources.SoPhongDat, out lblValSoPhongDat);
            card3.Location = new Point(740, 20);
            card3.Size = new Size(340, 110);

            pnlMain.Controls.AddRange(new Control[] { card1, card2, card3 });

            // 2. Left column (Top badges + Donut Chart)
            Panel pnlLeft = new Panel
            {
                Location = new Point(20, 145),
                Size = new Size(460, 560),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Badge 1: Loại phòng doanh thu cao nhất
            Panel badge1 = TaoTheTop("Loại phòng doanh thu cao nhất", "---", Properties.Resources.top1, out lblTopDoanhThu);
            badge1.Location = new Point(15, 15);
            badge1.Size = new Size(428, 60);

            // Badge 2: Loại phòng được đặt nhiều nhất
            Panel badge2 = TaoTheTop("Loại phòng được đặt nhiều nhất", "---", Properties.Resources.top2, out lblTopSoLuotDat);
            badge2.Location = new Point(15, 85);
            badge2.Size = new Size(428, 60);

            // Badge 3: Dịch vụ doanh thu cao nhất
            Panel badge3 = TaoTheTop("Dịch vụ doanh thu cao nhất", "---", Properties.Resources.top3, out lblTopDichVu);
            badge3.Location = new Point(15, 155);
            badge3.Size = new Size(428, 60);

            // Chart label & canvas for Dich vu
            Label lblChartDvTitle = new Label
            {
                Text = "Các dịch vụ được sử dụng",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Location = new Point(15, 230),
                AutoSize = true
            };

            pnlChartDichVu = new Panel
            {
                Location = new Point(15, 260),
                Size = new Size(428, 280),
                BackColor = Color.White
            };
            pnlChartDichVu.Paint += PnlChartDichVu_Paint;

            pnlLeft.Controls.AddRange(new Control[] { badge1, badge2, badge3, lblChartDvTitle, pnlChartDichVu });
            pnlMain.Controls.Add(pnlLeft);

            // 3. Right column (2 Bar Charts: Doanh thu thuê phòng & Số phòng được đặt)
            Panel pnlRight = new Panel
            {
                Location = new Point(495, 145),
                Size = new Size(585, 560),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblChartThueTitle = new Label
            {
                Text = "Doanh thu thuê phòng",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Location = new Point(20, 15),
                AutoSize = true
            };

            pnlChartThuePhong = new Panel
            {
                Location = new Point(20, 45),
                Size = new Size(545, 225),
                BackColor = Color.White
            };
            pnlChartThuePhong.Paint += PnlChartThuePhong_Paint;

            Label lblChartDatTitle = new Label
            {
                Text = "Số phòng được đặt",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Location = new Point(20, 285),
                AutoSize = true
            };

            pnlChartSoPhongDat = new Panel
            {
                Location = new Point(20, 315),
                Size = new Size(545, 225),
                BackColor = Color.White
            };
            pnlChartSoPhongDat.Paint += PnlChartSoPhongDat_Paint;

            pnlRight.Controls.AddRange(new Control[] { lblChartThueTitle, pnlChartThuePhong, lblChartDatTitle, pnlChartSoPhongDat });
            pnlMain.Controls.Add(pnlRight);
        }

        private Panel TaoTheKpi(string tieuDe, string giaTriKhoiTao, Color mauNen, Image? icon, out Label lblGiaTri)
        {
            Panel card = new Panel
            {
                BackColor = mauNen,
                Padding = new Padding(10)
            };

            Label lblTieuDe = new Label
            {
                Text = tieuDe,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Regular),
                Location = new Point(15, 18),
                AutoSize = true
            };

            lblGiaTri = new Label
            {
                Text = giaTriKhoiTao,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(15, 48),
                AutoSize = true
            };

            PictureBox pic = new PictureBox
            {
                Image = icon,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(50, 50),
                Location = new Point(270, 28)
            };

            card.Controls.AddRange(new Control[] { lblTieuDe, lblGiaTri, pic });
            return card;
        }

        private Panel TaoTheTop(string tieuDe, string noiDung, Image? icon, out Label lblNoiDung)
        {
            Panel p = new Panel
            {
                BackColor = Color.FromArgb(248, 249, 250),
                BorderStyle = BorderStyle.FixedSingle
            };

            PictureBox pic = new PictureBox
            {
                Image = icon,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(36, 36),
                Location = new Point(8, 11)
            };

            Label lblT = new Label
            {
                Text = tieuDe,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.DimGray,
                Location = new Point(50, 8),
                AutoSize = true
            };

            lblNoiDung = new Label
            {
                Text = noiDung,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Location = new Point(50, 28),
                AutoSize = true
            };

            p.Controls.AddRange(new Control[] { pic, lblT, lblNoiDung });
            return p;
        }

        private void LoadDuLieuThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            try
            {
                using var db = new HotelManagementContext();

                // 1. Phieu thue trong khoang thoi gian
                var cacChiTiet = db.Ctdps
                    .AsNoTracking()
                    .Where(c => c.DaXoa != true && c.CheckIn >= tuNgay && c.CheckIn < denNgay)
                    .Select(c => new
                    {
                        c.MaCtdp,
                        c.MaPh,
                        TenLph = c.MaPhNavigation.MaLphNavigation.TenLph,
                        ThanhTien = c.ThanhTien ?? 0,
                        c.TrangThai
                    })
                    .ToList();

                decimal tongDoanhThuPhong = cacChiTiet.Sum(c => c.ThanhTien);
                int tongSoPhongDat = cacChiTiet.Count;

                // 2. Dich vu su dung trong khoang thoi gian
                var maCtdps = cacChiTiet.Select(c => c.MaCtdp).Distinct().ToList();
                var cacDichVu = db.Ctdvs
                    .AsNoTracking()
                    .Where(v => v.DaXoa != true && maCtdps.Contains(v.MaCtdp))
                    .Select(v => new
                    {
                        v.MaDv,
                        TenDv = v.MaDvNavigation.TenDv,
                        Sl = v.Sl,
                        DonGia = v.MaDvNavigation.DonGia,
                        ThanhTien = v.ThanhTien ?? (v.Sl * v.MaDvNavigation.DonGia)
                    })
                    .ToList();

                decimal tongDoanhThuDichVu = cacDichVu.Sum(v => v.ThanhTien);

                // Update KPI Cards
                lblValDoanhThuPhong.Text = tongDoanhThuPhong.ToString("N0", viVN) + " VND";
                lblValDoanhThuDichVu.Text = tongDoanhThuDichVu.ToString("N0", viVN) + " VND";
                lblValSoPhongDat.Text = tongSoPhongDat.ToString("N0");

                // Update Top 1: Loại phòng doanh thu cao nhất
                var topDtLph = cacChiTiet
                    .GroupBy(c => c.TenLph ?? "Khác")
                    .Select(g => new { TenLph = g.Key, TongTien = g.Sum(x => x.ThanhTien) })
                    .OrderByDescending(x => x.TongTien)
                    .FirstOrDefault();

                if (topDtLph != null && topDtLph.TongTien > 0)
                    lblTopDoanhThu.Text = $"{topDtLph.TenLph} ({topDtLph.TongTien.ToString("N0", viVN)} VND)";
                else
                    lblTopDoanhThu.Text = "Chưa có dữ liệu";

                // Update Top 2: Loại phòng được đặt nhiều nhất
                var topDatLph = cacChiTiet
                    .GroupBy(c => c.TenLph ?? "Khác")
                    .Select(g => new { TenLph = g.Key, SoLuong = g.Count() })
                    .OrderByDescending(x => x.SoLuong)
                    .FirstOrDefault();

                if (topDatLph != null && topDatLph.SoLuong > 0)
                    lblTopSoLuotDat.Text = $"{topDatLph.TenLph} ({topDatLph.SoLuong} lượt)";
                else
                    lblTopSoLuotDat.Text = "Chưa có dữ liệu";

                // Update Top 3: Dịch vụ doanh thu cao nhất
                var topDv = cacDichVu
                    .GroupBy(v => v.TenDv ?? "Khác")
                    .Select(g => new { TenDv = g.Key, TongTien = g.Sum(x => x.ThanhTien) })
                    .OrderByDescending(x => x.TongTien)
                    .FirstOrDefault();

                if (topDv != null && topDv.TongTien > 0)
                    lblTopDichVu.Text = $"{topDv.TenDv} ({topDv.TongTien.ToString("N0", viVN)} VND)";
                else
                    lblTopDichVu.Text = "Chưa có dữ liệu";

                // 3. Prepare Chart Data
                // Chart Dịch vụ
                _chartDataDichVu = cacDichVu
                    .GroupBy(v => v.TenDv ?? "Khác")
                    .Select(g => (Ten: g.Key, GiaTri: g.Sum(x => x.ThanhTien)))
                    .OrderByDescending(x => x.GiaTri)
                    .Take(5)
                    .ToList();

                // Chart Doanh thu thuê phòng theo loại phòng
                _chartDataThuePhong = cacChiTiet
                    .GroupBy(c => c.TenLph ?? "Khác")
                    .Select(g => (Ten: g.Key, GiaTri: g.Sum(x => x.ThanhTien)))
                    .OrderByDescending(x => x.GiaTri)
                    .ToList();

                // Chart Số phòng được đặt theo loại phòng
                _chartDataSoPhongDat = cacChiTiet
                    .GroupBy(c => c.TenLph ?? "Khác")
                    .Select(g => (Ten: g.Key, GiaTri: g.Count()))
                    .OrderByDescending(x => x.GiaTri)
                    .ToList();

                // Redraw charts
                pnlChartDichVu.Invalidate();
                pnlChartThuePhong.Invalidate();
                pnlChartSoPhongDat.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Custom GDI+ Pie/Donut Chart for Dịch vụ
        private void PnlChartDichVu_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_chartDataDichVu.Count == 0)
            {
                using var font = new Font("Segoe UI", 10F, FontStyle.Italic);
                g.DrawString("Không có dữ liệu dịch vụ trong khoảng thời gian này.", font, Brushes.Gray, 20, 100);
                return;
            }

            decimal tong = _chartDataDichVu.Sum(x => x.GiaTri);
            if (tong <= 0) return;

            Color[] colors = { Color.FromArgb(0, 150, 214), Color.FromArgb(235, 104, 65), Color.FromArgb(242, 179, 61), Color.FromArgb(76, 175, 80), Color.FromArgb(156, 39, 176) };

            Rectangle pieRect = new Rectangle(20, 25, 170, 170);
            float startAngle = 0;

            for (int i = 0; i < _chartDataDichVu.Count; i++)
            {
                float sweepAngle = (float)(_chartDataDichVu[i].GiaTri / tong) * 360f;
                using var brush = new SolidBrush(colors[i % colors.Length]);
                g.FillPie(brush, pieRect, startAngle, sweepAngle);
                startAngle += sweepAngle;
            }

            // Donut center hole
            using (var centerBrush = new SolidBrush(Color.White))
            {
                g.FillEllipse(centerBrush, 65, 70, 80, 80);
            }

            // Legend
            int legendX = 210;
            int legendY = 30;
            using var fontLegend = new Font("Segoe UI", 9F);

            for (int i = 0; i < _chartDataDichVu.Count; i++)
            {
                using var boxBrush = new SolidBrush(colors[i % colors.Length]);
                g.FillRectangle(boxBrush, legendX, legendY + (i * 28), 14, 14);

                string text = $"{_chartDataDichVu[i].Ten} ({(_chartDataDichVu[i].GiaTri / tong * 100):0.0}%)";
                g.DrawString(text, fontLegend, Brushes.Black, legendX + 22, legendY + (i * 28) - 1);
            }
        }

        // Custom GDI+ Bar Chart for Doanh thu thuê phòng
        private void PnlChartThuePhong_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_chartDataThuePhong.Count == 0)
            {
                using var font = new Font("Segoe UI", 10F, FontStyle.Italic);
                g.DrawString("Không có dữ liệu phòng thuê trong khoảng thời gian này.", font, Brushes.Gray, 20, 80);
                return;
            }

            int left = 75;
            int bottom = 180;
            int top = 25;
            int right = pnlChartThuePhong.Width - 30;
            int chartHeight = bottom - top;

            // Draw axis
            using var axisPen = new Pen(Color.LightGray, 1);
            g.DrawLine(axisPen, left, top, left, bottom);
            g.DrawLine(axisPen, left, bottom, right, bottom);

            decimal maxVal = _chartDataThuePhong.Max(x => x.GiaTri);
            if (maxVal <= 0) maxVal = 1000000;
            maxVal = Math.Ceiling(maxVal / 500000m) * 500000m;

            // Grid lines & labels
            using var fontY = new Font("Segoe UI", 8F);
            int numSteps = 4;
            for (int i = 0; i <= numSteps; i++)
            {
                decimal stepVal = (maxVal / numSteps) * i;
                int y = bottom - (int)((stepVal / maxVal) * chartHeight);
                g.DrawLine(axisPen, left, y, right, y);
                string strVal = stepVal >= 1000000 ? (stepVal / 1000000m).ToString("0.#") + "M" : stepVal.ToString("0");
                g.DrawString(strVal, fontY, Brushes.DimGray, 15, y - 7);
            }

            // Draw Bars
            int count = _chartDataThuePhong.Count;
            int availableWidth = right - left - 20;
            int barWidth = Math.Min(45, availableWidth / Math.Max(count, 1) - 20);
            int spacing = (availableWidth - (count * barWidth)) / (count + 1);

            using var barBrush = new SolidBrush(Color.FromArgb(51, 153, 255));
            using var fontX = new Font("Segoe UI", 9F);

            for (int i = 0; i < count; i++)
            {
                int barHeight = (int)((_chartDataThuePhong[i].GiaTri / maxVal) * chartHeight);
                int x = left + 15 + (i * (barWidth + spacing));
                int y = bottom - barHeight;

                g.FillRectangle(barBrush, x, y, barWidth, barHeight);
                g.DrawRectangle(Pens.DodgerBlue, x, y, barWidth, barHeight);

                // Label below bar
                string ten = _chartDataThuePhong[i].Ten;
                if (ten.Length > 10) ten = ten.Substring(0, 8) + "..";
                g.DrawString(ten, fontX, Brushes.Black, x - 5, bottom + 5);
            }
        }

        // Custom GDI+ Bar Chart for Số phòng được đặt
        private void PnlChartSoPhongDat_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (_chartDataSoPhongDat.Count == 0)
            {
                using var font = new Font("Segoe UI", 10F, FontStyle.Italic);
                g.DrawString("Không có dữ liệu đặt phòng trong khoảng thời gian này.", font, Brushes.Gray, 20, 80);
                return;
            }

            int left = 50;
            int bottom = 180;
            int top = 25;
            int right = pnlChartSoPhongDat.Width - 30;
            int chartHeight = bottom - top;

            // Draw axis
            using var axisPen = new Pen(Color.LightGray, 1);
            g.DrawLine(axisPen, left, top, left, bottom);
            g.DrawLine(axisPen, left, bottom, right, bottom);

            int maxVal = _chartDataSoPhongDat.Max(x => x.GiaTri);
            if (maxVal < 4) maxVal = 4;
            else maxVal = (int)Math.Ceiling(maxVal / 4.0) * 4;

            // Grid lines & labels
            using var fontY = new Font("Segoe UI", 8F);
            int numSteps = 4;
            for (int i = 0; i <= numSteps; i++)
            {
                int stepVal = (maxVal / numSteps) * i;
                int y = bottom - (int)(((float)stepVal / maxVal) * chartHeight);
                g.DrawLine(axisPen, left, y, right, y);
                g.DrawString(stepVal.ToString(), fontY, Brushes.DimGray, 20, y - 7);
            }

            // Draw Bars
            int count = _chartDataSoPhongDat.Count;
            int availableWidth = right - left - 20;
            int barWidth = Math.Min(45, availableWidth / Math.Max(count, 1) - 20);
            int spacing = (availableWidth - (count * barWidth)) / (count + 1);

            using var barBrush = new SolidBrush(Color.FromArgb(30, 144, 255));
            using var fontX = new Font("Segoe UI", 9F);

            for (int i = 0; i < count; i++)
            {
                int barHeight = (int)(((float)_chartDataSoPhongDat[i].GiaTri / maxVal) * chartHeight);
                int x = left + 15 + (i * (barWidth + spacing));
                int y = bottom - barHeight;

                g.FillRectangle(barBrush, x, y, barWidth, barHeight);
                g.DrawRectangle(Pens.SteelBlue, x, y, barWidth, barHeight);

                string ten = _chartDataSoPhongDat[i].Ten;
                if (ten.Length > 10) ten = ten.Substring(0, 8) + "..";
                g.DrawString(ten, fontX, Brushes.Black, x - 5, bottom + 5);
            }
        }
    }
}
